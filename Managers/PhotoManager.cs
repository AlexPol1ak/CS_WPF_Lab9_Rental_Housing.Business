using CS_WPF_Lab9_Rental_Housing.Domain.Entities;
using CS_WPF_Lab9_Rental_Housing.Domain.Interfaces;

namespace CS_WPF_Lab9_Rental_Housing.Business.Managers
{
    public class PhotoManager : BaseManager
    {
        public PhotoManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region basic CRUD operations
        /// <summary>
        /// Add a photo of the apartment.
        /// </summary>
        /// <param name="apartmentId">Apartment ID </param>
        /// <param name="photo">Photo entity</param>
        public bool AddPhoto(int apartmentId, Photo photo)
        {
            Apartment apartment = apartmentRepository.Get(apartmentId);
            if (apartment == null) return false;
            photo.Apartment = apartment;
            photoRepository.Create(photo);
            return true;
        }

        /// <summary>
        /// Add a photo of the apartment.
        /// </summary>
        /// <param name="apartment">Apartment entity</param>
        /// <param name="photo">Photo entit</param>
        public bool AddPhoto(Apartment apartment, Photo photo)
        {
            photo.Apartment = apartment;
            photoRepository.Create(photo);
            return true;
        }

        /// <summary>
        /// Delete photo by ID.
        /// </summary>
        /// <param name="id">Photo ID</param>
        public bool DeletePhoto(int id)
        {
            return photoRepository.Delete(id);
        }

        /// <summary>
        /// Count all photo.
        /// </summary>
        /// <returns></returns>
        public int CountPhotos() => photoRepository.Count();
        #endregion

    }
}
