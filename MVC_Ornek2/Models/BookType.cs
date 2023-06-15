namespace MVC_Ornek2.Models
{
    public class BookType : BaseEntity  
    {
        public string Name { get; set; }

        //relational prop
        public List<Book> Books { get; set; }
    }
}
