using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticeProject1.DataConnection;
using PracticeProject1.Models;


namespace Ado.netApplication.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult EmployeeList(string FName)
        {
            //EmployeeDataAccessLayer employeeData = new EmployeeDataAccessLayer();
            //List<Employee> employees = employeeData.Employees.ToList();
            //return View(employees);
            EmployeeDataAccessLayer employeeData = new EmployeeDataAccessLayer();
            List<Employee> employees = employeeData.Employees.Where(x => x.FirstName.StartsWith(FName) || FName == null).ToList();
            return View(employees);
            fmorfkfs;elmfesjr
                smfsodjwoep
                lsddkmfsk();

        }

        //public ActionResult EmployeeSearch(string FName,string LastName)
        //{
        //    EmployeeDataAccessLayer employeeData = new EmployeeDataAccessLayer();
        //    List<Employee> employees = employeeData.Employees.Where(x=>x.FirstName == FName).ToList();
        //    return View(employees);
        //}

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            //Employee employee = new Employee();
            //  employee.FirstName = FirstName;
            //we can pass entire employee object as a parameter as above.
            if (ModelState.IsValid)
            {
                EmployeeDataAccessLayer employeeData = new EmployeeDataAccessLayer();
                employeeData.AddEmployee(employee);
                return RedirectToAction("EmployeeList");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditEmployee(int Id)
        {
            Employee employee = new Employee();
            EmployeeDataAccessLayer employeeData = new EmployeeDataAccessLayer();
           employee =  employeeData.GetEmployeeById(Id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult EditEmployee(int id,Employee employee)
        {

            //if (id != employee.EmpId)
            //{
            //    return RedirectToAction("EmployeeList");
            //}

            if (ModelState.IsValid)
            {
                EmployeeDataAccessLayer employeeData = new EmployeeDataAccessLayer();
                string FirstName = employee.FirstName;
                string LastName = employee.LastName;    
                string phoneNumber = employee.PhoneNumber;  
                string email = employee.Email;
                string Remarks = employee.Remarks;
                 employeeData.UpdateEmployee(employee);
                return RedirectToAction("EmployeeList");
                }
                return View();
                //Changes made is not getting saved in DAtabase..Please have a look.
            }

            public ActionResult DeleteEmployee(int? Id)
        {
            EmployeeDataAccessLayer employeeData = new EmployeeDataAccessLayer();
            employeeData.DeleteEmployee(Id);
            return RedirectToAction("EmployeeList");
        }
    }
}