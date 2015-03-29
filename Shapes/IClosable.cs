using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    interface IClosable
    {
        double Area { get; }
        double Perimeter { get; }
    }
}
