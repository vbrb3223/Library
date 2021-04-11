using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Library.Pages.AuthPages.Sign_inFunctional
{
    class SelectUserAnimationSign_in
    {
        static Border _firstUserLine;
        static Border _secondUserLine;
        static Border _thirdUserLine;

        static double _firstUserLineStartWidth;
        static double _secondUserLineStartWidth;
        static double _thirdUserLineStartWidth;

        static int _millisecondsSleepAnimation = 150;
        static int _selectedUser = 2;

        public static Border FirstUserLine
        {
            set { _firstUserLine = value; _firstUserLineStartWidth = value.Width; }
        }

        public static Border SecondUserLine
        {
            set { _secondUserLine = value; _secondUserLineStartWidth = value.Width; }
        }

        public static Border ThirdUserLine
        {
            set { _thirdUserLine = value; _thirdUserLineStartWidth = value.Width; }
        }

        public static int MillisecondsSleepAnimation
        {
            set { _millisecondsSleepAnimation = value; }
        }

        public static int SelectedUser
        {
            set { _selectedUser = value; }
        }

        public void ChangeUser(int userNumber)
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

        private static void  SelectFirstUser()
        {
            if (_selectedUser == 2)
            {
                double coefOfDifference = GetCoefOfDifference_RemoveLine(_firstUserLine.Width, _secondUserLine.Width);
                Animation_RemoveLineAsync(_firstUserLine, _secondUserLine, _thirdUserLine, coefOfDifference);
                _selectedUser = 1;
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

        private static double GetCoefOfDifference_RemoveLine(double lineForRemoveWidth, double lineToScaleWidth)
        {
            double difference = Math.Abs(lineForRemoveWidth - lineToScaleWidth);

            if (difference != 0)
            {
                return lineForRemoveWidth > difference ? lineForRemoveWidth / difference : difference / lineForRemoveWidth;
            }
            else
                return 0;
        }

        private static void Animation_RemoveLineAsync(Border lineForRemove, Border lineToScale, Border lineResidue, double coefOfDifference)
        {
            if (lineToScale.Width > lineForRemove.Width)
            {
                double removeLineWidth = 1;
                double scaleLineWidth = coefOfDifference != 0 ? removeLineWidth / coefOfDifference : removeLineWidth;
                while (true)
                {
                    if (lineForRemove.Width == 0)
                        break;
                    lineForRemove.Width -= removeLineWidth;
                    if (lineToScale.Width - scaleLineWidth > _firstUserLineStartWidth)
                    {
                        lineToScale.Width -= scaleLineWidth;
                        lineResidue.Width += removeLineWidth + scaleLineWidth;
                    }
                    else
                    {
                        double remainder = _firstUserLineStartWidth - lineToScale.Width;
                        lineResidue.Width += removeLineWidth;
                        lineResidue.Width -= remainder;
                        lineToScale.Width += remainder;
                        break;
                    }
                }
            }
            else
            {
                double removeLineWidth = 1;
                double scaleLineWidth = coefOfDifference != 0 ? removeLineWidth / coefOfDifference : removeLineWidth;
                while (true)
                {
                    if (lineForRemove.Width == 0)
                        break;
                    lineForRemove.Width -= removeLineWidth;
                    if (lineToScale.Width + scaleLineWidth < _firstUserLineStartWidth)
                    {
                        lineToScale.Width += scaleLineWidth;
                        lineResidue.Width += removeLineWidth - scaleLineWidth;
                    }
                    else
                    {
                        double remainder = lineToScale.Width - _firstUserLineStartWidth;
                        lineResidue.Width += removeLineWidth;
                        lineResidue.Width += remainder;
                        lineToScale.Width -= remainder;
                        

                        break;
                    }
                }
            }
        }
    }
}
