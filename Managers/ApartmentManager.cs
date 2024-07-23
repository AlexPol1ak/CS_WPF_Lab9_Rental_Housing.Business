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

        public bool AddApartment(int idHouse, Apartment apartment )
        {
            House house = housesRepository.Get(idHouse);
            if (house is null) return false;
            apartment.House = house;
            apartmentRepository.Create(apartment);
            return true;
        }

        public bool AddApartment(House house, Apartment apartment)
        {
            apartment.House = house;
            apartmentRepository.Create(apartment);
            return true;
        }

        public bool DeleteApartment( int id)
        {
            return apartmentRepository.Delete(id);
        }

        public IEnumerable<Apartment> FindApartments(Expression<Func<Apartment, bool>> predicate) =>
            apartmentRepository.Find(predicate);

        public void UpdateApartment(Apartment apartment)
        {
            apartmentRepository.Update(apartment);
        }

        public bool ContainsApartment(Apartment apartment) => apartmentRepository.Contains(apartment);

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

        public int CountApartments() => apartmentRepository.Count();
    }
}
