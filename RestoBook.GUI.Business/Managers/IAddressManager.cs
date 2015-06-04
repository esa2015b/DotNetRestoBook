using RestoBook.Common.Model.Models;
using System.Collections.Generic;

namespace RestoBook.Common.Business.Managers
{
    public interface IAddressManager
    {
        /// <summary>
        /// Gets a list of the restaurant's addresses by the restaurant's identifier.
        /// </summary>
        /// <param name="restaurantId">The restaurant identifier.</param>
        /// <returns>The list of restaurant's addresses.</returns>
        List<Address> GetAddressesByRestaurantId(int restaurantId);


        /// <summary>
        /// Creates a new address.
        /// </summary>
        /// <param name="address">The address to create.</param>
        /// <param name="restaurantid">For which restaurant is the address?</param>
        /// <returns>True in case of successful update, false in case of failure.</returns>
        bool CreateAddres(Address address, int restaurantid);

        /// <summary>
        /// Deletes an address.
        /// </summary>
        /// <param name="address">The address to delete.</param>
        /// <param name="restaurantId">The restaurant identifier.</param>
        /// <returns>True in case of successful update, false in case of failure.</returns>
        bool DeleteAddress(Address address, int restaurantId);

    }
}
