using EntryPoint.Api.KdTree.exceptions;
using EntryPoint.Api.KdTree.Node;
using EntryPoint.Api.KdTree.Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint.Api.KdTree
{
    public class KDTree
    {
        private int m_K;

        private KDNode m_root;

        private int m_count;

        public KDTree(int k)
        {
            m_K = k;
            m_root = null;
        }

        public void insert(double[] key, Object value)
        {

            if (key.Length != m_K)
            {
                throw new KeySizeException();
            }

            else try
                {
                    m_root = KDNode.insert(new Coordinate(key), value, m_root, 0, m_K);
                }

                catch (KeyDuplicateException e)
                {
                    throw e;
                }

            m_count++;
        }

        public Object[] range(double[] lowk, double[] uppk)
        {

            if (lowk.Length != uppk.Length)
            {
                throw new KeySizeException();
            }

            else if (lowk.Length != m_K)
            {
                throw new KeySizeException();
            }

            else
            {
                List<KDNode> v = new List<KDNode>();
                KDNode.rsearch(new Coordinate(lowk), new Coordinate(uppk),
                       m_root, 0, m_K, v);
                Object[] o = new Object[v.Count];
                for (int i = 0; i < v.Count; ++i)
                {
                    KDNode n = (KDNode)v[i];
                    o[i] = n.v;
                }
                return o;
            }
        }
    }

}
