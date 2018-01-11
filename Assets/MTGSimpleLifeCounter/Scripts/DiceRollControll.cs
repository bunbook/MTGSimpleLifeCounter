using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using MTGSimpleLifeCounter;

public class DiceRollControll : MonoBehaviour 
{

    #region フィールド
    
    private GameObject diceRollWindow;
    /*
    private GameObject playerDicesUIPrefab;
    */
    private List<PlayerDicesUI> playerDicesUIs;


    private bool rollStart;

    private int rollCount;

    #endregion

    #region プロパティ



    #endregion


    #region Unity メソッド

    /// <summary> 
    /// 初期化処理
    /// </summary>
    void Awake ()
	{
        
        diceRollWindow = GameObject.Find("Canvas/Screen/Window/DiceRoll").gameObject;
        /*
        playerDicesUIPrefab = (GameObject)Resources.Load("Prefabs/PlayerDicesUI");

        playerDicesUIs = Enumerable.Range(0, Define.PlayerNum).Select(x => Instantiate(playerDicesUIPrefab).GetComponent<PlayerDicesUI>()).ToList();
        playerDicesUIs[0].Init(new Vector2(0, 0.5f), new Vector2(315, 0), diceRollWindow.transform);
        playerDicesUIs[1].Init(new Vector2(1, 0.5f), new Vector2(-315, 0), diceRollWindow.transform);

        InitPramatar();
        */
    }

    /// <summary> 
    /// 更新前処理
    /// </summary>
    void Start () 
	{
		
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


	#region メソッド
	
    public void Init(List<PlayerDicesUI> list)
    {
        playerDicesUIs = list;
        InitPramatar();
    }

    private void InitPramatar()
    {
        rollStart = false;
        rollCount = 100;
    }

    public void StartRoll()
    {
        if (diceRollWindow.activeSelf == false && rollStart == false) rollStart = true;
    }

    public void ReStartRoll()
    {
        if (diceRollWindow.activeSelf == true && rollStart == false) rollStart = true;
    }

    #endregion

}
