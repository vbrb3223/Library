using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Library.Pages.AuthPages.Sign_inFunctional
{
    static class SelectUserAnimation
    {
        static Border _firstUserLine;
        static Border _secondUserLine;
        static Border _thirdUserLine;

        static int _millisecondsSleepAnimation = 150;
        static int _selectedUser;

        public static Border FirstUserLine
        {
            set { _firstUserLine = value; }
        }

        public static Border SecondUserLine
        {
            set { _secondUserLine = value; }
        }

        public static Border ThirdUserLine
        {
            set { _thirdUserLine = value; }
        }

        public static int MillisecondsSleepAnimation
        {
            set { _millisecondsSleepAnimation = value; }
        }

        public static int SelectedUser
        {
            set { _selectedUser = value; }
        }

        public static void ChangeUser(int userNumber)
        {
            switch (userNumber)
            {
                case 1:
                    SelectFirstUser();
                    break;
                case 2:
                    SelectSecondUser();
                    break;
                case 3:
                    SelectThirdUser();
                    break;
            }
        }

        private static void SelectFirstUser()
        {
            if (_selectedUser == 2)
            {
                double coefOfDifference = GetCoefOfDifference(_firstUserLine.Width, _secondUserLine.Width);

                
            }
            else if (_selectedUser == 3)
            {

            }
        }

        private static void SelectSecondUser()
        {
            if (_selectedUser == 1)
            {

            }
            else if (_selectedUser == 3)
            {

            }
        }

        private static void SelectThirdUser()
        {
            if (_selectedUser == 1)
            {

            }
            else if (_selectedUser == 2)
            {

            }
        }

        private static double GetCoefOfDifference(double firstLine, double secondLine)
        {
            double difference = Math.Abs(firstLine - secondLine);

            if (difference != 0)
            {
                return firstLine > difference ? firstLine / difference : difference / firstLine;
            }
            else
                return 0;
        }
    }
}
