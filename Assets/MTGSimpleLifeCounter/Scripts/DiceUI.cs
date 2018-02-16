using UnityEngine;
using UnityEngine.UI;
using MTGSimpleLifeCounter;

public class DiceUI : MonoBehaviour 
{

    #region フィールド

    private Text pipNumText;

	#endregion


	#region プロパティ
	
    public Dice Dice { get; private set; }

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
        Dice = new Dice(this);
	}

    #endregion


    #region public メソッド

    public void Init(Vector2 anchor, Vector2 position, Transform parent)
    {
        GetComponent<RectTransform>().anchorMin = anchor;
        GetComponent<RectTransform>().anchorMax = anchor;
        transform.position = position;
        transform.SetParent(parent, false);
    }

    public void Roll()
    {
        // Random.range(0 <= x < 6 * 167) % 6 + 1
        // Random.range(0 <= x < 6) + 1 の方が良い？
        Dice.PipNum = (Random.Range(0, (int)Define.DicePipType.Six * 167) % (int)Define.DicePipType.Six) + (int)Define.DicePipType.One;
        // Dice.PipNum = (Random.Range(0, (int)Define.DicePipType.Six)) + (int)Define.DicePipType.One;
    }

    #endregion

}
