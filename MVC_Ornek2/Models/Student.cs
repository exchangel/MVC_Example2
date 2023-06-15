using System.ComponentModel.DataAnnotations;

namespace MVC_Ornek2.Models
{
    public class Student : BaseEntity
    {
        //    [Required]
        //    [MaxLength(30)]
        //bu kodlarla FirstName kolonu için non-nullable ve nvarchar(30) özelliği ekledim.
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string PhoneNumber { get; set; }

        //relational prop
        public List<Operation> Operations { get; set; }
    }
}
