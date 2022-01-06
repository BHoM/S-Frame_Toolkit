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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.Results;
using BH.oM.Geometry;
using BH.oM.Adapters.SConcrete;
using BH.Engine.Structure;

namespace BH.Engine.Adapters.SConcrete.Create
{
    public static partial class Create
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static SConcreteModel SConcreteModel(this Bar bar)
        {
            SConcreteModel model = new SConcreteModel();

            String name;
            if (bar.Name != "")
                name = bar.Name;
            else
                name = bar.SectionProperty.DescriptionOrName();

            if (bar.SectionProperty.GetType() == typeof(ConcreteSection))
            {
                model.Section = (ConcreteSection)bar.SectionProperty;
                model.LengthYY = model.LengthZZ = bar.Length();
                model.Usage = bar.IsVertical() ? StructuralUsage1D.Column : StructuralUsage1D.Beam;
                model.Name = name;
            }
            else Engine.Reflection.Compute.RecordError("Bar must have a ConcreteSection");

            return model;
        }

        /***************************************************/

        public static SConcreteModel SConcreteModel(this Bar bar, List<BarForce> forces = null)
        {
            SConcreteModel model = bar.SConcreteModel();

            if (forces != null)
                model.Forces = forces;

            return model;
        }

        /***************************************************/

        public static SConcreteModel SConcreteModel(this ISectionProperty section)
        {
            if (section.GetType() != typeof(ConcreteSection))
            {
                Engine.Reflection.Compute.RecordWarning($"S-Concrete can only design ConcreteSections. {section.GetType()} has been provided");
                return null;
            }


            ConcreteSection cSection = (ConcreteSection)section;

            StructuralUsage1D usage = StructuralUsage1D.Beam;

            if (cSection.SectionProfile.Shape == oM.Spatial.ShapeProfiles.ShapeType.Circle)//the only shape not supported by s-concrete beams
            {
                usage = StructuralUsage1D.Column;
            }

            SConcreteModel model = new SConcreteModel()
            {
                Name = cSection.DescriptionOrName(),
                Section = cSection,
                Usage = usage,
            };

            return model;
        }

        /***************************************************/

        public static SConcreteModel SConcreteModel(this ISectionProperty section, List<BarForce> forces = null)
        {
            SConcreteModel model = section.SConcreteModel();

            if (forces != null)
                model.Forces = forces;

            return model;
        }

        /***************************************************/
    }
}


