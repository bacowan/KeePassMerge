using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Windows.Input;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace KeePassMerge
{
    public sealed partial class FilePicker : UserControl
    {
        public FilePicker()
        {
            InitializeComponent();
        }

        public string FilePath
        {
            get { return (string)GetValue(FilePathProperty); }
            set { SetValue(FilePathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FilePath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilePathProperty =
            DependencyProperty.Register("FilePath", typeof(string), typeof(FilePicker), new PropertyMetadata(""));



        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(FilePicker), new PropertyMetadata(""));





        public ICommand SelectFileCommand
        {
            get { return (ICommand)GetValue(SelectFileCommandProperty); }
            set { SetValue(SelectFileCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectFileCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectFileCommandProperty =
            DependencyProperty.Register("SelectFileCommand", typeof(ICommand), typeof(FilePicker), new PropertyMetadata(null));




        public object SelectFileCommandParameter
        {
            get { return (object)GetValue(SelectFileCommandParameterProperty); }
            set { SetValue(SelectFileCommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectFileCommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectFileCommandParameterProperty =
            DependencyProperty.Register("SelectFileCommandParameter", typeof(object), typeof(FilePicker), new PropertyMetadata(0));





        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(FilePicker), new PropertyMetadata(""));



    }
}
