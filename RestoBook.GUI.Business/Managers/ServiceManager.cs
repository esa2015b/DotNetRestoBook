using RestoBook.Common.Model;
using RestoBook.Common.Model.Models;
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
    /// The servicemanager, deals with the restaurants services.
    /// </summary>
    public class ServiceManager : IServiceManager
    {
        #region PROPERTIES
        private DataProvider dp;
        #endregion PROPERTIES


        #region CONSTRUCTOR
        public ServiceManager()
        {
            this.dp = new DataProvider();
            this.dp.PrepareServiceDP();
        }
        #endregion CONSTRUCTOR


        #region PUBLIC METHODS
        /// <summary>
        /// Gets a list of services linked to the restaurant.
        /// </summary>
        /// <param name="restaurantId">The restaurant identifier.</param>
        /// <returns>A list of services.</returns>
        public List<Service> GetServices(int restaurantId)
        {
            List<Service> services = new List<Service>();

            this.dp.ds.SERVICE.Where(s => s.RESTAURANTID == restaurantId)
                              .ToList()
                              .ForEach(s => services.Add(new Service() 
                                                            { 
                                                                Id = (int)s.SERVICEID,
                                                                BeginShift = s.STARTSHIFT,
                                                                EndShift = s.ENDSHIFT,
                                                                IsEnabled = s.ENABLE,
                                                                PlaceQuantity = s.PLACEQUANTITY,
                                                                ServiceDay = s.SERVICEDAY.DayOfWeek,
                                                                TypeService = s.TYPESERVICE
                                                            }));
            return services;
        }
        #endregion PUBLIC METHODS
    }
}
