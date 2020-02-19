using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SurfaceProperties;
using BH.oM.Structure.Constraints;
using BH.oM.Common.Materials;

namespace BH.Adapter.SConcrete
{
    public partial class SConcrete_Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/

        //The List<string> in the methods below can be changed to a list of any type of identification more suitable for the toolkit
        //If no ids are provided, the convention is to return all elements of the type

        private ISurfaceProperty ReadSurfaceProperty(string filePath = "")
        {
            //Tip: If the software stores depending types such as Nodes and SectionProperties in separate object tables,
            //it might be a massive preformance boost to read in and store these properties before reading in the bars 
            //and referenced these stored objects instead of reading them in each time.
            //For example, a case where 1000 bars share 5 total number of different SectionProperties you want, if possible,
            //to only read in the section properties 5 times, not 1000. This might of course vary from software to software.

            //Implement code for reading bars
            throw new NotImplementedException();
        }

        /***************************************************/

    }
}
