using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using System.ComponentModel;
using hemopet.Core.Controls;
using Android.Content;

[assembly: ExportRendererAttribute(typeof(TintedImage), typeof(hemopet.Droid.Renderers.TintedImageRenderer))]
namespace hemopet.Droid.Renderers
{
    public class TintedImageRenderer : ImageRenderer
    {
        public TintedImageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            SetTint();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == TintedImage.TintColorProperty.PropertyName || e.PropertyName == Image.SourceProperty.PropertyName)
                SetTint();
        }

        private void SetTint()
        {
            if (Control == null || Element == null)
                return;

            if (((TintedImage)Element).TintColor.Equals(Xamarin.Forms.Color.Transparent))
            {
                if (Control.ColorFilter != null)
                    Control.ClearColorFilter();

                return;
            }

            var colorFilter = new PorterDuffColorFilter(((TintedImage)Element).TintColor.ToAndroid(), PorterDuff.Mode.SrcIn);
            Control.SetColorFilter(colorFilter);
        }
    }
}