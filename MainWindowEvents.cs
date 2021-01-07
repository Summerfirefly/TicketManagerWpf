using System.Windows;
using System.Windows.Controls;

namespace TicketManagerWpf
{
    public partial class MainWindow
    {
        /// <summary>
        /// Used on ListBox, show dialog to edit selected item
        /// </summary>
        private void ticketDoubleClick(object sender, RoutedEventArgs args)
        {
            ListBox list = sender as ListBox;
            if (list != null && list.SelectedItem != null)
            {
                TicketInfo ticket = list.SelectedItem as TicketInfo;
                TicketEditor editor = new TicketEditor(ticket);

                editor.Owner = this;
                editor.ShowInTaskbar = false;
                editor.ShowDialog();
                list.Items.Refresh();
            }
        }
    }
}