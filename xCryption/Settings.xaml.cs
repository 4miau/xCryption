using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace xCryption
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void btnConfirmC_Click(object sender, RoutedEventArgs e)
        {
            string failkey = txtPublicKeyManagement.Text;

            if (txtPublicKeyManagement.Text.Contains("try again please!") || txtPublicKeyManagement.Text.Contains("Do not use spaces"))
            {
                txtPublicKeyManagement.Clear();
            }
            else if (!(txtPublicKeyManagement.Text.Length == 8))
            {
                txtPublicKeyManagement.Text = InvalidChars(failkey);
            } 
            else if (txtPublicKeyManagement.Text.Contains(" ")) 
            {
                txtPublicKeyManagement.Text = NoSpacesEither();
            }
            else
            {
                xCryFuncs.PublicKeySetting.publickey = txtPublicKeyManagement.Text;
                Close();

            }
        }

        public static string InvalidChars(string keyattempt)
        {
            return keyattempt + " is not 8 characters long, try again please!";
        }

        public static string NoSpacesEither()
        {
            return "Do not use spaces in your key please.";
        }
    }
}
