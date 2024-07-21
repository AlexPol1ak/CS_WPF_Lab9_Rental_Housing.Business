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
    }
}
