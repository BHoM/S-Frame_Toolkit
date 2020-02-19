using BH.oM.Adapter.SConcrete;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SurfaceProperties;
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

        public static string ToSConcretePanelInformation(Panel panel, int i)
        {
            string l = "6000";
            string t = "400";
            string x0 = "0";
            string y0 = "3000";
            string angle = "0";
            string zonenoa = "1";
            string zonenob = "2";
            string vertd = "4";
            string horzd = "4";
            string curt = "1";
            string verts = "400";
            string horzs = "400";
            string hooka = "0";
            string hookb = "0";

            return $" {i}	 True	1	 {l}	 {t}	 {x0}    {y0}    {angle}	 {zonenoa}	 {zonenob}	 {vertd}	 {horzd}	 {curt}	 {verts}	 {horzs}	 {hooka}	 {hookb}";
        }

        /***************************************************/
    }
}
