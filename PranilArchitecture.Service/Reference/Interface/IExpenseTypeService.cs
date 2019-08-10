using PranilArchitecture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PranilArchitecture.Service
{
    public interface IExpenseTypeService
    {
        IEnumerable<ExpenseTypeEntity> GetAllExpenseType();
    }
}
