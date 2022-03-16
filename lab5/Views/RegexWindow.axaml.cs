using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace lab5.Views
{
    public partial class RegexWindow : Window
    {
        public RegexWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("OkButton").Click += async delegate
            {
                Close(this.FindControl<TextBox>("RegexTextBox").Text);

            };

            this.FindControl<Button>("CancelButton").Click += async delegate
            {
                Close();

            };
        }

        public RegexWindow(string pattern):this()
        {
            this.FindControl<TextBox>("RegexTextBox").Text = pattern;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
