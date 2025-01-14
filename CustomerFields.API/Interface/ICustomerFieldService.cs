using CustomerFields.API.Common;
using CustomerFields.API.Entity;

namespace CustomerFields.API.Interface
{
    public interface ICustomerFieldService
    {
        IEnumerable<CustomerField> GetAll();
        Responses GetByAccountNumber(string accountNumber);
        Responses GetByIndustry(string industry);
    }
}