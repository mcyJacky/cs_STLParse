using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STLStruct;
using System.IO;
using System.Text.RegularExpressions;

namespace STLReadWrite
{
    public class STLRead
    {
        Model mdl = null;
        /// <summary>
        /// read STL file
        /// </summary>
        /// <param name="stlFileName">fileName</param>
        /// <returns>model data struct</returns>
        public Model stlRead(string stlFileName)
        {
            mdl = new Model();
            
            FileStream stlFile = new FileStream(@"E:\VSFile\CS_proj\STLParse\doc\data\" + stlFileName, FileMode.Open);
            StreamReader sr = new StreamReader(stlFile);
            string line = sr.ReadLine();
            mdl.name = line;
            string patten = @"(-?\d+)(\.\d+)? (-?\d+)(\.\d+)? (-?\d+)(\.\d+)?";
            string[] strDatas;
            Match m;
            line = sr.ReadLine();
            while (line != null)
            {
                //line2
                Vertex normal = new Vertex();
                //line = sr.ReadLine();
                m = Regex.Match(line, patten);
                strDatas = m.Value.Split(' ');
                for (int i = 0; i<strDatas.Length; ++i)
                {
                    normal.points[i] = double.Parse(strDatas[i]);
                }
                //face1
                Facet facet = new Facet();
                facet.normal = normal;

                //line3
                sr.ReadLine();

                //line4
                line = sr.ReadLine();
                m = Regex.Match(line, patten);
                strDatas = m.Value.Split(' ');
                Vertex v0 = new Vertex();
                for (int i = 0; i < strDatas.Length; ++i)
                {
                    v0.points[i] = double.Parse(strDatas[i]);
                }
                facet.vertices[0] = v0;

                //line5
                line = sr.ReadLine();
                m = Regex.Match(line, patten);
                strDatas = m.Value.Split(' ');
                Vertex v1 = new Vertex();
                for (int i = 0; i < strDatas.Length; ++i)
                {
                    v1.points[i] = double.Parse(strDatas[i]);
                }
                facet.vertices[1] = v1;

                //line6
                line = sr.ReadLine();
                m = Regex.Match(line, patten);
                strDatas = m.Value.Split(' ');
                Vertex v2 = new Vertex();
                for (int i = 0; i < strDatas.Length; ++i)
                {
                    v2.points[i] = double.Parse(strDatas[i]);
                }
                facet.vertices[2] = v2;
                mdl.facets.Add(facet);
                //line7
                sr.ReadLine();
                //line8
                sr.ReadLine();

                line = sr.ReadLine();
                if (line == " endsolid")
                {
                    break;
                }
            }
            sr.Close();
            return mdl;
        }
    }
}
