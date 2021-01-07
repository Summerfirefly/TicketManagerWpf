using System;
using System.ComponentModel;

namespace TicketManagerWpf
{
    public partial class TicketEditor
    {
        private void DialogClosing(object sender, CancelEventArgs args)
        {
            this.ticketInfo.Id = editorOrderId.Text;

            try
            {
                this.ticketInfo.VipCount = int.Parse(editorVip.Text);
            }
            catch (FormatException)
            {
                editorVip.Foreground = System.Windows.Media.Brushes.Red;
                args.Cancel = true;
                return;
            }

            try
            {
                this.ticketInfo.NormalCount = int.Parse(editorNormal.Text);
            }
            catch (FormatException)
            {
                editorNormal.Foreground = System.Windows.Media.Brushes.Red;
                args.Cancel = true;
                return;
            }
        }
    }
}