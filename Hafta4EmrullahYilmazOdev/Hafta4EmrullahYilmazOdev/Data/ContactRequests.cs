using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hafta4EmrullahYilmazOdev.Data
{
    public class ContactRequests
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ForeignKey("Users")]
        public int UsersId { get; set; }
        public Users Users { get; set; }
    }
}
