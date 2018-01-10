using System.Collections;
using System.Collections.Generic;

namespace MTGSimpleLifeCounter
{
    public static class Define
    {

        #region 定数

        public const float ScreenWidth = 1600;
        public const float ScreenHeight = 1200;

        // public const int SmallScreenWidth = 1600;
        // public const int SmallScreenHeight = 1200;

        public const int PlayerNum = 2;
        public const int PlayerDiceNum = 2;
        
        public const int initialLifeCount = 20;
        public const int minLifeCount = 0;

        public const int minPoisonCount = 0;
        public const int maxPoisonCount = 10;

        #endregion

        #region 列挙

        public enum DicePipType
        {
            One = 1, 
            Two, 
            Three, 
            Four, 
            Five, 
            Six
        }

        #endregion

        #region プロパティ

        public static float ScreenAspectRatio
        {
            get
            {
                return ScreenWidth / ScreenHeight;
            }
        }

        #endregion


        #region メソッド

        public static string ToStr(this DicePipType dicePipType)
        {
            string str = string.Empty;
            switch (dicePipType)
            {
                case DicePipType.One:
                    str = "Φ"; // "Φ"; "●";
                    break;
                case DicePipType.Two:
                    str = "● 　 　\n"
                        + "　 　 　\n"
                        + "　 　 ●";
                    break;
                case DicePipType.Three:
                    str = "● 　 　\n"
                        + "　 ● 　\n"
                        + "　 　 ●";
                    break;
                case DicePipType.Four:
                    str = "● 　 ●\n"
                        + "　 　 　\n"
                        + "● 　 ●";
                    break;
                case DicePipType.Five:
                    str = "● 　 ●\n"
                        + "　 ● 　\n"
                        + "● 　 ●";
                    break;
                case DicePipType.Six:
                    str = "● 　 ●\n"
                        + "● 　 ●\n"
                        + "● 　 ●";
                    break;
            }
            return str;
        }

        #endregion

    }
}
