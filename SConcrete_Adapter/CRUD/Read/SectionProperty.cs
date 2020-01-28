/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2019, the respective contributors. All rights reserved.
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
            ISectionProperty property = null;
            Concrete material = ReadMaterial(filePath);
            List<Reinforcement> reinforcement = ReadReinforcement(filePath);

            string name = Path.GetFileNameWithoutExtension(filePath);

            Dictionary<string, double> values = new Dictionary<string, double>() {
                { "Cm bcol", 0},
                { "Cm hcol", 0},
                { "Cm D", 0},
            };

            ReadValues(filePath, ref values);

            switch (m_Config.MemberType)
            {
                case MemberType.CircColumn:
                    property = Create.ConcreteCircularSection(values["Cm D"], material, name, reinforcement);
                    break;
                case MemberType.RectColumn:
                    property = Create.ConcreteRectangleSection(values["Cm hcol"], values["Cm bcol"], material, name, reinforcement);
                    break;
                case MemberType.LBeam:
                case MemberType.RectBeam:
                case MemberType.TBeam:
                    //Get Beam data
                    Engine.Reflection.Compute.RecordNote($"SConcrete file contains {m_Config.MemberType.ToString()}!");
                    break;
                case MemberType.CShapeWall:
                case MemberType.IShapeWall:
                case MemberType.LShapeWall:
                case MemberType.TShapeWall:
                    Engine.Reflection.Compute.RecordWarning($"SConcrete file contains {m_Config.MemberType.ToString()} section; could not convert to SectionProperty");
                    break;
                default:
                    Engine.Reflection.Compute.RecordWarning($"Pull of Member Type {m_Config.MemberType.ToString()} not implemented");
                    break;
            }

            return null;
        }

        /***************************************************/

    }
}
