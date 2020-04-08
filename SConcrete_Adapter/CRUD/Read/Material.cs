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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Structure.MaterialFragments;
using System.IO;
using BH.Engine.SConcrete;
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

        private Concrete ReadMaterial(string filePath = "")
        {
            //Create empty section
            Concrete material = new Concrete();

            //Read file
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

            //Collect Section Property Values
            Dictionary<string, double> values = new Dictionary<string, double>() {
                { "fcu", 0},
                { "Wc", 0},
                { "Poisson", 0},
                { "Ec", 0},
            };

            ReadValues(str, ref values);

            int cylStr = (int)Math.Round(values["fcu"], 0);
            int cubeStr = (int)Math.Round(values["fcu"]/0.8, 0);

            material.Name = m_Config.Units == Units.Imperial ? $"{cylStr}psi" : $"C{cylStr}/{cubeStr}"; // default names for US/Euro concrete

            material.YoungsModulus = values["Ec"].FromUnit(m_Config.Units, UnitType.Pressure);
            material.PoissonsRatio = values["Poisson"];
            material.Density = values["Wc"].FromUnit(m_Config.Units, UnitType.Density);
            material.CylinderStrength = values["fcu"].FromUnit(m_Config.Units, UnitType.Pressure) / (m_Config.Units == Units.Imperial ? 1000 : 1);
            
            return material;
        }

        /***************************************************/

    }
}
