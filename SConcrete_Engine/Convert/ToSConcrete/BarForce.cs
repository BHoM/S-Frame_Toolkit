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

using BH.oM.Structure.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Adapter.SConcrete;

namespace BH.Engine.SConcrete
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static string ToSConcrete(this BarForce barForce, int i, SConcreteConfig config)
        {

            string LC = i.ToString("F0");
            string Nf = (barForce.FX.ToUnit(config.Units, UnitType.Force)).ToString("G");
            string Tf = (barForce.MX.ToUnit(config.Units, UnitType.Moment)).ToString("G");
            string Vfz = (barForce.FZ.ToUnit(config.Units, UnitType.Force)).ToString("G");
            string Mfy = (barForce.MY.ToUnit(config.Units, UnitType.Moment)).ToString("G");
            string Cmy = " 1";
            string Vfy = (barForce.FY.ToUnit(config.Units, UnitType.Force)).ToString("G");
            string Mfz = (barForce.MZ.ToUnit(config.Units, UnitType.Moment)).ToString("G");
            string Cmz = " 1";
            string Pdistr = " 0";
            string CheckLC = " True";
            string LoadType = " 1";
            string Comment = "--";
            string AutoGen = "False";

            return $"{LC}	{Nf}	{Tf}	{Vfz}	{Mfy}	{Cmy}	{Vfy}	{Mfz}	{Cmz}	{Pdistr}	{CheckLC}	{LoadType}	{Comment}	{AutoGen}" + Environment.NewLine;
        }

        /***************************************************/

    }
}
