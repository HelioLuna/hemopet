using System;

using Xamarin.Forms;
using Path = System.IO.Path;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using System.ComponentModel;
using hemopet.Droid.Renderers;
using Android.Support.V4.Content;
using Android.Util;
using Android.Graphics;

[assembly: ExportRenderer(typeof(hemopet.Core.Controls.CustomEntry), typeof(CustomEntryRenderer))]
namespace hemopet.Droid.Renderers
{
    class CustomEntryRenderer : EntryRenderer
    {
        Context _context;
        public CustomEntryRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var view = (Core.Controls.CustomEntry)Element;

            if (view != null)
            {
                SetIcon(view);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var view = (Core.Controls.CustomEntry)Element;

            if (e.PropertyName == Core.Controls.CustomEntry.IconProperty.PropertyName)
            {
                SetIcon(view);
            }
            else if (e.PropertyName == "IsFocused")
            {
                SetIsFocusedColor(view);
            }
        }

        private void SetIsFocusedColor(Core.Controls.CustomEntry view)
        {
            var drawable = Control.GetCompoundDrawablesRelative();

            if (drawable[0] == null)
                return;

            if (Control.IsFocused)
            {
                if (view.AccentColor != Xamarin.Forms.Color.Gray)
                {
                    drawable[0].SetTint(view.AccentColor.ToAndroid());
                }
                else
                {
                    drawable[0].SetTint(Xamarin.Forms.Color.FromHex("#FF4081").ToAndroid());
                }
                Control.SetTextColor(Xamarin.Forms.Color.FromHex("#000000").ToAndroid());
                Control.SetCompoundDrawablesRelative(drawable[0], null, null, null);
            }
            else
            {
                drawable[0].SetTint(view.TintColor.ToAndroid());
                Control.SetTextColor(Xamarin.Forms.Color.FromHex("#757575").ToAndroid());
                Control.SetCompoundDrawablesRelative(drawable[0], null, null, null);
            }
        }

        private void SetIcon(Core.Controls.CustomEntry view)
        {
            if (!string.IsNullOrEmpty(view.Icon))
            {
                try
                {
                    var resId = _context.Resources.GetIdentifier(Path.GetFileNameWithoutExtension(view.Icon), "drawable", _context.PackageName);
                    var drawable = ContextCompat.GetDrawable(_context, resId);

                    if (view.TintColor != null)
                    {
                        drawable.SetTint(view.TintColor.ToAndroid());
                    }

                    var padding = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 8f, Context.Resources.DisplayMetrics);

                    drawable.SetBounds(0, 0,
                        (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, view.IconWidth, _context.Resources.DisplayMetrics),
                        (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, view.IconHeight, _context.Resources.DisplayMetrics));

                    if (resId != 0)
                    {
                        Control.Background.SetColorFilter(Xamarin.Forms.Color.White.ToAndroid(), PorterDuff.Mode.SrcAtop);
                        Control.SetPadding(padding, padding, padding, padding);
                        Control.SetCompoundDrawablesRelative(drawable, null, null, null);
                        Control.CompoundDrawablePadding = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 8f, Context.Resources.DisplayMetrics);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Control.SetCompoundDrawablesWithIntrinsicBounds(0, 0, 0, 0);
            }
        }
    }
}