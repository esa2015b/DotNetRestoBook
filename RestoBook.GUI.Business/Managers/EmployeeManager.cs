using RestoBook.Common.Model;
using RestoBook.Model;
using RestoBook.Model.Common.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Common.Business.Managers
{
    /// <summary>
    /// The employeemanager, deals with all employees related to a restaurant.
    /// </summary>
    public class EmployeeManager : IEmployeeManager
    {
        #region PROPERTIES
        private DataProvider dp;
        #endregion PROPERTIES


        #region CONSTRUCTOR
        public EmployeeManager()
        {
            this.dp = new DataProvider();
            dp.PrepareEmployeeDP();
        }
        #endregion CONSTRUCTOR


        #region PUBLIC METHODS
        /// <summary>
        /// Gets the employees for a given restaurant.
        /// </summary>
        /// <param name="restaurantId">The restaurant Identifier.</param>
        /// <returns>A list of employees.</returns>
        public List<Employee> GetEmployees(int restaurantId)
        {
            List<Employee> employees = new List<Employee>();
            this.dp.ds.EMPLOYEE.Where(e => e.RESTAURANTID == restaurantId)
                               .ToList()
                               .ForEach(e => employees.Add(new Employee()
                                                            {
                                                                Email = e.MAIL,
                                                                FirstName = e.FIRSTNAME,
                                                                Id = (int)e.EMPLOYEEID,
                                                                IsEnabled = e.ENABLE,
                                                                LastName = e.LASTNAME,
                                                                Login = e.LOGIN,
                                                                Mobile = e.MOBILE,
                                                                Password = e.PASSWORD,
                                                                RestaurantId = new List<int> { (int)e.RESTAURANTID }
                                                            }));
            
            return employees;
        }
        #endregion PUBLIC METHODS
    }
}
