using System.Windows.Controls;

namespace Library.Pages.AuthPages.Sign_inFunctional
{
    static class InitializeClasses
    {
        public static void InitSelectUserAnimation(Border FirstUserLine, Border SecondUserLine, Border ThirdUserLine)
        {
            SelectUserAnimationSign_in.FirstUserLine = FirstUserLine;
            SelectUserAnimationSign_in.SecondUserLine = SecondUserLine;
            SelectUserAnimationSign_in.ThirdUserLine = ThirdUserLine;
        }
    }
}
