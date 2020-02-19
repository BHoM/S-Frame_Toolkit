using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BH.oM.Structure.Elements;
using BH.oM.Adapter.SConcrete;
using BH.Engine.SConcrete;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.Constraints;
using BH.oM.Structure.Results;
using System.IO;

namespace BH.Adapter.SConcrete
{
    public partial class SConcrete_Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/

        private bool UpdateObject(ISectionProperty property, string filePath)
        {
            bool success = true;

            m_Config = ReadSConcreteConfig(filePath);

            string str = null;

            try
            {
                str = File.ReadAllText(filePath);
            }
            catch
            {
                Engine.Reflection.Compute.RecordError($"Could not read file {filePath}");
                return false;
            }
             
            

            return success;
        }
    }
}
