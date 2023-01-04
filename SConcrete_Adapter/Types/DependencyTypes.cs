/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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

using BH.Engine.Base.Objects;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SurfaceProperties;
using BH.oM.Structure.Constraints;
using BH.oM.Structure.Results;
using System;
using System.Collections.Generic;

namespace BH.Adapter.SConcrete
{
    public partial class SConcrete_Adapter
    {
        /***************************************************/
        /**** Protected Methods                         ****/
        /***************************************************/


        protected void SetupDependencies()
        {
            DependencyTypes = new Dictionary<Type, List<Type>>
            {
                {typeof(MeshResult), new List<Type> { typeof(Panel) } },
                {typeof(BarResult), new List<Type> { typeof(Bar) } }
            };
        }
        
        /***************************************************/
    }
}



