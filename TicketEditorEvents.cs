using System;
using System.Windows;

namespace TicketManagerWpf
{
    public partial class TicketEditor
    {
        private void ApplyChange(object sender, RoutedEventArgs args)
        {
            bool hasError = false;

            if (editorOrderId.Text != string.Empty)
            {
                this.ticketInfo.Id = editorOrderId.Text;
            }
            else
            {
                hasError = true;
            }

            try
            {
                this.ticketInfo.VipCount = int.Parse(editorVip.Text);
            }
            catch (FormatException)
            {
                textVip.Foreground = System.Windows.Media.Brushes.Red;
                hasError = true;
            }

            try
            {
                this.ticketInfo.NormalCount = int.Parse(editorNormal.Text);
            }
            catch (FormatException)
            {
                textNormal.Foreground = System.Windows.Media.Brushes.Red;
                hasError = true;
            }

            if (!hasError)
            {
                this.Close();
            }
        }

        private void CancelEdit(object sender, RoutedEventArgs args)
        {
            this.Close();
        }
    }
}