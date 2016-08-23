using System;
using System.Text;

namespace Quezacotl
{
    class InitWorker
    {
        #region Declarations

        public static byte[] Init;
        public static byte[] BackupInit;

        public static int GfDataOffset = -1;
        public static int OffsetToGfSelected = -1;

        public static int CharactersDataOffset = -1;
        public static int OffsetToCharactersSelected = -1;

        public static int MiscDataOffset = -1;
        public static int OffsetToMiscSelected = -1;

        public static GfData GetSelectedGfData;
        public static CharactersData GetSelectedCharactersData;

        static string[] _charstable;
        private static readonly string Chartable =
        @" , ,1,2,3,4,5,6,7,8,9,%,/,:,!,?,…,+,-,=,*,&,「,」,(,),·,.,,,~,“,”,‘,#,$,',_,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,À,Á,Â,Ä,Ç,È,É,Ê,Ë,Ì,Í,Î,Ï,Ñ,Ò,Ó,Ô,Ö,Ù,Ú,Û,Ü,Œ,ß,à,á,â,ä,ç,è,é,ê,ë,ì,í,î,ï,ñ,ò";


        public struct GfData
        {
            public string Name;
            public UInt32 Exp;
            public byte Unknown1;
            public byte Available;
            public UInt16 CurrentHp;
            public byte LearnedAbility1;
            public byte LearnedAbility2;
            public byte LearnedAbility3;
            public byte LearnedAbility4;
            public byte LearnedAbility5;
            public byte LearnedAbility6;
            public byte LearnedAbility7;
            public byte LearnedAbility8;
            public byte LearnedAbility9;
            public byte LearnedAbility10;
            public byte LearnedAbility11;
            public byte LearnedAbility12;
            public byte LearnedAbility13;
            public byte LearnedAbility14;
            public byte LearnedAbility15;
            public byte LearnedAbility16;
            public byte ApAbility1;
            public byte ApAbility2;
            public byte ApAbility3;
            public byte ApAbility4;
            public byte ApAbility5;
            public byte ApAbility6;
            public byte ApAbility7;
            public byte ApAbility8;
            public byte ApAbility9;
            public byte ApAbility10;
            public byte ApAbility11;
            public byte ApAbility12;
            public byte ApAbility13;
            public byte ApAbility14;
            public byte ApAbility15;
            public byte ApAbility16;
            public byte ApAbility17;
            public byte ApAbility18;
            public byte ApAbility19;
            public byte ApAbility20;
            public byte ApAbility21;
            public byte ApAbility22;
            public UInt16 Kills;
            public UInt16 KOs;
            public byte LearningAbility;
            public byte ForgottenAbilities;
        }

