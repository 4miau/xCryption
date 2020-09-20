using System.Windows;

namespace xCryption
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtMsg.Clear();
        }

        private void btnClearEncry_Click(object sender, RoutedEventArgs e)
        {
            txtEncryptedMsg.Clear();
        }

        private void btnClearDecry_Click(object sender, RoutedEventArgs e)
        {
            txtDecryptedMsg.Clear();
        }

        private void btnEncry_Click(object sender, RoutedEventArgs e)
        {
            xCryFuncs Encryp = new xCryFuncs();
            txtEncryptedMsg.Text = Encryp.Encrypt(txtMsg.Text);
        }

        private void btnDecry_Click(object sender, RoutedEventArgs e)
        {
            xCryFuncs Decryp = new xCryFuncs();
            txtDecryptedMsg.Text = Decryp.Decrypt(txtEncryptedMsg.Text);
        }

        private void btnPublicKey_Click(object sender, RoutedEventArgs e)
        {
            Settings getKey = new Settings();
            getKey.Show();
        }
    }
}
