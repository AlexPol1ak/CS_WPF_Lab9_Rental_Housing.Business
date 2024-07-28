using CS_WPF_Lab9_Rental_Housing.DAL.Data;
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
    public class BaseManager
    {
        
        protected readonly IUnitOfWork unitOfWork;
        //Table сontrol Repositories.
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

        public void SaveChanges() => unitOfWork.SaveChanges();


        /// <summary>
        /// Loads related entities
        /// </summary>
        /// <typeparam name="T">Primary entity type.</typeparam>
        /// <typeparam name="TProperty">Dependent entity Type.</typeparam>
        /// <param name="entity">Dependent Entity Type.</param>
        /// <param name="navigationProperty">
        /// An expression indicating a collection of related entities
        /// </param>
        public void LoadRelatedEntities<T, TProperty>(T entity, Expression<Func<T, IEnumerable<TProperty>>> navigationProperty)
               where T : class
               where TProperty : class
        {
            unitOfWork.LoadRelatedEntities(entity, navigationProperty);
        }
    }
}
