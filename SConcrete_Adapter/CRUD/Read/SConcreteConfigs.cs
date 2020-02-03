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
