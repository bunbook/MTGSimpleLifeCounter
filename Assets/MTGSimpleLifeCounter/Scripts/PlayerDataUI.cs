using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerDataUI : MonoBehaviour 
{

    #region フィールド

    private PlayerData _playerData;

    private Text lifeCountText;
    private Text poisonCountText;

    #endregion


    #region プロパティ

    public int LifeCount
    {
        set
        {
            lifeCountText.text = value.ToString();
        }
    }

    public int PoisonCount
    {
        set
        {
            poisonCountText.text = value.ToString();
        }
    }

    public Button LifeCountPlusOneButton { get; private set; }
    public Button LifeCountMinusOneButton { get; private set; }
    public Button LifeCountPlusFiveButton { get; private set; }
    public Button LifeCountMinusFiveButton { get; private set; }

    public Button PoisonCountPlusOneButton { get; private set; }
    public Button PoisonCountMinusOneButton { get; private set; }

    #endregion


    #region Unity メソッド

    /// <summary> 
    /// 初期化処理
    /// </summary>
    void Awake ()
	{
        lifeCountText = transform.Find("LifeCount/Text").GetComponent<Text>();
        poisonCountText = transform.Find("PoisonCount/Text").GetComponent<Text>();

        LifeCountPlusOneButton = transform.Find("LifeCount/Button/PlusOne").GetComponent<Button>();
        LifeCountPlusFiveButton = transform.Find("LifeCount/Button/PlusFive").GetComponent<Button>();

        LifeCountMinusOneButton = transform.Find("LifeCount/Button/MinusOne").GetComponent<Button>();
        LifeCountMinusFiveButton = transform.Find("LifeCount/Button/MinusFive").GetComponent<Button>();

        PoisonCountPlusOneButton = transform.Find("PoisonCount/Button/PlusOne").GetComponent<Button>();
        PoisonCountMinusOneButton = transform.Find("PoisonCount/Button/MinusOne").GetComponent<Button>();
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

    public void Init(Vector2 anchor, Vector2 position, Transform parent, PlayerData playerData)
    {
        GetComponent<RectTransform>().anchorMin = anchor;
        GetComponent<RectTransform>().anchorMax = anchor;
        transform.position = position;
        transform.SetParent(parent, false);
        transform.SetAsFirstSibling();

        LifeCountPlusOneButton.onClick.AddListener(() => playerData.AddLifeCount(1));
        LifeCountPlusFiveButton.onClick.AddListener(() => playerData.AddLifeCount(5));
        LifeCountMinusOneButton.onClick.AddListener(() => playerData.AddLifeCount(-1));
        LifeCountMinusFiveButton.onClick.AddListener(() => playerData.AddLifeCount(-5));

        PoisonCountPlusOneButton.onClick.AddListener(() => playerData.AddPoisonCount(1));
        PoisonCountMinusOneButton.onClick.AddListener(() => playerData.AddPoisonCount(-1));
    }

    #endregion

}