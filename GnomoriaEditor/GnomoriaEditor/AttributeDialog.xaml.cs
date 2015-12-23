using System;
using System.Windows;

namespace GnomoriaEditor
{
    /// <summary>
    /// Interaction logic for AttributeDialog.xaml
    /// </summary>
    public partial class AttributeDialog : Window
    {
        public AttributeDialog()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            int value;
            if (Int32.TryParse(AttributeValue.Text, out value))
            {
                DialogResult = true;
                Close();
            }
        }
    }
}
