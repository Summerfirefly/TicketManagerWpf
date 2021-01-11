using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicketManagerWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string AppPath
        {
            get => System.AppDomain.CurrentDomain.BaseDirectory;
        }

        public string DataDirPath
        {
            get => System.IO.Path.Combine(this.AppPath, "data");
        }

        public MainWindow()
        {
            InitializeComponent();
            InitializeData();

            ticketList.BorderThickness = new Thickness(0.0);

            ticketList.MouseDoubleClick += ticketDoubleClick;
            liveSelector.SelectionChanged += liveSelectorSelectionChange;
        }

        private void InitializeData()
        {
            DirectoryInfo dataDir;

            if (!Directory.Exists(this.DataDirPath))
            {
                dataDir = Directory.CreateDirectory(this.DataDirPath);
            }
            else
            {
                dataDir = new DirectoryInfo(this.DataDirPath);
            }

            liveSelector.ItemsSource = dataDir.GetFiles("*.json");
        }
    }

    public class TicketInfo
    {
        public string Id { get; set; }
        public int VipCount { get; set; }
        public int NormalCount { get; set; }
    }
}
