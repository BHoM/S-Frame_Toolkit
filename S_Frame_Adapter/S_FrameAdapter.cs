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

            Config.SeparateProperties = false;   //Set to true to push dependant properties of objects before the main objects are being pushed. Example: push nodes before pushing bars
            Config.MergeWithComparer = false;    //Set to true to use EqualityComparers to merge objects. Example: merge nodes in the same location
            Config.ProcessInMemory = false;     //Set to false to to update objects in the toolkit during the push
            Config.CloneBeforePush = false;      //Set to true to clone the objects before they are being pushed through the software. Required if any modifications at all, as adding a software ID is done to the objects
            Config.UseAdapterId = false;         //Tag objects with a software specific id in the CustomData. Requires the NextIndex method to be overridden and implemented
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
        /**** Overrides                                 ****/
        /***************************************************/

        public override List<IObject> Push(IEnumerable<IObject> objects, string tag = "", Dictionary<string, object> config = null)
        {
            bool success = true;

            string pushType;

            object ptObj;
            if (config != null && config.TryGetValue("PushType", out ptObj))
                pushType = ptObj.ToString();
            else
                pushType = "Replace";

            List<IObject> objectsToPush = Config.CloneBeforePush ? objects.Select(x => x is BHoMObject ? ((BHoMObject)x).GetShallowClone() : x).ToList() : objects.ToList(); //ToList() necessary for the return collection to function properly for cloned objects

            Type iBHoMObjectType = typeof(IBHoMObject);
            Type iResultType = typeof(IResult);
            MethodInfo miToList = typeof(Enumerable).GetMethod("Cast");
            foreach (var typeGroup in objectsToPush.GroupBy(x => x.GetType()))
            {
                MethodInfo miListObject = miToList.MakeGenericMethod(new[] { typeGroup.Key });

                var list = miListObject.Invoke(typeGroup, new object[] { typeGroup });

                if (iBHoMObjectType.IsAssignableFrom(typeGroup.Key))
                {
                    if (pushType == "Replace")
                        success &= Replace(list as dynamic, tag);
                    else if (pushType == "UpdateOnly")
                    {
                        success &= UpdateOnly(list as dynamic, tag);
                    }
                }
                else if (iResultType.IsAssignableFrom(typeGroup.Key))
                {
                    success &= Create(list as dynamic);
                }
            }

            return success ? objectsToPush : new List<IObject>();
        }

        /***************************************************/
    }
}
