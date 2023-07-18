using EFCore.Models;

namespace EFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _context = new ApplicationDBContext();

            var Author = new Author
            {
             FirstName = "Afnan",
             LastName = "Elhussini"
            };
            _context.Authors.Add(Author);
            _context.SaveChanges();
            
        }
    }
}