using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hafta4EmrullahYilmazOdev.Data
{
    public class Conversations
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CreatorId { get; set; }
        public int ChannelId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Participants> Participant { get; set; }
        public List<Messages> Message { get; set; }
        public List<DeletedUpdatedMessages> DeletedUpdatedMessage { get; set; }
        public List<DeletedUpdatedConversions> DeletedUpdatedConversion { get; set; }






    }
}
