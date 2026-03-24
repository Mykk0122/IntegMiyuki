using integ_class1;

namespace integ_class2
{
    public interface IEmployeeData
    {
        void Save(EmployeeModel data);
        List<EmployeeModel> GetAll();
    }
}