using RestoBook.Common.Business.Managers;
using RestoBook.Common.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.GUI.View.Controllers
{
    class ServiceController : IServiceController
    {
        
		#region PROPERTIES
		private ServiceManager serviceManager;
        private ReservationManager reservationManager;
		#endregion PROPERTIES


		#region CONSTRUCTOR
		public ServiceController()
		{
			this.serviceManager = new ServiceManager();
            this.reservationManager = new ReservationManager();
		}
		#endregion CONSTRUCTOR


		#region PUBLIC METHODS
        /// <summary>
        /// Gets a dictionary of services from a restaurant ID.
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        public Dictionary<int, string> GetServiceDictionary(int restaurantId)
        {
            return this.serviceManager.GetServicesDictionary(restaurantId);
        }

        /// <summary>
        /// Gets a service by it's ID.
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        public Service GetServiceById(int serviceId)
        {
            Service service = this.serviceManager.GetServiceById(serviceId);

            if (service != null)
            {
                service.Reservations = this.reservationManager.GetReservationByService(service.Id);
            }
            return service;
        }

        #endregion PUBLIC METHODS
    }
}