        public struct CharactersData
        {
            public UInt16 CurrentHp;
            public UInt16 MaxHp;
            public UInt32 Exp;
            public byte ModelId;
            public byte WeaponId;
            public byte Str;
            public byte Vit;
            public byte Mag;
            public byte Spr;
            public byte Spd;
            public byte Luck;
            public UInt16 Magic1;
            public UInt16 Magic2;
            public UInt16 Magic3;
            public UInt16 Magic4;
            public UInt16 Magic5;
            public UInt16 Magic6;
            public UInt16 Magic7;
            public UInt16 Magic8;
            public UInt16 Magic9;
            public UInt16 Magic10;
            public UInt16 Magic11;
            public UInt16 Magic12;
            public UInt16 Magic13;
            public UInt16 Magic14;
            public UInt16 Magic15;
            public UInt16 Magic16;
            public UInt16 Magic17;
            public UInt16 Magic18;
            public UInt16 Magic19;
            public UInt16 Magic20;
            public UInt16 Magic21;
            public UInt16 Magic22;
            public UInt16 Magic23;
            public UInt16 Magic24;
            public UInt16 Magic25;
            public UInt16 Magic26;
            public UInt16 Magic27;
            public UInt16 Magic28;
            public UInt16 Magic29;
            public UInt16 Magic30;
            public UInt16 Magic31;
            public UInt16 Magic32;
            public byte Command1;
            public byte Command2;
            public byte Command3;
            public byte Unknown1;
            public byte Ability1;
            public byte Ability2;
            public byte Ability3;
            public byte Ability4;
            public byte JunGf1;
            public byte JunGf2;
            public byte Unknown2;
            public byte AltModel;
            public byte JunHP;
            public byte JunStr;
            public byte JunVit;
            public byte JunMag;
            public byte JunSpr;
            public byte JunSpd;
            public byte JunEva;
            public byte JunHit;
            public byte JunLuck;
            public byte JunEleAtk;
            public byte JunStatusAtk;
            public byte JunEleDef1;
            public byte JunEleDef2;
            public byte JunEleDef3;
            public byte JunEleDef4;
            public byte JunStatusDef1;
            public byte JunStatusDef2;
            public byte JunStatusDef3;
            public byte JunStatusDef4;
            public byte Unknown3;
            public UInt16 GfComp1;
            public UInt16 GfComp2;
            public UInt16 GfComp3;
            public UInt16 GfComp4;
            public UInt16 GfComp5;
            public UInt16 GfComp6;
            public UInt16 GfComp7;
            public UInt16 GfComp8;
            public UInt16 GfComp9;
            public UInt16 GfComp10;
            public UInt16 GfComp11;
            public UInt16 GfComp12;
            public UInt16 GfComp13;
            public UInt16 GfComp14;
            public UInt16 GfComp15;
            public UInt16 GfComp16;
            public UInt16 Kills;
            public UInt16 KOs;
            public byte Exist;
            public byte Unknown4;
            public byte CurrentStatus;
            public byte Unknown5;
        }

        public struct MiscData
        {

        }
        #endregion

        #region Multiple bytes stuff

        /// <summary>
        /// This is for Exp
        /// </summary>
        /// <param name="a"></param>
        /// <param name="add"></param>
        private static void ExpToInit(uint a, int add, byte mode)
        {
            byte[] expBytes = BitConverter.GetBytes(a);
            switch (mode)
            {
                case (byte)Mode.Mode_GF:
                    Array.Copy(expBytes, 0, Init, OffsetToGfSelected + add, 4);
                    break;
                case (byte)Mode.Mode_Characters:
                    Array.Copy(expBytes, 0, Init, OffsetToCharactersSelected + add, 4);
                    break;

                default:
                    return;
            }
        }

        /// <summary>
        /// This is for Current Hp
        /// </summary>
        /// <param name="a"></param>
        /// <param name="add"></param>
        private static void CurrentHpToInit(uint a, int add, byte mode)
        {
            byte[] hpBytes = BitConverter.GetBytes(a);
            switch (mode)
            {
                case (byte)Mode.Mode_GF:
                    Array.Copy(hpBytes, 0, Init, OffsetToGfSelected + add, 2);
                    break;
                case (byte)Mode.Mode_Characters:
                    Array.Copy(hpBytes, 0, Init, OffsetToCharactersSelected + add, 2);
                    break;

                default:
                    return;
            }
        }

        /// <summary>
        /// This is for Kills
        /// </summary>
        /// <param name="a"></param>
        /// <param name="add"></param>
        private static void KillsToInit(uint a, int add, byte mode)
        {
            byte[] killsBytes = BitConverter.GetBytes(a);
            switch (mode)
            {
                case (byte)Mode.Mode_GF:
                    Array.Copy(killsBytes, 0, Init, OffsetToGfSelected + add, 2);
                    break;
                case (byte)Mode.Mode_Characters:
                    Array.Copy(killsBytes, 0, Init, OffsetToCharactersSelected + add, 2);
                    break;

                default:
                    return;
            }
        }

        /// <summary>
        /// This is for KOs
        /// </summary>
        /// <param name="a"></param>
        /// <param name="add"></param>
        private static void KOsToInit(uint a, int add, byte mode)
        {
            byte[] koBytes = BitConverter.GetBytes(a);
            switch (mode)
            {
                case (byte)Mode.Mode_GF:
                    Array.Copy(koBytes, 0, Init, OffsetToGfSelected + add, 2);
                    break;
                case (byte)Mode.Mode_Characters:
                    Array.Copy(koBytes, 0, Init, OffsetToCharactersSelected + add, 2);
                    break;

                default:
                    return;
            }
        }

