using System;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ClearVisionOrderForm
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void billingButton_Click(object sender, RoutedEventArgs e)
        {
            var rootframe = Window.Current.Content as Frame;
            if (rootframe == null)
            {
                diagnosticBox.Text = "There was an unspecified error obtaining the window context.";
                return;
            }
            if (string.IsNullOrEmpty(height.Text) || string.IsNullOrEmpty(width.Text) ||
                string.IsNullOrEmpty(length.Text) || string.IsNullOrEmpty(quantity.Text) ||
                string.IsNullOrWhiteSpace(height.Text) || string.IsNullOrWhiteSpace(width.Text) ||
                string.IsNullOrWhiteSpace(length.Text) || string.IsNullOrWhiteSpace(quantity.Text))
            {
                diagnosticBox.Text = "All entries on this form must be entered.";
                return;
            }
            if (Convert.ToDecimal(height.Text) < 0 || Convert.ToDecimal(width.Text) < 0 ||
                Convert.ToDecimal(length.Text) < 0 || Convert.ToDecimal(quantity.Text) < 0 )
            {
                diagnosticBox.Text = "All numerical values must be entered and be greater than or equal to zero.";
                return;
            }
            if (Convert.ToDecimal(quantity.Text) > 100)
            {
                diagnosticBox.Text = "No more than 100 of this item can be ordered at once.";
                return;
            }
            App.ProductDb.Add(new Product {Height = Convert.ToDecimal(height.Text), Width = Convert.ToDecimal(width.Text), Length = Convert.ToDecimal(length.Text), Quantity = Convert.ToDecimal(quantity.Text), Price = Convert.ToDecimal(quantity.Text) *((decimal)0.0078 * Convert.ToDecimal(height.Text) + (decimal)0.01 * Convert.ToDecimal(width.Text) + (decimal)0.156 * Convert.ToDecimal(length.Text))});
            rootframe.Navigate(typeof (BillingInformation));
        }
    }
}
