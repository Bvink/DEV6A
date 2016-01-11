using EntryPoint.Api.KdTree.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint.Api.KdTree.Node
{
    class KDNode
    {
        protected Coord k;
        public Object v;
        protected KDNode left, right;

        public static KDNode insert(Coord key, Object val, KDNode t, int lev, int K)
        {
            if (t == null)
            {
                t = new KDNode(key, val);
            }

            else if (key.equals(t.k))
            {
                throw (new KeyDuplicateException());
            }

            else if (key.coord[lev] > t.k.coord[lev])
            {
                t.right = insert(key, val, t.right, (lev + 1) % K, K);
            }
            else
            {
                t.left = insert(key, val, t.left, (lev + 1) % K, K);
            }

            return t;
        }


        public static void rsearch(Coord lowk, Coord uppk, KDNode t, int lev,
                  int K, List<KDNode> v)
        {

            if (t == null) return;
            if (lowk.coord[lev] <= t.k.coord[lev])
            {
                rsearch(lowk, uppk, t.left, (lev + 1) % K, K, v);
            }
            int j;
            for (j = 0; j < K && lowk.coord[j] <= t.k.coord[j] &&
                 uppk.coord[j] >= t.k.coord[j]; j++)
                ;
            if (j == K) v.Add(t);
            if (uppk.coord[lev] > t.k.coord[lev])
            {
                rsearch(lowk, uppk, t.right, (lev + 1) % K, K, v);
            }
        }

        private KDNode(Coord key, Object val)
        {
            k = key;
            v = val;
            left = null;
            right = null;
        }
    }
}
