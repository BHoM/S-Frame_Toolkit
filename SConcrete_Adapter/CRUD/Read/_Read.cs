using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using BH.oM.Base;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.SurfaceProperties;
using BH.oM.Physical.Materials;
using BH.oM.Adapter;
using BH.oM.Adapter.SConcrete;
using System.Text.RegularExpressions;

namespace BH.Adapter.SConcrete
{
    public partial class SConcrete_Adapter
    {
        /***************************************************/
        /**** Adapter overload method                   ****/
        /***************************************************/

        protected override IEnumerable<IBHoMObject> IRead(Type type, IList ids, ActionConfig actionConfig = null)
        {
            List<IBHoMObject> objects = new List<IBHoMObject>();

            if (ids == null)
            {
                IEnumerable<string> allFiles = Directory.EnumerateFiles(m_FolderPath, "*.SCO");
                ids = allFiles.Select(x => Path.GetFileNameWithoutExtension(x)).ToList();// this ain't workin'.
            }


            foreach (object id in ids)
            {
                //find the filepath in the m_folderPath matching the string
                string filePath = GetFilePath(id as string);
                if (File.Exists(filePath))
                {
                    m_Config = ReadSConcreteConfig(filePath);

                    if (type == typeof(SConcreteModel))
                        objects.Add(ReadSConcreteModel(filePath) as IBHoMObject);
                    else if (type == typeof(Bar))
                        objects.Add(ReadBar(filePath) as IBHoMObject);
                    else if (type == typeof(ISectionProperty) || type.GetInterfaces().Contains(typeof(ISectionProperty)))
                        objects.Add(ReadSectionProperty(filePath) as IBHoMObject);
                    else if (type == typeof(ISurfaceProperty) || type.GetInterfaces().Contains(typeof(ISurfaceProperty)))
                        objects.Add(ReadSurfaceProperty(filePath) as IBHoMObject);
                    else if (type == typeof(Material) || type.GetInterfaces().Contains(typeof(Material)))
                        objects.Add(ReadMaterial(filePath) as IBHoMObject);
                }
            }

            return objects;
        }

        /***************************************************/

        private bool ReadValues(string str, ref Dictionary<string, double> values)
        {
            List<string> keys = values.Keys.ToList();
            foreach (string key in keys)
            {
                Match m = Regex.Match(str, (key + @"\t ([^\s]+)"));
                float value;
                float.TryParse(m.Groups[1].ToString(), out value);
                values[key] = value;
            }

            return true;
        }
    }
}
