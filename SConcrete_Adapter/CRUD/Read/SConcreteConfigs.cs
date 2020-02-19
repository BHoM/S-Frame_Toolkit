using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
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

        private SConcreteConfig ReadSConcreteConfig(string filePath = "")
        {
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

            //search the file for each property of config

            //DesignCodes designCode = new DesignCodes();
            //BarType barType = new BarType();
            //MemberType memberType = new MemberType();
            //Units units = new Units();

            Dictionary<string, double> values = new Dictionary<string, double>() {
                { "Codes", 0},
                { "Bar Type", 0},
                { "Member Type", 0},
                { "Units", 0},
            };

            ReadValues(str, ref values);

            //make a config
            SConcreteConfig config = new SConcreteConfig()
            {
                DesignCodes = (DesignCodes)values["Codes"],
                BarType = (BarType)values["Bar Type"],
                MemberType = (MemberType)values["Member Type"],
                Units = (Units)values["Units"],
            };

            return config;
        }

        /***************************************************/

    }
}
