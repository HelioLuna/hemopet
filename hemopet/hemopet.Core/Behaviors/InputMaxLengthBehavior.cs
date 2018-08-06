using System.Diagnostics;
using Xamarin.Forms;

namespace hemopet.Core.Behaviors
{
    public class InputMaxLengthBehavior : Behavior<InputView>
    {
        public int MaxLength { get; set; }

        protected override void OnAttachedTo(InputView bindable)
        {
            base.OnAttachedTo(bindable);

            if (bindable is Entry entry) entry.TextChanged += OnTextChanged;
            else if (bindable is Editor editor) editor.TextChanged += OnTextChanged;
            else Debug.WriteLine("Impossible to Attache eventHandler");
        }

        protected override void OnDetachingFrom(InputView bindable)
        {
            base.OnDetachingFrom(bindable);

            if (bindable is Entry entry) entry.TextChanged -= OnTextChanged;
            else if (bindable is Editor editor) editor.TextChanged -= OnTextChanged;
            else Debug.WriteLine("Impossible to Detache eventHandler");
        }

        void OnTextChanged(object sender, TextChangedEventArgs eventArgs)
        {
            if ((sender is Entry entry) && entry?.Text.Length > this.MaxLength)
            {
                string entryText = entry.Text;
                entry.Text = entryText.Remove(entryText.Length - 1);
            }
            else if ((sender is Editor editor) && editor?.Text.Length > this.MaxLength)
            {
                string entryText = editor.Text;
                editor.Text = entryText.Remove(entryText.Length - 1);
            }
        }
    }
}
