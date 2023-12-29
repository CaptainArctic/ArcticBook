namespace ArcticBook.Models.Domain
{
    public class BookGenre
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int GenreId { get; set; }
    }
}
