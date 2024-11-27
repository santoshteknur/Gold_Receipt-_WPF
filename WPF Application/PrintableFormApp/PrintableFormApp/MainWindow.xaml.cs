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
                new ElementComposition { Element = "Gold", Percentage = "" },
                new ElementComposition { Element = "Silver", Percentage = "" },
                new ElementComposition { Element = "Copper", Percentage = "" },
                new ElementComposition { Element = "Platinum", Percentage = "" },
                new ElementComposition { Element = "Lead", Percentage = "" }
            };

            DateTimeTextBlock.Text = CurrentDateTime;
            CompositionDataGrid.ItemsSource = CompositionList;
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            // Create the print layout and bind data
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

            // Show the preview window
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
