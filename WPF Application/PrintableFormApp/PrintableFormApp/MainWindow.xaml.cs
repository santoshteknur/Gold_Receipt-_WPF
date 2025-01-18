using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace PrintableFormApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<ElementComposition> CompositionList { get; set; }
        public string CurrentDateTime => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        public MainWindow()
        {
            InitializeComponent();

            // Initialize the Composition List
            CompositionList = new ObservableCollection<ElementComposition>
            {
                new ElementComposition { Element = "Gold", Percentage = "0.00" },
                new ElementComposition { Element = "Silver", Percentage = "0.00" },
                new ElementComposition { Element = "Copper", Percentage = "0.00" },
                new ElementComposition { Element = "Platinum", Percentage = "0.00" },
                new ElementComposition { Element = "Lead", Percentage = "0.00" }
            };


            DateTimeTextBlock.Text = CurrentDateTime;
            CompositionDataGrid.ItemsSource = CompositionList;
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CustomerNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(SampleTypeTextBox.Text) ||
                string.IsNullOrWhiteSpace(SampleWeightTextBox.Text))
            {
                MessageBox.Show("Please fill all required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Proceed with the printing logic
            PrintLayout printLayout = new PrintLayout();
            printLayout.DataContext = new
            {
                CustomerName = CustomerNameTextBox.Text,
                SampleType = SampleTypeTextBox.Text,
                SampleWeight = SampleWeightTextBox.Text,
                GoldPurity = GoldPurityTextBox.Text,
                Karat = KaratTextBox.Text,
                DateTime = CurrentDateTime,
                CompositionList = CompositionList
            };

            PrintPreviewWindow previewWindow = new PrintPreviewWindow(printLayout);
            previewWindow.ShowDialog();
        }
    }

    public class ElementComposition
    {
        public string Element { get; set; }
        public string Percentage { get; set; }
    }
}
