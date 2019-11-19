using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Adapter.S_Frame
{
    public enum DesignCodes
    {
        CSA_2004 = 1,
        ACI_2005 = 2,
        BS810_1997 = 5,
        ACI_2002 = 9,
        CP65_1999 = 10,
        ACI_2008 = 12,
        EC2_2004_DFLT = 13,
        EC2_2004_UK = 14,
        ACI_2011 = 15,
        ACI_2014 = 17,
        CSA_2014 = 16
    }
    public enum Units
    {
        Imperial = 0,
        Metric
    }
    public enum BarType
    {
        Custom = 0,
        Canadian,
        American,
        British,
        Korean,
        Singapore
    }
    public enum MemberType
    {
        TBeam = 0,
        LBeam = 1,
        RectBeam = 2,
        RectColumn = 3,
        CircColumn = 4,
        IShapeWall = 5,
        CShapeWall = 6,
        TShapeWall = 7,
        LShapeWall = 8
    }
    public enum UnitType
    {
        Length,
        Force,
        Moment
    }
}
