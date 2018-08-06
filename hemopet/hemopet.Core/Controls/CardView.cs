using Xamarin.Forms;

namespace hemopet.Core.Controls
{
    public class CardView : Frame
    {
        public CardView()
        {
            Padding = 0;
            if (Device.RuntimePlatform == Device.iOS)
            {
                HasShadow = false;
                OutlineColor = Color.Transparent;
                BackgroundColor = Color.Transparent;
            }

            if (Device.RuntimePlatform == Device.Android)
            {
                HasShadow = true;
                OutlineColor = Color.Transparent;
                BackgroundColor = Color.White;
            }
        }
    }
}
