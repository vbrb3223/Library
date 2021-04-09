using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ManagementClass.Window = this;
            ManagementClass.MainFrame = MainFrame;
        }

        //Кнопка выхода из программы
        private void BTNExit_Click(object sender, RoutedEventArgs e)
        {
            var messageResult = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageResult == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        //Кнопка возвращения на предыдущую страницу
        private void BTNBack_Click(object sender, RoutedEventArgs e)
        {
            if (ManagementClass.MainFrame.CanGoBack)
                ManagementClass.MainFrame.GoBack();
        }
    }
}
