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
            this.RefreshDataSet();
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

        /// <summary>
        /// Deletes an employee for a given restaurant.
        /// </summary>
        /// <param name="employee">The employee to delete.</param>
        /// <param name="restaurantId">The employee's restaurant identifier.</param>
        /// <returns>True in case of successful update, false in case of failure.</returns>
        public bool DeleteEmployee(Employee employee, int restaurantId)
        {
            int nbrRowsDeleted = -1;
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.EMPLOYEETableAdapter daEmployee = new Model.DataSetRestoBookTableAdapters.EMPLOYEETableAdapter())
            {
                nbrRowsDeleted = daEmployee.Delete(employee.Id,
                                                   restaurantId,
                                                   employee.FirstName,
                                                   employee.LastName,
                                                   employee.Email,
                                                   employee.Mobile,
                                                   employee.Login,
                                                   employee.Password,
                                                   employee.IsEnabled);
            }
            return nbrRowsDeleted > 0;
        }
        #endregion PUBLIC METHODS


        #region PRIVATE METHODS
        /// <summary>
        /// Refreshes the dataset, so that the new data from database becomes available.
        /// </summary>
        private void RefreshDataSet()
        {
            // refresh the dataset
            this.dp.ds.Reset();
            this.dp.PrepareEmployeeDP();
        }
        #endregion PRIVATE METHODS

    }
}
