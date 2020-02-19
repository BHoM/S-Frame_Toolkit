using BH.oM.Adapter.SConcrete;
using BH.oM.Geometry.ShapeProfiles;
using System;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Engine.SConcrete
{
    public static partial class Query
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static void GetColumnProfileData(this IProfile profile, SConcreteConfig config, ref double cm_bcol, ref double cm_hcol, ref double cm_D)
        {
            GetColumnProfileData(profile as dynamic, config, ref cm_bcol, ref cm_hcol, ref cm_D);
        }

        /***************************************************/

        public static void GetBeamProfileData(this IProfile profile, SConcreteConfig config, ref double bm_h, ref double bm_b, ref double bm_bf, ref double bm_hf)
        {
            GetBeamProfileData(profile as dynamic, config, ref bm_h, ref bm_b, ref bm_bf, ref bm_hf);
        }

        /***************************************************/

        public static MemberType GetMemberType(this SConcreteModel model)
        {
            ConcreteSection section = (ConcreteSection)model.Section;

            if (model.Usage == StructuralUsage1D.Column)
            {
                if (section.SectionProfile.GetType() == typeof(RectangleProfile))
                    return MemberType.RectColumn;
                else if (section.SectionProfile.GetType() == typeof(CircleProfile))
                    return MemberType.CircColumn;
                else
                    return MemberType.RectBeam;
            }
            else
            {
                if (section.SectionProfile.GetType() == typeof(RectangleProfile))
                    return MemberType.RectBeam;
                else if (section.SectionProfile.GetType() == typeof(TSectionProfile))
                    return MemberType.TBeam;
                else if (section.SectionProfile.GetType() == typeof(AngleProfile))
                    return MemberType.LBeam;
                else
                {
                    Engine.Reflection.Compute.RecordError($"Could not get MemberType for model {model.Name}");
                    return MemberType.RectBeam;
                }
            }
        }

        /***************************************************/
        /**** Private Methods                           ****/
        /***************************************************/

        private static void GetBeamProfileData(RectangleProfile profile, SConcreteConfig config, ref double bm_h, ref double bm_b, ref double bm_bf, ref double bm_hf)
        {
            bm_h = profile.Height.ToUnit(config.Units, UnitType.Length);
            bm_b = profile.Width.ToUnit(config.Units, UnitType.Length);            
        }

        /***************************************************/

        private static void GetBeamProfileData(TSectionProfile profile, SConcreteConfig config, ref double bm_h, ref double bm_b, ref double bm_bf, ref double bm_hf)
        {
            bm_h  = profile.Height.ToUnit(config.Units, UnitType.Length);
            bm_b  = profile.WebThickness.ToUnit(config.Units, UnitType.Length);
            bm_bf = profile.Width.ToUnit(config.Units, UnitType.Length);
            bm_hf = profile.FlangeThickness.ToUnit(config.Units, UnitType.Length);            
        }

        /***************************************************/

        private static void GetBeamProfileData(AngleProfile profile, SConcreteConfig config, ref double bm_h, ref double bm_b, ref double bm_bf, ref double bm_hf)
        {
            bm_h  = profile.Height.ToUnit(config.Units, UnitType.Length);
            bm_b = profile.WebThickness.ToUnit(config.Units, UnitType.Length);
            bm_bf = profile.Width.ToUnit(config.Units, UnitType.Length);
            bm_hf = profile.FlangeThickness.ToUnit(config.Units, UnitType.Length);   
        }

        /***************************************************/

        private static void GetColumnProfileData(RectangleProfile profile, SConcreteConfig config, ref double cm_bcol, ref double cm_hcol, ref double cm_D)
        {
            cm_bcol = profile.Height.ToUnit(config.Units, UnitType.Length);
            cm_hcol = profile.Width.ToUnit(config.Units, UnitType.Length);            
        }

        /***************************************************/

        private static void GetColumnProfileData(CircleProfile profile, SConcreteConfig config, ref double cm_bcol, ref double cm_hcol, ref double cm_D)
        {
            cm_D = profile.Diameter.ToUnit(config.Units, UnitType.Length);            
        }



        /***************************************************/
    }
}
