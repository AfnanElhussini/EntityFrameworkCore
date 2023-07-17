namespace EFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _context = new ApplicationDBContext();
            var employee = new Employee
            {
                EmployeeName = "Employee 1"
            };
            _context.Employees.Add(employee);
            _context.SaveChanges();
            
        }
    }
}