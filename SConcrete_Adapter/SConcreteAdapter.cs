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
using BH.Adapter;
using BH.oM.Base;
using System.IO;
using BH.oM.Adapters.SConcrete;
using BH.oM.Adapter;
using BH.Engine.Structure;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.Results;

namespace BH.Adapter.SConcrete
{
    public partial class SConcrete_Adapter : BHoMAdapter
    {

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        //Add any applicable constructors here, such as linking to a specific file or anything else as well as linking to that file through the (if existing) com link via the API

        public SConcrete_Adapter(string folderPath = "")
        {
            //Initialization
            Modules.Structure.ModuleLoader.LoadModules(this);
            SetupComparers();
            SetupDependencies();
            m_AdapterSettings.DefaultPushType = PushType.UpdateOnly;

            AdapterIdName = Convert.AdapterIdName;   //Set the "AdapterIdName" to "SoftwareName_id". Generally stored as a constant string in the convert class in the SoftwareName_Engine

             m_FolderPath = CreateFolder(folderPath);
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private string CreateFolder(string folderPath)
        {

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            return folderPath;
            
        }

        /***************************************************/

        private string GetFilePath(object item, ref bool exists)
        {
            string filePath = "";
            
            if (item.GetType() == typeof(BarForce))
            {
                filePath = Path.Combine(paths: new string[] { m_FolderPath, ((item as BarForce).ObjectId.ToString() + ".SCO") });
                exists = File.Exists(filePath);
                return filePath;
            }

            if (item.GetType() == typeof(Bar))
            {
                Bar bar = item as Bar;

                String name;
                if (bar.Name != "")
                    name = bar.Name;
                else
                    name = bar.SectionProperty.DescriptionOrName();

                filePath = Path.Combine(paths: new string[] { m_FolderPath, (name + ".SCO") });
                exists = File.Exists(filePath);
                return filePath;
            }

            if (typeof(ISectionProperty).IsAssignableFrom(item.GetType()))
            {
                string name = (item as ISectionProperty).DescriptionOrName();

                filePath = Path.Combine(paths: new string[] { m_FolderPath, (name + ".SCO") });
                exists = File.Exists(filePath);
                return filePath;
            }

            if (typeof(IBHoMObject).IsAssignableFrom(item.GetType()))
            {
                filePath = Path.Combine(paths: new string[] { m_FolderPath, ((item as IBHoMObject).Name.ToString() + ".SCO") });
                exists = File.Exists(filePath);
                return filePath;
            }

            exists = false;
            Engine.Reflection.Compute.RecordError("Could not create S-Concrete file; object or filename is invalid.");
            return filePath;
        }
        /***************************************************/

        private string GetFilePath(string id)
        {
            string filePath = "";

            filePath = Path.Combine(paths: new string[] { m_FolderPath, (id + ".SCO") });

            return filePath;
        }

        /***************************************************/
        /**** Private Fields                            ****/
        /***************************************************/

        private string m_FolderPath = "";
        private SConcreteConfig m_Config = new SConcreteConfig();

        /***************************************************/
    }
}


