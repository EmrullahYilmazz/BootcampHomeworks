using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hafta5EmrullahYilmazOdev.Data
{
    public class DeletedUpdatedMessages
    {
        public int Id { get; set; }
        public DateTime DeletedAt { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        [ForeignKey("Users")]
        public int UsersId { get; set; }
        public Users Users { get; set; }
        [ForeignKey("Messages")]
        public int MessageId { get; set; }
        public Messages Messages { get; set; }
    }
}
