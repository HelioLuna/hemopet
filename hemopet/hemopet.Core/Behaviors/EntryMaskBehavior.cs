using System.Diagnostics;
using Xamarin.Forms;

namespace hemopet.Core.Behaviors
{
    public class EntryMaskBehavior : Behavior<Entry>
    {
        public string Mask { get; set; }
        private bool _isUpdating;

        private string Unmask(string value)
        {
            return value.Replace(".", "").Replace("-", "")
                .Replace("/", "").Replace("(", "")
                .Replace(")", "");
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnTextChanged;
        }

        void OnTextChanged(object sender, TextChangedEventArgs eventArgs)
        {
            if (!(sender is Entry entry) ||
                eventArgs.NewTextValue.Length < eventArgs.OldTextValue?.Length)
                return;

            string unmaskedValue = Unmask(entry.Text);
            string valueWithMask = "";
            string old = "";

            if (_isUpdating)
            {
                old = unmaskedValue;
                _isUpdating = false;
                return;
            }

            int i = 0;

            foreach (var letter in Mask.ToCharArray())
            {
                if (letter != '#' && unmaskedValue.Length > old.Length)
                {
                    valueWithMask += letter;
                    continue;
                }
                try
                {
                    valueWithMask += unmaskedValue[i];
                }
                catch (System.Exception ex)
                {
                    Debug.WriteLine("EntryMaskBehavior:OnTextChanged = " + ex.Message);
                    break;
                }
                i++;
            }

            _isUpdating = true;
            entry.Text = valueWithMask;
        }
    }
}
