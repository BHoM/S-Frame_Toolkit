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
    public static partial class Convert
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static string ToSConcrete(this SConcreteModel model, SConcreteConfig config)
        {
            //Config Data
            int codes = (int)config.DesignCodes;
            int units = (int)config.Units;
            int bar_type = (int)config.BarType;

            //Model Data
            int memberType = (int)model.GetMemberType();
            string memberName = model.Name;
            double Luyy = model.LengthYY.ToUnit(config.Units, UnitType.Length);
            double Luzz = model.LengthZZ.ToUnit(config.Units, UnitType.Length);

            //Profile Data
            double bm_h = 0;
            double bm_b = 0;
            double bm_bf = 0;
            double bm_hf = 0;
            double cm_bcol = 0;
            double cm_hcol = 0;
            double cm_D = 0;

            switch (model.Usage)
            {
                case StructuralUsage1D.Column:
                    GetColumnProfileData(model.Section.SectionProfile as dynamic, config, ref cm_bcol, ref cm_hcol, ref cm_D); 
                    break;
                case StructuralUsage1D.Beam:
                    GetBeamProfileData(model.Section.SectionProfile as dynamic, config, ref bm_h, ref bm_b, ref bm_bf, ref bm_hf);
                    break;
                default:
                    Engine.Reflection.Compute.RecordError("Member type not implemented");
                    return "";
            }

            string data =
                $"Codes	 {codes}	Units	 {units}	Bar Type	 {bar_type}	Maximum	 1	Simple	 True	ThetaIn	 0	UtilNoReinf	 .05	ApplyImprfct	 False	ReducedSHorzMax	 False	Text10	Value10	Text11	Value11	Member Name	{memberName}	Job Number	A123.45	Member Type	 {memberType}	Member Status	 {memberType}	Initialize Reinf	 True	Report Check 1	 True	Report Check 2	 True	Report Check 3	 True	Report Check 4	 True	Report Check 5	 True	Report Check 6	 True	Report Check 7	 True	Report Check 8	 True	Report Check 9	 True	Ignore Nf	 False	Orientation	 0	ClosedBeams	 False	Closed	 True	Bm b	 {bm_b}" + Environment.NewLine
                + $"Bm h	 {bm_h}	Bm bf	 {bm_bf}	Bm hf	 {bm_hf}	Bm IgnoreFlange	 False	Bm Top	 1.5	Bm Bottom	 1.5	Bm Side	 1.5	Bm CheckCracks	 True	Bm CheckBarS	 True	Bm Dstir	 3	Bm Sstir	 8	Bm StirHook	 135	Bm StirHook1	 135	Bm ApplyStir	 True	Bm ShowStir	 True	Bm NlegsZ	 2	Bm NlegsY	 0	Bm NlegsZreqd	 0	Bm DoubleStir	 False	Bm NbmFace	 0	Bm DbmFace	 5	Bm SbmFace	 6	Bm ZbmFace	 0	Bm ApplyFace	 False	Bm ApplyFaceNvsM	 True	Bm NfaceCurtains	 2	Bm Exposure	 0	Bm CoatTop	 0	Bm CoatBot	 0	Bm Show2ndT	 True" + Environment.NewLine
                + $"Bm Show2ndB	 True	Bm SameDTop	 True	Bm SameDBot	 True	Bm dzT	 1	Bm dzB	 1	Bm ComputedzT	 True	Bm ComputedzB	 True	Bm NT(1,1)	 8	Bm NT(1,2)	 0	Bm NT(1,3)	 0	Bm NT(1,4)	 0	Bm NT(1,5)	 0	Bm NT(2,1)	 0	Bm NT(2,2)	 0	Bm NT(2,3)	 0	Bm NT(2,4)	 0	Bm NT(2,5)	 0	Bm NB(1,1)	 8	Bm NB(1,2)	 0	Bm NB(1,3)	 0	Bm NB(1,4)	 0	Bm NB(1,5)	 0	Bm NB(2,1)	 0	Bm NB(2,2)	 0	Bm NB(2,3)	 0	Bm NB(2,4)	 0	Bm NB(2,5)	 0	Bm DT(1,1)	 10	Bm DT(1,2)	 10	Bm DT(1,3)	 10" + Environment.NewLine
                + $"Bm DT(1,4)	 10	Bm DT(1,5)	 10	Bm DT(2,1)	 10	Bm DT(2,2)	 10	Bm DT(2,3)	 10	Bm DT(2,4)	 10	Bm DT(2,5)	 10	Bm DB(1,1)	 10	Bm DB(1,2)	 10	Bm DB(1,3)	 10	Bm DB(1,4)	 10	Bm DB(1,5)	 10	Bm DB(2,1)	 10	Bm DB(2,2)	 10	Bm DB(2,3)	 10	Bm DB(2,4)	 10	Bm DB(2,5)	 10	Cm bcol	 {cm_bcol}	Cm hcol	 {cm_hcol}	Cm D	 {cm_D}	Cm Cover	 1.5	Cm CoverInside	 1.5	Cm ApplyMinM	 True	Cm Do1Pcnt	 False	Cm NrClause	 4	Cm HoleType	 0	Cm bcolHole	 2	Cm hcolHole	 2	Cm DcolHole	 2	Cm ApplySteelSect	 False" + Environment.NewLine
                + $"Cm Nzcol	 5	Cm Nycol	 5	Cm Nface1	 8	Cm Nface2	 6	Cm Nface1draw	 0	Cm Nface2draw	 0	Cm DVert	 7	Cm DVert2	 7	Cm DHorz	 3	Cm DHorz2	 3	Cm NClegsZ	 2	Cm NClegsY	 2	Cm TieHook	 135	Cm CrossHook	 135	Cm NLayers	 1	Cm Apply2ndLayer	 False	Cm ApplyDiamond	 False	Cm TieReinf	 0	Cm Splice	 0	Cm dlayer	 1.5	Cm ComputeDlayer	 True	Cm Stie	 12	Cm Stie2	 8	Cm Pitch	 2	Cm Pitch2	 2	Cm SteelSectTable	 2	Cm SteelSectNo	 191	Cm SteelSectName	W14X61	Cm WWFd	 13.89	Cm WWFb	 9.995" + Environment.NewLine
                + $"Cm WWFt	 .645	Cm WWFw	 .375	Wa CoverW	 1.5	Wa CoverZ	 1.5	Wa Npanels	 0	Wa Offset	 24	Wa Symmetric	 False	Wa Rectangular	 False	Wa AddWall	 True	Wa VertOut	 False	Wa DoNomProb	 True	Wa L2	 24	Wa T2	 16	Wa L3	 30	Wa T3	 20	Slender	 False	NomStfnsSlndr	 True	CoMomDFyy	 8	CoMomDFzz	 8	CcvtrDFyy	 8	CcvtrDFzz	 8	LuYY	 {Luyy}	LuZZ	 {Luzz}	ky	 1	kz	 1	kEcIg	 .25	Bm hIncr	 2	Bm bIncr	 1	Cm hcolIncr	 2	Cm bcolIncr	 2" + Environment.NewLine
                + $"Cm Dincr	 2	Cm HoleIncr	 1	Bm bfIncr	 4	Bm hfIncr	 .5	Wa Lincr	 2	Wa Tincr	 1	fyIncr	 5	fcuIncr	 1000	Bm StirIncr	 1	Bm FaceIncr	 .5	Cm TieIncr	 1	Cm PitchIncr	 .5	Wa ZoneVertSIncr	 1	Wa ZoneTieSIncr	 1	Wa PanelSincr	 2	ScaleBarWidth	 True	fy	 60	fy2	 60	fy3	 50	Wc	 150	Ws	 490	Poisson	 .2	hagg	 .75	Gc	 2526.036	Ec	 6062.5	Es	 29000	kIe	 1	kAe	 1	kAse	 1	kJe	 1" + Environment.NewLine
                + $"MaxIter	 25	fyDesMin	 15	fyDesMax	 150	fy2DesMin	 15	fy2DesMax	 150	fy3DesMin	 15	fy3DesMax	 150	fcuDesMin	 700	fcuDesMax	 15000	Freezefy	 True	Freezefy2	 True	Freezefy3	 True	Freezefcu	 True	Bm Bmbovrh	 .7	Bm bmin	 5	Bm bmax	 400	Bm hmin	 6	Bm hmax	 400	Bm Freezeb	 False	Bm Freezeh	 False	Bm dbTopMin	 .5	Bm dbTopMax	 1.375	Bm dbBotMin	 .5	Bm dbBotMax	 1.375	Bm dbStirMin	 .5	Bm dbStirMax	 1.375	Bm dbFaceMin	 .625	Bm dbFaceMax	 1	Bm FreezeTop	 False	Bm FreezeBot	 False" + Environment.NewLine
                + $"Bm FreezeStir	 False	Bm FreezeFace	 False	Bm RhogMinT	 .004	Bm RhogMaxT	 .025	Bm RhogMinB	 .004	Bm RhogMaxB	 .025	Bm SclMaxTens	 8	Bm SclMaxComp	 8	Cm Colbovrh	 1	Cm bcolmin	 6	Cm bcolmax	 400	Cm hcolmin	 6	Cm hcolmax	 400	Cm Dcolmin	 6	Cm Dcolmax	 400	Cm FreezeDcol	 False	Cm Freezebcol	 False	Cm Freezehcol	 False	Cm FreezeSplice	 False	Cm dbVertMin	 .625	Cm dbVertMax	 1.375	Cm dbHorzMin	 .5	Cm dbHorzMax	 .75	Cm FreezeVert	 False	Cm FreezeHorz	 False	Cm RhoVmin	 2	Cm RhoVmax	 4	fcu	 10000	Quick Calc	 True	Wa EDM	 False" + Environment.NewLine
                + $"Wa Duct	 0	Wa MagVf	 False	Wa Plastic	 True	Wa EstimateG	 0	Wa MfoverMr	 25	Wa R	 1.5	Wa GammaWy	 1.3	Wa GammaWz	 1.5	Wa GammaWpy	 1.6	Wa GammaWpz	 1.7	Wa hw	 1200	Wa Zone	 1	Wa Strain	 False	Wa BZDL	 .05	Wa PhiV	 .6	Wa PhiVmode	 0	Cm AddSteelShear	 False	Cm WWFIconfig	 True	Cm ApplyWWFbeam	 False	Cm WWFbeamb	 10	Cm WWFbeamh	 10	Cm WWFbdincr	 .5	Cm WWFtwincr	 .125	Cm UseSteelTables	 True	Cm bshapemin	 4	Cm bshapemax	 100	Cm dshapemin	 4	Cm dshapemax	 100	Cm FreezeShape	 False	Wa dbPanelVertMin	 .375" + Environment.NewLine
                + $"Wa dbPanelVertMax	 1.375	Wa dbPanelHorzMin	 .375	Wa dbPanelHorzMax	 1.375	Wa FreezePanelVert	 False	Wa FreezePanelHorz	 False	Wa dbZoneVertMin	 .375	Wa dbZoneVertMax	 1.375	Wa dbZoneHorzMin	 .375	Wa dbZoneHorzMax	 1.375	Wa FreezeZoneVert	 False	Wa FreezeZoneHorz	 False	Wa FreezeZoneSplice	 False	Wa tmin1	 4	Wa tmin2	 4	Wa tmin3	 4	Wa tmin4	 4	Wa tmax1	 400	Wa tmax2	 400	Wa tmax3	 400	Wa tmax4	 400	Wa Lmin1	 30	Wa Lmin2	 30	Wa Lmin3	 30	Wa Lmin4	 30	Wa Lmax1	 400	Wa Lmax2	 400	Wa Lmax3	 400	Wa Lmax4	 400	Wa FreezeWallDim	 False	Wa L2minDes	 12" + Environment.NewLine
                + $"Wa L2maxDes	 400	Wa T2minDes	 10	Wa T2maxDes	 400	Wa L3minDes	 12	Wa L3maxDes	 400	Wa T3minDes	 12	Wa T3maxDes	 400	Wa R0	 1.3	Wa DeltaFyy	 3	Wa DeltaFzz	 3	Wa Coupled	 0	Wa DispMethod	 True	Wa MuoverMr	 25	Wa duhwYY	 .007	Wa duhwZZ	 .007	Cohesion	 75	Mew	 1	Ep	 28500	fyzVert	 60	fyzHorz	 60	fpu	 270	Bm End	 2	Cm ApplySteelSectH	 False	Cm SteelSectNoH	 191	Cm SteelSectNameH	W14X61	Cm WWFd_H	 13.89	Cm WWFb_H	 9.995	Cm WWFt_H	 .645	Cm WWFw_H	 .375	Cm OrientI	 0" + Environment.NewLine
                + $"Cm OrientH	 90	Cm OffsetdyI	 0	Cm OffsetdzI	 0	Cm OffsetdyH	 0	Cm OffsetdzH	 0	Cm WWFOffsetIncr	 1	Bm CheckCracksF	 True	kIez	 1	Cm BetaD	 .6	PhiEffY	 2	PhiEffZ	 2	Bm Applydlimit	 True	Bm FibreReinf	 False	Concrete Qty	 707.8867	Steel Qty	 52.59831	Primary Qty	 43.14641	Secondary Qty	 9.451905	Shape Qty	 0	Bm SeisOption	 0	Bm SeisLocType	 0	Cm SeisOption	 0	Cm SeisLocType	 0	Cm SeisLwYY	 240	Cm SeisLwZZ	 240	Cm SeisThetaIDyy	 .004	Cm SeisThetaIDzz	 .004	Bm BondTop	 1	Bm BondBot	 1	Bm BondSkn	 1	Bm CrkWdthLmt	 .012" + Environment.NewLine
                + $"LoadDuration	 2	CohesionC	 .2	Wa EstimateHM	 0	Wa HiModFctrYY	 1.25	Wa HiModFctrZZ	 1.25	Wa PeriodTaYY	 1	Wa PeriodTaZZ	 1	Wa PeriodTL	 .5	Wa PeriodTU	 1	Text10	Value10	Text11	Value11	Text12	Value12	Text13	Value13	Text14	Value14	Text15	Value15	Text16	Value16	Text17	Value17	Text18	Value18	Text19	Value19	Text20	Value20	Text21	Value21	Text22	Value22	Text23	Value23	Text24	Value24	Text25	Value25	Text26	Value26	Text27	Value27	Text28	Value28	Text29	Value29	Text30	Value30";

            return data;
        }

        /***************************************************/

        public static void GetBeamProfileData(RectangleProfile profile, SConcreteConfig config, ref double bm_h, ref double bm_b, ref double bm_bf, ref double bm_hf)
        {
            bm_h = profile.Height.ToUnit(config.Units, UnitType.Length);
            bm_b = profile.Width.ToUnit(config.Units, UnitType.Length);            
        }

        /***************************************************/

        public static void GetBeamProfileData(TSectionProfile profile, SConcreteConfig config, ref double bm_h, ref double bm_b, ref double bm_bf, ref double bm_hf)
        {
            bm_h  = profile.Height.ToUnit(config.Units, UnitType.Length);
            bm_b  = profile.WebThickness.ToUnit(config.Units, UnitType.Length);
            bm_bf = profile.Width.ToUnit(config.Units, UnitType.Length);
            bm_hf = profile.FlangeThickness.ToUnit(config.Units, UnitType.Length);            
        }

        /***************************************************/

        public static void GetBeamProfileData(AngleProfile profile, SConcreteConfig config, ref double bm_h, ref double bm_b, ref double bm_bf, ref double bm_hf)
        {
            bm_h  = profile.Height.ToUnit(config.Units, UnitType.Length);
            bm_b = profile.WebThickness.ToUnit(config.Units, UnitType.Length);
            bm_bf = profile.Width.ToUnit(config.Units, UnitType.Length);
            bm_hf = profile.FlangeThickness.ToUnit(config.Units, UnitType.Length);   
        }

        /***************************************************/

        public static void GetColumnProfileData(RectangleProfile profile, SConcreteConfig config, ref double cm_bcol, ref double cm_hcol, ref double cm_D)
        {
            cm_bcol = profile.Height.ToUnit(config.Units, UnitType.Length);
            cm_hcol = profile.Width.ToUnit(config.Units, UnitType.Length);            
        }

        /***************************************************/

        public static void GetColumnProfileData(CircleProfile profile, SConcreteConfig config, ref double cm_bcol, ref double cm_hcol, ref double cm_D)
        {
            cm_D = profile.Diameter.ToUnit(config.Units, UnitType.Length);            
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
    }
}