        /// <summary>
        /// This is for Max Hp
        /// </summary>
        /// <param name="a"></param>
        /// <param name="add"></param>
        private static void MaxHpToInit(uint a, int add, byte mode)
        {
            byte[] hpBytes = BitConverter.GetBytes(a);
            switch (mode)
            {
                case (byte)Mode.Mode_Characters:
                    Array.Copy(hpBytes, 0, Init, OffsetToCharactersSelected + add, 2);
                    break;

                default:
                    return;
            }
        }

        /// <summary>
        /// This is for Magic
        /// </summary>
        /// <param name="a"></param>
        /// <param name="add"></param>
        private static void MagicToInit(uint a, int add, byte mode)
        {
            byte[] magicBytes = BitConverter.GetBytes(a);
            switch (mode)
            {
                case (byte)Mode.Mode_Characters:
                    Array.Copy(magicBytes, 0, Init, OffsetToCharactersSelected + add, 2);
                    break;

                default:
                    return;
            }
        }

        /// <summary>
        /// This is for GF Compatibility
        /// </summary>
        /// <param name="a"></param>
        /// <param name="add"></param>
        private static void GfCompToInit(uint a, int add, byte mode)
        {
            byte[] compBytes = BitConverter.GetBytes(a);
            switch (mode)
            {
                case (byte)Mode.Mode_Characters:
                    Array.Copy(compBytes, 0, Init, OffsetToCharactersSelected + add, 2);
                    break;

                default:
                    return;
            }
        }

        /// <summary>
        /// This is for GF Compatibility
        /// </summary>
        /// <param name="a"></param>
        /// <param name="add"></param>
        private static void GfNameToInit(uint a, int add, byte mode)
        {
            byte[] nameBytes = BitConverter.GetBytes(a);
            switch (mode)
            {
                case (byte)Mode.Mode_GF:
                    Array.Copy(nameBytes, 0, Init, OffsetToCharactersSelected + add, 12);
                    break;

                default:
                    return;
            }
        }

        enum Mode : byte
        {
            Mode_GF,
            Mode_Characters
        }

        #endregion

        #region Write GF Variables

