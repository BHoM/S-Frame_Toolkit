using BH.Engine.Structure;
using BH.oM.Adapter.SConcrete;
using BH.oM.Geometry.ShapeProfiles;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Engine.SConcrete
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static ConcreteSection SectionToBHoM(this SConcreteConfig config, Dictionary<string, double> values)
        {
            ConcreteSection section = null;
            //Create BHoM Sections

            // TO DO: Call constructors with the other values
            // TO DO: Check that dictionary has the keys needed
            // TO DO: Implement units scaling

            switch (config.MemberType)
            {
                case MemberType.CircColumn:
                    if (values.ContainsKey("Cm D"))
                    {
                        section = Structure.Create.ConcreteCircularSection(values["Cm D"].FromUnit(config.Units, UnitType.Length));
                    }
                    break;
                case MemberType.RectColumn:
                case MemberType.LBeam:
                case MemberType.RectBeam:
                case MemberType.TBeam:
                case MemberType.CShapeWall:
                case MemberType.IShapeWall:
                case MemberType.LShapeWall:
                case MemberType.TShapeWall:
                default:
                    Engine.Reflection.Compute.RecordWarning($"Pull of Member Type {config.MemberType.ToString()} not implemented. A dummy section has been returned.");
                    section = Structure.Create.ConcreteCircularSection(1);
                    break;
            }

            return section;
        }


        /***************************************************/
    }

}
