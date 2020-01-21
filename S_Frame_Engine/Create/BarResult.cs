using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Structure.Results;
using BH.oM.Geometry;

namespace BH.Engine.SConcrete.Create
{
    public static partial class Create
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static BarForce BarForce(string name = null, Vector f = null, Vector m = null )
        {
            BarForce result = new BarForce()
            {
                ObjectId = name,
                MX = m.X,
                MY = m.Y,
                MZ = m.Z,
                FX = f.X,
                FY = f.Y,
                FZ = f.Z,
            };

            return result;
        }

        /***************************************************/

        public static BarForce BarForce(string name = "", BarForce force = null)
        {
            force.ObjectId = name;

            return force;
        }

        /***************************************************/
    }
}