        public static void UpdateVariable_GF(int index, object variable)
        {
            if (!Form1._loaded || Init == null)
                return;
            switch (index)
            {
                case 0:
                    //GfNameToInit(Convert.ToUInt32(variable), 0, (byte)Mode.Mode_GF); //GF Name
                    return;
                case 1:
                    ExpToInit(Convert.ToUInt32(variable), 12, (byte)Mode.Mode_GF); //Exp
                    return;
                case 2:
                    Init[OffsetToGfSelected + 16] = Convert.ToByte(variable); //Unknown 1
                    return;
                case 3:
                    Init[OffsetToGfSelected + 17] = Convert.ToByte(variable); //Available
                    return;
                case 4:
                    CurrentHpToInit(Convert.ToUInt32(variable), 18, (byte)Mode.Mode_GF); //Current Hp
                    return;
                case 5:
                    Init[OffsetToGfSelected + 20] = (byte)(Init[OffsetToGfSelected + 20] ^ Convert.ToByte(variable)); //Ability 1
                    return;
                case 6:
                    Init[OffsetToGfSelected + 21] = (byte)(Init[OffsetToGfSelected + 21] ^ Convert.ToByte(variable)); //Ability 2
                    return;
                case 7:
                    Init[OffsetToGfSelected + 22] = (byte)(Init[OffsetToGfSelected + 22] ^ Convert.ToByte(variable)); //Ability 3
                    return;
                case 8:
                    Init[OffsetToGfSelected + 23] = (byte)(Init[OffsetToGfSelected + 23] ^ Convert.ToByte(variable)); //Ability 4
                    return;
                case 9:
                    Init[OffsetToGfSelected + 24] = (byte)(Init[OffsetToGfSelected + 24] ^ Convert.ToByte(variable)); //Ability 5
                    return;
                case 10:
                    Init[OffsetToGfSelected + 25] = (byte)(Init[OffsetToGfSelected + 25] ^ Convert.ToByte(variable)); //Ability 6
                    return;
                case 11:
                    Init[OffsetToGfSelected + 26] = (byte)(Init[OffsetToGfSelected + 26] ^ Convert.ToByte(variable)); //Ability 7
                    return;
                case 12:
                    Init[OffsetToGfSelected + 27] = (byte)(Init[OffsetToGfSelected + 27] ^ Convert.ToByte(variable)); //Ability 8
                    return;
                case 13:
                    Init[OffsetToGfSelected + 28] = (byte)(Init[OffsetToGfSelected + 28] ^ Convert.ToByte(variable)); //Ability 9
                    return;
                case 14:
                    Init[OffsetToGfSelected + 29] = (byte)(Init[OffsetToGfSelected + 29] ^ Convert.ToByte(variable)); //Ability 10
                    return;
                case 15:
                    Init[OffsetToGfSelected + 30] = (byte)(Init[OffsetToGfSelected + 30] ^ Convert.ToByte(variable)); //Ability 11
                    return;
                case 16:
                    Init[OffsetToGfSelected + 31] = (byte)(Init[OffsetToGfSelected + 31] ^ Convert.ToByte(variable)); //Ability 12
                    return;
                case 17:
                    Init[OffsetToGfSelected + 32] = (byte)(Init[OffsetToGfSelected + 32] ^ Convert.ToByte(variable)); //Ability 13
                    return;
                case 18:
                    Init[OffsetToGfSelected + 33] = (byte)(Init[OffsetToGfSelected + 33] ^ Convert.ToByte(variable)); //Ability 14
                    return;
                case 19:
                    Init[OffsetToGfSelected + 34] = (byte)(Init[OffsetToGfSelected + 34] ^ Convert.ToByte(variable)); //Ability 15
                    return;
                case 20:
                    Init[OffsetToGfSelected + 35] = (byte)(Init[OffsetToGfSelected + 35] ^ Convert.ToByte(variable)); //Ability 16
                    return;
                case 21:
                    Init[OffsetToGfSelected + 36] = Convert.ToByte(variable); //Ap Ability 1
                    return;
                case 22:
                    Init[OffsetToGfSelected + 37] = Convert.ToByte(variable); //Ap Ability 2
                    return;
                case 23:
                    Init[OffsetToGfSelected + 38] = Convert.ToByte(variable); //Ap Ability 3
                    return;
                case 24:
                    Init[OffsetToGfSelected + 39] = Convert.ToByte(variable); //Ap Ability 4
                    return;
                case 25:
                    Init[OffsetToGfSelected + 40] = Convert.ToByte(variable); //Ap Ability 5
                    return;
                case 26:
                    Init[OffsetToGfSelected + 41] = Convert.ToByte(variable); //Ap Ability 6
                    return;
                case 27:
                    Init[OffsetToGfSelected + 42] = Convert.ToByte(variable); //Ap Ability 7
                    return;
                case 28:
                    Init[OffsetToGfSelected + 43] = Convert.ToByte(variable); //Ap Ability 8
                    return;
                case 29:
                    Init[OffsetToGfSelected + 44] = Convert.ToByte(variable); //Ap Ability 9
                    return;
                case 30:
                    Init[OffsetToGfSelected + 45] = Convert.ToByte(variable); //Ap Ability 10
                    return;
                case 31:
                    Init[OffsetToGfSelected + 46] = Convert.ToByte(variable); //Ap Ability 11
                    return;
                case 32:
                    Init[OffsetToGfSelected + 47] = Convert.ToByte(variable); //Ap Ability 12
                    return;
                case 33:
                    Init[OffsetToGfSelected + 48] = Convert.ToByte(variable); //Ap Ability 13
                    return;
                case 34:
                    Init[OffsetToGfSelected + 49] = Convert.ToByte(variable); //Ap Ability 14
                    return;
                case 35:
                    Init[OffsetToGfSelected + 50] = Convert.ToByte(variable); //Ap Ability 15
                    return;
                case 36:
                    Init[OffsetToGfSelected + 51] = Convert.ToByte(variable); //Ap Ability 16
                    return;
                case 37:
                    Init[OffsetToGfSelected + 52] = Convert.ToByte(variable); //Ap Ability 17
                    return;
                case 38:
                    Init[OffsetToGfSelected + 53] = Convert.ToByte(variable); //Ap Ability 18
                    return;
                case 39:
                    Init[OffsetToGfSelected + 54] = Convert.ToByte(variable); //Ap Ability 19
                    return;
                case 40:
                    Init[OffsetToGfSelected + 55] = Convert.ToByte(variable); //Ap Ability 20
                    return;
                case 41:
                    Init[OffsetToGfSelected + 56] = Convert.ToByte(variable); //Ap Ability 21
                    return;
                case 42:
                    Init[OffsetToGfSelected + 57] = Convert.ToByte(variable); //Ap Ability 22
                    return;
                case 43:
                    KillsToInit(Convert.ToUInt16(variable), 60, (byte)Mode.Mode_GF); //Kills
                    return;
                case 44:
                    KOsToInit(Convert.ToUInt16(variable), 62, (byte)Mode.Mode_GF); //KOs
                    return;
                case 45:
                    Init[OffsetToGfSelected + 64] = Convert.ToByte(variable); //Learning Ability
                    return;
                case 46:
                    //Reserved for forgotten abilities
                    return;
            }
        }

