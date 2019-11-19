﻿using BH.Engine.Structure;
using BH.oM.Adapter.S_Frame;
using BH.oM.Geometry.ShapeProfiles;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Engine.S_Frame
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static MemberType GetMemberType(this ConcreteSection section)
        {
            switch (section.SectionProfile.Shape)
            {
                case ShapeType.Angle:
                    return MemberType.LBeam;
                case ShapeType.Circle:
                    return MemberType.CircColumn;
                case ShapeType.Rectangle:
                    return MemberType.RectBeam;
                case ShapeType.Tee:
                    return MemberType.TBeam;
                default:
                    return MemberType.RectBeam;
            }

        }

        /***************************************************/
    }
}
