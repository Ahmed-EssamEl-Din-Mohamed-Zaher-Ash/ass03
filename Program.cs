namespace Assignment_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            //Create an array of Employees with size three a DBA, Guest and the third one is security officer who have full permissions. (Employee [] EmpArr;)
            Employee[] employees = Employee.CreateEmp(2);

            Employee.InsertData(employees);

            Console.Clear();
            Console.WriteLine("Before Soting");
            Employee.printArray(employees);

            Console.WriteLine("After Soting");
            Employee.SortAray(employees);
            Employee.printArray(employees);
            
        }
    }
}
