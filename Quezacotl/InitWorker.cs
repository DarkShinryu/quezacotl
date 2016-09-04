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

        public static int ShopsDataOffset = -1;
        public static int OffsetToShopsSelected = -1;

        public static int ConfigDataOffset = -1;
        public static int OffsetToConfigSelected = -1;

        public static int MiscDataOffset = -1;
        public static int OffsetToMiscSelected = -1;

        public static int ItemsBattleOrderDataOffset = -1;
        public static int OffsetToItemsBattleOrderSelected = -1;

        public static int ItemsDataOffset = -1;
        public static int OffsetToItemsSelected = -1;

        public static GfData GetSelectedGfData;
        public static CharactersData GetSelectedCharactersData;
        public static ConfigData GetSelectedConfigData;
        public static MiscData GetSelectedMiscData;
        public static ItemsBattleOrderData GetSelectedItemsBattleOrderData;
        public static ItemsData GetSelectedItemsData;


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

        public struct ConfigData
        {
            public byte BattleSpeed;
            public byte BattleMessage;
            public byte FieldMessage;
            public byte Volume;
            public byte Flag;
            public byte Scan;
            public byte Camera;
            public byte KeyUnk1;
            public byte KeyEscape;
            public byte KeyPov;
            public byte KeyWindow;
            public byte KeyTrigger;
            public byte KeyCancel;
            public byte KeyMenu;
            public byte KeyTalk;
            public byte KeyTripleTriad;
            public byte KeySelect;
            public byte KeyUnk2;
            public byte KeyUnk3;
            public byte KeyStart;          
        }

        public struct MiscData
        {
            public byte PartyMem1;
            public byte PartyMem2;
            public byte PartyMem3;
            public byte KnownWeapons1;
            public byte KnownWeapons2;
            public byte KnownWeapons3;
            public byte KnownWeapons4;
            public string GrieverName;
            public UInt16 Unknown1;
            public UInt16 Unknown2;
            public UInt32 Gil;
            public UInt32 GilLaguna;
            public byte limitQuistis1;
            public byte limitQuistis2;
            public byte limitZell1;
            public byte limitZell2;
            public byte limitIrvine;
            public byte limitSelphie;
            public byte limitAngeloCompleted;
            public byte limitAngeloKnown;
            public byte limitAngeloPoints1;
            public byte limitAngeloPoints2;
            public byte limitAngeloPoints3;
            public byte limitAngeloPoints4;
            public byte limitAngeloPoints5;
            public byte limitAngeloPoints6;
            public byte limitAngeloPoints7;
            public byte limitAngeloPoints8;
        }

        public struct ItemsBattleOrderData
        {

        }

        public struct ItemsData
        {
            public byte Item1;
            public byte Item2;
            public byte Item3;
            public byte Item4;
            public byte Item5;
            public byte Item6;
            public byte Item7;
            public byte Item8;
            public byte Item9;
            public byte Item10;
            public byte Item11;
            public byte Item12;
            public byte Item13;
            public byte Item14;
            public byte Item15;
            public byte Item16;
            public byte Item17;
            public byte Item18;
            public byte Item19;
            public byte Item20;
            public byte Item21;
            public byte Item22;
            public byte Item23;
            public byte Item24;
            public byte Item25;
            public byte Item26;
            public byte Item27;
            public byte Item28;
            public byte Item29;
            public byte Item30;
            public byte Item31;
            public byte Item32;
            public byte Item33;
            public byte Item34;
            public byte Item35;
            public byte Item36;
            public byte Item37;
            public byte Item38;
            public byte Item39;
            public byte Item40;
            public byte Item41;
            public byte Item42;
            public byte Item43;
            public byte Item44;
            public byte Item45;
            public byte Item46;
            public byte Item47;
            public byte Item48;
            public byte Item49;
            public byte Item50;
            public byte Item51;
            public byte Item52;
            public byte Item53;
            public byte Item54;
            public byte Item55;
            public byte Item56;
            public byte Item57;
            public byte Item58;
            public byte Item59;
            public byte Item60;
            public byte Item61;
            public byte Item62;
            public byte Item63;
            public byte Item64;
            public byte Item65;
            public byte Item66;
            public byte Item67;
            public byte Item68;
            public byte Item69;
            public byte Item70;
            public byte Item71;
            public byte Item72;
            public byte Item73;
            public byte Item74;
            public byte Item75;
            public byte Item76;
            public byte Item77;
            public byte Item78;
            public byte Item79;
            public byte Item80;
            public byte Item81;
            public byte Item82;
            public byte Item83;
            public byte Item84;
            public byte Item85;
            public byte Item86;
            public byte Item87;
            public byte Item88;
            public byte Item89;
            public byte Item90;
            public byte Item91;
            public byte Item92;
            public byte Item93;
            public byte Item94;
            public byte Item95;
            public byte Item96;
            public byte Item97;
            public byte Item98;
            public byte Item99;
            public byte Item100;
            public byte Item101;
            public byte Item102;
            public byte Item103;
            public byte Item104;
            public byte Item105;
            public byte Item106;
            public byte Item107;
            public byte Item108;
            public byte Item109;
            public byte Item110;
            public byte Item111;
            public byte Item112;
            public byte Item113;
            public byte Item114;
            public byte Item115;
            public byte Item116;
            public byte Item117;
            public byte Item118;
            public byte Item119;
            public byte Item120;
            public byte Item121;
            public byte Item122;
            public byte Item123;
            public byte Item124;
            public byte Item125;
            public byte Item126;
            public byte Item127;
            public byte Item128;
            public byte Item129;
            public byte Item130;
            public byte Item131;
            public byte Item132;
            public byte Item133;
            public byte Item134;
            public byte Item135;
            public byte Item136;
            public byte Item137;
            public byte Item138;
            public byte Item139;
            public byte Item140;
            public byte Item141;
            public byte Item142;
            public byte Item143;
            public byte Item144;
            public byte Item145;
            public byte Item146;
            public byte Item147;
            public byte Item148;
            public byte Item149;
            public byte Item150;
            public byte Item151;
            public byte Item152;
            public byte Item153;
            public byte Item154;
            public byte Item155;
            public byte Item156;
            public byte Item157;
            public byte Item158;
            public byte Item159;
            public byte Item160;
            public byte Item161;
            public byte Item162;
            public byte Item163;
            public byte Item164;
            public byte Item165;
            public byte Item166;
            public byte Item167;
            public byte Item168;
            public byte Item169;
            public byte Item170;
            public byte Item171;
            public byte Item172;
            public byte Item173;
            public byte Item174;
            public byte Item175;
            public byte Item176;
            public byte Item177;
            public byte Item178;
            public byte Item179;
            public byte Item180;
            public byte Item181;
            public byte Item182;
            public byte Item183;
            public byte Item184;
            public byte Item185;
            public byte Item186;
            public byte Item187;
            public byte Item188;
            public byte Item189;
            public byte Item190;
            public byte Item191;
            public byte Item192;
            public byte Item193;
            public byte Item194;
            public byte Item195;
            public byte Item196;
            public byte Item197;
            public byte Item198;
            public byte Item1Quantity;
            public byte Item2Quantity;
            public byte Item3Quantity;
            public byte Item4Quantity;
            public byte Item5Quantity;
            public byte Item6Quantity;
            public byte Item7Quantity;
            public byte Item8Quantity;
            public byte Item9Quantity;
            public byte Item10Quantity;
            public byte Item11Quantity;
            public byte Item12Quantity;
            public byte Item13Quantity;
            public byte Item14Quantity;
            public byte Item15Quantity;
            public byte Item16Quantity;
            public byte Item17Quantity;
            public byte Item18Quantity;
            public byte Item19Quantity;
            public byte Item20Quantity;
            public byte Item21Quantity;
            public byte Item22Quantity;
            public byte Item23Quantity;
            public byte Item24Quantity;
            public byte Item25Quantity;
            public byte Item26Quantity;
            public byte Item27Quantity;
            public byte Item28Quantity;
            public byte Item29Quantity;
            public byte Item30Quantity;
            public byte Item31Quantity;
            public byte Item32Quantity;
            public byte Item33Quantity;
            public byte Item34Quantity;
            public byte Item35Quantity;
            public byte Item36Quantity;
            public byte Item37Quantity;
            public byte Item38Quantity;
            public byte Item39Quantity;
            public byte Item40Quantity;
            public byte Item41Quantity;
            public byte Item42Quantity;
            public byte Item43Quantity;
            public byte Item44Quantity;
            public byte Item45Quantity;
            public byte Item46Quantity;
            public byte Item47Quantity;
            public byte Item48Quantity;
            public byte Item49Quantity;
            public byte Item50Quantity;
            public byte Item51Quantity;
            public byte Item52Quantity;
            public byte Item53Quantity;
            public byte Item54Quantity;
            public byte Item55Quantity;
            public byte Item56Quantity;
            public byte Item57Quantity;
            public byte Item58Quantity;
            public byte Item59Quantity;
            public byte Item60Quantity;
            public byte Item61Quantity;
            public byte Item62Quantity;
            public byte Item63Quantity;
            public byte Item64Quantity;
            public byte Item65Quantity;
            public byte Item66Quantity;
            public byte Item67Quantity;
            public byte Item68Quantity;
            public byte Item69Quantity;
            public byte Item70Quantity;
            public byte Item71Quantity;
            public byte Item72Quantity;
            public byte Item73Quantity;
            public byte Item74Quantity;
            public byte Item75Quantity;
            public byte Item76Quantity;
            public byte Item77Quantity;
            public byte Item78Quantity;
            public byte Item79Quantity;
            public byte Item80Quantity;
            public byte Item81Quantity;
            public byte Item82Quantity;
            public byte Item83Quantity;
            public byte Item84Quantity;
            public byte Item85Quantity;
            public byte Item86Quantity;
            public byte Item87Quantity;
            public byte Item88Quantity;
            public byte Item89Quantity;
            public byte Item90Quantity;
            public byte Item91Quantity;
            public byte Item92Quantity;
            public byte Item93Quantity;
            public byte Item94Quantity;
            public byte Item95Quantity;
            public byte Item96Quantity;
            public byte Item97Quantity;
            public byte Item98Quantity;
            public byte Item99Quantity;
            public byte Item100Quantity;
            public byte Item101Quantity;
            public byte Item102Quantity;
            public byte Item103Quantity;
            public byte Item104Quantity;
            public byte Item105Quantity;
            public byte Item106Quantity;
            public byte Item107Quantity;
            public byte Item108Quantity;
            public byte Item109Quantity;
            public byte Item110Quantity;
            public byte Item111Quantity;
            public byte Item112Quantity;
            public byte Item113Quantity;
            public byte Item114Quantity;
            public byte Item115Quantity;
            public byte Item116Quantity;
            public byte Item117Quantity;
            public byte Item118Quantity;
            public byte Item119Quantity;
            public byte Item120Quantity;
            public byte Item121Quantity;
            public byte Item122Quantity;
            public byte Item123Quantity;
            public byte Item124Quantity;
            public byte Item125Quantity;
            public byte Item126Quantity;
            public byte Item127Quantity;
            public byte Item128Quantity;
            public byte Item129Quantity;
            public byte Item130Quantity;
            public byte Item131Quantity;
            public byte Item132Quantity;
            public byte Item133Quantity;
            public byte Item134Quantity;
            public byte Item135Quantity;
            public byte Item136Quantity;
            public byte Item137Quantity;
            public byte Item138Quantity;
            public byte Item139Quantity;
            public byte Item140Quantity;
            public byte Item141Quantity;
            public byte Item142Quantity;
            public byte Item143Quantity;
            public byte Item144Quantity;
            public byte Item145Quantity;
            public byte Item146Quantity;
            public byte Item147Quantity;
            public byte Item148Quantity;
            public byte Item149Quantity;
            public byte Item150Quantity;
            public byte Item151Quantity;
            public byte Item152Quantity;
            public byte Item153Quantity;
            public byte Item154Quantity;
            public byte Item155Quantity;
            public byte Item156Quantity;
            public byte Item157Quantity;
            public byte Item158Quantity;
            public byte Item159Quantity;
            public byte Item160Quantity;
            public byte Item161Quantity;
            public byte Item162Quantity;
            public byte Item163Quantity;
            public byte Item164Quantity;
            public byte Item165Quantity;
            public byte Item166Quantity;
            public byte Item167Quantity;
            public byte Item168Quantity;
            public byte Item169Quantity;
            public byte Item170Quantity;
            public byte Item171Quantity;
            public byte Item172Quantity;
            public byte Item173Quantity;
            public byte Item174Quantity;
            public byte Item175Quantity;
            public byte Item176Quantity;
            public byte Item177Quantity;
            public byte Item178Quantity;
            public byte Item179Quantity;
            public byte Item180Quantity;
            public byte Item181Quantity;
            public byte Item182Quantity;
            public byte Item183Quantity;
            public byte Item184Quantity;
            public byte Item185Quantity;
            public byte Item186Quantity;
            public byte Item187Quantity;
            public byte Item188Quantity;
            public byte Item189Quantity;
            public byte Item190Quantity;
            public byte Item191Quantity;
            public byte Item192Quantity;
            public byte Item193Quantity;
            public byte Item194Quantity;
            public byte Item195Quantity;
            public byte Item196Quantity;
            public byte Item197Quantity;
            public byte Item198Quantity;
        }

        #endregion


        #region WORD and DWORD to Init

        /// <summary>
        /// This is for 2 bytes
        /// </summary>
        /// <param name="a"></param>
        /// <param name="add"></param>
        private static void WordToInit(uint a, int add, byte mode)
        {
            byte[] bytes = BitConverter.GetBytes(a);
            switch (mode)
            {
                case (byte)Mode.Mode_GF:
                    Array.Copy(bytes, 0, Init, OffsetToGfSelected + add, 2);
                    break;
                case (byte)Mode.Mode_Characters:
                    Array.Copy(bytes, 0, Init, OffsetToCharacterSelected + add, 2);
                    break;
                case (byte)Mode.Mode_Config:
                    Array.Copy(bytes, 0, Init, OffsetToConfigSelected + add, 2);
                    break;
                case (byte)Mode.Mode_Misc:
                    Array.Copy(bytes, 0, Init, OffsetToMiscSelected + add, 2);
                    break;
                case (byte)Mode.Mode_Items:
                    Array.Copy(bytes, 0, Init, OffsetToItemsSelected + add, 2);
                    break;

                default:
                    return;
            }
        }


        /// <summary>
        /// This is for 4 bytes
        /// </summary>
        /// <param name="a"></param>
        /// <param name="add"></param>
        private static void DwordToInit(uint a, int add, byte mode)
        {
            byte[] bytes = BitConverter.GetBytes(a);
            switch (mode)
            {
                case (byte)Mode.Mode_GF:
                    Array.Copy(bytes, 0, Init, OffsetToGfSelected + add, 4);
                    break;
                case (byte)Mode.Mode_Characters:
                    Array.Copy(bytes, 0, Init, OffsetToCharacterSelected + add, 4);
                    break;
                case (byte)Mode.Mode_Config:
                    Array.Copy(bytes, 0, Init, OffsetToConfigSelected + add, 4);
                    break;
                case (byte)Mode.Mode_Misc:
                    Array.Copy(bytes, 0, Init, OffsetToMiscSelected + add, 4);
                    break;
                case (byte)Mode.Mode_Items:
                    Array.Copy(bytes, 0, Init, OffsetToItemsSelected + add, 4);
                    break;

                default:
                    return;
            }
        }

        enum Mode : byte
        {
            Mode_GF,
            Mode_Characters,
            Mode_Config,
            Mode_Misc,
            Mode_Items,
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
                    byte[] text = FF8Text.Cipher((string)variable);
                    int emptyLenght = 12 - text.Length;
                    if (emptyLenght > 0)
                    {
                        byte[] empty = new byte[emptyLenght];
                        byte[] temp = new byte[text.Length + empty.Length];
                        Buffer.BlockCopy(text, 0, temp, 0, text.Length);
                        Buffer.BlockCopy(empty, 0, temp, text.Length, empty.Length);

                        Array.Copy(temp, 0, Init, OffsetToGfSelected, 12);
                    }
                    else
                        Array.Copy(text, 0, Init, OffsetToGfSelected, 12);

                    return;
                case 1:
                    DwordToInit(Convert.ToUInt32(variable), 12, (byte)Mode.Mode_GF); //Exp
                    return;
                case 2:
                    Init[OffsetToGfSelected + 16] = Convert.ToByte(variable); //Unknown 1
                    return;
                case 3:
                    Init[OffsetToGfSelected + 17] = Convert.ToByte(variable); //Available
                    return;
                case 4:
                    WordToInit(Convert.ToUInt16(variable), 18, (byte)Mode.Mode_GF); //Current Hp
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
                    WordToInit(Convert.ToUInt16(variable), 60, (byte)Mode.Mode_GF); //Kills
                    return;
                case 44:
                    WordToInit(Convert.ToUInt16(variable), 62, (byte)Mode.Mode_GF); //KOs
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
                    WordToInit(Convert.ToUInt16(variable), 0, (byte)Mode.Mode_Characters); //Current Hp
                    return;
                case 1:
                    WordToInit(Convert.ToUInt16(variable), 2, (byte)Mode.Mode_Characters); //Max Hp
                    return;
                case 2:
                    DwordToInit(Convert.ToUInt32(variable), 4, (byte)Mode.Mode_Characters); //Exp
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
                    Init[OffsetToCharacterSelected + 108] = Convert.ToByte(variable); //JunStatusDef2
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
                    WordToInit(6000 - (Convert.ToUInt16(variable)) * (uint)5, 112, (byte)Mode.Mode_Characters); //GF Compatibility 1
                    return;
                case 108:
                    WordToInit(6000 - (Convert.ToUInt16(variable)) * (uint)5, 114, (byte)Mode.Mode_Characters); //GF Compatibility 2
                    return;
                case 109:
                    WordToInit(6000 - (Convert.ToUInt16(variable)) * (uint)5, 116, (byte)Mode.Mode_Characters); //GF Compatibility 3
                    return;
                case 110:
                    WordToInit(6000 - (Convert.ToUInt16(variable)) * (uint)5, 118, (byte)Mode.Mode_Characters); //GF Compatibility 4
                    return;
                case 111:
                    WordToInit(6000 - (Convert.ToUInt16(variable)) * (uint)5, 120, (byte)Mode.Mode_Characters); //GF Compatibility 5
                    return;
                case 112:
                    WordToInit(6000 - (Convert.ToUInt16(variable)) * (uint)5, 122, (byte)Mode.Mode_Characters); //GF Compatibility 6
                    return;
                case 113:
                    WordToInit(6000 - (Convert.ToUInt16(variable)) * (uint)5, 124, (byte)Mode.Mode_Characters); //GF Compatibility 7
                    return;
                case 114:
                    WordToInit(6000 - (Convert.ToUInt16(variable)) * (uint)5, 126, (byte)Mode.Mode_Characters); //GF Compatibility 8
                    return;
                case 115:
                    WordToInit(6000 - (Convert.ToUInt16(variable)) * (uint)5, 128, (byte)Mode.Mode_Characters); //GF Compatibility 9
                    return;
                case 116:
                    WordToInit(6000 - (Convert.ToUInt16(variable)) * (uint)5, 130, (byte)Mode.Mode_Characters); //GF Compatibility 10
                    return;
                case 117:
                    WordToInit(6000 - (Convert.ToUInt16(variable)) * (uint)5, 132, (byte)Mode.Mode_Characters); //GF Compatibility 11
                    return;
                case 118:
                    WordToInit(6000 - (Convert.ToUInt16(variable)) * (uint)5, 134, (byte)Mode.Mode_Characters); //GF Compatibility 12
                    return;
                case 119:
                    WordToInit(6000 - (Convert.ToUInt16(variable)) * (uint)5, 136, (byte)Mode.Mode_Characters); //GF Compatibility 13
                    return;
                case 120:
                    WordToInit(6000 - (Convert.ToUInt16(variable)) * (uint)5, 138, (byte)Mode.Mode_Characters); //GF Compatibility 14
                    return;
                case 121:
                    WordToInit(6000 - (Convert.ToUInt16(variable)) * (uint)5, 140, (byte)Mode.Mode_Characters); //GF Compatibility 15
                    return;
                case 122:
                    WordToInit(6000 - (Convert.ToUInt16(variable)) * (uint)5, 142, (byte)Mode.Mode_Characters); //GF Compatibility 16
                    return;
                case 123:
                    WordToInit(Convert.ToUInt16(variable), 144, (byte)Mode.Mode_Characters); //Kills
                    return;
                case 124:
                    WordToInit(Convert.ToUInt16(variable), 146, (byte)Mode.Mode_Characters); //KOs
                    return;
                case 125:
                    Init[OffsetToCharacterSelected + 148] = (byte)(Init[OffsetToCharacterSelected + 148] ^ Convert.ToByte(variable)); //Exist
                    return;
                case 126:
                    Init[OffsetToCharacterSelected + 149] = Convert.ToByte(variable); //Unk 4
                    return;
                case 127:
                    Init[OffsetToCharacterSelected + 150] = (byte)(Init[OffsetToCharacterSelected + 150] ^ Convert.ToByte(variable)); //Current Status
                    return;
                case 128:
                    Init[OffsetToCharacterSelected + 151] = Convert.ToByte(variable); //Unk 5
                    return;
            }
        }

        #endregion

        #region Write Config Variables

        public static void UpdateVariable_Config(int index, object variable)
        {
            if (!Form1._loaded || Init == null)
                return;
            switch (index)
            {
                case 0:
                    Init[OffsetToConfigSelected] = Convert.ToByte(variable); //battle speed
                    return;
                case 1:
                    Init[OffsetToConfigSelected + 1] = Convert.ToByte(variable); //battle message
                    return;
                case 2:
                    Init[OffsetToConfigSelected + 2] = Convert.ToByte(variable); //field message
                    return;
                case 3:
                    Init[OffsetToConfigSelected + 3] = Convert.ToByte(variable); //Volume
                    return;
                case 4:
                    Init[OffsetToConfigSelected + 4] = (byte)(Init[OffsetToConfigSelected + 4] ^ Convert.ToByte(variable)); //flag
                    return;
                case 5:
                    Init[OffsetToConfigSelected + 5] = (byte)(Init[OffsetToConfigSelected + 5] ^ Convert.ToByte(variable)); //scan
                    return;
                case 6:
                    Init[OffsetToConfigSelected + 6] = Convert.ToByte(variable); //camera movement
                    return;
                case 7:
                    Init[OffsetToConfigSelected + 7] = Convert.ToByte(variable); // key unk 1
                    return;
                case 8:
                    Init[OffsetToConfigSelected + 8] = Convert.ToByte(variable); //key escape
                    return;
                case 9:
                    Init[OffsetToConfigSelected + 9] = Convert.ToByte(variable); //key pov
                    return;
                case 10:
                    Init[OffsetToConfigSelected + 10] = Convert.ToByte(variable); //key window
                    return;
                case 11:
                    Init[OffsetToConfigSelected + 11] = Convert.ToByte(variable); //key trigger
                    return;
                case 12:
                    Init[OffsetToConfigSelected + 12] = Convert.ToByte(variable); //key cancel
                    return;
                case 13:
                    Init[OffsetToConfigSelected + 13] = Convert.ToByte(variable); //key menu
                    return;
                case 14:
                    Init[OffsetToConfigSelected + 14] = Convert.ToByte(variable); //key talk
                    return;
                case 15:
                    Init[OffsetToConfigSelected + 15] = Convert.ToByte(variable); //key triple triad
                    return;
                case 16:
                    Init[OffsetToConfigSelected + 16] = Convert.ToByte(variable); //key select
                    return;
                case 17:
                    Init[OffsetToConfigSelected + 17] = Convert.ToByte(variable); //key unk 2
                    return;
                case 18:
                    Init[OffsetToConfigSelected + 18] = Convert.ToByte(variable); //key unk 3
                    return;
                case 19:
                    Init[OffsetToConfigSelected + 19] = Convert.ToByte(variable); //key start
                    return;               
            }
        }

        #endregion

        #region Write Misc Variables

        public static void UpdateVariable_Misc(int index, object variable)
        {
            if (!Form1._loaded || Init == null)
                return;
            switch (index)
            {
                case 0:
                    Init[OffsetToMiscSelected] = (byte)(Init[OffsetToMiscSelected] ^ Convert.ToByte(variable)); //party member 1
                    return;
                case 1:
                    Init[OffsetToMiscSelected + 1] = (byte)(Init[OffsetToMiscSelected + 1] ^ Convert.ToByte(variable)); //party member 2
                    return;
                case 2:
                    Init[OffsetToMiscSelected + 2] = (byte)(Init[OffsetToMiscSelected + 2] ^ Convert.ToByte(variable)); //party member 3
                    return;
                case 3:
                    Init[OffsetToMiscSelected + 3] = (byte)(Init[OffsetToMiscSelected + 4] ^ Convert.ToByte(variable)); //known weapons 1
                    return;
                case 4:
                    Init[OffsetToMiscSelected + 4] = (byte)(Init[OffsetToMiscSelected + 5] ^ Convert.ToByte(variable)); //known weapons 2
                    return;
                case 5:
                    Init[OffsetToMiscSelected + 5] = (byte)(Init[OffsetToMiscSelected + 6] ^ Convert.ToByte(variable)); //known weapons 3
                    return;
                case 6:
                    Init[OffsetToMiscSelected + 6] = (byte)(Init[OffsetToMiscSelected + 7] ^ Convert.ToByte(variable)); //known weapons 4
                    return;
                case 7:
                    byte[] text = FF8Text.Cipher((string)variable);
                    int emptyLenght = 12 - text.Length;
                    if (emptyLenght > 0)
                    {
                        byte[] empty = new byte[emptyLenght];
                        byte[] temp = new byte[text.Length + empty.Length];
                        Buffer.BlockCopy(text, 0, temp, 0, text.Length);
                        Buffer.BlockCopy(empty, 0, temp, text.Length, empty.Length);

                        Array.Copy(temp, 0, Init, OffsetToMiscSelected + 8, 12);
                    }
                    else
                        Array.Copy(text, 0, Init, OffsetToMiscSelected + 8, 12);

                    return;
                case 8:
                    WordToInit(Convert.ToUInt16(variable), 20, (byte)Mode.Mode_Misc); //Unknown 1
                    return;
                case 9:
                    WordToInit(Convert.ToUInt16(variable), 22, (byte)Mode.Mode_Misc); //Unknown 2
                    return;
                case 10:
                    DwordToInit(Convert.ToUInt32(variable), 24, (byte)Mode.Mode_Misc); //Gil
                    return;
                case 11:
                    DwordToInit(Convert.ToUInt32(variable), 28, (byte)Mode.Mode_Misc); //Gil Laguna
                    return;
                case 12:
                    Init[OffsetToMiscSelected + 32] = (byte)(Init[OffsetToMiscSelected + 32] ^ Convert.ToByte(variable)); //Quistis LB 1
                    return;
                case 13:
                    Init[OffsetToMiscSelected + 33] = (byte)(Init[OffsetToMiscSelected + 33] ^ Convert.ToByte(variable)); //Quistis LB 1
                    return;
                case 14:
                    Init[OffsetToMiscSelected + 34] = (byte)(Init[OffsetToMiscSelected + 34] ^ Convert.ToByte(variable)); //Zell LB 1
                    return;
                case 15:
                    Init[OffsetToMiscSelected + 35] = (byte)(Init[OffsetToMiscSelected + 35] ^ Convert.ToByte(variable)); //Zell LB 1
                    return;
                case 16:
                    Init[OffsetToMiscSelected + 36] = (byte)(Init[OffsetToMiscSelected + 36] ^ Convert.ToByte(variable)); //Irvine LB 1
                    return;
                case 17:
                    Init[OffsetToMiscSelected + 37] = (byte)(Init[OffsetToMiscSelected + 37] ^ Convert.ToByte(variable)); //Selphie LB 1
                    return;
                case 18:
                    Init[OffsetToMiscSelected + 38] = (byte)(Init[OffsetToMiscSelected + 38] ^ Convert.ToByte(variable)); //Angelo Completed
                    return;
                case 19:
                    Init[OffsetToMiscSelected + 39] = (byte)(Init[OffsetToMiscSelected + 39] ^ Convert.ToByte(variable)); //Angelo Known
                    return;
                case 20:
                    Init[OffsetToItemsSelected + 40] = Convert.ToByte(variable); //Angelo Point 1
                    return;
                case 21:
                    Init[OffsetToItemsSelected + 41] = Convert.ToByte(variable); //Angelo Point 2
                    return;
                case 22:
                    Init[OffsetToItemsSelected + 42] = Convert.ToByte(variable); //Angelo Point 3
                    return;
                case 23:
                    Init[OffsetToItemsSelected + 43] = Convert.ToByte(variable); //Angelo Point 4
                    return;
                case 24:
                    Init[OffsetToItemsSelected + 44] = Convert.ToByte(variable); //Angelo Point 5
                    return;
                case 25:
                    Init[OffsetToItemsSelected + 45] = Convert.ToByte(variable); //Angelo Point 6
                    return;
                case 26:
                    Init[OffsetToItemsSelected + 46] = Convert.ToByte(variable); //Angelo Point 7
                    return;
                case 27:
                    Init[OffsetToItemsSelected + 47] = Convert.ToByte(variable); //Angelo Point 8
                    return;
            }
        }

        #endregion

        #region Write Items Variables

        public static void UpdateVariable_Items(int index, object variable)
        {
            if (!Form1._loaded || Init == null)
                return;
            switch (index)
            {
                case 0:
                    Init[OffsetToItemsSelected + 0] = Convert.ToByte(variable); //Item 1
                    return;
                case 1:
                    Init[OffsetToItemsSelected + 1] = Convert.ToByte(variable); //Item 1 Quantity
                    return;
                case 2:
                    Init[OffsetToItemsSelected + 2] = Convert.ToByte(variable); //Item 2
                    return;
                case 3:
                    Init[OffsetToItemsSelected + 3] = Convert.ToByte(variable); //Item 2 Quantity
                    return;
                case 4:
                    Init[OffsetToItemsSelected + 4] = Convert.ToByte(variable); //Item 3
                    return;
                case 5:
                    Init[OffsetToItemsSelected + 5] = Convert.ToByte(variable); //Item 3 Quantity
                    return;
                case 6:
                    Init[OffsetToItemsSelected + 6] = Convert.ToByte(variable); //Item 4
                    return;
                case 7:
                    Init[OffsetToItemsSelected + 7] = Convert.ToByte(variable); //Item 4 Quantity
                    return;
                case 8:
                    Init[OffsetToItemsSelected + 8] = Convert.ToByte(variable); //Item 5
                    return;
                case 9:
                    Init[OffsetToItemsSelected + 9] = Convert.ToByte(variable); //Item 5 Quantity
                    return;
                case 10:
                    Init[OffsetToItemsSelected + 10] = Convert.ToByte(variable); //Item 6
                    return;
                case 11:
                    Init[OffsetToItemsSelected + 11] = Convert.ToByte(variable); //Item 6 Quantity
                    return;
                case 12:
                    Init[OffsetToItemsSelected + 12] = Convert.ToByte(variable); //Item 7
                    return;
                case 13:
                    Init[OffsetToItemsSelected + 13] = Convert.ToByte(variable); //Item 7 Quantity
                    return;
                case 14:
                    Init[OffsetToItemsSelected + 14] = Convert.ToByte(variable); //Item 8
                    return;
                case 15:
                    Init[OffsetToItemsSelected + 15] = Convert.ToByte(variable); //Item 8 Quantity
                    return;
                case 16:
                    Init[OffsetToItemsSelected + 16] = Convert.ToByte(variable); //Item 9
                    return;
                case 17:
                    Init[OffsetToItemsSelected + 17] = Convert.ToByte(variable); //Item 9 Quantity
                    return;
                case 18:
                    Init[OffsetToItemsSelected + 18] = Convert.ToByte(variable); //Item 10
                    return;
                case 19:
                    Init[OffsetToItemsSelected + 19] = Convert.ToByte(variable); //Item 10 Quantity
                    return;
                case 20:
                    Init[OffsetToItemsSelected + 20] = Convert.ToByte(variable); //Item 11
                    return;
                case 21:
                    Init[OffsetToItemsSelected + 21] = Convert.ToByte(variable); //Item 11 Quantity
                    return;
                case 22:
                    Init[OffsetToItemsSelected + 22] = Convert.ToByte(variable); //Item 12
                    return;
                case 23:
                    Init[OffsetToItemsSelected + 23] = Convert.ToByte(variable); //Item 12 Quantity
                    return;
                case 24:
                    Init[OffsetToItemsSelected + 24] = Convert.ToByte(variable); //Item 13
                    return;
                case 25:
                    Init[OffsetToItemsSelected + 25] = Convert.ToByte(variable); //Item 13 Quantity
                    return;
                case 26:
                    Init[OffsetToItemsSelected + 26] = Convert.ToByte(variable); //Item 14
                    return;
                case 27:
                    Init[OffsetToItemsSelected + 27] = Convert.ToByte(variable); //Item 14 Quantity
                    return;
                case 28:
                    Init[OffsetToItemsSelected + 28] = Convert.ToByte(variable); //Item 15
                    return;
                case 29:
                    Init[OffsetToItemsSelected + 29] = Convert.ToByte(variable); //Item 15 Quantity
                    return;
                case 30:
                    Init[OffsetToItemsSelected + 30] = Convert.ToByte(variable); //Item 16
                    return;
                case 31:
                    Init[OffsetToItemsSelected + 31] = Convert.ToByte(variable); //Item 16 Quantity
                    return;
                case 32:
                    Init[OffsetToItemsSelected + 32] = Convert.ToByte(variable); //Item 17
                    return;
                case 33:
                    Init[OffsetToItemsSelected + 33] = Convert.ToByte(variable); //Item 17 Quantity
                    return;
                case 34:
                    Init[OffsetToItemsSelected + 34] = Convert.ToByte(variable); //Item 18
                    return;
                case 35:
                    Init[OffsetToItemsSelected + 35] = Convert.ToByte(variable); //Item 18 Quantity
                    return;
                case 36:
                    Init[OffsetToItemsSelected + 36] = Convert.ToByte(variable); //Item 19
                    return;
                case 37:
                    Init[OffsetToItemsSelected + 37] = Convert.ToByte(variable); //Item 19 Quantity
                    return;
                case 38:
                    Init[OffsetToItemsSelected + 38] = Convert.ToByte(variable); //Item 20
                    return;
                case 39:
                    Init[OffsetToItemsSelected + 39] = Convert.ToByte(variable); //Item 20 Quantity
                    return;
                case 40:
                    Init[OffsetToItemsSelected + 40] = Convert.ToByte(variable); //Item 21
                    return;
                case 41:
                    Init[OffsetToItemsSelected + 41] = Convert.ToByte(variable); //Item 21 Quantity
                    return;
                case 42:
                    Init[OffsetToItemsSelected + 42] = Convert.ToByte(variable); //Item 22
                    return;
                case 43:
                    Init[OffsetToItemsSelected + 43] = Convert.ToByte(variable); //Item 22 Quantity
                    return;
                case 44:
                    Init[OffsetToItemsSelected + 44] = Convert.ToByte(variable); //Item 23
                    return;
                case 45:
                    Init[OffsetToItemsSelected + 45] = Convert.ToByte(variable); //Item 23 Quantity
                    return;
                case 46:
                    Init[OffsetToItemsSelected + 46] = Convert.ToByte(variable); //Item 24
                    return;
                case 47:
                    Init[OffsetToItemsSelected + 47] = Convert.ToByte(variable); //Item 24 Quantity
                    return;
                case 48:
                    Init[OffsetToItemsSelected + 48] = Convert.ToByte(variable); //Item 25
                    return;
                case 49:
                    Init[OffsetToItemsSelected + 49] = Convert.ToByte(variable); //Item 25 Quantity
                    return;
                case 50:
                    Init[OffsetToItemsSelected + 50] = Convert.ToByte(variable); //Item 26
                    return;
                case 51:
                    Init[OffsetToItemsSelected + 51] = Convert.ToByte(variable); //Item 26 Quantity
                    return;
                case 52:
                    Init[OffsetToItemsSelected + 52] = Convert.ToByte(variable); //Item 27
                    return;
                case 53:
                    Init[OffsetToItemsSelected + 53] = Convert.ToByte(variable); //Item 27 Quantity
                    return;
                case 54:
                    Init[OffsetToItemsSelected + 54] = Convert.ToByte(variable); //Item 28
                    return;
                case 55:
                    Init[OffsetToItemsSelected + 55] = Convert.ToByte(variable); //Item 28 Quantity
                    return;
                case 56:
                    Init[OffsetToItemsSelected + 56] = Convert.ToByte(variable); //Item 29
                    return;
                case 57:
                    Init[OffsetToItemsSelected + 57] = Convert.ToByte(variable); //Item 29 Quantity
                    return;
                case 58:
                    Init[OffsetToItemsSelected + 58] = Convert.ToByte(variable); //Item 30
                    return;
                case 59:
                    Init[OffsetToItemsSelected + 59] = Convert.ToByte(variable); //Item 30 Quantity
                    return;
                case 60:
                    Init[OffsetToItemsSelected + 60] = Convert.ToByte(variable); //Item 31
                    return;
                case 61:
                    Init[OffsetToItemsSelected + 61] = Convert.ToByte(variable); //Item 31 Quantity
                    return;
                case 62:
                    Init[OffsetToItemsSelected + 62] = Convert.ToByte(variable); //Item 32
                    return;
                case 63:
                    Init[OffsetToItemsSelected + 63] = Convert.ToByte(variable); //Item 32 Quantity
                    return;
                case 64:
                    Init[OffsetToItemsSelected + 64] = Convert.ToByte(variable); //Item 33
                    return;
                case 65:
                    Init[OffsetToItemsSelected + 65] = Convert.ToByte(variable); //Item 33 Quantity
                    return;
                case 66:
                    Init[OffsetToItemsSelected + 66] = Convert.ToByte(variable); //Item 34
                    return;
                case 67:
                    Init[OffsetToItemsSelected + 67] = Convert.ToByte(variable); //Item 34 Quantity
                    return;
                case 68:
                    Init[OffsetToItemsSelected + 68] = Convert.ToByte(variable); //Item 35
                    return;
                case 69:
                    Init[OffsetToItemsSelected + 69] = Convert.ToByte(variable); //Item 35 Quantity
                    return;
                case 70:
                    Init[OffsetToItemsSelected + 70] = Convert.ToByte(variable); //Item 36
                    return;
                case 71:
                    Init[OffsetToItemsSelected + 71] = Convert.ToByte(variable); //Item 36 Quantity
                    return;
                case 72:
                    Init[OffsetToItemsSelected + 72] = Convert.ToByte(variable); //Item 37
                    return;
                case 73:
                    Init[OffsetToItemsSelected + 73] = Convert.ToByte(variable); //Item 37 Quantity
                    return;
                case 74:
                    Init[OffsetToItemsSelected + 74] = Convert.ToByte(variable); //Item 38
                    return;
                case 75:
                    Init[OffsetToItemsSelected + 75] = Convert.ToByte(variable); //Item 38 Quantity
                    return;
                case 76:
                    Init[OffsetToItemsSelected + 76] = Convert.ToByte(variable); //Item 39
                    return;
                case 77:
                    Init[OffsetToItemsSelected + 77] = Convert.ToByte(variable); //Item 39 Quantity
                    return;
                case 78:
                    Init[OffsetToItemsSelected + 78] = Convert.ToByte(variable); //Item 40
                    return;
                case 79:
                    Init[OffsetToItemsSelected + 79] = Convert.ToByte(variable); //Item 40 Quantity
                    return;
                case 80:
                    Init[OffsetToItemsSelected + 80] = Convert.ToByte(variable); //Item 41
                    return;
                case 81:
                    Init[OffsetToItemsSelected + 81] = Convert.ToByte(variable); //Item 41 Quantity
                    return;
                case 82:
                    Init[OffsetToItemsSelected + 82] = Convert.ToByte(variable); //Item 42
                    return;
                case 83:
                    Init[OffsetToItemsSelected + 83] = Convert.ToByte(variable); //Item 42 Quantity
                    return;
                case 84:
                    Init[OffsetToItemsSelected + 84] = Convert.ToByte(variable); //Item 43
                    return;
                case 85:
                    Init[OffsetToItemsSelected + 85] = Convert.ToByte(variable); //Item 43 Quantity
                    return;
                case 86:
                    Init[OffsetToItemsSelected + 86] = Convert.ToByte(variable); //Item 44
                    return;
                case 87:
                    Init[OffsetToItemsSelected + 87] = Convert.ToByte(variable); //Item 44 Quantity
                    return;
                case 88:
                    Init[OffsetToItemsSelected + 88] = Convert.ToByte(variable); //Item 45
                    return;
                case 89:
                    Init[OffsetToItemsSelected + 89] = Convert.ToByte(variable); //Item 45 Quantity
                    return;
                case 90:
                    Init[OffsetToItemsSelected + 90] = Convert.ToByte(variable); //Item 46
                    return;
                case 91:
                    Init[OffsetToItemsSelected + 91] = Convert.ToByte(variable); //Item 46 Quantity
                    return;
                case 92:
                    Init[OffsetToItemsSelected + 92] = Convert.ToByte(variable); //Item 47
                    return;
                case 93:
                    Init[OffsetToItemsSelected + 93] = Convert.ToByte(variable); //Item 47 Quantity
                    return;
                case 94:
                    Init[OffsetToItemsSelected + 94] = Convert.ToByte(variable); //Item 48
                    return;
                case 95:
                    Init[OffsetToItemsSelected + 95] = Convert.ToByte(variable); //Item 48 Quantity
                    return;
                case 96:
                    Init[OffsetToItemsSelected + 96] = Convert.ToByte(variable); //Item 49
                    return;
                case 97:
                    Init[OffsetToItemsSelected + 97] = Convert.ToByte(variable); //Item 49 Quantity
                    return;
                case 98:
                    Init[OffsetToItemsSelected + 98] = Convert.ToByte(variable); //Item 50
                    return;
                case 99:
                    Init[OffsetToItemsSelected + 99] = Convert.ToByte(variable); //Item 50 Quantity
                    return;
                case 100:
                    Init[OffsetToItemsSelected + 100] = Convert.ToByte(variable); //Item 51
                    return;
                case 101:
                    Init[OffsetToItemsSelected + 101] = Convert.ToByte(variable); //Item 51 Quantity
                    return;
                case 102:
                    Init[OffsetToItemsSelected + 102] = Convert.ToByte(variable); //Item 52
                    return;
                case 103:
                    Init[OffsetToItemsSelected + 103] = Convert.ToByte(variable); //Item 52 Quantity
                    return;
                case 104:
                    Init[OffsetToItemsSelected + 104] = Convert.ToByte(variable); //Item 53
                    return;
                case 105:
                    Init[OffsetToItemsSelected + 105] = Convert.ToByte(variable); //Item 53 Quantity
                    return;
                case 106:
                    Init[OffsetToItemsSelected + 106] = Convert.ToByte(variable); //Item 54
                    return;
                case 107:
                    Init[OffsetToItemsSelected + 107] = Convert.ToByte(variable); //Item 54 Quantity
                    return;
                case 108:
                    Init[OffsetToItemsSelected + 108] = Convert.ToByte(variable); //Item 55
                    return;
                case 109:
                    Init[OffsetToItemsSelected + 109] = Convert.ToByte(variable); //Item 55 Quantity
                    return;
                case 110:
                    Init[OffsetToItemsSelected + 110] = Convert.ToByte(variable); //Item 56
                    return;
                case 111:
                    Init[OffsetToItemsSelected + 111] = Convert.ToByte(variable); //Item 56 Quantity
                    return;
                case 112:
                    Init[OffsetToItemsSelected + 112] = Convert.ToByte(variable); //Item 57
                    return;
                case 113:
                    Init[OffsetToItemsSelected + 113] = Convert.ToByte(variable); //Item 57 Quantity
                    return;
                case 114:
                    Init[OffsetToItemsSelected + 114] = Convert.ToByte(variable); //Item 58
                    return;
                case 115:
                    Init[OffsetToItemsSelected + 115] = Convert.ToByte(variable); //Item 58 Quantity
                    return;
                case 116:
                    Init[OffsetToItemsSelected + 116] = Convert.ToByte(variable); //Item 59
                    return;
                case 117:
                    Init[OffsetToItemsSelected + 117] = Convert.ToByte(variable); //Item 59 Quantity
                    return;
                case 118:
                    Init[OffsetToItemsSelected + 118] = Convert.ToByte(variable);
                    return;
                case 119:
                    Init[OffsetToItemsSelected + 119] = Convert.ToByte(variable);
                    return;
                case 120:
                    Init[OffsetToItemsSelected + 120] = Convert.ToByte(variable);
                    return;
                case 121:
                    Init[OffsetToItemsSelected + 121] = Convert.ToByte(variable);
                    return;
                case 122:
                    Init[OffsetToItemsSelected + 122] = Convert.ToByte(variable);
                    return;
                case 123:
                    Init[OffsetToItemsSelected + 123] = Convert.ToByte(variable);
                    return;
                case 124:
                    Init[OffsetToItemsSelected + 124] = Convert.ToByte(variable);
                    return;
                case 125:
                    Init[OffsetToItemsSelected + 125] = Convert.ToByte(variable);
                    return;
                case 126:
                    Init[OffsetToItemsSelected + 126] = Convert.ToByte(variable);
                    return;
                case 127:
                    Init[OffsetToItemsSelected + 127] = Convert.ToByte(variable);
                    return;
                case 128:
                    Init[OffsetToItemsSelected + 128] = Convert.ToByte(variable);
                    return;
                case 129:
                    Init[OffsetToItemsSelected + 129] = Convert.ToByte(variable);
                    return;
                case 130:
                    Init[OffsetToItemsSelected + 130] = Convert.ToByte(variable);
                    return;
                case 131:
                    Init[OffsetToItemsSelected + 131] = Convert.ToByte(variable);
                    return;
                case 132:
                    Init[OffsetToItemsSelected + 132] = Convert.ToByte(variable);
                    return;
                case 133:
                    Init[OffsetToItemsSelected + 133] = Convert.ToByte(variable);
                    return;
                case 134:
                    Init[OffsetToItemsSelected + 134] = Convert.ToByte(variable);
                    return;
                case 135:
                    Init[OffsetToItemsSelected + 135] = Convert.ToByte(variable);
                    return;
                case 136:
                    Init[OffsetToItemsSelected + 136] = Convert.ToByte(variable);
                    return;
                case 137:
                    Init[OffsetToItemsSelected + 137] = Convert.ToByte(variable);
                    return;
                case 138:
                    Init[OffsetToItemsSelected + 138] = Convert.ToByte(variable);
                    return;
                case 139:
                    Init[OffsetToItemsSelected + 139] = Convert.ToByte(variable);
                    return;
                case 140:
                    Init[OffsetToItemsSelected + 140] = Convert.ToByte(variable);
                    return;
                case 141:
                    Init[OffsetToItemsSelected + 141] = Convert.ToByte(variable);
                    return;
                case 142:
                    Init[OffsetToItemsSelected + 142] = Convert.ToByte(variable);
                    return;
                case 143:
                    Init[OffsetToItemsSelected + 143] = Convert.ToByte(variable);
                    return;
                case 144:
                    Init[OffsetToItemsSelected + 144] = Convert.ToByte(variable);
                    return;
                case 145:
                    Init[OffsetToItemsSelected + 145] = Convert.ToByte(variable);
                    return;
                case 146:
                    Init[OffsetToItemsSelected + 146] = Convert.ToByte(variable);
                    return;
                case 147:
                    Init[OffsetToItemsSelected + 147] = Convert.ToByte(variable);
                    return;
                case 148:
                    Init[OffsetToItemsSelected + 148] = Convert.ToByte(variable);
                    return;
                case 149:
                    Init[OffsetToItemsSelected + 149] = Convert.ToByte(variable);
                    return;
                case 150:
                    Init[OffsetToItemsSelected + 150] = Convert.ToByte(variable);
                    return;
                case 151:
                    Init[OffsetToItemsSelected + 151] = Convert.ToByte(variable);
                    return;
                case 152:
                    Init[OffsetToItemsSelected + 152] = Convert.ToByte(variable);
                    return;
                case 153:
                    Init[OffsetToItemsSelected + 153] = Convert.ToByte(variable);
                    return;
                case 154:
                    Init[OffsetToItemsSelected + 154] = Convert.ToByte(variable);
                    return;
                case 155:
                    Init[OffsetToItemsSelected + 155] = Convert.ToByte(variable);
                    return;
                case 156:
                    Init[OffsetToItemsSelected + 156] = Convert.ToByte(variable);
                    return;
                case 157:
                    Init[OffsetToItemsSelected + 157] = Convert.ToByte(variable);
                    return;
                case 158:
                    Init[OffsetToItemsSelected + 158] = Convert.ToByte(variable);
                    return;
                case 159:
                    Init[OffsetToItemsSelected + 159] = Convert.ToByte(variable);
                    return;
                case 160:
                    Init[OffsetToItemsSelected + 160] = Convert.ToByte(variable);
                    return;
                case 161:
                    Init[OffsetToItemsSelected + 161] = Convert.ToByte(variable);
                    return;
                case 162:
                    Init[OffsetToItemsSelected + 162] = Convert.ToByte(variable);
                    return;
                case 163:
                    Init[OffsetToItemsSelected + 163] = Convert.ToByte(variable);
                    return;
                case 164:
                    Init[OffsetToItemsSelected + 164] = Convert.ToByte(variable);
                    return;
                case 165:
                    Init[OffsetToItemsSelected + 165] = Convert.ToByte(variable);
                    return;
                case 166:
                    Init[OffsetToItemsSelected + 166] = Convert.ToByte(variable);
                    return;
                case 167:
                    Init[OffsetToItemsSelected + 167] = Convert.ToByte(variable);
                    return;
                case 168:
                    Init[OffsetToItemsSelected + 168] = Convert.ToByte(variable);
                    return;
                case 169:
                    Init[OffsetToItemsSelected + 169] = Convert.ToByte(variable);
                    return;
                case 170:
                    Init[OffsetToItemsSelected + 170] = Convert.ToByte(variable);
                    return;
                case 171:
                    Init[OffsetToItemsSelected + 171] = Convert.ToByte(variable);
                    return;
                case 172:
                    Init[OffsetToItemsSelected + 172] = Convert.ToByte(variable);
                    return;
                case 173:
                    Init[OffsetToItemsSelected + 173] = Convert.ToByte(variable);
                    return;
                case 174:
                    Init[OffsetToItemsSelected + 174] = Convert.ToByte(variable);
                    return;
                case 175:
                    Init[OffsetToItemsSelected + 175] = Convert.ToByte(variable);
                    return;
                case 176:
                    Init[OffsetToItemsSelected + 176] = Convert.ToByte(variable);
                    return;
                case 177:
                    Init[OffsetToItemsSelected + 177] = Convert.ToByte(variable);
                    return;
                case 178:
                    Init[OffsetToItemsSelected + 178] = Convert.ToByte(variable);
                    return;
                case 179:
                    Init[OffsetToItemsSelected + 179] = Convert.ToByte(variable);
                    return;
                case 180:
                    Init[OffsetToItemsSelected + 180] = Convert.ToByte(variable);
                    return;
                case 181:
                    Init[OffsetToItemsSelected + 181] = Convert.ToByte(variable);
                    return;
                case 182:
                    Init[OffsetToItemsSelected + 182] = Convert.ToByte(variable);
                    return;
                case 183:
                    Init[OffsetToItemsSelected + 183] = Convert.ToByte(variable);
                    return;
                case 184:
                    Init[OffsetToItemsSelected + 184] = Convert.ToByte(variable);
                    return;
                case 185:
                    Init[OffsetToItemsSelected + 185] = Convert.ToByte(variable);
                    return;
                case 186:
                    Init[OffsetToItemsSelected + 186] = Convert.ToByte(variable);
                    return;
                case 187:
                    Init[OffsetToItemsSelected + 187] = Convert.ToByte(variable);
                    return;
                case 188:
                    Init[OffsetToItemsSelected + 188] = Convert.ToByte(variable);
                    return;
                case 189:
                    Init[OffsetToItemsSelected + 189] = Convert.ToByte(variable);
                    return;
                case 190:
                    Init[OffsetToItemsSelected + 190] = Convert.ToByte(variable);
                    return;
                case 191:
                    Init[OffsetToItemsSelected + 191] = Convert.ToByte(variable);
                    return;
                case 192:
                    Init[OffsetToItemsSelected + 192] = Convert.ToByte(variable);
                    return;
                case 193:
                    Init[OffsetToItemsSelected + 193] = Convert.ToByte(variable);
                    return;
                case 194:
                    Init[OffsetToItemsSelected + 194] = Convert.ToByte(variable);
                    return;
                case 195:
                    Init[OffsetToItemsSelected + 195] = Convert.ToByte(variable);
                    return;
                case 196:
                    Init[OffsetToItemsSelected + 196] = Convert.ToByte(variable);
                    return;
                case 197:
                    Init[OffsetToItemsSelected + 197] = Convert.ToByte(variable);
                    return;
                case 198:
                    Init[OffsetToItemsSelected + 198] = Convert.ToByte(variable);
                    return;
                case 199:
                    Init[OffsetToItemsSelected + 199] = Convert.ToByte(variable);
                    return;
                case 200:
                    Init[OffsetToItemsSelected + 200] = Convert.ToByte(variable);
                    return;
                case 201:
                    Init[OffsetToItemsSelected + 201] = Convert.ToByte(variable);
                    return;
                case 202:
                    Init[OffsetToItemsSelected + 202] = Convert.ToByte(variable);
                    return;
                case 203:
                    Init[OffsetToItemsSelected + 203] = Convert.ToByte(variable);
                    return;
                case 204:
                    Init[OffsetToItemsSelected + 204] = Convert.ToByte(variable);
                    return;
                case 205:
                    Init[OffsetToItemsSelected + 205] = Convert.ToByte(variable);
                    return;
                case 206:
                    Init[OffsetToItemsSelected + 206] = Convert.ToByte(variable);
                    return;
                case 207:
                    Init[OffsetToItemsSelected + 207] = Convert.ToByte(variable);
                    return;
                case 208:
                    Init[OffsetToItemsSelected + 208] = Convert.ToByte(variable);
                    return;
                case 209:
                    Init[OffsetToItemsSelected + 209] = Convert.ToByte(variable);
                    return;
                case 210:
                    Init[OffsetToItemsSelected + 210] = Convert.ToByte(variable);
                    return;
                case 211:
                    Init[OffsetToItemsSelected + 211] = Convert.ToByte(variable);
                    return;
                case 212:
                    Init[OffsetToItemsSelected + 212] = Convert.ToByte(variable);
                    return;
                case 213:
                    Init[OffsetToItemsSelected + 213] = Convert.ToByte(variable);
                    return;
                case 214:
                    Init[OffsetToItemsSelected + 214] = Convert.ToByte(variable);
                    return;
                case 215:
                    Init[OffsetToItemsSelected + 215] = Convert.ToByte(variable);
                    return;
                case 216:
                    Init[OffsetToItemsSelected + 216] = Convert.ToByte(variable);
                    return;
                case 217:
                    Init[OffsetToItemsSelected + 217] = Convert.ToByte(variable);
                    return;
                case 218:
                    Init[OffsetToItemsSelected + 218] = Convert.ToByte(variable);
                    return;
                case 219:
                    Init[OffsetToItemsSelected + 219] = Convert.ToByte(variable);
                    return;
                case 220:
                    Init[OffsetToItemsSelected + 220] = Convert.ToByte(variable);
                    return;
                case 221:
                    Init[OffsetToItemsSelected + 221] = Convert.ToByte(variable);
                    return;
                case 222:
                    Init[OffsetToItemsSelected + 222] = Convert.ToByte(variable);
                    return;
                case 223:
                    Init[OffsetToItemsSelected + 223] = Convert.ToByte(variable);
                    return;
                case 224:
                    Init[OffsetToItemsSelected + 224] = Convert.ToByte(variable);
                    return;
                case 225:
                    Init[OffsetToItemsSelected + 225] = Convert.ToByte(variable);
                    return;
                case 226:
                    Init[OffsetToItemsSelected + 226] = Convert.ToByte(variable);
                    return;
                case 227:
                    Init[OffsetToItemsSelected + 227] = Convert.ToByte(variable);
                    return;
                case 228:
                    Init[OffsetToItemsSelected + 228] = Convert.ToByte(variable);
                    return;
                case 229:
                    Init[OffsetToItemsSelected + 229] = Convert.ToByte(variable);
                    return;
                case 230:
                    Init[OffsetToItemsSelected + 230] = Convert.ToByte(variable);
                    return;
                case 231:
                    Init[OffsetToItemsSelected + 231] = Convert.ToByte(variable);
                    return;
                case 232:
                    Init[OffsetToItemsSelected + 232] = Convert.ToByte(variable);
                    return;
                case 233:
                    Init[OffsetToItemsSelected + 233] = Convert.ToByte(variable);
                    return;
                case 234:
                    Init[OffsetToItemsSelected + 234] = Convert.ToByte(variable);
                    return;
                case 235:
                    Init[OffsetToItemsSelected + 235] = Convert.ToByte(variable);
                    return;
                case 236:
                    Init[OffsetToItemsSelected + 236] = Convert.ToByte(variable);
                    return;
                case 237:
                    Init[OffsetToItemsSelected + 237] = Convert.ToByte(variable);
                    return;
                case 238:
                    Init[OffsetToItemsSelected + 238] = Convert.ToByte(variable);
                    return;
                case 239:
                    Init[OffsetToItemsSelected + 239] = Convert.ToByte(variable);
                    return;
                case 240:
                    Init[OffsetToItemsSelected + 240] = Convert.ToByte(variable);
                    return;
                case 241:
                    Init[OffsetToItemsSelected + 241] = Convert.ToByte(variable);
                    return;
                case 242:
                    Init[OffsetToItemsSelected + 242] = Convert.ToByte(variable);
                    return;
                case 243:
                    Init[OffsetToItemsSelected + 243] = Convert.ToByte(variable);
                    return;
                case 244:
                    Init[OffsetToItemsSelected + 244] = Convert.ToByte(variable);
                    return;
                case 245:
                    Init[OffsetToItemsSelected + 245] = Convert.ToByte(variable);
                    return;
                case 246:
                    Init[OffsetToItemsSelected + 246] = Convert.ToByte(variable);
                    return;
                case 247:
                    Init[OffsetToItemsSelected + 247] = Convert.ToByte(variable);
                    return;
                case 248:
                    Init[OffsetToItemsSelected + 248] = Convert.ToByte(variable);
                    return;
                case 249:
                    Init[OffsetToItemsSelected + 249] = Convert.ToByte(variable);
                    return;
                case 250:
                    Init[OffsetToItemsSelected + 250] = Convert.ToByte(variable);
                    return;
                case 251:
                    Init[OffsetToItemsSelected + 251] = Convert.ToByte(variable);
                    return;
                case 252:
                    Init[OffsetToItemsSelected + 252] = Convert.ToByte(variable);
                    return;
                case 253:
                    Init[OffsetToItemsSelected + 253] = Convert.ToByte(variable);
                    return;
                case 254:
                    Init[OffsetToItemsSelected + 254] = Convert.ToByte(variable);
                    return;
                case 255:
                    Init[OffsetToItemsSelected + 255] = Convert.ToByte(variable);
                    return;
                case 256:
                    Init[OffsetToItemsSelected + 256] = Convert.ToByte(variable);
                    return;
                case 257:
                    Init[OffsetToItemsSelected + 257] = Convert.ToByte(variable);
                    return;
                case 258:
                    Init[OffsetToItemsSelected + 258] = Convert.ToByte(variable);
                    return;
                case 259:
                    Init[OffsetToItemsSelected + 259] = Convert.ToByte(variable);
                    return;
                case 260:
                    Init[OffsetToItemsSelected + 260] = Convert.ToByte(variable);
                    return;
                case 261:
                    Init[OffsetToItemsSelected + 261] = Convert.ToByte(variable);
                    return;
                case 262:
                    Init[OffsetToItemsSelected + 262] = Convert.ToByte(variable);
                    return;
                case 263:
                    Init[OffsetToItemsSelected + 263] = Convert.ToByte(variable);
                    return;
                case 264:
                    Init[OffsetToItemsSelected + 264] = Convert.ToByte(variable);
                    return;
                case 265:
                    Init[OffsetToItemsSelected + 265] = Convert.ToByte(variable);
                    return;
                case 266:
                    Init[OffsetToItemsSelected + 266] = Convert.ToByte(variable);
                    return;
                case 267:
                    Init[OffsetToItemsSelected + 267] = Convert.ToByte(variable);
                    return;
                case 268:
                    Init[OffsetToItemsSelected + 268] = Convert.ToByte(variable);
                    return;
                case 269:
                    Init[OffsetToItemsSelected + 269] = Convert.ToByte(variable);
                    return;
                case 270:
                    Init[OffsetToItemsSelected + 270] = Convert.ToByte(variable);
                    return;
                case 271:
                    Init[OffsetToItemsSelected + 271] = Convert.ToByte(variable);
                    return;
                case 272:
                    Init[OffsetToItemsSelected + 272] = Convert.ToByte(variable);
                    return;
                case 273:
                    Init[OffsetToItemsSelected + 273] = Convert.ToByte(variable);
                    return;
                case 274:
                    Init[OffsetToItemsSelected + 274] = Convert.ToByte(variable);
                    return;
                case 275:
                    Init[OffsetToItemsSelected + 275] = Convert.ToByte(variable);
                    return;
                case 276:
                    Init[OffsetToItemsSelected + 276] = Convert.ToByte(variable);
                    return;
                case 277:
                    Init[OffsetToItemsSelected + 277] = Convert.ToByte(variable);
                    return;
                case 278:
                    Init[OffsetToItemsSelected + 278] = Convert.ToByte(variable);
                    return;
                case 279:
                    Init[OffsetToItemsSelected + 279] = Convert.ToByte(variable);
                    return;
                case 280:
                    Init[OffsetToItemsSelected + 280] = Convert.ToByte(variable);
                    return;
                case 281:
                    Init[OffsetToItemsSelected + 281] = Convert.ToByte(variable);
                    return;
                case 282:
                    Init[OffsetToItemsSelected + 282] = Convert.ToByte(variable);
                    return;
                case 283:
                    Init[OffsetToItemsSelected + 283] = Convert.ToByte(variable);
                    return;
                case 284:
                    Init[OffsetToItemsSelected + 284] = Convert.ToByte(variable);
                    return;
                case 285:
                    Init[OffsetToItemsSelected + 285] = Convert.ToByte(variable);
                    return;
                case 286:
                    Init[OffsetToItemsSelected + 286] = Convert.ToByte(variable);
                    return;
                case 287:
                    Init[OffsetToItemsSelected + 287] = Convert.ToByte(variable);
                    return;
                case 288:
                    Init[OffsetToItemsSelected + 288] = Convert.ToByte(variable);
                    return;
                case 289:
                    Init[OffsetToItemsSelected + 289] = Convert.ToByte(variable);
                    return;
                case 290:
                    Init[OffsetToItemsSelected + 290] = Convert.ToByte(variable);
                    return;
                case 291:
                    Init[OffsetToItemsSelected + 291] = Convert.ToByte(variable);
                    return;
                case 292:
                    Init[OffsetToItemsSelected + 292] = Convert.ToByte(variable);
                    return;
                case 293:
                    Init[OffsetToItemsSelected + 293] = Convert.ToByte(variable);
                    return;
                case 294:
                    Init[OffsetToItemsSelected + 294] = Convert.ToByte(variable);
                    return;
                case 295:
                    Init[OffsetToItemsSelected + 295] = Convert.ToByte(variable);
                    return;
                case 296:
                    Init[OffsetToItemsSelected + 296] = Convert.ToByte(variable);
                    return;
                case 297:
                    Init[OffsetToItemsSelected + 297] = Convert.ToByte(variable);
                    return;
                case 298:
                    Init[OffsetToItemsSelected + 298] = Convert.ToByte(variable);
                    return;
                case 299:
                    Init[OffsetToItemsSelected + 299] = Convert.ToByte(variable);
                    return;
                case 300:
                    Init[OffsetToItemsSelected + 300] = Convert.ToByte(variable);
                    return;
                case 301:
                    Init[OffsetToItemsSelected + 301] = Convert.ToByte(variable);
                    return;
                case 302:
                    Init[OffsetToItemsSelected + 302] = Convert.ToByte(variable);
                    return;
                case 303:
                    Init[OffsetToItemsSelected + 303] = Convert.ToByte(variable);
                    return;
                case 304:
                    Init[OffsetToItemsSelected + 304] = Convert.ToByte(variable);
                    return;
                case 305:
                    Init[OffsetToItemsSelected + 305] = Convert.ToByte(variable);
                    return;
                case 306:
                    Init[OffsetToItemsSelected + 306] = Convert.ToByte(variable);
                    return;
                case 307:
                    Init[OffsetToItemsSelected + 307] = Convert.ToByte(variable);
                    return;
                case 308:
                    Init[OffsetToItemsSelected + 308] = Convert.ToByte(variable);
                    return;
                case 309:
                    Init[OffsetToItemsSelected + 309] = Convert.ToByte(variable);
                    return;
                case 310:
                    Init[OffsetToItemsSelected + 310] = Convert.ToByte(variable);
                    return;
                case 311:
                    Init[OffsetToItemsSelected + 311] = Convert.ToByte(variable);
                    return;
                case 312:
                    Init[OffsetToItemsSelected + 312] = Convert.ToByte(variable);
                    return;
                case 313:
                    Init[OffsetToItemsSelected + 313] = Convert.ToByte(variable);
                    return;
                case 314:
                    Init[OffsetToItemsSelected + 314] = Convert.ToByte(variable);
                    return;
                case 315:
                    Init[OffsetToItemsSelected + 315] = Convert.ToByte(variable);
                    return;
                case 316:
                    Init[OffsetToItemsSelected + 316] = Convert.ToByte(variable);
                    return;
                case 317:
                    Init[OffsetToItemsSelected + 317] = Convert.ToByte(variable);
                    return;
                case 318:
                    Init[OffsetToItemsSelected + 318] = Convert.ToByte(variable);
                    return;
                case 319:
                    Init[OffsetToItemsSelected + 319] = Convert.ToByte(variable);
                    return;
                case 320:
                    Init[OffsetToItemsSelected + 320] = Convert.ToByte(variable);
                    return;
                case 321:
                    Init[OffsetToItemsSelected + 321] = Convert.ToByte(variable);
                    return;
                case 322:
                    Init[OffsetToItemsSelected + 322] = Convert.ToByte(variable);
                    return;
                case 323:
                    Init[OffsetToItemsSelected + 323] = Convert.ToByte(variable);
                    return;
                case 324:
                    Init[OffsetToItemsSelected + 324] = Convert.ToByte(variable);
                    return;
                case 325:
                    Init[OffsetToItemsSelected + 325] = Convert.ToByte(variable);
                    return;
                case 326:
                    Init[OffsetToItemsSelected + 326] = Convert.ToByte(variable);
                    return;
                case 327:
                    Init[OffsetToItemsSelected + 327] = Convert.ToByte(variable);
                    return;
                case 328:
                    Init[OffsetToItemsSelected + 328] = Convert.ToByte(variable);
                    return;
                case 329:
                    Init[OffsetToItemsSelected + 329] = Convert.ToByte(variable);
                    return;
                case 330:
                    Init[OffsetToItemsSelected + 330] = Convert.ToByte(variable);
                    return;
                case 331:
                    Init[OffsetToItemsSelected + 331] = Convert.ToByte(variable);
                    return;
                case 332:
                    Init[OffsetToItemsSelected + 332] = Convert.ToByte(variable);
                    return;
                case 333:
                    Init[OffsetToItemsSelected + 333] = Convert.ToByte(variable);
                    return;
                case 334:
                    Init[OffsetToItemsSelected + 334] = Convert.ToByte(variable);
                    return;
                case 335:
                    Init[OffsetToItemsSelected + 335] = Convert.ToByte(variable);
                    return;
                case 336:
                    Init[OffsetToItemsSelected + 336] = Convert.ToByte(variable);
                    return;
                case 337:
                    Init[OffsetToItemsSelected + 337] = Convert.ToByte(variable);
                    return;
                case 338:
                    Init[OffsetToItemsSelected + 338] = Convert.ToByte(variable);
                    return;
                case 339:
                    Init[OffsetToItemsSelected + 339] = Convert.ToByte(variable);
                    return;
                case 340:
                    Init[OffsetToItemsSelected + 340] = Convert.ToByte(variable);
                    return;
                case 341:
                    Init[OffsetToItemsSelected + 341] = Convert.ToByte(variable);
                    return;
                case 342:
                    Init[OffsetToItemsSelected + 342] = Convert.ToByte(variable);
                    return;
                case 343:
                    Init[OffsetToItemsSelected + 343] = Convert.ToByte(variable);
                    return;
                case 344:
                    Init[OffsetToItemsSelected + 344] = Convert.ToByte(variable);
                    return;
                case 345:
                    Init[OffsetToItemsSelected + 345] = Convert.ToByte(variable);
                    return;
                case 346:
                    Init[OffsetToItemsSelected + 346] = Convert.ToByte(variable);
                    return;
                case 347:
                    Init[OffsetToItemsSelected + 347] = Convert.ToByte(variable);
                    return;
                case 348:
                    Init[OffsetToItemsSelected + 348] = Convert.ToByte(variable);
                    return;
                case 349:
                    Init[OffsetToItemsSelected + 349] = Convert.ToByte(variable);
                    return;
                case 350:
                    Init[OffsetToItemsSelected + 350] = Convert.ToByte(variable);
                    return;
                case 351:
                    Init[OffsetToItemsSelected + 351] = Convert.ToByte(variable);
                    return;
                case 352:
                    Init[OffsetToItemsSelected + 352] = Convert.ToByte(variable);
                    return;
                case 353:
                    Init[OffsetToItemsSelected + 353] = Convert.ToByte(variable);
                    return;
                case 354:
                    Init[OffsetToItemsSelected + 354] = Convert.ToByte(variable);
                    return;
                case 355:
                    Init[OffsetToItemsSelected + 355] = Convert.ToByte(variable);
                    return;
                case 356:
                    Init[OffsetToItemsSelected + 356] = Convert.ToByte(variable);
                    return;
                case 357:
                    Init[OffsetToItemsSelected + 357] = Convert.ToByte(variable);
                    return;
                case 358:
                    Init[OffsetToItemsSelected + 358] = Convert.ToByte(variable);
                    return;
                case 359:
                    Init[OffsetToItemsSelected + 359] = Convert.ToByte(variable);
                    return;
                case 360:
                    Init[OffsetToItemsSelected + 360] = Convert.ToByte(variable);
                    return;
                case 361:
                    Init[OffsetToItemsSelected + 361] = Convert.ToByte(variable);
                    return;
                case 362:
                    Init[OffsetToItemsSelected + 362] = Convert.ToByte(variable);
                    return;
                case 363:
                    Init[OffsetToItemsSelected + 363] = Convert.ToByte(variable);
                    return;
                case 364:
                    Init[OffsetToItemsSelected + 364] = Convert.ToByte(variable);
                    return;
                case 365:
                    Init[OffsetToItemsSelected + 365] = Convert.ToByte(variable);
                    return;
                case 366:
                    Init[OffsetToItemsSelected + 366] = Convert.ToByte(variable);
                    return;
                case 367:
                    Init[OffsetToItemsSelected + 367] = Convert.ToByte(variable);
                    return;
                case 368:
                    Init[OffsetToItemsSelected + 368] = Convert.ToByte(variable);
                    return;
                case 369:
                    Init[OffsetToItemsSelected + 369] = Convert.ToByte(variable);
                    return;
                case 370:
                    Init[OffsetToItemsSelected + 370] = Convert.ToByte(variable);
                    return;
                case 371:
                    Init[OffsetToItemsSelected + 371] = Convert.ToByte(variable);
                    return;
                case 372:
                    Init[OffsetToItemsSelected + 372] = Convert.ToByte(variable);
                    return;
                case 373:
                    Init[OffsetToItemsSelected + 373] = Convert.ToByte(variable);
                    return;
                case 374:
                    Init[OffsetToItemsSelected + 374] = Convert.ToByte(variable);
                    return;
                case 375:
                    Init[OffsetToItemsSelected + 375] = Convert.ToByte(variable);
                    return;
                case 376:
                    Init[OffsetToItemsSelected + 376] = Convert.ToByte(variable);
                    return;
                case 377:
                    Init[OffsetToItemsSelected + 377] = Convert.ToByte(variable);
                    return;
                case 378:
                    Init[OffsetToItemsSelected + 378] = Convert.ToByte(variable);
                    return;
                case 379:
                    Init[OffsetToItemsSelected + 379] = Convert.ToByte(variable);
                    return;
                case 380:
                    Init[OffsetToItemsSelected + 380] = Convert.ToByte(variable);
                    return;
                case 381:
                    Init[OffsetToItemsSelected + 381] = Convert.ToByte(variable);
                    return;
                case 382:
                    Init[OffsetToItemsSelected + 382] = Convert.ToByte(variable);
                    return;
                case 383:
                    Init[OffsetToItemsSelected + 383] = Convert.ToByte(variable);
                    return;
                case 384:
                    Init[OffsetToItemsSelected + 384] = Convert.ToByte(variable);
                    return;
                case 385:
                    Init[OffsetToItemsSelected + 385] = Convert.ToByte(variable);
                    return;
                case 386:
                    Init[OffsetToItemsSelected + 386] = Convert.ToByte(variable);
                    return;
                case 387:
                    Init[OffsetToItemsSelected + 387] = Convert.ToByte(variable);
                    return;
                case 388:
                    Init[OffsetToItemsSelected + 388] = Convert.ToByte(variable);
                    return;
                case 389:
                    Init[OffsetToItemsSelected + 389] = Convert.ToByte(variable);
                    return;
                case 390:
                    Init[OffsetToItemsSelected + 390] = Convert.ToByte(variable);
                    return;
                case 391:
                    Init[OffsetToItemsSelected + 391] = Convert.ToByte(variable);
                    return;
                case 392:
                    Init[OffsetToItemsSelected + 392] = Convert.ToByte(variable);
                    return;
                case 393:
                    Init[OffsetToItemsSelected + 393] = Convert.ToByte(variable);
                    return;
                case 394:
                    Init[OffsetToItemsSelected + 394] = Convert.ToByte(variable);
                    return;
                case 395:
                    Init[OffsetToItemsSelected + 395] = Convert.ToByte(variable);
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
            ShopsDataOffset = 2304;
            ConfigDataOffset = 2704;
            MiscDataOffset = 2724;
            ItemsDataOffset = 2804;
        }

        #endregion


        #region Gf

        public static void ReadGF(int GfId_List, byte[] Init)
        {
            GetSelectedGfData = new GfData();
            int selectedGfOffset = GfDataOffset + (GfId_List * 68);
            OffsetToGfSelected = selectedGfOffset;

            byte[] byteArray = new byte[12];
            Array.Copy(Init, selectedGfOffset, byteArray, 0, 12);
            byte[] buffer = FF8Text.BuildString_b(byteArray);
            GetSelectedGfData.Name = Encoding.UTF8.GetString(buffer);

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

        #region Config

        public static void ReadConfig(byte[] Init)
        {
            GetSelectedConfigData = new ConfigData();
            int selectedConfigOffset = ConfigDataOffset;
            OffsetToConfigSelected = selectedConfigOffset;

            GetSelectedConfigData.BattleSpeed = Init[selectedConfigOffset];
            GetSelectedConfigData.BattleMessage = Init[selectedConfigOffset + 1];
            GetSelectedConfigData.FieldMessage = Init[selectedConfigOffset + 2];
            GetSelectedConfigData.Volume = Init[selectedConfigOffset + 3];
            GetSelectedConfigData.Flag = Init[selectedConfigOffset + 4];
            GetSelectedConfigData.Scan = Init[selectedConfigOffset + 5];
            GetSelectedConfigData.Camera = Init[selectedConfigOffset + 6];
            GetSelectedConfigData.KeyUnk1 = Init[selectedConfigOffset + 7];
            GetSelectedConfigData.KeyEscape = Init[selectedConfigOffset + 8];
            GetSelectedConfigData.KeyPov = Init[selectedConfigOffset + 9];
            GetSelectedConfigData.KeyWindow = Init[selectedConfigOffset + 10];
            GetSelectedConfigData.KeyTrigger = Init[selectedConfigOffset + 11];
            GetSelectedConfigData.KeyCancel = Init[selectedConfigOffset + 12];
            GetSelectedConfigData.KeyMenu = Init[selectedConfigOffset + 13];
            GetSelectedConfigData.KeyTalk = Init[selectedConfigOffset + 14];
            GetSelectedConfigData.KeyTripleTriad = Init[selectedConfigOffset + 15];
            GetSelectedConfigData.KeySelect = Init[selectedConfigOffset + 16];
            GetSelectedConfigData.KeyUnk2 = Init[selectedConfigOffset + 17];
            GetSelectedConfigData.KeyUnk3 = Init[selectedConfigOffset + 18];
            GetSelectedConfigData.KeyStart = Init[selectedConfigOffset + 19];
        }

        #endregion

        #region Misc

        public static void ReadMisc(byte[] Init)
        {
            GetSelectedMiscData = new MiscData();
            int selectedMiscOffset = MiscDataOffset;
            OffsetToMiscSelected = selectedMiscOffset;

            GetSelectedMiscData.PartyMem1 = Init[selectedMiscOffset];
            GetSelectedMiscData.PartyMem2 = Init[selectedMiscOffset + 1];
            GetSelectedMiscData.PartyMem3 = Init[selectedMiscOffset + 2];
            GetSelectedMiscData.KnownWeapons1 = Init[selectedMiscOffset + 4];
            GetSelectedMiscData.KnownWeapons2 = Init[selectedMiscOffset + 5];
            GetSelectedMiscData.KnownWeapons3 = Init[selectedMiscOffset + 6];
            GetSelectedMiscData.KnownWeapons4 = Init[selectedMiscOffset + 7];

            byte[] byteArray = new byte[12];
            Array.Copy(Init, selectedMiscOffset + 8, byteArray, 0, 12);
            byte[] buffer = FF8Text.BuildString_b(byteArray);
            GetSelectedMiscData.GrieverName = Encoding.UTF8.GetString(buffer);

            GetSelectedMiscData.Unknown1 = BitConverter.ToUInt16(Init, selectedMiscOffset + 20);
            GetSelectedMiscData.Unknown2 = BitConverter.ToUInt16(Init, selectedMiscOffset + 22);
            GetSelectedMiscData.Gil = BitConverter.ToUInt32(Init, selectedMiscOffset + 24);
            GetSelectedMiscData.GilLaguna = BitConverter.ToUInt32(Init, selectedMiscOffset + 28);
            GetSelectedMiscData.limitQuistis1 = Init[selectedMiscOffset + 32];
            GetSelectedMiscData.limitQuistis2 = Init[selectedMiscOffset + 33];
            GetSelectedMiscData.limitZell1 = Init[selectedMiscOffset + 34];
            GetSelectedMiscData.limitZell2 = Init[selectedMiscOffset + 35];
            GetSelectedMiscData.limitIrvine = Init[selectedMiscOffset + 36];
            GetSelectedMiscData.limitSelphie = Init[selectedMiscOffset + 37];
            GetSelectedMiscData.limitAngeloCompleted = Init[selectedMiscOffset + 38];
            GetSelectedMiscData.limitAngeloKnown = Init[selectedMiscOffset + 39];
            GetSelectedMiscData.limitAngeloPoints1 = Init[selectedMiscOffset + 40];
            GetSelectedMiscData.limitAngeloPoints2 = Init[selectedMiscOffset + 41];
            GetSelectedMiscData.limitAngeloPoints3 = Init[selectedMiscOffset + 42];
            GetSelectedMiscData.limitAngeloPoints4 = Init[selectedMiscOffset + 43];
            GetSelectedMiscData.limitAngeloPoints5 = Init[selectedMiscOffset + 44];
            GetSelectedMiscData.limitAngeloPoints6 = Init[selectedMiscOffset + 45];
            GetSelectedMiscData.limitAngeloPoints7 = Init[selectedMiscOffset + 46];
            GetSelectedMiscData.limitAngeloPoints8 = Init[selectedMiscOffset + 47];
        }

        #endregion

        #region Items

        public static void ReadItems(byte[] Init)
        {
            GetSelectedItemsData = new ItemsData();
            int selectedItemsOffset = ItemsDataOffset;
            OffsetToItemsSelected = selectedItemsOffset;


            GetSelectedItemsData.Item1 = Init[selectedItemsOffset + 0];
            GetSelectedItemsData.Item1Quantity = Init[selectedItemsOffset + 1];
            GetSelectedItemsData.Item2 = Init[selectedItemsOffset + 2];
            GetSelectedItemsData.Item2Quantity = Init[selectedItemsOffset + 3];
            GetSelectedItemsData.Item3 = Init[selectedItemsOffset + 4];
            GetSelectedItemsData.Item3Quantity = Init[selectedItemsOffset + 5];
            GetSelectedItemsData.Item4 = Init[selectedItemsOffset + 6];
            GetSelectedItemsData.Item4Quantity = Init[selectedItemsOffset + 7];
            GetSelectedItemsData.Item5 = Init[selectedItemsOffset + 8];
            GetSelectedItemsData.Item5Quantity = Init[selectedItemsOffset + 9];
            GetSelectedItemsData.Item6 = Init[selectedItemsOffset + 10];
            GetSelectedItemsData.Item6Quantity = Init[selectedItemsOffset + 11];
            GetSelectedItemsData.Item7 = Init[selectedItemsOffset + 12];
            GetSelectedItemsData.Item7Quantity = Init[selectedItemsOffset + 13];
            GetSelectedItemsData.Item8 = Init[selectedItemsOffset + 14];
            GetSelectedItemsData.Item8Quantity = Init[selectedItemsOffset + 15];
            GetSelectedItemsData.Item9 = Init[selectedItemsOffset + 16];
            GetSelectedItemsData.Item9Quantity = Init[selectedItemsOffset + 17];
            GetSelectedItemsData.Item10 = Init[selectedItemsOffset + 18];
            GetSelectedItemsData.Item10Quantity = Init[selectedItemsOffset + 19];
            GetSelectedItemsData.Item11 = Init[selectedItemsOffset + 20];
            GetSelectedItemsData.Item11Quantity = Init[selectedItemsOffset + 21];
            GetSelectedItemsData.Item12 = Init[selectedItemsOffset + 22];
            GetSelectedItemsData.Item12Quantity = Init[selectedItemsOffset + 23];
            GetSelectedItemsData.Item13 = Init[selectedItemsOffset + 24];
            GetSelectedItemsData.Item13Quantity = Init[selectedItemsOffset + 25];
            GetSelectedItemsData.Item14 = Init[selectedItemsOffset + 26];
            GetSelectedItemsData.Item14Quantity = Init[selectedItemsOffset + 27];
            GetSelectedItemsData.Item15 = Init[selectedItemsOffset + 28];
            GetSelectedItemsData.Item15Quantity = Init[selectedItemsOffset + 29];
            GetSelectedItemsData.Item16 = Init[selectedItemsOffset + 30];
            GetSelectedItemsData.Item16Quantity = Init[selectedItemsOffset + 31];
            GetSelectedItemsData.Item17 = Init[selectedItemsOffset + 32];
            GetSelectedItemsData.Item17Quantity = Init[selectedItemsOffset + 33];
            GetSelectedItemsData.Item18 = Init[selectedItemsOffset + 34];
            GetSelectedItemsData.Item18Quantity = Init[selectedItemsOffset + 35];
            GetSelectedItemsData.Item19 = Init[selectedItemsOffset + 36];
            GetSelectedItemsData.Item19Quantity = Init[selectedItemsOffset + 37];
            GetSelectedItemsData.Item20 = Init[selectedItemsOffset + 38];
            GetSelectedItemsData.Item20Quantity = Init[selectedItemsOffset + 39];
            GetSelectedItemsData.Item21 = Init[selectedItemsOffset + 40];
            GetSelectedItemsData.Item21Quantity = Init[selectedItemsOffset + 41];
            GetSelectedItemsData.Item22 = Init[selectedItemsOffset + 42];
            GetSelectedItemsData.Item22Quantity = Init[selectedItemsOffset + 43];
            GetSelectedItemsData.Item23 = Init[selectedItemsOffset + 44];
            GetSelectedItemsData.Item23Quantity = Init[selectedItemsOffset + 45];
            GetSelectedItemsData.Item24 = Init[selectedItemsOffset + 46];
            GetSelectedItemsData.Item24Quantity = Init[selectedItemsOffset + 47];
            GetSelectedItemsData.Item25 = Init[selectedItemsOffset + 48];
            GetSelectedItemsData.Item25Quantity = Init[selectedItemsOffset + 49];
            GetSelectedItemsData.Item26 = Init[selectedItemsOffset + 50];
            GetSelectedItemsData.Item26Quantity = Init[selectedItemsOffset + 51];
            GetSelectedItemsData.Item27 = Init[selectedItemsOffset + 52];
            GetSelectedItemsData.Item27Quantity = Init[selectedItemsOffset + 53];
            GetSelectedItemsData.Item28 = Init[selectedItemsOffset + 54];
            GetSelectedItemsData.Item28Quantity = Init[selectedItemsOffset + 55];
            GetSelectedItemsData.Item29 = Init[selectedItemsOffset + 56];
            GetSelectedItemsData.Item29Quantity = Init[selectedItemsOffset + 57];
            GetSelectedItemsData.Item30 = Init[selectedItemsOffset + 58];
            GetSelectedItemsData.Item30Quantity = Init[selectedItemsOffset + 59];
            GetSelectedItemsData.Item31 = Init[selectedItemsOffset + 60];
            GetSelectedItemsData.Item31Quantity = Init[selectedItemsOffset + 61];
            GetSelectedItemsData.Item32 = Init[selectedItemsOffset + 62];
            GetSelectedItemsData.Item32Quantity = Init[selectedItemsOffset + 63];
            GetSelectedItemsData.Item33 = Init[selectedItemsOffset + 64];
            GetSelectedItemsData.Item33Quantity = Init[selectedItemsOffset + 65];
            GetSelectedItemsData.Item34 = Init[selectedItemsOffset + 66];
            GetSelectedItemsData.Item34Quantity = Init[selectedItemsOffset + 67];
            GetSelectedItemsData.Item35 = Init[selectedItemsOffset + 68];
            GetSelectedItemsData.Item35Quantity = Init[selectedItemsOffset + 69];
            GetSelectedItemsData.Item36 = Init[selectedItemsOffset + 70];
            GetSelectedItemsData.Item36Quantity = Init[selectedItemsOffset + 71];
            GetSelectedItemsData.Item37 = Init[selectedItemsOffset + 72];
            GetSelectedItemsData.Item37Quantity = Init[selectedItemsOffset + 73];
            GetSelectedItemsData.Item38 = Init[selectedItemsOffset + 74];
            GetSelectedItemsData.Item38Quantity = Init[selectedItemsOffset + 75];
            GetSelectedItemsData.Item39 = Init[selectedItemsOffset + 76];
            GetSelectedItemsData.Item39Quantity = Init[selectedItemsOffset + 77];
            GetSelectedItemsData.Item40 = Init[selectedItemsOffset + 78];
            GetSelectedItemsData.Item40Quantity = Init[selectedItemsOffset + 79];
            GetSelectedItemsData.Item41 = Init[selectedItemsOffset + 80];
            GetSelectedItemsData.Item41Quantity = Init[selectedItemsOffset + 81];
            GetSelectedItemsData.Item42 = Init[selectedItemsOffset + 82];
            GetSelectedItemsData.Item42Quantity = Init[selectedItemsOffset + 83];
            GetSelectedItemsData.Item43 = Init[selectedItemsOffset + 84];
            GetSelectedItemsData.Item43Quantity = Init[selectedItemsOffset + 85];
            GetSelectedItemsData.Item44 = Init[selectedItemsOffset + 86];
            GetSelectedItemsData.Item44Quantity = Init[selectedItemsOffset + 87];
            GetSelectedItemsData.Item45 = Init[selectedItemsOffset + 88];
            GetSelectedItemsData.Item45Quantity = Init[selectedItemsOffset + 89];
            GetSelectedItemsData.Item46 = Init[selectedItemsOffset + 90];
            GetSelectedItemsData.Item46Quantity = Init[selectedItemsOffset + 91];
            GetSelectedItemsData.Item47 = Init[selectedItemsOffset + 92];
            GetSelectedItemsData.Item47Quantity = Init[selectedItemsOffset + 93];
            GetSelectedItemsData.Item48 = Init[selectedItemsOffset + 94];
            GetSelectedItemsData.Item48Quantity = Init[selectedItemsOffset + 95];
            GetSelectedItemsData.Item49 = Init[selectedItemsOffset + 96];
            GetSelectedItemsData.Item49Quantity = Init[selectedItemsOffset + 97];
            GetSelectedItemsData.Item50 = Init[selectedItemsOffset + 98];
            GetSelectedItemsData.Item50Quantity = Init[selectedItemsOffset + 99];
            GetSelectedItemsData.Item51 = Init[selectedItemsOffset + 100];
            GetSelectedItemsData.Item51Quantity = Init[selectedItemsOffset + 101];
            GetSelectedItemsData.Item52 = Init[selectedItemsOffset + 102];
            GetSelectedItemsData.Item52Quantity = Init[selectedItemsOffset + 103];
            GetSelectedItemsData.Item53 = Init[selectedItemsOffset + 104];
            GetSelectedItemsData.Item53Quantity = Init[selectedItemsOffset + 105];
            GetSelectedItemsData.Item54 = Init[selectedItemsOffset + 106];
            GetSelectedItemsData.Item54Quantity = Init[selectedItemsOffset + 107];
            GetSelectedItemsData.Item55 = Init[selectedItemsOffset + 108];
            GetSelectedItemsData.Item55Quantity = Init[selectedItemsOffset + 109];
            GetSelectedItemsData.Item56 = Init[selectedItemsOffset + 110];
            GetSelectedItemsData.Item56Quantity = Init[selectedItemsOffset + 111];
            GetSelectedItemsData.Item57 = Init[selectedItemsOffset + 112];
            GetSelectedItemsData.Item57Quantity = Init[selectedItemsOffset + 113];
            GetSelectedItemsData.Item58 = Init[selectedItemsOffset + 114];
            GetSelectedItemsData.Item58Quantity = Init[selectedItemsOffset + 115];
            GetSelectedItemsData.Item59 = Init[selectedItemsOffset + 116];
            GetSelectedItemsData.Item59Quantity = Init[selectedItemsOffset + 117];
            GetSelectedItemsData.Item60 = Init[selectedItemsOffset + 118];
            GetSelectedItemsData.Item60Quantity = Init[selectedItemsOffset + 119];
            GetSelectedItemsData.Item61 = Init[selectedItemsOffset + 120];
            GetSelectedItemsData.Item61Quantity = Init[selectedItemsOffset + 121];
            GetSelectedItemsData.Item62 = Init[selectedItemsOffset + 122];
            GetSelectedItemsData.Item62Quantity = Init[selectedItemsOffset + 123];
            GetSelectedItemsData.Item63 = Init[selectedItemsOffset + 124];
            GetSelectedItemsData.Item63Quantity = Init[selectedItemsOffset + 125];
            GetSelectedItemsData.Item64 = Init[selectedItemsOffset + 126];
            GetSelectedItemsData.Item64Quantity = Init[selectedItemsOffset + 127];
            GetSelectedItemsData.Item65 = Init[selectedItemsOffset + 128];
            GetSelectedItemsData.Item65Quantity = Init[selectedItemsOffset + 129];
            GetSelectedItemsData.Item66 = Init[selectedItemsOffset + 130];
            GetSelectedItemsData.Item66Quantity = Init[selectedItemsOffset + 131];
            GetSelectedItemsData.Item67 = Init[selectedItemsOffset + 132];
            GetSelectedItemsData.Item67Quantity = Init[selectedItemsOffset + 133];
            GetSelectedItemsData.Item68 = Init[selectedItemsOffset + 134];
            GetSelectedItemsData.Item68Quantity = Init[selectedItemsOffset + 135];
            GetSelectedItemsData.Item69 = Init[selectedItemsOffset + 136];
            GetSelectedItemsData.Item69Quantity = Init[selectedItemsOffset + 137];
            GetSelectedItemsData.Item70 = Init[selectedItemsOffset + 138];
            GetSelectedItemsData.Item70Quantity = Init[selectedItemsOffset + 139];
            GetSelectedItemsData.Item71 = Init[selectedItemsOffset + 140];
            GetSelectedItemsData.Item71Quantity = Init[selectedItemsOffset + 141];
            GetSelectedItemsData.Item72 = Init[selectedItemsOffset + 142];
            GetSelectedItemsData.Item72Quantity = Init[selectedItemsOffset + 143];
            GetSelectedItemsData.Item73 = Init[selectedItemsOffset + 144];
            GetSelectedItemsData.Item73Quantity = Init[selectedItemsOffset + 145];
            GetSelectedItemsData.Item74 = Init[selectedItemsOffset + 146];
            GetSelectedItemsData.Item74Quantity = Init[selectedItemsOffset + 147];
            GetSelectedItemsData.Item75 = Init[selectedItemsOffset + 148];
            GetSelectedItemsData.Item75Quantity = Init[selectedItemsOffset + 149];
            GetSelectedItemsData.Item76 = Init[selectedItemsOffset + 150];
            GetSelectedItemsData.Item76Quantity = Init[selectedItemsOffset + 151];
            GetSelectedItemsData.Item77 = Init[selectedItemsOffset + 152];
            GetSelectedItemsData.Item77Quantity = Init[selectedItemsOffset + 153];
            GetSelectedItemsData.Item78 = Init[selectedItemsOffset + 154];
            GetSelectedItemsData.Item78Quantity = Init[selectedItemsOffset + 155];
            GetSelectedItemsData.Item79 = Init[selectedItemsOffset + 156];
            GetSelectedItemsData.Item79Quantity = Init[selectedItemsOffset + 157];
            GetSelectedItemsData.Item80 = Init[selectedItemsOffset + 158];
            GetSelectedItemsData.Item80Quantity = Init[selectedItemsOffset + 159];
            GetSelectedItemsData.Item81 = Init[selectedItemsOffset + 160];
            GetSelectedItemsData.Item81Quantity = Init[selectedItemsOffset + 161];
            GetSelectedItemsData.Item82 = Init[selectedItemsOffset + 162];
            GetSelectedItemsData.Item82Quantity = Init[selectedItemsOffset + 163];
            GetSelectedItemsData.Item83 = Init[selectedItemsOffset + 164];
            GetSelectedItemsData.Item83Quantity = Init[selectedItemsOffset + 165];
            GetSelectedItemsData.Item84 = Init[selectedItemsOffset + 166];
            GetSelectedItemsData.Item84Quantity = Init[selectedItemsOffset + 167];
            GetSelectedItemsData.Item85 = Init[selectedItemsOffset + 168];
            GetSelectedItemsData.Item85Quantity = Init[selectedItemsOffset + 169];
            GetSelectedItemsData.Item86 = Init[selectedItemsOffset + 170];
            GetSelectedItemsData.Item86Quantity = Init[selectedItemsOffset + 171];
            GetSelectedItemsData.Item87 = Init[selectedItemsOffset + 172];
            GetSelectedItemsData.Item87Quantity = Init[selectedItemsOffset + 173];
            GetSelectedItemsData.Item88 = Init[selectedItemsOffset + 174];
            GetSelectedItemsData.Item88Quantity = Init[selectedItemsOffset + 175];
            GetSelectedItemsData.Item89 = Init[selectedItemsOffset + 176];
            GetSelectedItemsData.Item89Quantity = Init[selectedItemsOffset + 177];
            GetSelectedItemsData.Item90 = Init[selectedItemsOffset + 178];
            GetSelectedItemsData.Item90Quantity = Init[selectedItemsOffset + 179];
            GetSelectedItemsData.Item91 = Init[selectedItemsOffset + 180];
            GetSelectedItemsData.Item91Quantity = Init[selectedItemsOffset + 181];
            GetSelectedItemsData.Item92 = Init[selectedItemsOffset + 182];
            GetSelectedItemsData.Item92Quantity = Init[selectedItemsOffset + 183];
            GetSelectedItemsData.Item93 = Init[selectedItemsOffset + 184];
            GetSelectedItemsData.Item93Quantity = Init[selectedItemsOffset + 185];
            GetSelectedItemsData.Item94 = Init[selectedItemsOffset + 186];
            GetSelectedItemsData.Item94Quantity = Init[selectedItemsOffset + 187];
            GetSelectedItemsData.Item95 = Init[selectedItemsOffset + 188];
            GetSelectedItemsData.Item95Quantity = Init[selectedItemsOffset + 189];
            GetSelectedItemsData.Item96 = Init[selectedItemsOffset + 190];
            GetSelectedItemsData.Item96Quantity = Init[selectedItemsOffset + 191];
            GetSelectedItemsData.Item97 = Init[selectedItemsOffset + 192];
            GetSelectedItemsData.Item97Quantity = Init[selectedItemsOffset + 193];
            GetSelectedItemsData.Item98 = Init[selectedItemsOffset + 194];
            GetSelectedItemsData.Item98Quantity = Init[selectedItemsOffset + 195];
            GetSelectedItemsData.Item99 = Init[selectedItemsOffset + 196];
            GetSelectedItemsData.Item99Quantity = Init[selectedItemsOffset + 197];
            GetSelectedItemsData.Item100 = Init[selectedItemsOffset + 198];
            GetSelectedItemsData.Item100Quantity = Init[selectedItemsOffset + 199];
            GetSelectedItemsData.Item101 = Init[selectedItemsOffset + 200];
            GetSelectedItemsData.Item101Quantity = Init[selectedItemsOffset + 201];
            GetSelectedItemsData.Item102 = Init[selectedItemsOffset + 202];
            GetSelectedItemsData.Item102Quantity = Init[selectedItemsOffset + 203];
            GetSelectedItemsData.Item103 = Init[selectedItemsOffset + 204];
            GetSelectedItemsData.Item103Quantity = Init[selectedItemsOffset + 205];
            GetSelectedItemsData.Item104 = Init[selectedItemsOffset + 206];
            GetSelectedItemsData.Item104Quantity = Init[selectedItemsOffset + 207];
            GetSelectedItemsData.Item105 = Init[selectedItemsOffset + 208];
            GetSelectedItemsData.Item105Quantity = Init[selectedItemsOffset + 209];
            GetSelectedItemsData.Item106 = Init[selectedItemsOffset + 210];
            GetSelectedItemsData.Item106Quantity = Init[selectedItemsOffset + 211];
            GetSelectedItemsData.Item107 = Init[selectedItemsOffset + 212];
            GetSelectedItemsData.Item107Quantity = Init[selectedItemsOffset + 213];
            GetSelectedItemsData.Item108 = Init[selectedItemsOffset + 214];
            GetSelectedItemsData.Item108Quantity = Init[selectedItemsOffset + 215];
            GetSelectedItemsData.Item109 = Init[selectedItemsOffset + 216];
            GetSelectedItemsData.Item109Quantity = Init[selectedItemsOffset + 217];
            GetSelectedItemsData.Item110 = Init[selectedItemsOffset + 218];
            GetSelectedItemsData.Item110Quantity = Init[selectedItemsOffset + 219];
            GetSelectedItemsData.Item111 = Init[selectedItemsOffset + 220];
            GetSelectedItemsData.Item111Quantity = Init[selectedItemsOffset + 221];
            GetSelectedItemsData.Item112 = Init[selectedItemsOffset + 222];
            GetSelectedItemsData.Item112Quantity = Init[selectedItemsOffset + 223];
            GetSelectedItemsData.Item113 = Init[selectedItemsOffset + 224];
            GetSelectedItemsData.Item113Quantity = Init[selectedItemsOffset + 225];
            GetSelectedItemsData.Item114 = Init[selectedItemsOffset + 226];
            GetSelectedItemsData.Item114Quantity = Init[selectedItemsOffset + 227];
            GetSelectedItemsData.Item115 = Init[selectedItemsOffset + 228];
            GetSelectedItemsData.Item115Quantity = Init[selectedItemsOffset + 229];
            GetSelectedItemsData.Item116 = Init[selectedItemsOffset + 230];
            GetSelectedItemsData.Item116Quantity = Init[selectedItemsOffset + 231];
            GetSelectedItemsData.Item117 = Init[selectedItemsOffset + 232];
            GetSelectedItemsData.Item117Quantity = Init[selectedItemsOffset + 233];
            GetSelectedItemsData.Item118 = Init[selectedItemsOffset + 234];
            GetSelectedItemsData.Item118Quantity = Init[selectedItemsOffset + 235];
            GetSelectedItemsData.Item119 = Init[selectedItemsOffset + 236];
            GetSelectedItemsData.Item119Quantity = Init[selectedItemsOffset + 237];
            GetSelectedItemsData.Item120 = Init[selectedItemsOffset + 238];
            GetSelectedItemsData.Item120Quantity = Init[selectedItemsOffset + 239];
            GetSelectedItemsData.Item121 = Init[selectedItemsOffset + 240];
            GetSelectedItemsData.Item121Quantity = Init[selectedItemsOffset + 241];
            GetSelectedItemsData.Item122 = Init[selectedItemsOffset + 242];
            GetSelectedItemsData.Item122Quantity = Init[selectedItemsOffset + 243];
            GetSelectedItemsData.Item123 = Init[selectedItemsOffset + 244];
            GetSelectedItemsData.Item123Quantity = Init[selectedItemsOffset + 245];
            GetSelectedItemsData.Item124 = Init[selectedItemsOffset + 246];
            GetSelectedItemsData.Item124Quantity = Init[selectedItemsOffset + 247];
            GetSelectedItemsData.Item125 = Init[selectedItemsOffset + 248];
            GetSelectedItemsData.Item125Quantity = Init[selectedItemsOffset + 249];
            GetSelectedItemsData.Item126 = Init[selectedItemsOffset + 250];
            GetSelectedItemsData.Item126Quantity = Init[selectedItemsOffset + 251];
            GetSelectedItemsData.Item127 = Init[selectedItemsOffset + 252];
            GetSelectedItemsData.Item127Quantity = Init[selectedItemsOffset + 253];
            GetSelectedItemsData.Item128 = Init[selectedItemsOffset + 254];
            GetSelectedItemsData.Item128Quantity = Init[selectedItemsOffset + 255];
            GetSelectedItemsData.Item129 = Init[selectedItemsOffset + 256];
            GetSelectedItemsData.Item129Quantity = Init[selectedItemsOffset + 257];
            GetSelectedItemsData.Item130 = Init[selectedItemsOffset + 258];
            GetSelectedItemsData.Item130Quantity = Init[selectedItemsOffset + 259];
            GetSelectedItemsData.Item131 = Init[selectedItemsOffset + 260];
            GetSelectedItemsData.Item131Quantity = Init[selectedItemsOffset + 261];
            GetSelectedItemsData.Item132 = Init[selectedItemsOffset + 262];
            GetSelectedItemsData.Item132Quantity = Init[selectedItemsOffset + 263];
            GetSelectedItemsData.Item133 = Init[selectedItemsOffset + 264];
            GetSelectedItemsData.Item133Quantity = Init[selectedItemsOffset + 265];
            GetSelectedItemsData.Item134 = Init[selectedItemsOffset + 266];
            GetSelectedItemsData.Item134Quantity = Init[selectedItemsOffset + 267];
            GetSelectedItemsData.Item135 = Init[selectedItemsOffset + 268];
            GetSelectedItemsData.Item135Quantity = Init[selectedItemsOffset + 269];
            GetSelectedItemsData.Item136 = Init[selectedItemsOffset + 270];
            GetSelectedItemsData.Item136Quantity = Init[selectedItemsOffset + 271];
            GetSelectedItemsData.Item137 = Init[selectedItemsOffset + 272];
            GetSelectedItemsData.Item137Quantity = Init[selectedItemsOffset + 273];
            GetSelectedItemsData.Item138 = Init[selectedItemsOffset + 274];
            GetSelectedItemsData.Item138Quantity = Init[selectedItemsOffset + 275];
            GetSelectedItemsData.Item139 = Init[selectedItemsOffset + 276];
            GetSelectedItemsData.Item139Quantity = Init[selectedItemsOffset + 277];
            GetSelectedItemsData.Item140 = Init[selectedItemsOffset + 278];
            GetSelectedItemsData.Item140Quantity = Init[selectedItemsOffset + 279];
            GetSelectedItemsData.Item141 = Init[selectedItemsOffset + 280];
            GetSelectedItemsData.Item141Quantity = Init[selectedItemsOffset + 281];
            GetSelectedItemsData.Item142 = Init[selectedItemsOffset + 282];
            GetSelectedItemsData.Item142Quantity = Init[selectedItemsOffset + 283];
            GetSelectedItemsData.Item143 = Init[selectedItemsOffset + 284];
            GetSelectedItemsData.Item143Quantity = Init[selectedItemsOffset + 285];
            GetSelectedItemsData.Item144 = Init[selectedItemsOffset + 286];
            GetSelectedItemsData.Item144Quantity = Init[selectedItemsOffset + 287];
            GetSelectedItemsData.Item145 = Init[selectedItemsOffset + 288];
            GetSelectedItemsData.Item145Quantity = Init[selectedItemsOffset + 289];
            GetSelectedItemsData.Item146 = Init[selectedItemsOffset + 290];
            GetSelectedItemsData.Item146Quantity = Init[selectedItemsOffset + 291];
            GetSelectedItemsData.Item147 = Init[selectedItemsOffset + 292];
            GetSelectedItemsData.Item147Quantity = Init[selectedItemsOffset + 293];
            GetSelectedItemsData.Item148 = Init[selectedItemsOffset + 294];
            GetSelectedItemsData.Item148Quantity = Init[selectedItemsOffset + 295];
            GetSelectedItemsData.Item149 = Init[selectedItemsOffset + 296];
            GetSelectedItemsData.Item149Quantity = Init[selectedItemsOffset + 297];
            GetSelectedItemsData.Item150 = Init[selectedItemsOffset + 298];
            GetSelectedItemsData.Item150Quantity = Init[selectedItemsOffset + 299];
            GetSelectedItemsData.Item151 = Init[selectedItemsOffset + 300];
            GetSelectedItemsData.Item151Quantity = Init[selectedItemsOffset + 301];
            GetSelectedItemsData.Item152 = Init[selectedItemsOffset + 302];
            GetSelectedItemsData.Item152Quantity = Init[selectedItemsOffset + 303];
            GetSelectedItemsData.Item153 = Init[selectedItemsOffset + 304];
            GetSelectedItemsData.Item153Quantity = Init[selectedItemsOffset + 305];
            GetSelectedItemsData.Item154 = Init[selectedItemsOffset + 306];
            GetSelectedItemsData.Item154Quantity = Init[selectedItemsOffset + 307];
            GetSelectedItemsData.Item155 = Init[selectedItemsOffset + 308];
            GetSelectedItemsData.Item155Quantity = Init[selectedItemsOffset + 309];
            GetSelectedItemsData.Item156 = Init[selectedItemsOffset + 310];
            GetSelectedItemsData.Item156Quantity = Init[selectedItemsOffset + 311];
            GetSelectedItemsData.Item157 = Init[selectedItemsOffset + 312];
            GetSelectedItemsData.Item157Quantity = Init[selectedItemsOffset + 313];
            GetSelectedItemsData.Item158 = Init[selectedItemsOffset + 314];
            GetSelectedItemsData.Item158Quantity = Init[selectedItemsOffset + 315];
            GetSelectedItemsData.Item159 = Init[selectedItemsOffset + 316];
            GetSelectedItemsData.Item159Quantity = Init[selectedItemsOffset + 317];
            GetSelectedItemsData.Item160 = Init[selectedItemsOffset + 318];
            GetSelectedItemsData.Item160Quantity = Init[selectedItemsOffset + 319];
            GetSelectedItemsData.Item161 = Init[selectedItemsOffset + 320];
            GetSelectedItemsData.Item161Quantity = Init[selectedItemsOffset + 321];
            GetSelectedItemsData.Item162 = Init[selectedItemsOffset + 322];
            GetSelectedItemsData.Item162Quantity = Init[selectedItemsOffset + 323];
            GetSelectedItemsData.Item163 = Init[selectedItemsOffset + 324];
            GetSelectedItemsData.Item163Quantity = Init[selectedItemsOffset + 325];
            GetSelectedItemsData.Item164 = Init[selectedItemsOffset + 326];
            GetSelectedItemsData.Item164Quantity = Init[selectedItemsOffset + 327];
            GetSelectedItemsData.Item165 = Init[selectedItemsOffset + 328];
            GetSelectedItemsData.Item165Quantity = Init[selectedItemsOffset + 329];
            GetSelectedItemsData.Item166 = Init[selectedItemsOffset + 330];
            GetSelectedItemsData.Item166Quantity = Init[selectedItemsOffset + 331];
            GetSelectedItemsData.Item167 = Init[selectedItemsOffset + 332];
            GetSelectedItemsData.Item167Quantity = Init[selectedItemsOffset + 333];
            GetSelectedItemsData.Item168 = Init[selectedItemsOffset + 334];
            GetSelectedItemsData.Item168Quantity = Init[selectedItemsOffset + 335];
            GetSelectedItemsData.Item169 = Init[selectedItemsOffset + 336];
            GetSelectedItemsData.Item169Quantity = Init[selectedItemsOffset + 337];
            GetSelectedItemsData.Item170 = Init[selectedItemsOffset + 338];
            GetSelectedItemsData.Item170Quantity = Init[selectedItemsOffset + 339];
            GetSelectedItemsData.Item171 = Init[selectedItemsOffset + 340];
            GetSelectedItemsData.Item171Quantity = Init[selectedItemsOffset + 341];
            GetSelectedItemsData.Item172 = Init[selectedItemsOffset + 342];
            GetSelectedItemsData.Item172Quantity = Init[selectedItemsOffset + 343];
            GetSelectedItemsData.Item173 = Init[selectedItemsOffset + 344];
            GetSelectedItemsData.Item173Quantity = Init[selectedItemsOffset + 345];
            GetSelectedItemsData.Item174 = Init[selectedItemsOffset + 346];
            GetSelectedItemsData.Item174Quantity = Init[selectedItemsOffset + 347];
            GetSelectedItemsData.Item175 = Init[selectedItemsOffset + 348];
            GetSelectedItemsData.Item175Quantity = Init[selectedItemsOffset + 349];
            GetSelectedItemsData.Item176 = Init[selectedItemsOffset + 350];
            GetSelectedItemsData.Item176Quantity = Init[selectedItemsOffset + 351];
            GetSelectedItemsData.Item177 = Init[selectedItemsOffset + 352];
            GetSelectedItemsData.Item177Quantity = Init[selectedItemsOffset + 353];
            GetSelectedItemsData.Item178 = Init[selectedItemsOffset + 354];
            GetSelectedItemsData.Item178Quantity = Init[selectedItemsOffset + 355];
            GetSelectedItemsData.Item179 = Init[selectedItemsOffset + 356];
            GetSelectedItemsData.Item179Quantity = Init[selectedItemsOffset + 357];
            GetSelectedItemsData.Item180 = Init[selectedItemsOffset + 358];
            GetSelectedItemsData.Item180Quantity = Init[selectedItemsOffset + 359];
            GetSelectedItemsData.Item181 = Init[selectedItemsOffset + 360];
            GetSelectedItemsData.Item181Quantity = Init[selectedItemsOffset + 361];
            GetSelectedItemsData.Item182 = Init[selectedItemsOffset + 362];
            GetSelectedItemsData.Item182Quantity = Init[selectedItemsOffset + 363];
            GetSelectedItemsData.Item183 = Init[selectedItemsOffset + 364];
            GetSelectedItemsData.Item183Quantity = Init[selectedItemsOffset + 365];
            GetSelectedItemsData.Item184 = Init[selectedItemsOffset + 366];
            GetSelectedItemsData.Item184Quantity = Init[selectedItemsOffset + 367];
            GetSelectedItemsData.Item185 = Init[selectedItemsOffset + 368];
            GetSelectedItemsData.Item185Quantity = Init[selectedItemsOffset + 369];
            GetSelectedItemsData.Item186 = Init[selectedItemsOffset + 370];
            GetSelectedItemsData.Item186Quantity = Init[selectedItemsOffset + 371];
            GetSelectedItemsData.Item187 = Init[selectedItemsOffset + 372];
            GetSelectedItemsData.Item187Quantity = Init[selectedItemsOffset + 373];
            GetSelectedItemsData.Item188 = Init[selectedItemsOffset + 374];
            GetSelectedItemsData.Item188Quantity = Init[selectedItemsOffset + 375];
            GetSelectedItemsData.Item189 = Init[selectedItemsOffset + 376];
            GetSelectedItemsData.Item189Quantity = Init[selectedItemsOffset + 377];
            GetSelectedItemsData.Item190 = Init[selectedItemsOffset + 378];
            GetSelectedItemsData.Item190Quantity = Init[selectedItemsOffset + 379];
            GetSelectedItemsData.Item191 = Init[selectedItemsOffset + 380];
            GetSelectedItemsData.Item191Quantity = Init[selectedItemsOffset + 381];
            GetSelectedItemsData.Item192 = Init[selectedItemsOffset + 382];
            GetSelectedItemsData.Item192Quantity = Init[selectedItemsOffset + 383];
            GetSelectedItemsData.Item193 = Init[selectedItemsOffset + 384];
            GetSelectedItemsData.Item193Quantity = Init[selectedItemsOffset + 385];
            GetSelectedItemsData.Item194 = Init[selectedItemsOffset + 386];
            GetSelectedItemsData.Item194Quantity = Init[selectedItemsOffset + 387];
            GetSelectedItemsData.Item195 = Init[selectedItemsOffset + 388];
            GetSelectedItemsData.Item195Quantity = Init[selectedItemsOffset + 389];
            GetSelectedItemsData.Item196 = Init[selectedItemsOffset + 390];
            GetSelectedItemsData.Item196Quantity = Init[selectedItemsOffset + 391];
            GetSelectedItemsData.Item197 = Init[selectedItemsOffset + 392];
            GetSelectedItemsData.Item197Quantity = Init[selectedItemsOffset + 393];
            GetSelectedItemsData.Item198 = Init[selectedItemsOffset + 394];
            GetSelectedItemsData.Item198Quantity = Init[selectedItemsOffset + 395];
        }

        #endregion

        #endregion
    }
}