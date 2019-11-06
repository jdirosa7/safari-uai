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
            var dac = new ServiceTypeDAC();

            result = dac.Create(serviceType);
            return result;
        }

        public void Update(ServiceType serviceType)
        {
            var dac = new ServiceTypeDAC();
            dac.Update(serviceType);
        }

        public ServiceType Find(int id)
        {
            var dac = new ServiceTypeDAC();
            return dac.ReadBy(id);
        }

        public void Delete(int id)
        {
            var dac = new ServiceTypeDAC();
            dac.Delete(id);
        }

        public List<ServiceType> List()
        {
            List<ServiceType> result = default(List<ServiceType>);

            var dac = new ServiceTypeDAC();
            result = dac.Read();
            return result;
        }
    }
}
