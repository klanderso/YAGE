using System;
using System.Windows;

namespace GnomoriaEditor
{
    /// <summary>
    /// Interaction logic for SkillDialog.xaml
    /// </summary>
    public partial class SkillDialog : Window
    {
        public SkillDialog()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            int value;
            if (Int32.TryParse(SkillValue.Text, out value))
            {
                DialogResult = true;
                Close();
            }
        }
    }
}
