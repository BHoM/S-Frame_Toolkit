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
using System.Text;
using System.Threading.Tasks;
using BH.oM.Structure.Elements;
using BH.oM.Adapter.SConcrete;
using BH.Engine.SConcrete;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.Constraints;
using BH.oM.Structure.Results;
using System.IO;

namespace BH.Adapter.SConcrete
{
    public partial class SConcrete_Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/

        private bool CreateCollection(IEnumerable<ISectionProperty> sections)
        {
            //Create models based on SectionProperties

            List<SConcreteModel> models = new List<SConcreteModel>();

            foreach (ISectionProperty section in sections)
            {
                if (section.GetType() == typeof(ConcreteSection))
                {
                    ConcreteSection cSection = (ConcreteSection)section;

                    StructuralUsage1D usage = StructuralUsage1D.Beam;

                    if (cSection.SectionProfile.Shape == oM.Geometry.ShapeProfiles.ShapeType.Circle)//the only shape not supported by s-concrete beams
                    {
                        usage = StructuralUsage1D.Column;
                    }

                    SConcreteModel model = new SConcreteModel()
                    {
                        Name = cSection.Name,
                        Section = cSection,
                        Usage = usage,
                    };

                    models.Add(model);
                }
            }

            return CreateCollection(models);
        }
    }
}
