using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using MTGSimpleLifeCounter;

public class PlayerDicesUI : MonoBehaviour 
{

    #region フィールド

    private Text dicePipsSumText;

    private GameObject diceUIPrefab;

    private List<DiceUI> diceUIs;

    #endregion


    #region プロパティ

    public int PipsSum
    {
        get
        {
            return diceUIs.Select(x => x.dice.PipNum).Sum();
        }
    }

    #endregion


    #region Unity メソッド

    /// <summary> 
    /// 初期化処理
    /// </summary>
    void Awake ()
	{
        dicePipsSumText = transform.Find("Text").GetComponent<Text>();
        dicePipsSumText.text = "-";

        diceUIPrefab = (GameObject)Resources.Load("Prefabs/DiceUI");

        diceUIs = Enumerable.Range(0, Define.PlayerDiceNum).Select(x => Instantiate(diceUIPrefab).GetComponent<DiceUI>()).ToList();
        diceUIs[0].Init(new Vector2(0.5f, 0.5f), new Vector2(95, -95), this.transform);
        diceUIs[1].Init(new Vector2(0.5f, 0.5f), new Vector2(-95, -95), this.transform);
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
		
	}

    #endregion


    #region メソッド

    public void Init(Vector2 anchor, Vector2 position, Transform parent)
    {
        GetComponent<RectTransform>().anchorMin = anchor;
        GetComponent<RectTransform>().anchorMax = anchor;
        transform.position = position;
        transform.SetParent(parent, false);
    }

    public void RollDices()
    {
        foreach(DiceUI dice in diceUIs)
        {
            dice.Roll();
        }
    }

    public void DisplayPipsSum(bool winColor)
    {
        if (winColor)
        {
            dicePipsSumText.color = new Color(255f/255, 255f/255, 100f/255, 1f);
        }
        else
        {
            dicePipsSumText.color = new Color(1f, 1f, 1f, 1f);
        }

        dicePipsSumText.text = PipsSum.ToString();
    }

	#endregion

}
