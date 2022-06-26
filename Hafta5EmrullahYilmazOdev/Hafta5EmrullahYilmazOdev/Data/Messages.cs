using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hafta5EmrullahYilmazOdev.Data
{
    public class Messages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("Participiants")]
        public int ParticipiantsId { get; set; }
        public Participants Participants { get; set; }
        [ForeignKey("Conversations")]
        public int ConversationId { get; set; }
        public Conversations Conversations { get; set; }
        public List<DeletedUpdatedMessages> DeletedUpdatedMessage { get; set; }

    }
}
