/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Adapters.SConcrete
{
    public enum DesignCodes
    {
        CSA_2004 = 1,
        ACI_2005 = 2,
        BS810_1997 = 5,
        ACI_2002 = 9,
        CP65_1999 = 10,
        ACI_2008 = 12,
        EC2_2004_DFLT = 13,
        EC2_2004_UK = 14,
        ACI_2011 = 15,
        ACI_2014 = 17,
        CSA_2014 = 16
    }
    public enum S_Units
    {
        Imperial = 0,
        Metric
    }
    public enum BarType
    {
        Custom = 0,
        Canadian,
        American,
        British,
        Korean,
        Singapore
    }
    public enum MemberType
    {
        TBeam = 0,
        LBeam = 1,
        RectBeam = 2,
        RectColumn = 3,
        CircColumn = 4,
        IShapeWall = 5,
        CShapeWall = 6,
        TShapeWall = 7,
        LShapeWall = 8
    }
    public enum UnitType
    {
        Length,
        Force,
        Moment,
        Pressure,
        Density,
    }
}

