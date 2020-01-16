using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.Adapter;
using BH.oM.Base;
using BH.oM.Common;
using BH.Engine.S_Frame;
using System.Reflection;
using System.IO;
using BH.oM.Adapter.S_Frame;

namespace BH.Adapter.S_Frame
{
    public partial class S_Frame_Adapter : BHoMAdapter
    {

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        //Add any applicable constructors here, such as linking to a specific file or anything else as well as linking to that file through the (if existing) com link via the API

        public S_Frame_Adapter(string folderPath = "", bool Active = false)
        {
            //Initialization
            Modules.Structure.ModuleLoader.LoadModules(this);

            AdapterIdName = BH.Engine.S_Frame.Convert.AdapterIdName;   //Set the "AdapterIdName" to "SoftwareName_id". Generally stored as a constant string in the convert class in the SoftwareName_Engine

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
        private SConcreteConfig m_config = new SConcreteConfig();

  

        /***************************************************/
    }
}
