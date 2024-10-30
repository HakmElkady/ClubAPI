using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Club.Model
{
    public class EmployeeDTO
    {

        public int EmployeeId { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Address { get; set; }

        public int Gender { get; set; }

        public decimal Salary { get; set; }

        [ForeignKey(nameof(Club))]
        public int Clubid { get; set; }
    }
}
