using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using RestoBook.Model;
using RestoBook.Common.Model.Models;
using RestoBook.Common.Model;

namespace RestoBook.Common.Business.Managers
{
    /// <summary>
    /// The owner manager.
    /// </summary>
    public class OwnerManager : IOwnerManager
    {
        #region PROPERTIES
        private DataProvider dp;
        #endregion PROPERTIES


        #region CONSTRUCTOR
        public OwnerManager()
        {
            this.dp = new DataProvider();
            this.dp.PrepareOwnerDP();
        }
        #endregion CONSTRUCTOR


        #region PUBLIC METHODS
        /// <summary>
        /// Gets the owner of a restaurant.
        /// </summary>
        /// <param name="ownerId">The owner identifier.</param>
        /// <returns>The owner of a restaurant.</returns>
        public Owner GetOwner(int ownerId)
        {
            this.RefreshDataSet();
            var res = this.dp.ds.OWNER.Where(o => o.OWNERID == ownerId).FirstOrDefault();
            // if no result (owner) is found previously, the return type will be null.
            // otherwise, return a new owner type of object, filled with the found properties.
            return res == null ? null : new Owner()
            {
                Id = (int)res.OWNERID,
                FirstName = res.FIRSTNAME,
                IsEnabled = res.ENABLE,
                LastName = res.LASTNAME
            };
        }

        /// <summary>
        /// Gets a list of owners corresponding to the firstname & lastname searched.
        /// </summary>
        /// <param name="firstName">The owner's first name.</param>
        /// <param name="lastName">The owner's last name.</param>
        /// <returns>A list of owners with corresponding firstname and lastname.</returns>
        public List<Owner> GetOwnerByFirstAndLastName(string firstName, string lastName)
        {
            this.RefreshDataSet();
            List<Owner> result = new List<Owner>();
            var owners = this.dp.ds.OWNER.Where(o => o.FIRSTNAME == firstName && o.LASTNAME == lastName).ToList();
            owners.ForEach(r => result.Add(new Owner()
                            {
                                Id = r.OWNERID,
                                FirstName = r.FIRSTNAME,
                                LastName = r.LASTNAME,
                                IsEnabled = r.ENABLE
                            }));
            return result;
        }

        /// <summary>
        /// Creates a new owner.
        /// </summary>
        /// <param name="owner">The owner to create.</param>
        /// <returns>True in case of successful update, false in case of failure.</returns>
        public bool CreateOwner(Owner owner)
        {
            int nbrRowsCreated = -1;
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.OWNERTableAdapter daOwner = new Model.DataSetRestoBookTableAdapters.OWNERTableAdapter())
            {
                nbrRowsCreated = daOwner.Insert(owner.FirstName,
                                                owner.LastName,
                                                owner.IsEnabled);
            }
            return nbrRowsCreated > 0;
        }

        /// <summary>
        /// Deletes an owner.
        /// </summary>
        /// <param name="owner">The owner to delete.</param>
        /// <returns>True in case of successful update, false in case of failure.</returns>
        public bool DeleteOwner(Owner owner)
        {
            int nbrRowsDeleted = -1;
            using (RestoBook.Common.Model.DataSetRestoBookTableAdapters.OWNERTableAdapter daOwner = new Model.DataSetRestoBookTableAdapters.OWNERTableAdapter())
            {
                nbrRowsDeleted = daOwner.Delete(owner.Id,
                                                owner.FirstName,
                                                owner.LastName,
                                                owner.IsEnabled);
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
            this.dp.PrepareOwnerDP();
        }
        #endregion PRIVATE METHODS

    }
}
