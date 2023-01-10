using Capgemini.EMS.BussinessLayer;
using Capgemini.EMS.Entities;
using Capgemini.EMS.Exceptions;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1 Add employee, 2 Employee List, 3 Update Employee," +
                "4 Delete Employee, 5 Exit");
            Console.WriteLine("Enter your choice");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("invalid input");
                return;
            }
            switch (choice)
            {
                case 1:
                    AddEmployee();
                    break;
                case 2:
                    EmployeeList();
                    break;
                case 3:
                    UpdateEmployee();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;
            }
        }
    }

    private static void UpdateEmployee()
    {
        //emp id
        string input;
        int empId;
        do
        {
            Console.WriteLine("enter employee id");
            input = Console.ReadLine();
        } while (!int.TryParse(input, out empId));
        //emp id - check
        var existingEmployee = EmployeeBL.GetById(empId);
        if (existingEmployee == null)
        {
            Console.WriteLine("Employee not found");
            return;
        }
        //name/doj
        Employee newEmp = new Employee();
        newEmp.Id = empId;
        do
        {
            Console.WriteLine("Enter employee name");
            input = Console.ReadLine();
        } while (string.IsNullOrEmpty(input));
        newEmp.Name = input;

        DateTime dateOfJoining;
        do
        {
            Console.WriteLine("Enter date of joining");
            input = Console.ReadLine();
        } while (!DateTime.TryParse(input, out dateOfJoining));
        newEmp.DateOfJoining = dateOfJoining;
        //update
        var isUpdated = EmployeeBL.Update(newEmp);
        if (isUpdated)
        {
            Console.WriteLine("Employee updated successfully");
        }
        else
        {
            Console.WriteLine("Employee update failed");
        }
    }

    private static void EmployeeList()
    {
        var list = EmployeeBL.GetList();
        Console.WriteLine("Employee list");
        foreach (var emp in list)
        {
            Console.WriteLine(emp);
        }
    }

    private static void AddEmployee()
    {
        Employee newEmployee = new Employee();

        string input;
        int empId;
        do
        {
            Console.WriteLine("enter employee id");
            input = Console.ReadLine();
        } while (!int.TryParse(input, out empId));
        newEmployee.Id = empId;

        do
        {
            Console.WriteLine("Enter employee name");
            input = Console.ReadLine();
        } while (string.IsNullOrEmpty(input));
        newEmployee.Name = input;

        DateTime dateOfJoining;
        do
        {
            Console.WriteLine("Enter date of joining");
            input = Console.ReadLine();
        } while (!DateTime.TryParse(input, out dateOfJoining));
        newEmployee.DateOfJoining = dateOfJoining;

        //call BL
        try
        {
            bool isAdded = EmployeeBL.Add(newEmployee);
            if (isAdded)
            {
                Console.WriteLine("Employee add successfully");
            }
            else
            {
                Console.WriteLine("Employee add failed");
            }
        }
        catch (EmsException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}