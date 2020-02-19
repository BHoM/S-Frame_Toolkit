using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;
using BH.oM.Common.Materials;
using BH.Engine.Structure;
using BH.oM.Structure.SectionProperties;
using BH.oM.Adapter.SConcrete;
using BH.oM.Structure.MaterialFragments;
using System.IO;
using BH.oM.Structure.SectionProperties.Reinforcement;
using BH.Engine.SConcrete;

namespace BH.Adapter.SConcrete
{
    public partial class SConcrete_Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/

        //The List<string> in the methods below can be changed to a list of any type of identification more suitable for the toolkit
        //If no ids are provided, the convention is to return all elements of the type

        private ISectionProperty ReadSectionProperty(string filePath = "")
        {
            //Create empty section
            ConcreteSection property = null;

            string str = "";

            //check that id is a real file
            if (File.Exists(filePath))
            {
                //read the file into memory
                str = File.ReadAllText(filePath);
            }
            else
            {
                Engine.Reflection.Compute.RecordError("Could not read file");
                return null;
            }

            //Gather pre-requisites
            Concrete material = ReadMaterial(filePath);
            //List<Reinforcement> reinforcement = ReadReinforcement(filePath);

            //Collect Section Property Values
            Dictionary<string, double> values = new Dictionary<string, double>() {
                { "Cm bcol", 0},
                { "Cm hcol", 0},
                { "Cm D", 0},
                { "Bm h", 0},
                { "Bm b", 0},
                { "Bm bf", 0},
                { "Bm D", 0}, //TO DO: Add the rest of the dimension values
            };

            ReadValues(str, ref values);

            property = m_Config.ToConcreteSection(values);

            //property.Name = Path.GetFileNameWithoutExtension(filePath).ToString();

            //property.AddReinforcement(reinforcement);
            property.Material = material;

            return property;
        }

        /***************************************************/

    }
}
