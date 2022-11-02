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

namespace CaesarsCipher
{
    public partial class MainWindow : Window
    {
 
        private readonly string alphabet = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
        public MainWindow()
        {
            InitializeComponent();
        }

        private static string ReverseString(string stringToReverse)
        {
            var charArray = stringToReverse.ToCharArray();
            Array.Reverse(charArray);
            var reversedString = new string(charArray);
            return reversedString;
        }

        private static bool IsAlphaNumeric(char c)
        {
            return Char.IsLetter(c) || Char.IsWhiteSpace(c);
        }

        private static string Encrypt(int shift, string input, string alphabet)
        {
            var message = new StringBuilder();

            foreach (char letter in input)
            {
                if (Char.IsWhiteSpace(letter))
                {
                    message.Append(" ");
                    continue;
                } 
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (letter == alphabet[i])
                    {
                        message.Append(alphabet[(i + shift) % alphabet.Length]);
                    }
                }
            }
            return message.ToString();
        }


        public void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var key = Int32.Parse(tbxKey.Text);
                var encrypt = tbxEncrypt.Text.ToLower();
                encrypt = String.Concat(Array.FindAll(encrypt.ToCharArray(), IsAlphaNumeric));

                tbxEncrypted.Text = Encrypt(key, encrypt, alphabet);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input");
            }
        }

        public void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            var reversedAlphabet = ReverseString(alphabet);
            try
            {
                var key = Int32.Parse(tbxKey.Text);
                var decrypt = tbxEncrypted.Text.ToLower();
                decrypt = String.Concat(Array.FindAll(decrypt.ToCharArray(), IsAlphaNumeric));

                tbxEncrypt.Text = Encrypt(key, decrypt, reversedAlphabet);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Invalid input");
            }
        }

    }
}
