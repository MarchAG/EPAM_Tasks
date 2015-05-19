using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hierarchy
{
    class Client
    {
        IProductA a;
        IProductB b;

        public Client(IFactory factory)
        {
            a = factory.GetProductA();
            b = factory.GetProductB();
        }
    }
}
