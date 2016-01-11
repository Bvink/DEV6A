using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint.Api.KdTree.Node
{
    class HPoint
    {
        public double[] coord;

        public HPoint(double[] x)
        {
            coord = new double[x.Length];
            for (int i = 0; i < x.Length; ++i) coord[i] = x[i];
        }

        public bool equals(HPoint p)
        {

            for (int i = 0; i < coord.Length; ++i)
                if (coord[i] != p.coord[i])
                    return false;

            return true;
        }

    }

}
