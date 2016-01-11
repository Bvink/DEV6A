using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint.Api.KdTree.exceptions
{
    public class KeySizeException : Exception
    {
        public KeySizeException()
        {
            Console.WriteLine("Key size mismatch");
        }
    }
}
