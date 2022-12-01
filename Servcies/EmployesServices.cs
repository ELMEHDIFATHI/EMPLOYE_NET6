using Crud_NET.Models;

namespace Crud_NET.Servcies
{
    public class EmployesServices
    {

        static List<Employes> employeesList { get; }
        static int nextEmpId = 3;


        static EmployesServices()
        {
            employeesList = new List<Employes>()
            {
                new Employes {ID=1,Name="Ayman",Title="Developer" ,Salary=1000},
                new Employes {ID=2,Name="Mohamed",Title="CEO" ,Salary=50000}
            };
        }

        public static List<Employes> GetAll() => employeesList;

        public static Employes Get(int id) => employeesList.FirstOrDefault(p => p.ID == id);

        public static void Add(Employes emp)
        {
            emp.ID = nextEmpId++;
            employeesList.Add(emp);
        }

        public static void update(Employes emp)
        {
            var index=employeesList.FindIndex(p => p.ID == emp.ID);
            if (index == -1)
                return;
            employeesList[index] = emp;
        }

        public static void Delete(int id)
        {
            var employee = Get(id);
            if (employee is null)
                return;
            employeesList.Remove(employee);
        }

    }
}
