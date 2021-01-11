using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace TicketManagerWpf
{
    public partial class MainWindow
    {
        private async void liveSelectorSelectionChange(object sender, SelectionChangedEventArgs args)
        {
            ComboBox selector = sender as ComboBox;
            if (selector != null && selector.SelectedItem != null)
            {
                FileInfo file = selector.SelectedItem as FileInfo;
                ticketList.ItemsSource = await Utilities.ParseTicketsFromFileAsync(file.FullName);
                ticketList.Items.Refresh();
            }
        }

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