using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Model.Common.Models
{
    /// <summary>
    /// A restaurant employee.
    /// </summary>
    [DataContract()]
    public class Employee
    {
        #region PROPERTIES
        /// <summary>
        /// The employee's identifier.
        /// </summary>
        [DataMember(IsRequired = true)]
        public int Id { get; set; }

        /// <summary>
        /// The restaurants where the employee works.
        /// </summary>
        [DataMember(IsRequired = true)]
        public List<int> RestaurantId { get; set; }

        /// <summary>
        /// the employee's first name.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string FirstName { get; set; }

        /// <summary>
        /// the employee's last name.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string LastName { get; set; }

        /// <summary>
        /// The employee's email address.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Email { get; set; }

        /// <summary>
        /// The employee's mobile number.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Mobile { get; set; }

        /// <summary>
        /// The employee's login / username.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Login { get; set; }

        /// <summary>
        /// The employee's password. 
        /// TODO : change to a hash.
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Password { get; set; }

        /// <summary>
        /// Is the employee still active?
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool IsEnabled { get; set; }
        #endregion PROPERTIES
    }
}