        #region READ INIT VARIABLES

        #region INIT OFFSETS

        public static void ReadInit(byte[] init)
        {
            Init = init;

            GfDataOffset = 0;
            CharactersDataOffset = 1088;
            MiscDataOffset = 2264;
        }

        #endregion


        #region GF

        public static void ReadGF(int GfId_List, byte[] Init)
        {
            GetSelectedGfData = new GfData();
            int selectedGfOffset = GfDataOffset + (GfId_List * 68);
            OffsetToGfSelected = selectedGfOffset;

            //GetSelectedGfData.Name = BuildString((ushort)BitConverter.ToUInt32(Init, selectedGfOffset));
            GetSelectedGfData.Exp = BitConverter.ToUInt32(Init, selectedGfOffset + 12);
            GetSelectedGfData.Unknown1 = Init[selectedGfOffset + 16];
            GetSelectedGfData.Available = Init[selectedGfOffset + 17];
            GetSelectedGfData.CurrentHp = BitConverter.ToUInt16(Init, selectedGfOffset + 18);
            GetSelectedGfData.LearnedAbility1 = Init[selectedGfOffset + 20];
            GetSelectedGfData.LearnedAbility2 = Init[selectedGfOffset + 21];
            GetSelectedGfData.LearnedAbility3 = Init[selectedGfOffset + 22];
            GetSelectedGfData.LearnedAbility4 = Init[selectedGfOffset + 23];
            GetSelectedGfData.LearnedAbility5 = Init[selectedGfOffset + 24];
            GetSelectedGfData.LearnedAbility6 = Init[selectedGfOffset + 25];
            GetSelectedGfData.LearnedAbility7 = Init[selectedGfOffset + 26];
            GetSelectedGfData.LearnedAbility8 = Init[selectedGfOffset + 27];
            GetSelectedGfData.LearnedAbility9 = Init[selectedGfOffset + 28];
            GetSelectedGfData.LearnedAbility10 = Init[selectedGfOffset + 29];
            GetSelectedGfData.LearnedAbility11 = Init[selectedGfOffset + 30];
            GetSelectedGfData.LearnedAbility12 = Init[selectedGfOffset + 31];
            GetSelectedGfData.LearnedAbility13 = Init[selectedGfOffset + 32];
            GetSelectedGfData.LearnedAbility14 = Init[selectedGfOffset + 33];
            GetSelectedGfData.LearnedAbility15 = Init[selectedGfOffset + 34];
            GetSelectedGfData.LearnedAbility16 = Init[selectedGfOffset + 35];
            GetSelectedGfData.ApAbility1 = Init[selectedGfOffset + 36];
            GetSelectedGfData.ApAbility2 = Init[selectedGfOffset + 37];
            GetSelectedGfData.ApAbility3 = Init[selectedGfOffset + 38];
            GetSelectedGfData.ApAbility4 = Init[selectedGfOffset + 39];
            GetSelectedGfData.ApAbility5 = Init[selectedGfOffset + 40];
            GetSelectedGfData.ApAbility6 = Init[selectedGfOffset + 41];
            GetSelectedGfData.ApAbility7 = Init[selectedGfOffset + 42];
            GetSelectedGfData.ApAbility8 = Init[selectedGfOffset + 43];
            GetSelectedGfData.ApAbility9 = Init[selectedGfOffset + 44];
            GetSelectedGfData.ApAbility10 = Init[selectedGfOffset + 45];
            GetSelectedGfData.ApAbility11 = Init[selectedGfOffset + 46];
            GetSelectedGfData.ApAbility12 = Init[selectedGfOffset + 47];
            GetSelectedGfData.ApAbility13 = Init[selectedGfOffset + 48];
            GetSelectedGfData.ApAbility14 = Init[selectedGfOffset + 49];
            GetSelectedGfData.ApAbility15 = Init[selectedGfOffset + 50];
            GetSelectedGfData.ApAbility16 = Init[selectedGfOffset + 51];
            GetSelectedGfData.ApAbility17 = Init[selectedGfOffset + 52];
            GetSelectedGfData.ApAbility18 = Init[selectedGfOffset + 53];
            GetSelectedGfData.ApAbility19 = Init[selectedGfOffset + 54];
            GetSelectedGfData.ApAbility20 = Init[selectedGfOffset + 55];
            GetSelectedGfData.ApAbility21 = Init[selectedGfOffset + 56];
            GetSelectedGfData.ApAbility22 = Init[selectedGfOffset + 57];
            GetSelectedGfData.Kills = BitConverter.ToUInt16(Init, selectedGfOffset + 60);
            GetSelectedGfData.KOs = BitConverter.ToUInt16(Init, selectedGfOffset + 62);
            GetSelectedGfData.LearningAbility = Init[selectedGfOffset + 64];
            //to add forgotten abilities
        }

