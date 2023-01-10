using Capgemini.EMS.Entities;

namespace Capgemini.EMS.DataAccessLayer
{
    public class EmplyeeDAL
    {
        static List<Employee> list = new List<Employee>();
        public static bool Add(Employee emp)
        {
            list.Add(emp);
            return true;
        }

        public static List<Employee> GetList()
        {
            return list;
        }
        public static Employee GetById(int id)
        {
            //linq
            var emp = list.Where(e => e.Id == id).FirstOrDefault();
            return emp;
        }
        public static bool Update(Employee emp)
        {
            //get emp by id
            var exisitngEmp = list.Where(e => e.Id == emp.Id).FirstOrDefault();
            //update
            exisitngEmp.Name = emp.Name;
            exisitngEmp.DateOfJoining = emp.DateOfJoining;

            return true;
        }
    }
}