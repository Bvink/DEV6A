using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint.Api.KdTree.exceptions
{
    public class KeyDuplicateException : Exception
    {
        public KeyDuplicateException()
        {
            Console.WriteLine("Key already in tree");
        }
    }
}
