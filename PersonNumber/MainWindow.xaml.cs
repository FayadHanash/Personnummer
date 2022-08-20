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

namespace PersonNumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person person; // Declare Person object
        public MainWindow()
        {
            InitializeComponent();
            InitializeGUI();
        }

        /// <summary>
        /// Method that initializes the window
        /// </summary>
        void InitializeGUI()
        {
            person = new Person();  
            txtNamn.Text = String.Empty;
            txtPersonNumber.Text = String.Empty;    
            txtResult.Text = String.Empty;   
        }

        /// <summary>
        /// Method that validates the inputs
        /// </summary>
        /// <returns></returns>
        bool GetInputs()
        {
            bool ok = false;
            bool forName = ValidateText(txtNamn.Text, "Du behöver ange Förnamn");
            bool personNum = ValidateText(txtPersonNumber.Text, "Du bör ange ditt person nummer");
            if(forName && personNum)
            {
                if(txtPersonNumber.Text.Length >= 10 && txtPersonNumber.Text.Length <= 12)
                {
                    person.Name = txtNamn.Text;
                    person.PersonNumber = txtPersonNumber.Text;
                    ok = true;
                }
                else
                {
                    MessageBox.Show("Personnummeret bör vara mellan 10 och 12 siffror.");
                    ok = false; 
                }
            }
            return ok;
        }

        /// <summary>
        /// Method that validates a string is not null, otherwise shows an error message
        /// </summary>
        /// <param name="text">the string to be validated</param>
        /// <param name="errMessage">the error string</param>
        /// <returns></returns>
        private bool ValidateText(string text, string errMessage)
        {
            if (String.IsNullOrEmpty(text.Trim()))
            {
                MessageBox.Show(errMessage);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Method that gets the input and controls the personnumber and updates the window
        /// </summary>
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool inputOk = GetInputs();
                if (inputOk)
                {
                    if (person.Check())
                        txtResult.Text = $"{person.Name}\n{person.PersonNumber}\n{person.Gender}\n";
                    else
                        txtResult.Text = "Felaktig Personnummer.\nFörsök igen";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        /// <summary>
        /// Method that reinitilaizes the window
        /// </summary>
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            InitializeGUI();
        }

        /// <summary>
        /// Method that allows to enter only numeric values in PersonNumber textbox
        /// </summary>
        private void txtPersonNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
               
                if (e.Key < Key.D0 || e.Key > Key.D9)
                    if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                        if (e.Key != Key.Back && e.Key != Key.Decimal)
                            e.Handled = true;

                if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                    e.Handled = true;
      
                if (e.Key == Key.Left || e.Key == Key.Right)
                    e.Handled = false;

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

    }
}
