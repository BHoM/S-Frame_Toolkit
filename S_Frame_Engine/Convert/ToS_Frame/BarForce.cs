using BH.oM.Structure.Results;
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

        public static string ToS_Frame(this BarForce barForce, int i)
        {
            string LC = i.ToString(" 0; 0; 0");
            string Nf = (barForce.FX / 1000).ToString(" 0; 0; 0");
            string Tf = (barForce.MX / 1000).ToString(" 0; 0; 0");
            string Vfz = (barForce.FZ / 1000).ToString(" 0; 0; 0");
            string Mfy = (barForce.MY / 1000).ToString(" 0; 0; 0");
            string Cmy = " 1";
            string Vfy = (barForce.FY / 1000).ToString(" 0; 0; 0");
            string Mfz = (barForce.MZ / 1000).ToString(" 0; 0; 0");
            string Cmz = " 1";
            string Pdistr = " 0";
            string CheckLC = " True";
            string LoadType = " 1";
            string Comment = "--";
            string AutoGen = "False";

            return $"{LC}	{Nf}	{Tf}	{Vfz}	{Mfy}	{Cmy}	{Vfy}	{Mfz}	{Cmz}	{Pdistr}	{CheckLC}	{LoadType}	{Comment}	{AutoGen}" + Environment.NewLine;
        }

        /***************************************************/

    }
}
