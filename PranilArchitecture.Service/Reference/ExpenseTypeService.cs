using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PranilArchitecture.Data;
using PranilArchitecture.Entities;

namespace PranilArchitecture.Service
{
    public class ExpenseTypeService : IExpenseTypeService
    {
        private readonly UnitOfWork _unitOfWork;

        public ExpenseTypeService(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<ExpenseTypeEntity> GetAllExpenseType()
        {
            var expenseTypeList = this._unitOfWork.ExpenseTypeRepository.GetAll().ToList();
            if (expenseTypeList.Any())
            {
                var expenseTypeModel = AutoMapperConfiguration.Mapper.Map<ICollection<ExpenseType>, ICollection<ExpenseTypeEntity>>(expenseTypeList);
                return expenseTypeModel;
            }

            return null;
        }
    }
}
