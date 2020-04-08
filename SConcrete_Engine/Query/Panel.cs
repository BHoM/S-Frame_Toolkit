/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

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
    public static partial class Query
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static MemberType GetMemberType(Panel panel)
        {
            ConstantThickness section = (ConstantThickness)panel.Property;

            return MemberType.IShapeWall;
        }

        /***************************************************/

        public static string GetWallProfileData(ConstantThickness property) //Should be re-aligned with bar creates
        {
            string memberType = MemberType.RectColumn.ToString("D");
            string memberName = property.Name;
            string height = "3000";


            string data =
                $"Codes	 17	Units	 1	Bar Type	 2	Maximum	 1	Simple	 True	ThetaIn	 0	UtilNoReinf	 .05	ApplyImprfct	 False	ReducedSHorzMax	 False	Text10	Value10	Text11	Value11	Member Name	{memberName}	Job Number	A123.45	Member Type	 2	Member Status	 2	Initialize Reinf	 True	Report Check 1	 True	Report Check 2	 True	Report Check 3	 True	Report Check 4	 True	Report Check 5	 True	Report Check 6	 True	Report Check 7	 True	Report Check 8	 True	Report Check 9	 True	Ignore Nf	 False	Orientation	 0	ClosedBeams	 True	Closed	 True	Bm b	 500" + Environment.NewLine
                + "Bm h	 600	Bm bf	 1500	Bm hf	 125	Bm IgnoreFlange	 False	Bm Top	 40	Bm Bottom	 40	Bm Side	 40	Bm CheckCracks	 True	Bm CheckBarS	 True	Bm Dstir	 3	Bm Sstir	 200	Bm StirHook	 135	Bm StirHook1	 135	Bm ApplyStir	 True	Bm ShowStir	 True	Bm NlegsZ	 2	Bm NlegsY	 2	Bm NlegsZreqd	 0	Bm DoubleStir	 False	Bm NbmFace	 4	Bm DbmFace	 4	Bm SbmFace	 180	Bm ZbmFace	 210	Bm ApplyFace	 True	Bm ApplyFaceNvsM	 True	Bm NfaceCurtains	 2	Bm Exposure	 0	Bm CoatTop	 0	Bm CoatBot	 0	Bm Show2ndT	 True" + Environment.NewLine
                + "Bm Show2ndB	 True	Bm SameDTop	 True	Bm SameDBot	 True	Bm dzT	 25.4	Bm dzB	 25.4	Bm ComputedzT	 True	Bm ComputedzB	 True	Bm NT(1,1)	 2	Bm NT(1,2)	 0	Bm NT(1,3)	 0	Bm NT(1,4)	 0	Bm NT(1,5)	 0	Bm NT(2,1)	 3	Bm NT(2,2)	 0	Bm NT(2,3)	 0	Bm NT(2,4)	 0	Bm NT(2,5)	 0	Bm NB(1,1)	 2	Bm NB(1,2)	 0	Bm NB(1,3)	 0	Bm NB(1,4)	 0	Bm NB(1,5)	 0	Bm NB(2,1)	 2	Bm NB(2,2)	 0	Bm NB(2,3)	 0	Bm NB(2,4)	 0	Bm NB(2,5)	 0	Bm DT(1,1)	 7	Bm DT(1,2)	 7	Bm DT(1,3)	 7" + Environment.NewLine
                + "Bm DT(1,4)	 7	Bm DT(1,5)	 7	Bm DT(2,1)	 7	Bm DT(2,2)	 7	Bm DT(2,3)	 7	Bm DT(2,4)	 7	Bm DT(2,5)	 7	Bm DB(1,1)	 7	Bm DB(1,2)	 7	Bm DB(1,3)	 7	Bm DB(1,4)	 7	Bm DB(1,5)	 7	Bm DB(2,1)	 7	Bm DB(2,2)	 7	Bm DB(2,3)	 7	Bm DB(2,4)	 7	Bm DB(2,5)	 7	Cm bcol	 450	Cm hcol	 550	Cm D	 600	Cm Cover	 40	Cm CoverInside	 40	Cm ApplyMinM	 True	Cm Do1Pcnt	 False	Cm NrClause	 4	Cm HoleType	 0	Cm bcolHole	 50	Cm hcolHole	 50	Cm DcolHole	 50	Cm ApplySteelSect	 False" + Environment.NewLine
                + "Cm Nzcol	 5	Cm Nycol	 5	Cm Nface1	 8	Cm Nface2	 6	Cm Nface1draw	 0	Cm Nface2draw	 0	Cm DVert	 7	Cm DVert2	 7	Cm DHorz	 3	Cm DHorz2	 3	Cm NClegsZ	 2	Cm NClegsY	 2	Cm TieHook	 135	Cm CrossHook	 135	Cm NLayers	 1	Cm Apply2ndLayer	 False	Cm ApplyDiamond	 True	Cm TieReinf	 0	Cm Splice	 0	Cm dlayer	 38.1	Cm ComputeDlayer	 True	Cm Stie	 200	Cm Stie2	 200	Cm Pitch	 50	Cm Pitch2	 50	Cm SteelSectTable	 2	Cm SteelSectNo	 191	Cm SteelSectName	W14X61	Cm WWFd	 352.806	Cm WWFb	 253.873" + Environment.NewLine
                + "Cm WWFt	 16.383	Cm WWFw	 9.525	Wa CoverW	 40	Wa CoverZ	 40	Wa Npanels	 0	Wa Offset	 600	Wa Symmetric	 False	Wa Rectangular	 True	Wa AddWall	 True	Wa VertOut	 False	Wa DoNomProb	 True	Wa L2	 75	Wa T2	 400	Wa L3	 75	Wa T3	 400	Slender	 False	NomStfnsSlndr	 True	CoMomDFyy	 8	CoMomDFzz	 8	CcvtrDFyy	 8	CcvtrDFzz	 8	LuYY	 3000	LuZZ	 3000	ky	 1	kz	 1	kEcIg	 .25	Bm hIncr	 50	Bm bIncr	 25	Cm hcolIncr	 50	Cm bcolIncr	 50" + Environment.NewLine
                + "Cm Dincr	 50	Cm HoleIncr	 25	Bm bfIncr	 100	Bm hfIncr	 10	Wa Lincr	 50	Wa Tincr	 25	fyIncr	 50	fcuIncr	 5	Bm StirIncr	 25	Bm FaceIncr	 10	Cm TieIncr	 25	Cm PitchIncr	 10	Wa ZoneVertSIncr	 25	Wa ZoneTieSIncr	 25	Wa PanelSincr	 50	ScaleBarWidth	 True	fy	 413.6854	fy2	 413.6854	fy3	 344.7379	Wc	 2402.769	Ws	 8009.229	Poisson	 .2	hagg	 19.05	Gc	 12315.26	Ec	 29556.62	Es	 199948	kIe	 1	kAe	 1	kAse	 1	kJe	 1" + Environment.NewLine
                + "MaxIter	 25	fyDesMin	 100	fyDesMax	 1000	fy2DesMin	 100	fy2DesMax	 1000	fy3DesMin	 100	fy3DesMax	 1000	fcuDesMin	 5	fcuDesMax	 100	Freezefy	 True	Freezefy2	 True	Freezefy3	 True	Freezefcu	 True	Bm Bmbovrh	 .7	Bm bmin	 125	Bm bmax	 10000	Bm hmin	 150	Bm hmax	 10000	Bm Freezeb	 False	Bm Freezeh	 False	Bm dbTopMin	 11	Bm dbTopMax	 35	Bm dbBotMin	 11	Bm dbBotMax	 35	Bm dbStirMin	 11	Bm dbStirMax	 20	Bm dbFaceMin	 16	Bm dbFaceMax	 25	Bm FreezeTop	 False	Bm FreezeBot	 False" + Environment.NewLine
                + "Bm FreezeStir	 False	Bm FreezeFace	 False	Bm RhogMinT	 .004	Bm RhogMaxT	 .025	Bm RhogMinB	 .004	Bm RhogMaxB	 .025	Bm SclMaxTens	 250	Bm SclMaxComp	 300	Cm Colbovrh	 1	Cm bcolmin	 150	Cm bcolmax	 10000	Cm hcolmin	 150	Cm hcolmax	 10000	Cm Dcolmin	 150	Cm Dcolmax	 10000	Cm FreezeDcol	 False	Cm Freezebcol	 False	Cm Freezehcol	 False	Cm FreezeSplice	 False	Cm dbVertMin	 16	Cm dbVertMax	 35	Cm dbHorzMin	 11	Cm dbHorzMax	 20	Cm FreezeVert	 False	Cm FreezeHorz	 False	Cm RhoVmin	 2	Cm RhoVmax	 4	fcu	 34.47379	Quick Calc	 True	Wa EDM	 False" + Environment.NewLine
                + $"Wa Duct	 0	Wa MagVf	 False	Wa Plastic	 True	Wa EstimateG	 0	Wa MfoverMr	 25	Wa R	 1.5	Wa GammaWy	 1.3	Wa GammaWz	 1.5	Wa GammaWpy	 1.6	Wa GammaWpz	 1.7	Wa hw	 {height}	Wa Zone	 1	Wa Strain	 False	Wa BZDL	 .05	Wa PhiV	 .6	Wa PhiVmode	 0	Cm AddSteelShear	 False	Cm WWFIconfig	 True	Cm ApplyWWFbeam	 False	Cm WWFbeamb	 254	Cm WWFbeamh	 254	Cm WWFbdincr	 10	Cm WWFtwincr	 2	Cm UseSteelTables	 True	Cm bshapemin	 100	Cm bshapemax	 2500	Cm dshapemin	 100	Cm dshapemax	 2500	Cm FreezeShape	 False	Wa dbPanelVertMin	 11" + Environment.NewLine
                + "Wa dbPanelVertMax	 35	Wa dbPanelHorzMin	 11	Wa dbPanelHorzMax	 35	Wa FreezePanelVert	 False	Wa FreezePanelHorz	 False	Wa dbZoneVertMin	 11	Wa dbZoneVertMax	 35	Wa dbZoneHorzMin	 11	Wa dbZoneHorzMax	 35	Wa FreezeZoneVert	 False	Wa FreezeZoneHorz	 False	Wa FreezeZoneSplice	 False	Wa tmin1	 100	Wa tmin2	 100	Wa tmin3	 100	Wa tmin4	 100	Wa tmax1	 10000	Wa tmax2	 10000	Wa tmax3	 10000	Wa tmax4	 10000	Wa Lmin1	 750	Wa Lmin2	 750	Wa Lmin3	 750	Wa Lmin4	 750	Wa Lmax1	 10000	Wa Lmax2	 10000	Wa Lmax3	 10000	Wa Lmax4	 10000	Wa FreezeWallDim	 False	Wa L2minDes	 300" + Environment.NewLine
                + "Wa L2maxDes	 10000	Wa T2minDes	 250	Wa T2maxDes	 10000	Wa L3minDes	 300	Wa L3maxDes	 10000	Wa T3minDes	 250	Wa T3maxDes	 10000	Wa R0	 1.3	Wa DeltaFyy	 75	Wa DeltaFzz	 75	Wa Coupled	 0	Wa DispMethod	 True	Wa MuoverMr	 25	Wa duhwYY	 .007	Wa duhwZZ	 .007	Cohesion	 .5	Mew	 1	Ep	 196500.6	fyzVert	 413.6854	fyzHorz	 413.6854	fpu	 1860	Bm End	 50	Cm ApplySteelSectH	 False	Cm SteelSectNoH	 191	Cm SteelSectNameH	W14X61	Cm WWFd_H	 352.806	Cm WWFb_H	 253.873	Cm WWFt_H	 16.383	Cm WWFw_H	 9.525	Cm OrientI	 0" + Environment.NewLine
                + "Cm OrientH	 90	Cm OffsetdyI	 0	Cm OffsetdzI	 0	Cm OffsetdyH	 0	Cm OffsetdzH	 0	Cm WWFOffsetIncr	 25	Bm CheckCracksF	 True	kIez	 1	Cm BetaD	 .6	PhiEffY	 2	PhiEffZ	 2	Bm Applydlimit	 True	Bm FibreReinf	 False	Concrete Qty	 707.8867	Steel Qty	 52.59831	Primary Qty	 43.14641	Secondary Qty	 9.451905	Shape Qty	 0	Bm SeisOption	 0	Bm SeisLocType	 0	Cm SeisOption	 0	Cm SeisLocType	 0	Cm SeisLwYY	 6000	Cm SeisLwZZ	 6000	Cm SeisThetaIDyy	 .004	Cm SeisThetaIDzz	 .004	Bm BondTop	 1	Bm BondBot	 1	Bm BondSkn	 1	Bm CrkWdthLmt	 .3" + Environment.NewLine
                + "LoadDuration	 2	CohesionC	 .2	Wa EstimateHM	 0	Wa HiModFctrYY	 1.25	Wa HiModFctrZZ	 1.25	Wa PeriodTaYY	 1	Wa PeriodTaZZ	 1	Wa PeriodTL	 .5	Wa PeriodTU	 1	Text10	Value10	Text11	Value11	Text12	Value12	Text13	Value13	Text14	Value14	Text15	Value15	Text16	Value16	Text17	Value17	Text18	Value18	Text19	Value19	Text20	Value20	Text21	Value21	Text22	Value22	Text23	Value23	Text24	Value24	Text25	Value25	Text26	Value26	Text27	Value27	Text28	Value28	Text29	Value29	Text30	Value30";

            return data;
        }

        /***************************************************/

        public static string GetSectionData(Panel panel)
        {
            ConstantThickness section = (ConstantThickness)panel.Property;
            return GetWallProfileData(section);
        }

        /***************************************************/
    }
}
