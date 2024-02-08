using System.Data;

namespace RewardsProgram.Interface
{
    public interface ICustomer
    {
        DataSet GetCustomerByItem(int CustomerId);
    }
}
