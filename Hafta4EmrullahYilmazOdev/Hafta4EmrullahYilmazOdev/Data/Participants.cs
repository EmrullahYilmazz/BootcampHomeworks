using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hafta4EmrullahYilmazOdev.Data
{
    public class Participants
    {
       
        public int Id { get; set; }
        public string Type { get; set; }
        [ForeignKey("Users")]
        public int UsersId { get; set; }
        public Users Users { get; set; }
        [ForeignKey("Conversations")]
        public int ConversationId { get; set; }
        public Conversations Conversations { get; set; }
        public List<Messages> Messages { get; set; }




    }
}
