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
        public Dictionary<int, string> GetServiceDictionary(int restaurantId)
        {
            return this.serviceManager.GetServicesDictionary(restaurantId);
        }

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
