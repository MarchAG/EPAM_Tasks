using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hierarchy
{
    class Factory2 : IFactory
    {
        public IProductA GetProductA()
        {
            return new ProductA2();
        }

        public IProductB GetProductB()
        {
            return new ProductB2();
        }
    }
}
