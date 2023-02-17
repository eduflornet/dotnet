namespace NET5.WebApi.DAL.Entities
{
    public class Author
    {
        public const int NameLength = 100;

        public int AuthorId { get; set; }

        [Required]
        [MaxLength(NameLength)]
        public string Name { get; set; }

        //------------------------------
        //Relationships

        public ICollection<BookAuthor>
            BooksLink
        { get; set; }
    }
}
