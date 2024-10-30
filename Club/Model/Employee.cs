using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Club.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required , MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Address { get; set; }

        public int Gender { get; set; }

        public decimal Salary { get; set; }

        [ForeignKey(nameof(Club))]
        public int Clubid { get; set; }

        public Clubs Club { get; set; }



    }
}
