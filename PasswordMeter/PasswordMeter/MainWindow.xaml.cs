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

namespace PasswordMeter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Input velden: userNameTextBox en passwordTextBox
        /// Output veld: resultTextBlock
        /// </summary>

        public MainWindow()
        {
            InitializeComponent();
            resultTextBlock.Foreground = Brushes.Green;
            resultTextBlock.Text = "PXL";
        }

        private void passwordMeterButton_Click(object sender, RoutedEventArgs e)
        {
            resultTextBlock.Foreground = Brushes.Red;
            string username = userNameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            // drie voorwaarden voor sterk wachtwoord
            bool passwordLength = password.Length >= 10;
            bool containsDigit = password.Any(char.IsDigit);
            bool containsUsername = !password.Contains(username);

            if (passwordLength && containsDigit && containsUsername) // aan drie voorwaarden voldaan 
                resultTextBlock.Text = "Dit is een sterk wachtwoord";
            else if
                ((passwordLength && containsDigit) || (passwordLength && containsUsername) || (containsDigit && containsUsername)) // aan twee voorwaarden voldaan
                resultTextBlock.Text = "Dit wachtwoord is oké";
            else
            {
                resultTextBlock.Text = "Wachtwoord is zwak";
                Random rnd = new Random();
                StringBuilder sb = new StringBuilder();

                //5 willekeurige letters
                for (int i = 1; i <= 5; i++)
                {
                    int lengteUserName = userNameTextBox.Text.Length;
                    int nummerke = rnd.Next(0, lengteUserName);
                    string letterke = userNameTextBox.Text.Substring(nummerke, 1);
                    sb.Append(letterke.ToLower());
                    //sb.Append(UserNameTextBox.Text.Substring(rnd.Next(0, UserNameTextBox.Text.Length), 1).ToLower());
                }

                //5 willekeurige cijfers
                for (int i = 1; i <= 5; i++)
                {
                    sb.Append(rnd.Next(0, 11));
                }

                //Hoofdletters toevoegen
                for (int i = 1; i <= 2; i++)
                {
                    sb.Append(userNameTextBox.Text.Substring(rnd.Next(0, userNameTextBox.Text.Length), 1).ToUpper());
                }

                //Uitroeptekens
                int randomGetalleke = rnd.Next(1, 6);
                for (int i = 1; i <= randomGetalleke; i++)
                {
                    sb.Append('!');
                }

                if (MessageBox.Show($"Nieuw wachtwoord voorstelling: {sb.ToString()}", "Akkoord?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    passwordTextBox.Text = sb.ToString();
                }
            }
        }
    }
}
