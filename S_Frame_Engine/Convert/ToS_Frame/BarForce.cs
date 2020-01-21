using BH.oM.Structure.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Adapter.SConcrete;

namespace BH.Engine.SConcrete
{
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static string ToSConcrete(this BarForce barForce, int i, SConcreteConfig config)
        {

            string LC = (i+1).ToString("F0");
            string Nf = (barForce.FX.ToUnit(config.Units, UnitType.Force)).ToString("G");
            string Tf = (barForce.MX.ToUnit(config.Units, UnitType.Moment)).ToString("G");
            string Vfz = (barForce.FZ.ToUnit(config.Units, UnitType.Force)).ToString("G");
            string Mfy = (barForce.MY.ToUnit(config.Units, UnitType.Moment)).ToString("G");
            string Cmy = " 1";
            string Vfy = (barForce.FY.ToUnit(config.Units, UnitType.Force)).ToString("G");
            string Mfz = (barForce.MZ.ToUnit(config.Units, UnitType.Moment)).ToString("G");
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
