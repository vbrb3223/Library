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
            var adminAuth = context.AdminsAuth.Where(u => u.login == TBLogin.Text 
            && u.password == TBPassword.Text).FirstOrDefault();

            if (adminAuth != null)
            {
                var adminInfo = context.Admins.Where(u => u.id == adminAuth.id).FirstOrDefault();
                User user = new User();
                user = adminInfo;
                ManagementClass.AuthorizedUser = user;
                ManagementClass.MainFrame.Navigate(new AdminPages.MainPageAdmin());
            }
            else
            {
                var librarianAuth = context.LibrarinsAuth.Where(u => u.login == TBLogin.Text
                && u.password == TBPassword.Text).FirstOrDefault();

                if (librarianAuth != null)
                {
                    var librarianInfo = context.Librarians.Where(u => u.id == librarianAuth.id).FirstOrDefault();
                    User user = new User();
                    user = librarianInfo;
                    ManagementClass.AuthorizedUser = user;
                }
                else
                {
                    var readerAuth = context.ReadersAuth.Where(u => u.login == TBLogin.Text
                    && u.password == TBPassword.Text).FirstOrDefault();

                    if (readerAuth != null)
                    {
                        var readerInfo = context.ReaderCards.Where(u => u.id == readerAuth.id).FirstOrDefault();
                        User user = new User();
                        user = readerInfo;
                        ManagementClass.AuthorizedUser = user;
                    }
                }
            }
        }
    }
}
