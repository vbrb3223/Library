using System;
using System.Collections.Generic;
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
using Library.Data;

namespace Library.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        LibraryEntity context = new LibraryEntity();
        public Auth()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Авторизация
        /// </summary>
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
