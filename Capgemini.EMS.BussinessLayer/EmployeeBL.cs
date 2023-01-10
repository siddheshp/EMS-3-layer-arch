using Capgemini.EMS.DataAccessLayer;
using Capgemini.EMS.Entities;
using Capgemini.EMS.Exceptions;
using System.Net.Http.Headers;

namespace Capgemini.EMS.BussinessLayer
{
    public class EmployeeBL
    {
        public static bool Add(Employee emp)
        {
            //biz validations
            //throw UDE
            if (emp.Id <= 0) //invalid
            {
                throw new EmsException("Employee id should be greater than zero");
            }

            //call DAL method
            bool isAdded = EmplyeeDAL.Add(emp);
            return isAdded;
        }

        public static List<Employee> GetList()
        {
            var list = EmplyeeDAL.GetList();
            return list;
        }
        public static Employee GetById(int id)
        {
            var emp = EmplyeeDAL.GetById(id);
            return emp;
        }
        public static bool Update(Employee emp)
        {
            bool isUpdated = EmplyeeDAL.Update(emp);
            return isUpdated;
        }
    }
}