using CS_WPF_Lab9_Rental_Housing.Domain.Entities;
using CS_WPF_Lab9_Rental_Housing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_WPF_Lab9_Rental_Housing.Business.Managers
{
    public class PhotoManager : BaseManager
    {
        public PhotoManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public bool AddPhoto(int apartmentId, Photo photo)
        {
            Apartment apartment = apartmentRepository.Get(apartmentId);
            if (apartment == null) return false;
            photo.Apartment = apartment;
            photoRepository.Create(photo);
            return true;
        }

        public bool AddPhoto(Apartment apartment, Photo photo)
        {
            photo.Apartment = apartment;
            photoRepository.Create(photo);
            return true;
        }

        public bool DeletePhoto(int id)
        {
            return photoRepository.Delete(id);
        }

        public int CountPhotos() => photoRepository.Count();

    }
}
