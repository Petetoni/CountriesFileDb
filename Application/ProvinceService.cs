using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ProvinceService
    {
        public Province CreateProvince(string name)
        {
            return new Province() { Name = name };
        }
    }
}
