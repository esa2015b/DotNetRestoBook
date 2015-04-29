using RestoBook.Common.Model;
using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Common.Business.Managers
{
    /// <summary>
    /// The employeemanager interface.
    /// </summary>
    public interface IEmployeeManager
    {
        /// <summary>
        /// Gets the employees for a given restaurant.
        /// </summary>
        /// <param name="restaurantId">The restaurant Identifier.</param>
        /// <returns>A list of employees.</returns>
        List<Employee> GetEmployees(int restaurantId);

        /// <summary>
        /// Creates a new employee row in the database for a given restaurant.
        /// </summary>
        /// <param name="employee">The employee to create.</param>
        /// <param name="restaurantId">The employee's restaurant identifier.</param>
        /// <returns>True in case of successful creation, false in case of failure.</returns>
        bool CreateEmployee(Employee employee, int restaurantId);

        /// <summary>
        /// Deletes an employee for a given restaurant.
        /// </summary>
        /// <param name="employee">The employee to delete.</param>
        /// <param name="restaurantId">The employee's restaurant identifier.</param>
        /// <returns>True in case of successful update, false in case of failure.</returns>
        bool DeleteEmployee(Employee employee, int restaurantId);
    }
}
