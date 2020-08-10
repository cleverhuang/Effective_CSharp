using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex38
{
    //第38条：考虑用lambda表达式来代替方法
    static class Program
    {
        static void Main(string[] args)
        {
            //var allEmployees = FindAllEmployees();

            //var salaried = allEmployees.LowPaidSalariedFilter();

            //var earlyFolks = salaried.Where(e => e.YearsOfService > 20);

            //var newest = salaried.Where(e => e.YearsOfService < 2);
        }

        private static IQueryable<Employee> LowPaidSalariedFilter(this IQueryable<Employee> sequence) =>
            from s in sequence
            where s.Classification == EmployeeType.Salary &&
            s.MonthlySalary < 4000
            select s;


    }

    public class Employee
    {
        public EmployeeType Classification { get; set; }
        public double Salary { get; set; }
        public double MonthlySalary { get; set; }
        public int YearsOfService { get; set; }


    }

    public enum EmployeeType
    {
        Salary
    }
}
