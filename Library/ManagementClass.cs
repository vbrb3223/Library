using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Library.Data;

namespace Library
{
    class ManagementClass
    {
        static MainWindow _window;
        static Frame _mainFrame;
        public static Label UserInfo { get; set; }
        static User user;

        static public MainWindow Window
        {
            get
            {
                return _window;
            }
            set
            {
                _window = value;
            }
        }

        static public Frame MainFrame
        {
            get
            {
                return _mainFrame;
            }
            set
            {
                _mainFrame = value;
            }
        }

        public static User AuthorizedUser 
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                UserInfo.Content = $"{ value.Surname } { value.Name[0]}. { value.Patronymic[0] }."
                    + $" ({ value.Role })";
            }
        }
    }

    class User
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Role { get; set; }

        public static implicit operator User(Admins admin)
        {
            User user = new User();
            user.Id = admin.id;
            user.Surname = admin.surname;
            user.Name = admin.name;
            user.Patronymic = admin.patronymic;
            user.Role = "Администратор";
            return user;
        }
        public static implicit operator User(Librarians librarian)
        {
            User user = new User();
            user.Id = librarian.id;
            user.Surname = librarian.surname;
            user.Name = librarian.name;
            user.Patronymic = librarian.patronymic;
            user.Role = "Библиотекарь";
            return user;
        }
        public static implicit operator User(ReaderCards reader)
        {
            User user = new User();
            user.Id = reader.id;
            user.Surname = reader.surname;
            user.Name = reader.name;
            user.Patronymic = reader.patronymic;
            user.Role = "Администратор";
            return user;
        }
    }
}
