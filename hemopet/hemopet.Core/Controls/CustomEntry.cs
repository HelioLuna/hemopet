using Xamarin.Forms;

namespace hemopet.Core.Controls
{
    public class CustomEntry : Entry
    {
        public static readonly BindableProperty IconProperty = 
            BindableProperty.Create(nameof(Icon), typeof(string), typeof(CustomEntry), string.Empty);

        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly BindableProperty TintColorProperty = 
            BindableProperty.Create(nameof(TintColor), typeof(Color), typeof(CustomEntry), Color.Gray);

        public Color TintColor
        {
            get => (Color)GetValue(TintColorProperty);
            set => SetValue(TintColorProperty, value);
        }

        public static readonly BindableProperty BackgroundColorFilterProperty =
            BindableProperty.Create(nameof(BackgroundColorFilter), typeof(Color), typeof(CustomEntry), Color.Black);

        public Color BackgroundColorFilter
        {
            get => (Color)GetValue(BackgroundColorFilterProperty);
            set => SetValue(BackgroundColorFilterProperty, value);
        }

        public static readonly BindableProperty AccentColorProperty =
            BindableProperty.Create(nameof(AccentColor), typeof(Color), typeof(CustomEntry), Color.Gray);

        public Color AccentColor
        {
            get => (Color)GetValue(AccentColorProperty);
            set => SetValue(AccentColorProperty, value);
        }

        public static readonly BindableProperty IconHeightProperty =
            BindableProperty.Create(nameof(IconHeight), typeof(float), typeof(CustomEntry), 24f);

        public float IconHeight
        {
            get { return (float)GetValue(IconHeightProperty); }
            set { SetValue(IconHeightProperty, value); }
        }

        public static readonly BindableProperty IconWidthProperty =
            BindableProperty.Create(nameof(IconWidth), typeof(float), typeof(CustomEntry), 24f);

        public float IconWidth
        {
            get { return (float)GetValue(IconWidthProperty); }
            set { SetValue(IconWidthProperty, value); }
        }
    }
}
