using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MTGSimpleLifeCounter;

public class DiceUI : MonoBehaviour 
{

    #region フィールド

    private Text pipNumText;

	#endregion


	#region プロパティ
	
    public Dice dice { get; private set; }

    public Define.DicePipType PipNum
    {
        set
        {
            if (value == Define.DicePipType.One)
            {
                pipNumText.fontSize = 120;
            }
            else
            {
                pipNumText.fontSize = 33;
            }
            pipNumText.text = value.ToStr();
        }
    }

	#endregion


	#region Unity メソッド
	
	/// <summary> 
	/// 初期化処理
	/// </summary>
	void Awake ()
	{
        pipNumText = transform.Find("Text").GetComponent<Text>();
        dice = new Dice(this);
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

    public void Roll()
    {
        dice.PipNum = (Random.Range(0, (int)Define.DicePipType.Five + (int)Define.DicePipType.Six * 166) % (int)Define.DicePipType.Six) + (int)Define.DicePipType.One;
    }

    #endregion

}
