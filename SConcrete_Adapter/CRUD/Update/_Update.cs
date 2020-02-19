﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using BH.oM.Structure.Results;
using BH.oM.Structure.SectionProperties;
using BH.oM.Common.Materials;
using BH.oM.Base;
using BH.oM.Adapter;

namespace BH.Adapter.SConcrete
{
    public partial class SConcrete_Adapter
    {
        /***************************************************/
        /**** Adapter overload method                   ****/
        /***************************************************/

        protected override bool IUpdate<T>(IEnumerable<T> objects, ActionConfig actionConfig = null)
        {
            bool success = false;
            bool exists = false;

            foreach (IObject objectToUpdate in objects)
            {
                string filePath = GetFilePath(objectToUpdate, ref exists);
                if (exists)
                {
                    UpdateObject(objectToUpdate as dynamic, filePath);
                }
                else
                {
                    CreateObject(objectToUpdate as dynamic, filePath);
                }
                //if (typeof(T) == typeof(BarForce))
                //{
                //    BarForce barForce = (BarForce)objectToUpdate;
                //    string filePath = GetFilePath(barForce, ref exists);
                //    if (exists)
                //    {
                //        UpdateObject(barForce as dynamic, filePath);
                //    }
                //}
                //if (typeof(T) == typeof(IBHoMObject))
                //{
                //    IBHoMObject bhObject = (IBHoMObject)objectToUpdate;
                //    string filePath = GetFilePath(bhObject, ref exists);
                //    if (exists)
                //    {
                //        UpdateObject(bhObject as dynamic, filePath);
                //    }
                //    else
                //    {
                //        CreateObject(bhObject as dynamic, filePath);
                //    }
                //}
            }

            return success;
        }

        /***************************************************/
    }
}
