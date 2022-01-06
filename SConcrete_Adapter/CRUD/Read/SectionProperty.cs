/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
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
using BH.Engine.Structure;
using BH.oM.Structure.SectionProperties;
using BH.oM.Adapters.SConcrete;
using BH.oM.Structure.MaterialFragments;
using System.IO;
using BH.oM.Structure.SectionProperties.Reinforcement;
using BH.Engine.Adapters.SConcrete;

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


