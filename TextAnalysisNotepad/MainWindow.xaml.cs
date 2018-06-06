using System.Configuration;
using System.Windows;

namespace TextAnalysisNotepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string text = InputBox.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["AzureCognitiveServices"].ConnectionString;

            Recognision recognision = new Recognision(connectionString);

            var phrases = await recognision.RecogniseKeyPhrases(text);
            var sentiment = await recognision.RecogniseSentiment(text);

            string labelText = "";

            foreach (var phrase in phrases.documents[0].keyPhrases)
            {
                labelText += phrase + "\r\n";
            }

            labelText += "\r\n Sentiment: " + sentiment.documents[0].score;

            ResultLabel.Content = labelText;
        }
    }
}
