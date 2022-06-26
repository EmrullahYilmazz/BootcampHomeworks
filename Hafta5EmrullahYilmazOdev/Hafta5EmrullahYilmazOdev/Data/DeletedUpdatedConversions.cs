using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hafta5EmrullahYilmazOdev.Data
{
    public class DeletedUpdatedConversions
    {
        public int Id { get; set; }
        public DateTime DeletedAt { get; set; }
        [ForeignKey("Users")]
        public int UsersId { get; set; }
        public Users Users { get; set; }
        [ForeignKey("Conversations")]
        public int ConversationId { get; set; }
        public Conversations Conversations { get; set; }
    }
}
