using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SatoshiMinesStrategyStealer.Core.Providers;

namespace SatoshiMinesStrategyStealer.UI.Forms
{
    public partial class WithdrawForm : Form
    {             
        private readonly Player _player;

        public WithdrawForm(Player player)
        {
            _player = player;
            InitializeComponent(); 
        }
         
        private async void WithdrawForm_Load(object sender, EventArgs e)
        {
            await ShowBalance();
        }

        private async void btnWithdraw_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbAddress.Text))
                    throw new Exception("The withdraw address can not be empty.");

                if (nudAmount.Value == 0)
                    throw new Exception("The withdraw amount can not be 0.");

                var amount = (int) nudAmount.Value;
                var response = await _player.Withdraw(amount, tbAddress.Text);
                if (response.Status != "success")
                    throw new Exception(response.Message);

                var messageBuilder = new StringBuilder();
                messageBuilder.Append($"Sent: {response.Balance} Bits\r\n");
                messageBuilder.Append($"Txid: {response.Txid}");

                MessageBox.Show(messageBuilder.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }
        
        private async void lblBalance_Click(object sender, EventArgs e)
        {
            await ShowBalance();
        }

        private async void nudBalance_Click(object sender, EventArgs e)
        {
            await ShowBalance();
        }

        private async Task ShowBalance()
        {
            nudBalance.Value = await _player.GetBalance();
        }        
    }
}         