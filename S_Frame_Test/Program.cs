using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;
using BH.oM.Common.Materials;
using BH.oM.Structure;
using BH.oM.Structure.Results;
using BH.oM.Structure.Elements;
using BH.Adapter;
using BH.Adapter.S_Frame;
using BH.oM.Structure.Properties.Section;
using BH.oM.Structure.Properties.Section.ShapeProfiles;
using BH.Engine.Structure;

namespace S_Frame_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "SAMPLE - CircCol";

            Console.WriteLine("Creating the bar");
            List<Bar> bars = new List<Bar>();
            bars.Add(CreateBar(name));

            Console.WriteLine("Creating the bar force");
            List<BarForce> barForces = new List<BarForce>();
            barForces.Add(CreateForce(name));

            Console.WriteLine("Creating the adapter");
            S_Frame_Adapter app = new S_Frame_Adapter("C:/Users/jtaylor/OneDrive - BuroHappold/Tools in Progress/SConcrete_Toolkit", true);

            Console.WriteLine("Pushing");
            //app.Push(bars, "");
            app.Push(barForces, "");

            Console.WriteLine("Finished Pushing. Press any key to exit");
            Console.ReadKey();
        }

        private static BarForce CreateForce(string name)
        {
            BarForce bf = new BarForce();
            bf.ObjectId = name;
            bf.FX = 1;
            bf.FY = 2;
            bf.FZ = 3;
            bf.MX = 4;
            bf.MY = 5;
            bf.MZ = 6;
            Console.WriteLine("the bar is called \"" + bf.ObjectId + "\"");
            return bf;
        }

        private static Bar CreateBar(String name)
        {
            Material concrete = BH.Engine.Common.Create.Material("Concrete", MaterialType.Concrete, 1000, 0.3, 0.00012, 400);
            ISectionProperty section = BH.Engine.Structure.Create.ConcreteRectangleSection(0.9, 0.9, concrete, "mySection");

            Bar bar = new Bar();
            bar.Name = name;
            bar.StartNode = new Node() { Coordinates = new BH.oM.Geometry.CoordinateSystem.Cartesian() { Origin = new BH.oM.Geometry.Point() { X = 0, Y = 0, Z = 0 } } };
            bar.EndNode = new Node() { Coordinates = new BH.oM.Geometry.CoordinateSystem.Cartesian() { Origin = new BH.oM.Geometry.Point() { X = 0, Y = 0, Z = 10 } } };
            bar.SectionProperty = section;

            Console.WriteLine("the bar is called \"" + bar.Name + "\"");
            return bar;
        }
    }
}