        #endregion

        //#region CHARACTERS

        //public static void ReadCharacters(int CharactersID_List, byte[] Kernel)
        //{
        //    GetSelectedCharactersData = new CharactersData();
        //    int selectedCharactersOffset = CharactersDataOffset + (CharactersID_List * 36);
        //    OffsetToCharactersSelected = selectedCharactersOffset;

        //    GetSelectedCharactersData.CrisisLevel = Kernel[selectedCharactersOffset + 2];
        //    selectedCharactersOffset += 3;
        //    GetSelectedCharactersData.Gender = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.LimitID = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.LimitParam = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.EXP1 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.EXP2 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.HP1 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.HP2 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.HP3 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.HP4 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.STR1 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.STR2 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.STR3 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.STR4 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.VIT1 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.VIT2 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.VIT3 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.VIT4 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.MAG1 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.MAG2 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.MAG3 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.MAG4 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.SPR1 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.SPR2 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.SPR3 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.SPR4 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.SPD1 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.SPD2 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.SPD3 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.SPD4 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.LUCK1 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.LUCK2 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.LUCK3 = Kernel[selectedCharactersOffset++];
        //    GetSelectedCharactersData.LUCK4 = Kernel[selectedCharactersOffset++];
        //}

        #endregion


        #endregion


        private static string BuildString(int index)
        {
            if (_charstable == null)
                _charstable = Chartable.Split(',');
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                if (Init[index] == 0x00)
                    return sb.ToString();
                char c = _charstable[Init[index++] - 31].ToCharArray()[0];
                sb.Append(c);
            }
        }

    }
}