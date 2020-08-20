/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

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
using BH.oM.Geometry.ShapeProfiles;

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

            IProfile profile;

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

            try
            {
                profile = ((ConcreteSection)property).SectionProfile;
            }
            catch
            {
                Engine.Reflection.Compute.RecordError($"{property.Name} is not a ConcreteSection");
                return false;
            }

            //Profile Data
            double bm_h = 0;
            double bm_b = 0;
            double bm_bf = 0;
            double bm_hf = 0;
            double cm_bcol = 0;
            double cm_hcol = 0;
            double cm_D = 0;

            switch (m_Config.MemberType)
            {
                case MemberType.CircColumn:
                case MemberType.RectColumn:
                    profile.GetColumnProfileData(m_Config, ref cm_bcol, ref cm_hcol, ref cm_D);
                    str = cm_bcol != 0 ? ParamReplace(str, "Cm bcol", cm_bcol) : str;
                    str = cm_hcol != 0 ? ParamReplace(str, "Cm hcol", cm_hcol) : str;
                    str = cm_D != 0 ? ParamReplace(str, "Cm D", cm_D) : str;
                    break;
                case MemberType.RectBeam:
                case MemberType.LBeam:
                case MemberType.TBeam:
                    profile.GetBeamProfileData(m_Config, ref bm_h, ref bm_b, ref bm_bf, ref bm_hf);
                    str = bm_h != 0 ? ParamReplace(str, "Bm h", bm_h) : str;
                    str = bm_b != 0 ? ParamReplace(str, "Bm b", bm_b) : str;
                    str = bm_bf != 0 ? ParamReplace(str, "Bm bf", bm_bf) : str;
                    str = bm_hf != 0 ? ParamReplace(str, "Bm hf", bm_hf) : str;
                    break;
                default:
                    Engine.Reflection.Compute.RecordError("Member type not implemented");
                    return false;
            }

            File.WriteAllText(filePath, str);

            return success;
        }
    }
}
