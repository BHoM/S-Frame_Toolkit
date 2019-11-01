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

namespace BH.Adapter.S_Frame
{
    public partial class S_Frame_Adapter : BHoMAdapter
    {

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        //Add any applicable constructors here, such as linking to a specific file or anything else as well as linking to that file through the (if existing) com link via the API

        public S_Frame_Adapter(string m_FolderPath = "", bool Active = false)
        {
            AdapterId = BH.Engine.S_Frame.Convert.AdapterId;   //Set the "AdapterId" to "SoftwareName_id". Generally stored as a constant string in the convert class in the SoftwareName_Engine
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private void CreateFolder()
        {
            if (!Directory.Exists(m_FolderPath))
                Directory.CreateDirectory(m_FolderPath);
        }

        /***************************************************/
        /**** Private Fields                            ****/
        /***************************************************/

        private string m_FolderPath = ("C:/Users/jtaylor/OneDrive - BuroHappold/Tools in Progress/SConcrete_Toolkit");

  

        /***************************************************/
    }
}
