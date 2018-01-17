using System.Collections.Generic;
using UnityEngine;

public class DiceRollControll : MonoBehaviour 
{

    #region フィールド
    
    private GameObject diceRollWindow;
    private List<PlayerDicesUI> playerDicesUIs;
    private bool rollStart;
    private int rollCount;

    #endregion


    #region Unity メソッド

    /// <summary> 
    /// 初期化処理
    /// </summary>
    void Awake ()
	{
        diceRollWindow = GameObject.Find("Canvas/Screen/Window/DiceRoll").gameObject;
    }
	
	/// <summary> 
	/// 更新処理
	/// </summary>
	void Update () 
	{
        if (!rollStart) return;

        foreach (PlayerDicesUI playerDices in playerDicesUIs)
        {
            playerDices.RollDices();
        }
        rollCount--;

        if (rollCount != 0) return;

        playerDicesUIs[0].DisplayPipsSum(playerDicesUIs[0].PipsSum > playerDicesUIs[1].PipsSum);
        playerDicesUIs[1].DisplayPipsSum(playerDicesUIs[0].PipsSum < playerDicesUIs[1].PipsSum);

        InitPramatar();
    }

    #endregion


    #region private メソッド

    private void InitPramatar()
    {
        rollStart = false;
        rollCount = 60;
    }

    #endregion


    #region メソッド

    public void Init(List<PlayerDicesUI> list)
    {
        playerDicesUIs = list;
        InitPramatar();
    }
    
    public void StartRoll()
    {
        if (diceRollWindow.activeSelf == false && rollStart == false) rollStart = true;
    }

    #endregion

}
