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

        static int _millisecondsSleepAnimation = 1;
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

        private void  SelectFirstUser()
        {
            if (_selectedUser == 2)
            {
                double coefOfDifference = GetCoefOfDifference_RemoveLine(_firstUserLine.Width, _secondUserLine.Width);
                Animation_RemoveLineAsync(_firstUserLine, _secondUserLine, _thirdUserLine, coefOfDifference, _firstUserLineStartWidth, true);
                _selectedUser = 1;
            }
            else if (_selectedUser == 3)
            {
                
            }
        }

        private void SelectSecondUser()
        {
            if (_selectedUser == 1)
            {

            }
            else if (_selectedUser == 3)
            {

            }
        }

        private void SelectThirdUser()
        {
            if (_selectedUser == 1)
            {

            }
            else if (_selectedUser == 2)
            {
                double coefOfDifference = GetCoefOfDifference_RemoveLine(_thirdUserLine.Width, _secondUserLine.Width);
                Animation_RemoveLineAsync(_thirdUserLine, _secondUserLine, _firstUserLine, coefOfDifference, _thirdUserLineStartWidth, false);
                _selectedUser = 3;
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

        private async void Animation_RemoveLineAsync(Border lineForRemove, Border lineToScale, Border lineResidue, double coefOfDifference, double centuralWidth, bool leftCorner)
        {
            if (lineToScale.Width > lineForRemove.Width)
            {
                double removeLineWidth = 1;
                double removedWidth = 0;
                double scaleLineWidth = coefOfDifference != 0 ? removeLineWidth / coefOfDifference : removeLineWidth;
                while (true)
                {
                    await Task.Run(() => Dispatcher.CurrentDispatcher.BeginInvoke(new ThreadStart(() => { })));
                    if (lineForRemove.Width == 0)
                        break;
                    lineForRemove.Width -= removeLineWidth;
                    removedWidth++;
                    if (lineToScale.Width - scaleLineWidth > centuralWidth) //Сравнивать не с этим значением
                    {
                        lineToScale.Width -= scaleLineWidth;
                        lineResidue.Width += removeLineWidth + scaleLineWidth;
                    }
                    else
                    {
                        double remainder = centuralWidth - lineToScale.Width;
                        lineResidue.Width += removeLineWidth;
                        lineResidue.Width -= remainder;
                        lineToScale.Width += remainder;
                        break;
                    }
                    if (removedWidth % 15 == 0)
                        await Task.Delay(_millisecondsSleepAnimation);
                }
            }
            else
            {
                double removeLineWidth = 1;
                double removedWidth = 0;
                double scaleLineWidth = coefOfDifference != 0 ? removeLineWidth / coefOfDifference : removeLineWidth;
                while (true)
                {
                    await Task.Run(() => Dispatcher.CurrentDispatcher.BeginInvoke(new ThreadStart(() => { })));
                    if (lineForRemove.Width == 0)
                        break;
                    lineForRemove.Width -= removeLineWidth;
                    removedWidth++;
                    if (lineToScale.Width + scaleLineWidth < centuralWidth)
                    {
                        lineToScale.Width += scaleLineWidth;
                        lineResidue.Width += removeLineWidth - scaleLineWidth;
                    }
                    else
                    {
                        double remainder = lineToScale.Width - centuralWidth;
                        lineResidue.Width += removeLineWidth;
                        lineResidue.Width += remainder;
                        lineToScale.Width -= remainder;
                        

                        break;
                    }
                    if (removedWidth % 15 == 0)
                        await Task.Delay(_millisecondsSleepAnimation);
                }
            }

            if (leftCorner)
                lineToScale.CornerRadius = new CornerRadius(3, 0, 0, 3);
            else
                lineToScale.CornerRadius = new CornerRadius(0, 3, 3, 0);
        }
    }
}
