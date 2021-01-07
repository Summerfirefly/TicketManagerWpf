using System.Windows;

namespace TicketManagerWpf
{
    /// <summary>
    /// Interaction logic for TicketEditor.xaml
    /// </summary>
    public partial class TicketEditor : Window
    {
        private TicketInfo ticketInfo;

        public TicketEditor(TicketInfo ticket)
        {
            InitializeComponent();

            this.ticketInfo = ticket;
            editorOrderId.Text = ticket.Id;
            editorVip.Text = ticket.VipCount.ToString();
            editorNormal.Text = ticket.NormalCount.ToString();

            this.Closing += DialogClosing;
        }
    }
}