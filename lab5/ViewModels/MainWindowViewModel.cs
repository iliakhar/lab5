using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;

namespace lab5.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string path;
        string watermark;
        string regexByLine;

        public string Path
        {
            get { return path; }
            set { this.RaiseAndSetIfChanged(ref path, value); }
        }

        public string Watermark
        {
            get { return watermark; }
            set { this.RaiseAndSetIfChanged(ref watermark, value); }
        }

        public string RegexByLine
        {
            get { return regexByLine; }
            set { this.RaiseAndSetIfChanged(ref regexByLine, value); }
        }
    }
}
