using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hafta2EmrullahYilmazOdev2.Data
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        [ForeignKey("School")]
        public int SchoolId { get; set; }
        public School School { get; set; }
        [ForeignKey("Classroom")]
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
    }
}
