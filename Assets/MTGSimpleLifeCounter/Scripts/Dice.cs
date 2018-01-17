using System;
using MTGSimpleLifeCounter;

public class Dice
{

    #region フィールド

    private DiceUI diceUI;
    private Define.DicePipType _pipNum;

    #endregion


    #region プロパティ

    public int PipNum
    {
        get
        {
            return (int)_pipNum;
        }
        set
        {
            if (value < (int)Define.DicePipType.One || (int)Define.DicePipType.Six < value) return;
            _pipNum = (Define.DicePipType)Enum.ToObject(typeof(Define.DicePipType), value);
            diceUI.PipNum = _pipNum;
        }
    }

	#endregion


    #region コンストラクタ
    
    public Dice(DiceUI diceUI)
    {
        this.diceUI = diceUI;
        PipNum = (int)Define.DicePipType.One;
    }

    #endregion

}
