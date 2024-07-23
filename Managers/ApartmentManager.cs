using CS_WPF_Lab9_Rental_Housing.Domain.Entities;
using CS_WPF_Lab9_Rental_Housing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CS_WPF_Lab9_Rental_Housing.Business.Managers
{
    public class ApartmentManager : BaseManager
    {
        public ApartmentManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region basic CRUD operations
        /// <summary>
        /// Add apartment 
        /// </summary>
        /// <param name="idHouse">House ID</param>
        /// <param name="apartment">Apartment entity</param>
        public bool AddApartment(int idHouse, Apartment apartment )
        {
            House house = housesRepository.Get(idHouse);
            if (house is null) return false;
            apartment.House = house;
            apartmentRepository.Create(apartment);
            return true;
        }

        /// <summary>
        ///  Add apartment
        /// </summary>
        /// <param name="house">House entity</param>
        /// <param name="apartment">Apartment entity</param>
        public bool AddApartment(House house, Apartment apartment)
        {
            apartment.House = house;
            apartmentRepository.Create(apartment);
            return true;
        }

        /// <summary>
        /// Delete apartment by ID.
        /// </summary>
        /// <param name="id">Apartments ID</param>
        public bool DeleteApartment( int id)
        {
            return apartmentRepository.Delete(id);
        }

        /// <summary>
        /// Apartments search
        /// </summary>
        public IEnumerable<Apartment> FindApartments(Expression<Func<Apartment, bool>> predicate) =>
            apartmentRepository.Find(predicate);

        /// <summary>
        /// Update apartments.
        /// </summary>
        /// <param name="apartment"></param>
        public void UpdateApartment(Apartment apartment)
        {
            apartmentRepository.Update(apartment);
        }

        /// <summary>
        /// Check if the apartment exists
        /// </summary>
        public bool ContainsApartment(Apartment apartment) => apartmentRepository.Contains(apartment);

        /// <summary>
        /// Add a collection of photos to the apartment.
        /// </summary>
        /// <param name="id">Apartment</param>
        /// <param name="photos">Photos collection</param>
        /// <returns>Number of photos added</returns>
        public int AddPhotosApartment(int id, IEnumerable<Photo> photos)
        {
            Apartment ap = apartmentRepository.Get(id);
            if (ap == null) return 0;
            int i = 0;
            foreach(Photo photo in photos)
            {
                ap.Photos.Add(photo);
                i++;
            }
            UpdateApartment(ap);
            return i;

        }
        /// <summary>
        /// Number of apartments
        /// </summary>
        public int CountApartments() => apartmentRepository.Count();

        #endregion
    }
}
