using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hafta5EmrullahYilmazOdev.Data
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Participants> Participant { get; set; }
        public List<DeletedUpdatedMessages> DeletedUpdatedMessage { get; set; }
        public List<DeletedUpdatedConversions> DeletedUpdatedConversion { get; set; }
        public List<Contacts> Contact { get; set; }
        public List<ContactRequests> ContactRequest { get; set; }
    }
}
