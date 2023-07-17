namespace EFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _context = new ApplicationDBContext();
           
           
            _context.SaveChanges();
            
        }
    }
}