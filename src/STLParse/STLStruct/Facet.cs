using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STLStruct
{
    public class Facet
    {
        //normal vector
        public Vertex normal;

        //three point
        public Vertex[] vertices = new Vertex[3];
    }
}
