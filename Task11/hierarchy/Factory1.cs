using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hierarchy
{
    class Factory1 : IFactory
    {
        public IProductA GetProductA()
        {
            return new ProductA1();
        }

        public IProductB GetProductB()
        {
            return new ProductB1();
        }
    }
}
