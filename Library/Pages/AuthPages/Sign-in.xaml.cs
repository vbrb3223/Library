using Library.Pages.AuthPages.Sign_inFunctional;
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

namespace Library.AuthPages
{
    /// <summary>
    /// Логика взаимодействия для Sign_in.xaml
    /// </summary>
    public partial class Sign_in : Page
    {
        public Sign_in()
        {
            InitializeComponent();
            InitializeClasses.InitSelectUserAnimation(FirstUserLine, SecondUserLine, ThirdUserLine);
        }

        readonly SelectUserAnimationSign_in selectUserAnimation = new SelectUserAnimationSign_in();

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            selectUserAnimation.ChangeUser(1);
        }

        private void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            selectUserAnimation.ChangeUser(3);
        }

        private void Label_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            selectUserAnimation.ChangeUser(2);
        }
    }
}
