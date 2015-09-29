using System.Linq;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ClearVisionOrderForm
{
    public sealed partial class BillingInformation
    {
        public BillingInformation()
        {
            InitializeComponent();
        }

        private void order_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (province.Text.Length != 2)
            {
                diagnosticBox.Text = "The province code should be a two-character code.";
                return;
            }
            if (postalCode.Text.Length != 6)
            {
                diagnosticBox.Text = "Invalid postcal code.";
                return;
            }
            if (creditCardNumber.Text.Length != 16)
            {
                diagnosticBox.Text = "The credit card number should be a 16 digit number.";
                return;
            }
            if (cvv.Text.Length != 3)
            {
                diagnosticBox.Text = "The CVV number should be a 3 digit number.";
                return;
            }
            App.OrderDb.Add(new Order {Product = App.ProductDb.Last(), Contact = new Contact
            {
                Address = address.Text,
                City = city.Text,
                CreditCardNumber = creditCardNumber.Text,
                Cvv = cvv.Text,
                FirstName = firstName.Text,
                LastName = lastName.Text,
                PostalCode = postalCode.Text,
                Province = province.Text
            } });
            (Window.Current.Content as Frame)?.Navigate(typeof (MainPage));
            CoreApplication.Exit();
        }

        private void Click()
        {
            order_Click(this, null);
        }
    }
}
