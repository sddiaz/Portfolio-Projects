using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
namespace Portfolio_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Globals 
        public List<Decimal> Operands = new List<Decimal>();
        public List<Decimal> previousAnswers = new List<Decimal>();
        public char currentOperation;
        public char lastOperation;
        public int operationCount = 0;
        public int expressionCount = 0;
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            timer();

            #region Proportionality relative to Screen
            double buttonSize = SystemParameters.PrimaryScreenWidth * 0.04; 
            GridLengthConverter myConverter = new GridLengthConverter(); 
            this.Height = SystemParameters.PrimaryScreenHeight * 0.82;
            this.Width = SystemParameters.PrimaryScreenWidth * 0.22;
            darkModeGrid.Height = SystemParameters.PrimaryScreenHeight * 0.03;
            darkModeGrid.Width = SystemParameters.PrimaryScreenWidth * 0.035;
            this.mainGrid.RowDefinitions[0].Height = (GridLength)myConverter.ConvertFromString((SystemParameters.PrimaryScreenHeight * 0.32).ToString());
            this.mainGrid.RowDefinitions[1].Height = (GridLength)myConverter.ConvertFromString((SystemParameters.PrimaryScreenHeight * 0.47).ToString());
            #region Nightmare
            AC.Width = buttonSize;
            AC.Height = buttonSize;
            plusMinus.Width = buttonSize;
            plusMinus.Height = buttonSize;
            percent.Width = buttonSize;
            percent.Height = buttonSize;
            divide.Width = buttonSize;
            divide.Height = buttonSize; 
            seven.Height = buttonSize;
            seven.Width = buttonSize;
            six.Height = buttonSize;
            six.Width = buttonSize;
            five.Height = buttonSize;
            five.Width = buttonSize;
            four.Height = buttonSize;
            four.Width = buttonSize;
            three.Height = buttonSize;
            three.Width = buttonSize;
            two.Height = buttonSize;
            two.Width = buttonSize;
            one.Height = buttonSize;
            one.Width = buttonSize;
            zero.Height = buttonSize;
            zero.Width = buttonSize;
            dot.Height = buttonSize;
            dot.Width = buttonSize;
            redo.Height = buttonSize;
            redo.Width = buttonSize;
            equals.Height = buttonSize;
            equals.Width = buttonSize;
            add.Height = buttonSize;
            add.Width = buttonSize;
            subtract.Height = buttonSize;
            subtract.Width = buttonSize;
            multiply.Height = buttonSize;
            multiply.Width = buttonSize;
            eight.Height = buttonSize;
            eight.Width = buttonSize;
            nine.Height = buttonSize;
            nine.Width = buttonSize;
            #endregion
            #endregion
        }

        #region Timer
        public void timer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            timeLabel.Content = DateTime.Now.ToString("h:mm");
        }
        #endregion

        #region Operators
        private void AC_Click(object sender, RoutedEventArgs e)
        {
            if (numberLabel.Content != null && numberLabel.Content.ToString() != string.Empty)
            {
                // Clear entries, reset operator count. 
                numberLabel.Content = "";
                Operands.Clear();
                operationCount = 0;
            }
            else
            {
                MessageBox.Show("Nothing to clear.");
            }
        }

        private void plusMinus_Click(object sender, RoutedEventArgs e)
        {
            // If our expression isn't null (to start with). 
            if (numberLabel.Content != null && numberLabel.Content.ToString() != string.Empty)
            {
                string currentString = numberLabel.Content.ToString(); // Easier on the eyes. 
                if (Operands.Count == 1 && currentString[currentString.Count() - 1] == ' ')
                    {
                        MessageBox.Show("Please input a number first.");
                    }
                    else if (currentString.ElementAt(0) != '-')
                    {
                        if (Operands.Count == 0)
                        {
                            numberLabel.Content = currentString.Insert(0, "-");
                        }
                        else if (Operands.Count == 1 && currentOperation != null)
                        {
                            flip2ndSign(); 
                        }
                        else if (Operands.Count == 1)
                        {
                            Operands[0] = Operands[0] * -1;
                        }
                    }
                    else
                    {
                        if (Operands.Count == 0)
                        {
                            numberLabel.Content = currentString.Replace("-", "");
                        }
                        else
                        {
                            flip2ndSign();
                        }
                    }
            }
            else if (Operands.Count == 0)
            {
                MessageBox.Show("Please input a number first.");
            }
        }

        private void percent_Click(object sender, RoutedEventArgs e)
        {
            if (numberLabel.Content != null && numberLabel.Content.ToString() != string.Empty)
            {
                // If we're dealing with two numbers at once, divive the last one. 
                if (Operands.Count > 0)
                {
                    numberLabel.Content = Operands.ElementAt(Operands.Count - 1) / 100;

                }
                else
                {
                    numberLabel.Content = Decimal.Parse(numberLabel.Content.ToString()) / 100;

                }
            }
            else
            {
                MessageBox.Show("Please input a number first.");
            }
        }
        private void enter_Click(object sender, RoutedEventArgs e)
        {
            if (numberLabel.Content != null && numberLabel.Content.ToString() != string.Empty)
            {
                try
                {
                    var currentString = numberLabel.Content.ToString();
                    Decimal secondNumber = Decimal.Parse(currentString.Substring(currentString.LastIndexOf(' ') + 1));
                    // Everything after the LAST space will be our next number.
                    Operands.Add(secondNumber);
                    // Populate both texts. (Alternating last expression color);  
                    numberLabel.Content = performCalculation(Operands[Operands.Count - 2], Operands[Operands.Count - 1], currentOperation.ToString());
                    if (expressionCount % 2 == 0)
                    {
                        previousExpressionLabel.Foreground = makeBrush((Color)ColorConverter.ConvertFromString("#72F2EB"), (Color)ColorConverter.ConvertFromString("Black"), 0.1, 1.5);
                    }
                    else
                    {
                        previousExpressionLabel.Foreground = makeBrush((Color)ColorConverter.ConvertFromString("#BD2A2E"), (Color)ColorConverter.ConvertFromString("Black"), 0.1, 1.5); ;
                    }
                    previousExpressionLabel.Content = numberLabel.Content; // previous expression 
                    Operands.Clear();
                    operationCount = 0;
                    expressionCount++;
                }
                catch
                {
                    MessageBox.Show("You need two operands to perform an operation.");
                }
            }
            else
            {
                MessageBox.Show("You need two operands to perform an operation.");

            }
        }

        private void operationClick(object sender, RoutedEventArgs e)
        {
            // Check to see if we have any numbers first. 
            if (numberLabel.Content == null || numberLabel.Content.ToString() == string.Empty)
            {
                MessageBox.Show("Please input a number first"); 
            }
            else
            {
                char lastElement = numberLabel.Content.ToString()[numberLabel.Content.ToString().Length - 1];
                currentOperation = sender.ToString()[sender.ToString().Length - 1];
                // If the last element is already an operation element, simply replace it. 
                if (lastElement == ' ')
                {
                    numberLabel.Content = numberLabel.Content.ToString().Replace(lastOperation, currentOperation);
                }
                // Otherwise, add the last number to our list. 
                else
                {
                    // If we have more than one operator, don't. 
                    if (operationCount > 0)
                    {
                        MessageBox.Show("One operator at a time, please.");
                    }
                    else
                    {
                        try
                        {
                            Operands.Add(Decimal.Parse(numberLabel.Content.ToString()));
                            numberLabel.Content += " " + currentOperation + " ";
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(exc.Message); 
                        }
                    }
                }
                lastOperation = currentOperation;
                operationCount++;
            }
        }

        public string performCalculation(Decimal firstNumber, Decimal secondNumber, string operation)
        {
            // Initialize our answer variable. 
            Decimal answer = 0; 
            // Operation Switch
            switch (operation) {
                case "+":
                    answer = firstNumber + secondNumber;
                    break; 
                case "−":
                    answer = firstNumber - secondNumber;
                    break;
                case "×":
                    answer = firstNumber * secondNumber;
                    break;
                case "÷":
                    answer = firstNumber / secondNumber;
                    break;
            }
            // Add to our answer history (used for back button) 
            previousAnswers.Add(answer); 
            return answer.ToString();
        }

        public void flip2ndSign()
        {
            string currentString = numberLabel.Content.ToString(); // Easier on the eyes. 
            int lastSpace = currentString.LastIndexOf(" ");
            // if the last number is negative, make positive. 
            if (currentString[currentString.LastIndexOf(" ") + 1].ToString() == "-")
            {
                string newString = "";
                newString = currentString.Remove(currentString.LastIndexOf(" ") + 1, 1);
                numberLabel.Content = newString;
            }
            // if last number is positive, make it negative. 
            else
            {
                string newString = currentString.Insert(lastSpace, " -");
                newString = newString.Remove(newString.LastIndexOf(" "), 1);
                numberLabel.Content = newString;
            }
        }

        // Create brush (cosmetic only) 
        public LinearGradientBrush makeBrush(Color color1, Color color2, double offset1, double offset2)
        {
            LinearGradientBrush myBrush = new LinearGradientBrush();
            GradientStop stop1 = new GradientStop();
            GradientStop stop2 = new GradientStop();
            myBrush.StartPoint = new Point(0, 0); 
            myBrush.EndPoint = new Point(1, 1);
            stop1.Color = color1;
            stop2.Color = color2;
            stop1.Offset = offset1;
            stop2.Offset = offset2;
            myBrush.GradientStops.Add(stop1);
            myBrush.GradientStops.Add(stop2); 
            return myBrush; 
        }
        #endregion

        #region Numpad

        private void NumPad_Click(object sender, RoutedEventArgs e)
        {
            numberLabel.Content += sender.ToString()[sender.ToString().Length - 1].ToString();
        }
        private void dot_Click(object sender, RoutedEventArgs e)
        {
            // Decimal Point Logic
            if (numberLabel.Content == null)
            {
                numberLabel.Content += ".";
            }
            else
            {
                string currentString = numberLabel.Content.ToString();
                if (Operands.Count == 1)
                {
                   if (Operands.ElementAt(0).ToString().Contains("."))
                    {
                        if (currentString.Count(x => x == '.') < 2)
                        {
                            numberLabel.Content += ".";
                        }
                    }
                   else if (currentString.Count(x => x == '.') < 1)
                    {
                        numberLabel.Content += ".";
                    }
                }
                else
                {
                    if (currentString.Count(x => x == '.') < 1)
                    {
                        numberLabel.Content += ".";
                    }
                }
            }

        }
        private void redo_Click(object sender, RoutedEventArgs e)
        {
            // Use this to return the latest answer. 
            if (previousAnswers.Count != 0)
            {
                numberLabel.Content = previousAnswers[previousAnswers.Count - 1]; // answer
            }
        }

        #endregion

        #region Extras
        private void darkMode_Click(object sender, RoutedEventArgs e)
        {
            // If dark, turn to light. Else turn to dark. 
            if (Properties.Settings.Default.ColorModes == "Dark")
            {
                Properties.Settings.Default.ColorModes = "Light";
                darkModeGrid.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#f7f7f7");
                BottomGrid.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#f9f9f9");
                
            }
            else
            {
                Properties.Settings.Default.ColorModes = "Dark";
                darkModeGrid.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#292d36");
                BottomGrid.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#292d36");
            }


        }
        // Allows window to be dragged / moved
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }
        // Exits the program
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0); 
        }
        #endregion
    }
}
