using System.Runtime.Serialization;   
using SatoshiMinesStrategyStealer.Core.Extensions;
using SatoshiMinesStrategyStealer.Core.Helpers;

namespace SatoshiMinesStrategyStealer.Core.Models
{
    [DataContract]
    public class WithdrawResponse
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "balance")]
        public int Balance { get; set; }

        public int Sent { get; set; }
                                       
        public string Txid { get; set; }
            
        private static WithdrawResponse SetExtraWithdrawResponseFields(WithdrawResponse withdrawResponse)
        {
            if (withdrawResponse.Status == "success")
            {
                var sent = decimal.Parse(withdrawResponse.Message.GetBetween("฿", ". txid"));
                withdrawResponse.Sent = (int)(sent * 1000000);
                withdrawResponse.Txid = withdrawResponse.Message.GetBetween("<span class=\"txid\">", "</span>");
            }

            return withdrawResponse;
        }

        public static WithdrawResponse WithdrawResponseFromMessage(object content)
        {
            var withdrawResponse = JsonHelper.Deserialize<WithdrawResponse>(content.ToString());
            return SetExtraWithdrawResponseFields(withdrawResponse);
        }
    }
}