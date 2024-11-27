using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PrintableFormApp
{
    public partial class PrintPreviewWindow : Window
    {
        public PrintPreviewWindow(UserControl content)
        {
            InitializeComponent();
            PreviewContent.Content = content;
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(PreviewContent.Content as Visual, "Gold Purity Report");
            }
        }
    }
}