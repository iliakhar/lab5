using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using lab5.ViewModels;
using lab5.Models;
using Avalonia.Interactivity;

namespace lab5.Views
{
    public partial class MainWindow : Window
    {
        string? regexPattern;
        public MainWindow()
        {
            InitializeComponent();

            //this.FindControl<TextBox>("InputTB").AddHandler(TextInputEvent, TextBoxChange, RoutingStrategies.Tunnel);
            this.FindControl<TextBox>("InputTB").AddHandler(KeyUpEvent, TextBoxChange, RoutingStrategies.Tunnel);

            regexPattern = "";
            this.FindControl<Button>("OpenButton").Click += async delegate
            {

                var taskPath = new OpenFileDialog()
                {
                    Title = "Open File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);
                string[]? path = await taskPath;

                var context = this.DataContext as MainWindowViewModel;
                try
                {
                    if (path != null)
                        context.Path = WorkingWithText.LoadFromFile(string.Join(@"\", path));
                }
                catch (WorkingWithTextException)
                {
                    context.Path = "";
                    context.Watermark = "Ошибка чтения файла";
                }
                RegexByLineChange();
            };

            this.FindControl<Button>("SaveButton").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "Save File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);
                string[]? path = await taskPath;

                try
                {
                    if (path != null)
                        WorkingWithText.SaveFromFile(string.Join(@"\", path), this.FindControl<TextBox>("OutputTB").Text);
                }
                catch (WorkingWithTextException){}
            };
        }

        private async void SetRegexClick(object sender, RoutedEventArgs e)
        {
            
            string? tmpPattern = await new RegexWindow(regexPattern).ShowDialog<string?>((Window)this.VisualRoot);
            if(tmpPattern != null)
            {
                regexPattern = tmpPattern;
                RegexByLineChange();
            }
        }

        private async void TextBoxChange(object sender, RoutedEventArgs e)
        {
            RegexByLineChange();
        }

        private void RegexByLineChange()
        {
            var context = this.DataContext as MainWindowViewModel;
            context.RegexByLine = WorkingWithText.FindByTemplate(this.FindControl<TextBox>("InputTB").Text, regexPattern);
        }
    }
}
