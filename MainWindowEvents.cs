using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace TicketManagerWpf
{
    public partial class MainWindow
    {
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
}