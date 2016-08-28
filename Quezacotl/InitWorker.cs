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

        public static int CharacterDataOffset = -1;
        public static int OffsetToCharacterSelected = -1;

        public static int MiscDataOffset = -1;
        public static int OffsetToMiscSelected = -1;

        public static GfData GetSelectedGfData;
        public static CharactersData GetSelectedCharactersData;


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
            public UInt16 HpBonus;
            public UInt32 Exp;
            public byte ModelId;
            public byte WeaponId;
            public byte Str;
            public byte Vit;
            public byte Mag;
            public byte Spr;
            public byte Spd;
            public byte Luck;
            public byte Magic1;
            public byte Magic1Quantity;
            public byte Magic2;
            public byte Magic2Quantity;
            public byte Magic3;
            public byte Magic3Quantity;
            public byte Magic4;
            public byte Magic4Quantity;
            public byte Magic5;
            public byte Magic5Quantity;
            public byte Magic6;
            public byte Magic6Quantity;
            public byte Magic7;
            public byte Magic7Quantity;
            public byte Magic8;
            public byte Magic8Quantity;
            public byte Magic9;
            public byte Magic9Quantity;
            public byte Magic10;
            public byte Magic10Quantity;
            public byte Magic11;
            public byte Magic11Quantity;
            public byte Magic12;
            public byte Magic12Quantity;
            public byte Magic13;
            public byte Magic13Quantity;
            public byte Magic14;
            public byte Magic14Quantity;
            public byte Magic15;
            public byte Magic15Quantity;
            public byte Magic16;
            public byte Magic16Quantity;
            public byte Magic17;
            public byte Magic17Quantity;
            public byte Magic18;
            public byte Magic18Quantity;
            public byte Magic19;
            public byte Magic19Quantity;
            public byte Magic20;
            public byte Magic20Quantity;
            public byte Magic21;
            public byte Magic21Quantity;
            public byte Magic22;
            public byte Magic22Quantity;
            public byte Magic23;
            public byte Magic23Quantity;
            public byte Magic24;
            public byte Magic24Quantity;
            public byte Magic25;
            public byte Magic25Quantity;
            public byte Magic26;
            public byte Magic26Quantity;
            public byte Magic27;
            public byte Magic27Quantity;
            public byte Magic28;
            public byte Magic28Quantity;
            public byte Magic29;
            public byte Magic29Quantity;
            public byte Magic30;
            public byte Magic30Quantity;
            public byte Magic31;
            public byte Magic31Quantity;
            public byte Magic32;
            public byte Magic32Quantity;
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
                    Array.Copy(expBytes, 0, Init, OffsetToCharacterSelected + add, 4);
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
                    Array.Copy(hpBytes, 0, Init, OffsetToCharacterSelected + add, 2);
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
                    Array.Copy(killsBytes, 0, Init, OffsetToCharacterSelected + add, 2);
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
                    Array.Copy(koBytes, 0, Init, OffsetToCharacterSelected + add, 2);
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
        private static void HpBonusToInit(uint a, int add, byte mode)
        {
            byte[] hpBytes = BitConverter.GetBytes(a);
            switch (mode)
            {
                case (byte)Mode.Mode_Characters:
                    Array.Copy(hpBytes, 0, Init, OffsetToCharacterSelected + add, 2);
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
                    Array.Copy(magicBytes, 0, Init, OffsetToCharacterSelected + add, 2);
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
        private static void GfCompToInit(int a, int add, byte mode)
        {
            byte[] compBytes = BitConverter.GetBytes(a);
            switch (mode)
            {
                case (byte)Mode.Mode_Characters:
                    Array.Copy(compBytes, 0, Init, OffsetToCharacterSelected + add, 2);
                    break;

                default:
                    return;
            }
        }

        /// <summary>
        /// This is for Names
        /// </summary>
        /// <param name="a"></param>
        /// <param name="add"></param>
        private static void NameToInit(uint a, int add, byte mode)
        {
            byte[] nameBytes = BitConverter.GetBytes(a);
            switch (mode)
            {
                case (byte)Mode.Mode_GF:
                    Array.Copy(nameBytes, 0, Init, OffsetToGfSelected + add, 12);
                    break;
                case (byte)Mode.Mode_Characters:
                    Array.Copy(nameBytes, 0, Init, OffsetToCharacterSelected + add, 2);
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
                    NameToInit(Convert.ToUInt32(variable), 0, (byte)Mode.Mode_GF); //GF Name
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




        #endregion


        #region Write Characters Variables

        public static void UpdateVariable_Characters(int index, object variable)
        {
            if (!Form1._loaded || Init == null)
                return;
            switch (index)
            {
                case 0:
                    CurrentHpToInit(Convert.ToUInt16(variable), 0, (byte)Mode.Mode_Characters); //Current Hp
                    return;
                case 1:
                    HpBonusToInit(Convert.ToUInt16(variable), 2, (byte)Mode.Mode_Characters); //Max Hp
                    return;
                case 2:
                    ExpToInit(Convert.ToUInt32(variable), 4, (byte)Mode.Mode_Characters); //Exp
                    return;
                case 3:
                    Init[OffsetToCharacterSelected + 8] = Convert.ToByte(variable); //model id
                    return;
                case 4:
                    Init[OffsetToCharacterSelected + 9] = Convert.ToByte(variable); //weapon id
                    return;
                case 5:
                    Init[OffsetToCharacterSelected + 10] = Convert.ToByte(variable); //str
                    return;
                case 6:
                    Init[OffsetToCharacterSelected + 11] = Convert.ToByte(variable); //vit
                    return;
                case 7:
                    Init[OffsetToCharacterSelected + 12] = Convert.ToByte(variable); //mag
                    return;
                case 8:
                    Init[OffsetToCharacterSelected + 13] = Convert.ToByte(variable); //spr
                    return;
                case 9:
                    Init[OffsetToCharacterSelected + 14] = Convert.ToByte(variable); //spd
                    return;
                case 10:
                    Init[OffsetToCharacterSelected + 15] = Convert.ToByte(variable); //luck
                    return;
                case 11:
                    Init[OffsetToCharacterSelected + 16] = Convert.ToByte(variable); //magic 1
                    return;
                case 12:
                    Init[OffsetToCharacterSelected + 17] = Convert.ToByte(variable); //magic quantity 1
                    return;
                case 13:
                    Init[OffsetToCharacterSelected + 18] = Convert.ToByte(variable); //magic 2
                    return;
                case 14:
                    Init[OffsetToCharacterSelected + 19] = Convert.ToByte(variable); //magic quantity 2
                    return;
                case 15:
                    Init[OffsetToCharacterSelected + 20] = Convert.ToByte(variable); //magic 3
                    return;
                case 16:
                    Init[OffsetToCharacterSelected + 21] = Convert.ToByte(variable); //magic quantity 3
                    return;
                case 17:
                    Init[OffsetToCharacterSelected + 22] = Convert.ToByte(variable); //magic 4
                    return;
                case 18:
                    Init[OffsetToCharacterSelected + 23] = Convert.ToByte(variable); //magic quantity 4
                    return;
                case 19:
                    Init[OffsetToCharacterSelected + 24] = Convert.ToByte(variable); //magic 5
                    return;
                case 20:
                    Init[OffsetToCharacterSelected + 25] = Convert.ToByte(variable); //magic quantity 5
                    return;
                case 21:
                    Init[OffsetToCharacterSelected + 26] = Convert.ToByte(variable); //magic 6
                    return;
                case 22:
                    Init[OffsetToCharacterSelected + 27] = Convert.ToByte(variable); //magic quantity 6
                    return;
                case 23:
                    Init[OffsetToCharacterSelected + 28] = Convert.ToByte(variable); //magic 7
                    return;
                case 24:
                    Init[OffsetToCharacterSelected + 29] = Convert.ToByte(variable); //magic quantity 7
                    return;
                case 25:
                    Init[OffsetToCharacterSelected + 30] = Convert.ToByte(variable); //magic 8
                    return;
                case 26:
                    Init[OffsetToCharacterSelected + 31] = Convert.ToByte(variable); //magic quantity 8
                    return;
                case 27:
                    Init[OffsetToCharacterSelected + 32] = Convert.ToByte(variable); //magic 9
                    return;
                case 28:
                    Init[OffsetToCharacterSelected + 33] = Convert.ToByte(variable); //magic quantity 9
                    return;
                case 29:
                    Init[OffsetToCharacterSelected + 34] = Convert.ToByte(variable); //magic 10
                    return;
                case 30:
                    Init[OffsetToCharacterSelected + 35] = Convert.ToByte(variable); //magic quantity 10
                    return;
                case 31:
                    Init[OffsetToCharacterSelected + 36] = Convert.ToByte(variable); //magic 10
                    return;
                case 32:
                    Init[OffsetToCharacterSelected + 37] = Convert.ToByte(variable); //magic quantity 11
                    return;
                case 33:
                    Init[OffsetToCharacterSelected + 38] = Convert.ToByte(variable); //magic 12
                    return;
                case 34:
                    Init[OffsetToCharacterSelected + 39] = Convert.ToByte(variable); //magic quantity 12
                    return;
                case 35:
                    Init[OffsetToCharacterSelected + 40] = Convert.ToByte(variable); //magic 13
                    return;
                case 36:
                    Init[OffsetToCharacterSelected + 41] = Convert.ToByte(variable); //magic quantity 13
                    return;
                case 37:
                    Init[OffsetToCharacterSelected + 42] = Convert.ToByte(variable); //magic 14
                    return;
                case 38:
                    Init[OffsetToCharacterSelected + 43] = Convert.ToByte(variable); //magic quantity 14
                    return;
                case 39:
                    Init[OffsetToCharacterSelected + 44] = Convert.ToByte(variable); //magic 15
                    return;
                case 40:
                    Init[OffsetToCharacterSelected + 45] = Convert.ToByte(variable); //magic quantity 15
                    return;
                case 41:
                    Init[OffsetToCharacterSelected + 46] = Convert.ToByte(variable); //magic 16
                    return;
                case 42:
                    Init[OffsetToCharacterSelected + 47] = Convert.ToByte(variable); //magic quantity 16
                    return;
                case 43:
                    Init[OffsetToCharacterSelected + 48] = Convert.ToByte(variable); //magic 17
                    return;
                case 44:
                    Init[OffsetToCharacterSelected + 49] = Convert.ToByte(variable); //magic quantity 17
                    return;
                case 45:
                    Init[OffsetToCharacterSelected + 50] = Convert.ToByte(variable); //magic 18
                    return;
                case 46:
                    Init[OffsetToCharacterSelected + 51] = Convert.ToByte(variable); //magic quantity 18
                    return;
                case 47:
                    Init[OffsetToCharacterSelected + 52] = Convert.ToByte(variable); //magic 19
                    return;
                case 48:
                    Init[OffsetToCharacterSelected + 53] = Convert.ToByte(variable); //magic quantity 19
                    return;
                case 49:
                    Init[OffsetToCharacterSelected + 54] = Convert.ToByte(variable); //magic 20
                    return;
                case 50:
                    Init[OffsetToCharacterSelected + 55] = Convert.ToByte(variable); //magic quantity 20
                    return;
                case 51:
                    Init[OffsetToCharacterSelected + 56] = Convert.ToByte(variable); //magic 21
                    return;
                case 52:
                    Init[OffsetToCharacterSelected + 57] = Convert.ToByte(variable); //magic quantity 21
                    return;
                case 53:
                    Init[OffsetToCharacterSelected + 58] = Convert.ToByte(variable); //magic 22
                    return;
                case 54:
                    Init[OffsetToCharacterSelected + 59] = Convert.ToByte(variable); //magic quantity 22
                    return;
                case 55:
                    Init[OffsetToCharacterSelected + 60] = Convert.ToByte(variable); //magic 23
                    return;
                case 56:
                    Init[OffsetToCharacterSelected + 61] = Convert.ToByte(variable); //magic quantity 23
                    return;
                case 57:
                    Init[OffsetToCharacterSelected + 62] = Convert.ToByte(variable); //magic 24
                    return;
                case 58:
                    Init[OffsetToCharacterSelected + 63] = Convert.ToByte(variable); //magic quantity 24
                    return;
                case 59:
                    Init[OffsetToCharacterSelected + 64] = Convert.ToByte(variable); //magic 25
                    return;
                case 60:
                    Init[OffsetToCharacterSelected + 65] = Convert.ToByte(variable); //magic quantity 25
                    return;
                case 61:
                    Init[OffsetToCharacterSelected + 66] = Convert.ToByte(variable); //magic 26
                    return;
                case 62:
                    Init[OffsetToCharacterSelected + 67] = Convert.ToByte(variable); //magic quantity 26
                    return;
                case 63:
                    Init[OffsetToCharacterSelected + 68] = Convert.ToByte(variable); //magic 27
                    return;
                case 64:
                    Init[OffsetToCharacterSelected + 69] = Convert.ToByte(variable); //magic quantity 27
                    return;
                case 65:
                    Init[OffsetToCharacterSelected + 70] = Convert.ToByte(variable); //magic 28
                    return;
                case 66:
                    Init[OffsetToCharacterSelected + 71] = Convert.ToByte(variable); //magic quantity 28
                    return;
                case 67:
                    Init[OffsetToCharacterSelected + 72] = Convert.ToByte(variable); //magic 29
                    return;
                case 68:
                    Init[OffsetToCharacterSelected + 73] = Convert.ToByte(variable); //magic quantity 29
                    return;
                case 69:
                    Init[OffsetToCharacterSelected + 74] = Convert.ToByte(variable); //magic 30
                    return;
                case 70:
                    Init[OffsetToCharacterSelected + 75] = Convert.ToByte(variable); //magic quantity 30
                    return;
                case 71:
                    Init[OffsetToCharacterSelected + 76] = Convert.ToByte(variable); //magic 31
                    return;
                case 72:
                    Init[OffsetToCharacterSelected + 77] = Convert.ToByte(variable); //magic quantity 31
                    return;
                case 73:
                    Init[OffsetToCharacterSelected + 78] = Convert.ToByte(variable); //magic 32
                    return;
                case 74:
                    Init[OffsetToCharacterSelected + 79] = Convert.ToByte(variable); //magic quantity 32
                    return;
                case 75:
                    Init[OffsetToCharacterSelected + 80] = Convert.ToByte(variable); //command 1
                    return;
                case 76:
                    Init[OffsetToCharacterSelected + 81] = Convert.ToByte(variable); //command 2
                    return;
                case 77:
                    Init[OffsetToCharacterSelected + 82] = Convert.ToByte(variable); //command 3
                    return;
                case 78:
                    Init[OffsetToCharacterSelected + 83] = Convert.ToByte(variable); //unk 1
                    return;
                case 79:
                    Init[OffsetToCharacterSelected + 84] = Convert.ToByte(variable); //ability 1
                    return;
                case 80:
                    Init[OffsetToCharacterSelected + 85] = Convert.ToByte(variable); //ability 2
                    return;
                case 81:
                    Init[OffsetToCharacterSelected + 86] = Convert.ToByte(variable); //ability 3
                    return;
                case 82:
                    Init[OffsetToCharacterSelected + 87] = Convert.ToByte(variable); //ability 4
                    return;
                case 83:
                    Init[OffsetToCharacterSelected + 88] = (byte)(Init[OffsetToCharacterSelected + 88] ^ Convert.ToByte(variable)); //jun gf 1
                    return;
                case 84:
                    Init[OffsetToCharacterSelected + 89] = (byte)(Init[OffsetToCharacterSelected + 89] ^ Convert.ToByte(variable)); //jun gf 2
                    return;
                case 85:
                    Init[OffsetToCharacterSelected + 90] = Convert.ToByte(variable); //unk 2
                    return;
                case 86:
                    Init[OffsetToCharacterSelected + 91] = (byte)(Init[OffsetToCharacterSelected + 91] ^ Convert.ToByte(variable)); //alt model
                    return;
                case 87:
                    Init[OffsetToCharacterSelected + 92] = Convert.ToByte(variable); //jun hp
                    return;
                case 88:
                    Init[OffsetToCharacterSelected + 93] = Convert.ToByte(variable); //jun str
                    return;
                case 89:
                    Init[OffsetToCharacterSelected + 94] = Convert.ToByte(variable); //jun vit
                    return;
                case 90:
                    Init[OffsetToCharacterSelected + 95] = Convert.ToByte(variable); //jun mag
                    return;
                case 91:
                    Init[OffsetToCharacterSelected + 96] = Convert.ToByte(variable); //jun spr
                    return;
                case 92:
                    Init[OffsetToCharacterSelected + 97] = Convert.ToByte(variable); //jun spd
                    return;
                case 93:
                    Init[OffsetToCharacterSelected + 98] = Convert.ToByte(variable); //jun eva
                    return;
                case 94:
                    Init[OffsetToCharacterSelected + 99] = Convert.ToByte(variable); //jun hit
                    return;
                case 95:
                    Init[OffsetToCharacterSelected + 100] = Convert.ToByte(variable); //jun luck
                    return;
                case 96:
                    Init[OffsetToCharacterSelected + 101] = Convert.ToByte(variable); //jun ele atk
                    return;
                case 97:
                    Init[OffsetToCharacterSelected + 102] = Convert.ToByte(variable); //jun status atk
                    return;
                case 98:
                    Init[OffsetToCharacterSelected + 103] = Convert.ToByte(variable); //JunEleDef1
                    return;
                case 99:
                    Init[OffsetToCharacterSelected + 104] = Convert.ToByte(variable); //JunEleDef2
                    return;
                case 100:
                    Init[OffsetToCharacterSelected + 105] = Convert.ToByte(variable); //JunEleDef3
                    return;
                case 101:
                    Init[OffsetToCharacterSelected + 106] = Convert.ToByte(variable); //JunEleDef4
                    return;
                case 102:
                    Init[OffsetToCharacterSelected + 107] = Convert.ToByte(variable); //JunStatusDef1
                    return;
                case 103:
                    Init[OffsetToCharacterSelected + 118] = Convert.ToByte(variable); //JunStatusDef2
                    return;
                case 104:
                    Init[OffsetToCharacterSelected + 109] = Convert.ToByte(variable); //JunStatusDef3
                    return;
                case 105:
                    Init[OffsetToCharacterSelected + 110] = Convert.ToByte(variable); //JunStatusDef4
                    return;
                case 106:
                    Init[OffsetToCharacterSelected + 111] = Convert.ToByte(variable); //Unk 3
                    return;
                case 107:
                    GfCompToInit(6000 - (Convert.ToInt16(variable)) * 5, 112, (byte)Mode.Mode_Characters); //GF Compatibility 1
                    return;
                case 108:
                    GfCompToInit(6000 - (Convert.ToInt16(variable)) * 5, 114, (byte)Mode.Mode_Characters); //GF Compatibility 2
                    return;
                case 109:
                    GfCompToInit(6000 - (Convert.ToInt16(variable)) * 5, 116, (byte)Mode.Mode_Characters); //GF Compatibility 3
                    return;
                case 110:
                    GfCompToInit(6000 - (Convert.ToInt16(variable)) * 5, 118, (byte)Mode.Mode_Characters); //GF Compatibility 4
                    return;
                case 111:
                    GfCompToInit(6000 - (Convert.ToInt16(variable)) * 5, 120, (byte)Mode.Mode_Characters); //GF Compatibility 5
                    return;
                case 112:
                    GfCompToInit(6000 - (Convert.ToInt16(variable)) * 5, 122, (byte)Mode.Mode_Characters); //GF Compatibility 6
                    return;
                case 113:
                    GfCompToInit(6000 - (Convert.ToInt16(variable)) * 5, 124, (byte)Mode.Mode_Characters); //GF Compatibility 7
                    return;
                case 114:
                    GfCompToInit(6000 - (Convert.ToInt16(variable)) * 5, 126, (byte)Mode.Mode_Characters); //GF Compatibility 8
                    return;
                case 115:
                    GfCompToInit(6000 - (Convert.ToInt16(variable)) * 5, 128, (byte)Mode.Mode_Characters); //GF Compatibility 9
                    return;
                case 116:
                    GfCompToInit(6000 - (Convert.ToInt16(variable)) * 5, 130, (byte)Mode.Mode_Characters); //GF Compatibility 10
                    return;
                case 117:
                    GfCompToInit(6000 - (Convert.ToInt16(variable)) * 5, 132, (byte)Mode.Mode_Characters); //GF Compatibility 11
                    return;
                case 118:
                    GfCompToInit(6000 - (Convert.ToInt16(variable)) * 5, 134, (byte)Mode.Mode_Characters); //GF Compatibility 12
                    return;
                case 119:
                    GfCompToInit(6000 - (Convert.ToInt16(variable)) * 5, 136, (byte)Mode.Mode_Characters); //GF Compatibility 13
                    return;
                case 120:
                    GfCompToInit(6000 - (Convert.ToInt16(variable)) * 5, 138, (byte)Mode.Mode_Characters); //GF Compatibility 14
                    return;
                case 121:
                    GfCompToInit(6000 - (Convert.ToInt16(variable)) * 5, 140, (byte)Mode.Mode_Characters); //GF Compatibility 15
                    return;
                case 122:
                    GfCompToInit(6000 - (Convert.ToInt16(variable)) * 5, 142, (byte)Mode.Mode_Characters); //GF Compatibility 16
                    return;
                case 123:
                    KillsToInit(Convert.ToUInt16(variable), 144, (byte)Mode.Mode_Characters); //Kills
                    return;
                case 124:
                    KOsToInit(Convert.ToUInt16(variable), 146, (byte)Mode.Mode_Characters); //KOs
                    return;
                case 125:
                    Init[OffsetToCharacterSelected + 148] = Convert.ToByte(variable); //Exist
                    return;
                case 126:
                    Init[OffsetToCharacterSelected + 149] = Convert.ToByte(variable); //Unk 4
                    return;
                case 127:
                    Init[OffsetToCharacterSelected + 150] = Convert.ToByte(variable); //Current Status
                    return;
                case 128:
                    Init[OffsetToCharacterSelected + 151] = Convert.ToByte(variable); //Unk 5
                    return;
            }
        }

        #endregion


        #region READ INIT VARIABLES

        #region Init Offsets

        public static void ReadInit(byte[] init)
        {
            Init = init;
            FF8Text.SetInit(Init);

            GfDataOffset = 0;
            CharacterDataOffset = 1088;
            MiscDataOffset = 2264;
        }

        #endregion


        #region Gf

        public static void ReadGF(int GfId_List, byte[] Init)
        {
            GetSelectedGfData = new GfData();
            int selectedGfOffset = GfDataOffset + (GfId_List * 68);
            OffsetToGfSelected = selectedGfOffset;

            GetSelectedGfData.Name = FF8Text.BuildString((ushort)BitConverter.ToUInt16(Init, selectedGfOffset));
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

        #region Characters

        public static void ReadCharacters(int CharactersId_List, byte[] Init)
        {
            GetSelectedCharactersData = new CharactersData();
            int selectedCharactersOffset = CharacterDataOffset + (CharactersId_List * 152);
            OffsetToCharacterSelected = selectedCharactersOffset;

            GetSelectedCharactersData.CurrentHp = BitConverter.ToUInt16(Init, selectedCharactersOffset + 0);
            GetSelectedCharactersData.HpBonus = BitConverter.ToUInt16(Init, selectedCharactersOffset + 2);
            GetSelectedCharactersData.Exp = BitConverter.ToUInt32(Init, selectedCharactersOffset + 4);
            GetSelectedCharactersData.ModelId = Init[selectedCharactersOffset + 8];
            GetSelectedCharactersData.WeaponId = Init[selectedCharactersOffset + 9];
            GetSelectedCharactersData.Str = Init[selectedCharactersOffset + 10];
            GetSelectedCharactersData.Vit = Init[selectedCharactersOffset + 11];
            GetSelectedCharactersData.Mag = Init[selectedCharactersOffset + 12];
            GetSelectedCharactersData.Spr = Init[selectedCharactersOffset + 13];
            GetSelectedCharactersData.Spd = Init[selectedCharactersOffset + 14];
            GetSelectedCharactersData.Luck = Init[selectedCharactersOffset + 15];
            GetSelectedCharactersData.Magic1 = Init[selectedCharactersOffset + 16];
            GetSelectedCharactersData.Magic1Quantity = Init[selectedCharactersOffset + 17];
            GetSelectedCharactersData.Magic2 = Init[selectedCharactersOffset + 18];
            GetSelectedCharactersData.Magic2Quantity = Init[selectedCharactersOffset + 19];
            GetSelectedCharactersData.Magic3 = Init[selectedCharactersOffset + 20];
            GetSelectedCharactersData.Magic3Quantity = Init[selectedCharactersOffset + 21];
            GetSelectedCharactersData.Magic4 = Init[selectedCharactersOffset + 22];
            GetSelectedCharactersData.Magic4Quantity = Init[selectedCharactersOffset + 23];
            GetSelectedCharactersData.Magic5 = Init[selectedCharactersOffset + 24];
            GetSelectedCharactersData.Magic5Quantity = Init[selectedCharactersOffset + 25];
            GetSelectedCharactersData.Magic6 = Init[selectedCharactersOffset + 26];
            GetSelectedCharactersData.Magic6Quantity = Init[selectedCharactersOffset + 27];
            GetSelectedCharactersData.Magic7 = Init[selectedCharactersOffset + 28];
            GetSelectedCharactersData.Magic7Quantity = Init[selectedCharactersOffset + 29];
            GetSelectedCharactersData.Magic8 = Init[selectedCharactersOffset + 30];
            GetSelectedCharactersData.Magic8Quantity = Init[selectedCharactersOffset + 31];
            GetSelectedCharactersData.Magic9 = Init[selectedCharactersOffset + 32];
            GetSelectedCharactersData.Magic9Quantity = Init[selectedCharactersOffset + 33];
            GetSelectedCharactersData.Magic10 = Init[selectedCharactersOffset + 34];
            GetSelectedCharactersData.Magic10Quantity = Init[selectedCharactersOffset + 35];
            GetSelectedCharactersData.Magic11 = Init[selectedCharactersOffset + 36];
            GetSelectedCharactersData.Magic11Quantity = Init[selectedCharactersOffset + 37];
            GetSelectedCharactersData.Magic12 = Init[selectedCharactersOffset + 38];
            GetSelectedCharactersData.Magic12Quantity = Init[selectedCharactersOffset + 39];
            GetSelectedCharactersData.Magic13 = Init[selectedCharactersOffset + 40];
            GetSelectedCharactersData.Magic13Quantity = Init[selectedCharactersOffset + 41];
            GetSelectedCharactersData.Magic14 = Init[selectedCharactersOffset + 42];
            GetSelectedCharactersData.Magic14Quantity = Init[selectedCharactersOffset + 43];
            GetSelectedCharactersData.Magic15 = Init[selectedCharactersOffset + 44];
            GetSelectedCharactersData.Magic15Quantity = Init[selectedCharactersOffset + 45];
            GetSelectedCharactersData.Magic16 = Init[selectedCharactersOffset + 46];
            GetSelectedCharactersData.Magic16Quantity = Init[selectedCharactersOffset + 47];
            GetSelectedCharactersData.Magic17 = Init[selectedCharactersOffset + 48];
            GetSelectedCharactersData.Magic17Quantity = Init[selectedCharactersOffset + 49];
            GetSelectedCharactersData.Magic18 = Init[selectedCharactersOffset + 50];
            GetSelectedCharactersData.Magic18Quantity = Init[selectedCharactersOffset + 51];
            GetSelectedCharactersData.Magic19 = Init[selectedCharactersOffset + 52];
            GetSelectedCharactersData.Magic19Quantity = Init[selectedCharactersOffset + 53];
            GetSelectedCharactersData.Magic20 = Init[selectedCharactersOffset + 54];
            GetSelectedCharactersData.Magic20Quantity = Init[selectedCharactersOffset + 55];
            GetSelectedCharactersData.Magic21 = Init[selectedCharactersOffset + 56];
            GetSelectedCharactersData.Magic21Quantity = Init[selectedCharactersOffset + 57];
            GetSelectedCharactersData.Magic22 = Init[selectedCharactersOffset + 58];
            GetSelectedCharactersData.Magic22Quantity = Init[selectedCharactersOffset + 59];
            GetSelectedCharactersData.Magic23 = Init[selectedCharactersOffset + 60];
            GetSelectedCharactersData.Magic23Quantity = Init[selectedCharactersOffset + 61];
            GetSelectedCharactersData.Magic24 = Init[selectedCharactersOffset + 62];
            GetSelectedCharactersData.Magic24Quantity = Init[selectedCharactersOffset + 63];
            GetSelectedCharactersData.Magic25 = Init[selectedCharactersOffset + 64];
            GetSelectedCharactersData.Magic25Quantity = Init[selectedCharactersOffset + 65];
            GetSelectedCharactersData.Magic26 = Init[selectedCharactersOffset + 66];
            GetSelectedCharactersData.Magic26Quantity = Init[selectedCharactersOffset + 67];
            GetSelectedCharactersData.Magic27 = Init[selectedCharactersOffset + 68];
            GetSelectedCharactersData.Magic27Quantity = Init[selectedCharactersOffset + 69];
            GetSelectedCharactersData.Magic28 = Init[selectedCharactersOffset + 70];
            GetSelectedCharactersData.Magic28Quantity = Init[selectedCharactersOffset + 71];
            GetSelectedCharactersData.Magic29 = Init[selectedCharactersOffset + 72];
            GetSelectedCharactersData.Magic29Quantity = Init[selectedCharactersOffset + 73];
            GetSelectedCharactersData.Magic30 = Init[selectedCharactersOffset + 74];
            GetSelectedCharactersData.Magic30Quantity = Init[selectedCharactersOffset + 75];
            GetSelectedCharactersData.Magic31 = Init[selectedCharactersOffset + 76];
            GetSelectedCharactersData.Magic31Quantity = Init[selectedCharactersOffset + 77];
            GetSelectedCharactersData.Magic32 = Init[selectedCharactersOffset + 78];
            GetSelectedCharactersData.Magic32Quantity = Init[selectedCharactersOffset + 79];
            GetSelectedCharactersData.Command1 = Init[selectedCharactersOffset + 80];
            GetSelectedCharactersData.Command2 = Init[selectedCharactersOffset + 81];
            GetSelectedCharactersData.Command3 = Init[selectedCharactersOffset + 82];
            GetSelectedCharactersData.Unknown1 = Init[selectedCharactersOffset + 83];
            GetSelectedCharactersData.Ability1 = Init[selectedCharactersOffset + 84];
            GetSelectedCharactersData.Ability2 = Init[selectedCharactersOffset + 85];
            GetSelectedCharactersData.Ability3 = Init[selectedCharactersOffset + 86];
            GetSelectedCharactersData.Ability4 = Init[selectedCharactersOffset + 87];
            GetSelectedCharactersData.JunGf1 = Init[selectedCharactersOffset + 88];
            GetSelectedCharactersData.JunGf2 = Init[selectedCharactersOffset + 89];
            GetSelectedCharactersData.Unknown2 = Init[selectedCharactersOffset + 90];
            GetSelectedCharactersData.AltModel = Init[selectedCharactersOffset + 91];
            GetSelectedCharactersData.JunHP = Init[selectedCharactersOffset + 92];
            GetSelectedCharactersData.JunStr = Init[selectedCharactersOffset + 93];
            GetSelectedCharactersData.JunVit = Init[selectedCharactersOffset + 94];
            GetSelectedCharactersData.JunMag = Init[selectedCharactersOffset + 95];
            GetSelectedCharactersData.JunSpr = Init[selectedCharactersOffset + 96];
            GetSelectedCharactersData.JunSpd = Init[selectedCharactersOffset + 97];
            GetSelectedCharactersData.JunEva = Init[selectedCharactersOffset + 98];
            GetSelectedCharactersData.JunHit = Init[selectedCharactersOffset + 99];
            GetSelectedCharactersData.JunLuck = Init[selectedCharactersOffset + 100];
            GetSelectedCharactersData.JunEleAtk = Init[selectedCharactersOffset + 101];
            GetSelectedCharactersData.JunStatusAtk = Init[selectedCharactersOffset + 102];
            GetSelectedCharactersData.JunEleDef1 = Init[selectedCharactersOffset + 103];
            GetSelectedCharactersData.JunEleDef2 = Init[selectedCharactersOffset + 104];
            GetSelectedCharactersData.JunEleDef3 = Init[selectedCharactersOffset + 105];
            GetSelectedCharactersData.JunEleDef4 = Init[selectedCharactersOffset + 106];
            GetSelectedCharactersData.JunStatusDef1 = Init[selectedCharactersOffset + 107];
            GetSelectedCharactersData.JunStatusDef2 = Init[selectedCharactersOffset + 108];
            GetSelectedCharactersData.JunStatusDef3 = Init[selectedCharactersOffset + 109];
            GetSelectedCharactersData.JunStatusDef4 = Init[selectedCharactersOffset + 110];
            GetSelectedCharactersData.Unknown3 = Init[selectedCharactersOffset + 111];
            GetSelectedCharactersData.GfComp1 = BitConverter.ToUInt16(Init, selectedCharactersOffset + 112);
            GetSelectedCharactersData.GfComp2 = BitConverter.ToUInt16(Init, selectedCharactersOffset + 114);
            GetSelectedCharactersData.GfComp3 = BitConverter.ToUInt16(Init, selectedCharactersOffset + 116);
            GetSelectedCharactersData.GfComp4 = BitConverter.ToUInt16(Init, selectedCharactersOffset + 118);
            GetSelectedCharactersData.GfComp5 = BitConverter.ToUInt16(Init, selectedCharactersOffset + 120);
            GetSelectedCharactersData.GfComp6 = BitConverter.ToUInt16(Init, selectedCharactersOffset + 122);
            GetSelectedCharactersData.GfComp7 = BitConverter.ToUInt16(Init, selectedCharactersOffset + 124);
            GetSelectedCharactersData.GfComp8 = BitConverter.ToUInt16(Init, selectedCharactersOffset + 126);
            GetSelectedCharactersData.GfComp9 = BitConverter.ToUInt16(Init, selectedCharactersOffset + 128);
            GetSelectedCharactersData.GfComp10 = BitConverter.ToUInt16(Init, selectedCharactersOffset + 130);
            GetSelectedCharactersData.GfComp11 = BitConverter.ToUInt16(Init, selectedCharactersOffset + 132);
            GetSelectedCharactersData.GfComp12 = BitConverter.ToUInt16(Init, selectedCharactersOffset + 134);
            GetSelectedCharactersData.GfComp13 = BitConverter.ToUInt16(Init, selectedCharactersOffset + 136);
            GetSelectedCharactersData.GfComp14 = BitConverter.ToUInt16(Init, selectedCharactersOffset + 138);
            GetSelectedCharactersData.GfComp15 = BitConverter.ToUInt16(Init, selectedCharactersOffset + 140);
            GetSelectedCharactersData.GfComp16 = BitConverter.ToUInt16(Init, selectedCharactersOffset + 142);
            GetSelectedCharactersData.Kills = BitConverter.ToUInt16(Init, selectedCharactersOffset + 144);
            GetSelectedCharactersData.KOs = BitConverter.ToUInt16(Init, selectedCharactersOffset + 146);
            GetSelectedCharactersData.Exist = Init[selectedCharactersOffset + 148];
            GetSelectedCharactersData.Unknown4 = Init[selectedCharactersOffset + 149];
            GetSelectedCharactersData.CurrentStatus = Init[selectedCharactersOffset + 150];
            GetSelectedCharactersData.Unknown5 = Init[selectedCharactersOffset + 151];
        }

        #endregion

        #endregion

    }
}