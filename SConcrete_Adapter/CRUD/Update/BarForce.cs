using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.Constraints;
using BH.oM.Structure.Results;
using System.IO;
using BH.Engine.SConcrete;

namespace BH.Adapter.SConcrete
{
    public partial class SConcrete_Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/
        
        private bool UpdateObject(BarForce barForce, string filePath)
        {
            //Code for adding additional loads to an existing file 

            m_Config = ReadSConcreteConfig(filePath);

            string[] lines = null;
            try
            {
                lines = File.ReadAllLines(filePath);
            }
            catch
            {
                Engine.Reflection.Compute.RecordError($"Could not read file {filePath}");
                return false;
            }

            StringBuilder lines_out = new StringBuilder();

            bool replace = true;
            int seek = 0;
            int i = 1;
            string startLine = @"@Object@S-CONCRETE Sectional Loads@";
            string endLine = "@EndTable@";

            foreach (string line in lines)
            {
                if (seek == 0)
                {
                    if (line == startLine)
                    {
                        lines_out.Append(line + Environment.NewLine);
                        seek = 1;
                    }
                    else
                    {
                        lines_out.Append(line + Environment.NewLine);
                    }
                }
                if (seek == 1)
                {
                    if (line.StartsWith("@Table"))
                    {
                        lines_out.Append(line + Environment.NewLine);
                    }
                    if (line.StartsWith("LC"))
                    {
                        lines_out.Append(line + Environment.NewLine);
                    }
                    else if (line.StartsWith(" ") && !replace)
                    {
                        i = int.Parse(line.Split('\t')[0].Trim()) + 1;
                        lines_out.Append(line + Environment.NewLine);
                    }
                    else if (line.StartsWith(" ") && replace)
                    {
                        //ignore any existing loads
                    }
                    else if (line == endLine)
                    {
                        lines_out.Append(barForce.ToSConcrete(i, m_Config));
                        lines_out.Append(line + Environment.NewLine);
                        seek = 0;
                    }
                }
            }

            File.WriteAllText(filePath, lines_out.ToString());

            return true;
        }

        /***************************************************/

    }
}
