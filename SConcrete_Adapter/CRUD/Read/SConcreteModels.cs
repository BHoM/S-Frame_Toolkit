using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.Constraints;
using BH.oM.Common.Materials;
using BH.oM.Adapter.SConcrete;

namespace BH.Adapter.SConcrete
{
    public partial class SConcrete_Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/

        //The List<string> in the methods below can be changed to a list of any type of identification more suitable for the toolkit
        //If no ids are provided, the convention is to return all elements of the type

        private SConcreteModel ReadSConcreteModel(string filePath = "")
        {
            SConcreteModel model = new SConcreteModel();

            model.Section = (ConcreteSection)ReadSectionProperty(filePath);
            //Tuple<double, double> length = ReadLength(filePath);
            //model.LengthXX = length.Item1;
            //model.LengthYY = length.Item2;
            //model.Forces = ReadForces(filePath);

            return model;
        }

        /***************************************************/

    }
}
