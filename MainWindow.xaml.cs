using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Localization_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            buttonDialogTest.Click += (s, e) =>
            {
                string localizedMessage = (string)Application.Current.FindResource("MessageBoxText");
                MessageBox.Show(this, localizedMessage, (string)Application.Current.FindResource("MessageBoxCaption"), MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.None);
            };

            buttonNewWindowTest.Click += (s, e) => new NewWindow().Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResourceDictionary currentLanguage = new()
            {
                Source = comboBoxChangeLanguage.SelectedIndex switch
                {
                    0 => new Uri("pack://application:,,,/Localization_Demo;component/Languages/zh-hans.xaml", UriKind.RelativeOrAbsolute),
                    1 => new Uri("pack://application:,,,/Localization_Demo;component/Languages/zh-hant.xaml", UriKind.RelativeOrAbsolute),
                    2 => new Uri("pack://application:,,,/Localization_Demo;component/Languages/en-us.xaml", UriKind.RelativeOrAbsolute),
                    _ => new Uri("pack://application:,,,/Localization_Demo;component/Languages/zh-hans.xaml", UriKind.RelativeOrAbsolute),
                }
            };
            Application.Current.Resources.MergedDictionaries[0] = currentLanguage;
            WeakReferenceMessenger.Default.Send<RefreshMessage>();
        }
    }
}
