using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private string liveInfoFilePath;

        public MainWindow()
        {
            InitializeComponent();

            List<TicketInfo> list = new List<TicketInfo>();
            list.Add(new TicketInfo() { Id = "12345678", VipCount = 2, NormalCount = 1 });
            list.Add(new TicketInfo() { Id = "12345679", VipCount = 0, NormalCount = 1 });
            list.Add(new TicketInfo() { Id = "12345677", VipCount = 3, NormalCount = 0 });

            lbTicketList.ItemsSource = list;
            lbTicketList.BorderThickness = new Thickness(0.0);
            lbTicketList.MouseDoubleClick += ticketDoubleClick;
        }

        private void InitializeData()
        {
            liveInfoFilePath = System.IO.Path.Combine(this.DataDirPath, "live-info.json");

            if (!Directory.Exists(this.DataDirPath))
            {
                Directory.CreateDirectory(this.DataDirPath);
            }

            if (!File.Exists(liveInfoFilePath))
            {
                StreamWriter liveInfoWriter = new StreamWriter(liveInfoFilePath, false);
                liveInfoWriter.WriteLine("[]");
                liveInfoWriter.Flush();
                liveInfoWriter.Close();
            }
        }
    }

    public class LiveInfo
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
    }

    public class TicketInfo
    {
        public string Id { get; set; }
        public int VipCount { get; set; }
        public int NormalCount { get; set; }
    }
}
