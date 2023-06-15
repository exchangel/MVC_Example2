namespace MVC_Ornek2.Models
{
    public class BookEditViewModel
    {
        //aynı şeyleri taşıyo olsa bile (BookCreateViewModel) single responsibilty kuralından yeni class açılır.

        public List<BookType> BookTypes { get; set; }

        public List<Author> Authors { get; set; }

        public Book Book { get; set; }
    }
}
