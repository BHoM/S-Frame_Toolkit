using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.Adapter;
using BH.oM.Base;
using BH.oM.Common;
using BH.Engine.SConcrete;
using System.Reflection;
using System.IO;
using BH.oM.Adapter.SConcrete;
using BH.oM.Adapter;

namespace BH.Adapter.SConcrete
{
    public partial class SConcrete_Adapter : BHoMAdapter
    {

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        //Add any applicable constructors here, such as linking to a specific file or anything else as well as linking to that file through the (if existing) com link via the API

        public SConcrete_Adapter(string folderPath = "", bool Active = false)
        {
            //Initialization
            Modules.Structure.ModuleLoader.LoadModules(this);

            m_AdapterSettings.DefaultPushType = PushType.CreateOnly;

            AdapterIdName = BH.Engine.SConcrete.Convert.AdapterIdName;   //Set the "AdapterIdName" to "SoftwareName_id". Generally stored as a constant string in the convert class in the SoftwareName_Engine

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
        /**** Private Fields                            ****/
        /***************************************************/

        private string m_FolderPath = "";
        private SConcreteConfig m_Config = new SConcreteConfig();

        /***************************************************/
    }
}
