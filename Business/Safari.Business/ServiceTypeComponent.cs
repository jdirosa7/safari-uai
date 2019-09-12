using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public class ServiceTypeComponent
    {
        public ServiceType Add(ServiceType serviceType)
        {
            ServiceType result = default(ServiceType);
            var serviceTypeDAC = new ServiceTypeDAC();

            result = serviceTypeDAC.Create(serviceType);
            return result;
        }

        public void Update(ServiceType serviceType)
        {
            var serviceTypeDAC = new ServiceTypeDAC();
            serviceTypeDAC.Update(serviceType);
        }

        public void Delete(int id)
        {
            var serviceTypeDAC = new ServiceTypeDAC();
            serviceTypeDAC.Delete(id);
        }

        public List<ServiceType> List()
        {
            List<ServiceType> result = default(List<ServiceType>);

            var serviceTypeDAC = new ServiceTypeDAC();
            result = serviceTypeDAC.Read();
            return result;
        }
    }
}
