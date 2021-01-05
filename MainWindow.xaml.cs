using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();

            List<TicketInfo> list = new List<TicketInfo>();
            list.Add(new TicketInfo() { Id = "12345678", VipCount = 2, NormalCount = 1 });
            list.Add(new TicketInfo() { Id = "12345679", VipCount = 0, NormalCount = 1 });
            list.Add(new TicketInfo() { Id = "12345677", VipCount = 3, NormalCount = 0 });

            lbTicketList.ItemsSource = list;
            lbTicketList.SelectionChanged += listSelectionChanged;

            tboxOrderId.LostKeyboardFocus += tboxLostKeyboardFocus;
            tboxVip.LostKeyboardFocus += tboxLostKeyboardFocus;
            tboxNormal.LostKeyboardFocus += tboxLostKeyboardFocus;
        }

        private void listSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            if (lbTicketList.SelectedItem != null)
            {
                TicketInfo info = lbTicketList.SelectedItem as TicketInfo;
                tboxOrderId.Text = info.Id;
                tboxVip.Text = info.VipCount.ToString();
                tboxNormal.Text = info.NormalCount.ToString();
            }
        }

        private void tboxLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs args)
        {
            if (lbTicketList.SelectedItem != null)
            {
                TextBox tbox = sender as TextBox;
                TicketInfo info = lbTicketList.SelectedItem as TicketInfo;

                switch (tbox.Name)
                {
                    case "tboxOrderId":
                        info.Id = tbox.Text;
                        break;
                    case "tboxVip":
                        info.VipCount = Int32.Parse(tbox.Text);
                        break;
                    case "tboxNormal":
                        info.NormalCount = Int32.Parse(tbox.Text);
                        break;
                }

                lbTicketList.Items.Refresh();
            }
        }
    }

    public class TicketInfo
    {
        public string Id { get; set; }
        public int VipCount { get; set; }
        public int NormalCount { get; set; }
    }
}
