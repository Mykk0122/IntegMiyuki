using System.Collections.Generic;
using integ_class1;

namespace integ_class2
{
    public interface IEmployeeData
    {
        void Save(EmployeeModel employee);
        List<EmployeeModel> GetAll();
        void Delete(string name);
    }
}