namespace MVC_Ornek2.Models
{
    //hangi öğrenci hangi kitabı ne zman aldı ne zaman verdi
    public class Operation
    {

        public int StudentId { get; set; }
        public int BookId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //relational prop
        public Student Student { get; set; }
        public Book Book { get; set; }

    }
}
