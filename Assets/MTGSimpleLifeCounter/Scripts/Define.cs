
namespace MTGSimpleLifeCounter
{
    public static class Define
    {

        #region 定数

        // 結局使ってないが一応残しておく
        public const float ScreenWidth = 1280;
        public const float ScreenHeight = 800;
        
        public const int PlayerNum = 2;
        public const int PlayerDiceNum = 2;
        
        public const int InitialLifeCount = 20;
        public const int MinLifeCount = 0;

        public const int MinPoisonCount = 0;
        public const int MaxPoisonCount = 10;

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


        #region public static メソッド

        public static string ToStr(this DicePipType dicePipType)
        {
            string str = string.Empty;
            switch (dicePipType)
            {
                case DicePipType.One:
                    str = "Φ";
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
