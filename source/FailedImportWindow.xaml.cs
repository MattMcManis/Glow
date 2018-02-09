using System.Windows;
using System.Windows.Documents;

namespace Glow
{
    /// <summary>
    /// Interaction logic for FailedImportWindow.xaml
    /// </summary>
    public partial class FailedImportWindow : Window
    {
        public FailedImportWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        ///    Window Loaded
        /// </summary>
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Paragraph p = new Paragraph();
            rtbFailedImport.Document = new FlowDocument(p);

            rtbFailedImport.BeginChange();
            p.Inlines.Add(new Run("Please set the following and re-save your profile.\n\n"));
            p.Inlines.Add(new Run(Profiles.failedImportMessage));
            rtbFailedImport.EndChange();

            // clear
            Profiles.failedImportMessage = string.Empty;
        }
    }
}
