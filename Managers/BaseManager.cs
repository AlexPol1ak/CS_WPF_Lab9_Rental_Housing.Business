using CS_WPF_Lab9_Rental_Housing.Domain.Entities;
using CS_WPF_Lab9_Rental_Housing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_WPF_Lab9_Rental_Housing.Business.Managers
{
    public class BaseManager
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IRepository<House> housesRepository;
        protected readonly IRepository<Apartment> apartmentRepository;
        protected readonly IRepository<Photo> photoRepository;

        public BaseManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            housesRepository = unitOfWork.HousesRepository;
            apartmentRepository = unitOfWork.ApartmentsRepository;
            photoRepository = unitOfWork.PhotosRepository;
        }
    }
}
