/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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

using BH.oM.Adapters.SConcrete;
using BH.oM.Spatial.ShapeProfiles;
using System;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Adapter.SConcrete
{
    public static partial class Query
    {
        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        public static void IGetColumnProfileData(this IProfile profile, SConcreteConfig config, ref double cm_bcol, ref double cm_hcol, ref double cm_D)
        {
            try
            {
                GetColumnProfileData(profile as dynamic, config, ref cm_bcol, ref cm_hcol, ref cm_D);       
            }
            catch
            {
                return;
            }
        }

        /***************************************************/

        public static void IGetBeamProfileData(this IProfile profile, SConcreteConfig config, ref double bm_h, ref double bm_b, ref double bm_bf, ref double bm_hf)
        {
            try
            {
                GetBeamProfileData(profile as dynamic, config, ref bm_h, ref bm_b, ref bm_bf, ref bm_hf);
            }
            catch
            {
                return;
            }
        }

        /***************************************************/

        public static MemberType GetMemberType(this SConcreteModel model)
        {
            ConcreteSection section = (ConcreteSection)model.Section;

            if (model.Usage == StructuralUsage1D.Column)
            {
                if (section.SectionProfile.GetType() == typeof(RectangleProfile))
                    return MemberType.RectColumn;
                else if (section.SectionProfile.GetType() == typeof(CircleProfile))
                    return MemberType.CircColumn;
                else
                    return MemberType.RectBeam;
            }
            else
            {
                if (section.SectionProfile.GetType() == typeof(RectangleProfile))
                    return MemberType.RectBeam;
                else if (section.SectionProfile.GetType() == typeof(TSectionProfile))
                    return MemberType.TBeam;
                else if (section.SectionProfile.GetType() == typeof(AngleProfile))
                    return MemberType.LBeam;
                else
                {
                    Engine.Reflection.Compute.RecordError($"Could not get MemberType for model {model.Name}");
                    return MemberType.RectBeam;
                }
            }
        }

        /***************************************************/

        public static void GetBeamProfileData(RectangleProfile profile, SConcreteConfig config, ref double bm_h, ref double bm_b, ref double bm_bf, ref double bm_hf)
        {
            bm_h = profile.Height.ToUnit(config.Units, UnitType.Length);
            bm_b = profile.Width.ToUnit(config.Units, UnitType.Length);            
        }

        /***************************************************/

        public static void GetBeamProfileData(TSectionProfile profile, SConcreteConfig config, ref double bm_h, ref double bm_b, ref double bm_bf, ref double bm_hf)
        {
            bm_h  = profile.Height.ToUnit(config.Units, UnitType.Length);
            bm_b  = profile.WebThickness.ToUnit(config.Units, UnitType.Length);
            bm_bf = profile.Width.ToUnit(config.Units, UnitType.Length);
            bm_hf = profile.FlangeThickness.ToUnit(config.Units, UnitType.Length);            
        }

        /***************************************************/

        public static void GetBeamProfileData(AngleProfile profile, SConcreteConfig config, ref double bm_h, ref double bm_b, ref double bm_bf, ref double bm_hf)
        {
            bm_h  = profile.Height.ToUnit(config.Units, UnitType.Length);
            bm_b = profile.WebThickness.ToUnit(config.Units, UnitType.Length);
            bm_bf = profile.Width.ToUnit(config.Units, UnitType.Length);
            bm_hf = profile.FlangeThickness.ToUnit(config.Units, UnitType.Length);   
        }

        /***************************************************/

        public static void GetColumnProfileData(RectangleProfile profile, SConcreteConfig config, ref double cm_bcol, ref double cm_hcol, ref double cm_D)
        {
            cm_hcol = profile.Height.ToUnit(config.Units, UnitType.Length);
            cm_bcol = profile.Width.ToUnit(config.Units, UnitType.Length);            
        }

        /***************************************************/

        public static void GetColumnProfileData(CircleProfile profile, SConcreteConfig config, ref double cm_bcol, ref double cm_hcol, ref double cm_D)
        {
            cm_D = profile.Diameter.ToUnit(config.Units, UnitType.Length);            
        }



        /***************************************************/
    }
}




