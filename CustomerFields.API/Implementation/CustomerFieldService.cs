using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerFields.API.Entity;
using CustomerFields.API.Interface;
using CustomerFields.API.Common;


namespace CustomerFields.API.Implementation
{
    public class CustomerFieldService : ICustomerFieldService
    {
        private readonly List<CustomerField> _customerFields;

        public CustomerFieldService()
        {
            _customerFields = new List<CustomerField>
            {
                new CustomerField
                {
                    AccountNumber = "1234567890",
                    Industry = "Manufacturing",
                    Fields = new List<string> { "Invoice Number", "Quantity", "Delivery Address" }
                },
                new CustomerField
                {
                    AccountNumber = "2345678901",
                    Industry = "Education",
                    Fields = new List<string> { "Matric Number", "Level", "Course" }
                },
                new CustomerField
                {
                    AccountNumber = "3456789012",
                    Industry = "Telecommunication",
                    Fields = new List<string> { "GSM Number", "Network", "Residential Address" }
                }
            };
        }

        public IEnumerable<CustomerField> GetAll() => _customerFields;

        public Responses GetByAccountNumber(string accountNumber)
        {
            var response = new Responses();
            if (accountNumber == null)
            {
                response.ResponseCode = "400";
                response.ResponseMsg = "kindly input a valid accountnumber";
                response.ResponseDetails = null;

                return response;
            }
            var customerField = _customerFields.FirstOrDefault(c => c.AccountNumber == accountNumber);

            if (customerField == null )
            {
                response.ResponseCode = "400";
                response.ResponseMsg = "accountNumber does not exist";
                response.ResponseDetails = null;

                            return response;

            }

            response.ResponseCode = "200";
            response.ResponseMsg = "Success";
            response.ResponseDetails = customerField.Fields;

            return response;
        }

        public Responses GetByIndustry(string industry)
        {
            var response = new Responses();
            if (industry == null)
            {
                response.ResponseCode = "400";
                response.ResponseMsg = "kindly input a valid industry";
                response.ResponseDetails = null;

                return response;
            }
            var customerField = _customerFields.FirstOrDefault(c => c.Industry == industry);

            if (customerField == null)
            {
                response.ResponseCode = "400";
                response.ResponseMsg = "industry does not exist";
                response.ResponseDetails = null;
                return response;

            }

            response.ResponseCode = "200";
            response.ResponseMsg = "Success";
            response.ResponseDetails = customerField.Fields;

            return response;
        }
    }
}