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

using BH.Engine.Structure;
using BH.oM.Adapters.SConcrete;
using BH.oM.Geometry.ShapeProfiles;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Engine.Adapters.SConcrete
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static ConcreteSection ToConcreteSection(this SConcreteConfig config, Dictionary<string, double> values)
        {
            ConcreteSection section = null;
            //Create BHoM Sections

            // TO DO: Call constructors with the other values
            // TO DO: Check that dictionary has the keys needed
            // TO DO: Implement units scaling

            switch (config.MemberType)
            {
                case MemberType.CircColumn:
                    if (values.ContainsKey("Cm D"))
                    {
                        section = Structure.Create.ConcreteCircularSection(values["Cm D"].FromUnit(config.Units, UnitType.Length));
                    }
                    break;
                case MemberType.RectColumn:
                case MemberType.LBeam:
                case MemberType.RectBeam:
                case MemberType.TBeam:
                case MemberType.CShapeWall:
                case MemberType.IShapeWall:
                case MemberType.LShapeWall:
                case MemberType.TShapeWall:
                default:
                    Engine.Reflection.Compute.RecordWarning($"Pull of Member Type {config.MemberType.ToString()} not implemented. A dummy section has been returned.");
                    section = Structure.Create.ConcreteCircularSection(1);
                    break;
            }

            return section;
        }


        /***************************************************/
    }

}
