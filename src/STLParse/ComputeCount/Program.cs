using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STLReadWrite;
using STLStruct;


namespace ComputeCount
{
    class Program
    {
        /// <summary>
        /// Read the name, num of facets, num of points in hammer.stl file
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            STLRead stlRead = new STLRead();
            Model mdl = stlRead.stlRead("hammer.stl");
            Console.WriteLine("name of model： " + mdl.name);
            Console.WriteLine("num of facets: " + mdl.facets.Count);
            Console.WriteLine("num of points: " + mdl.facets.Count * 3);

            Console.ReadKey();
        }
    }
}
