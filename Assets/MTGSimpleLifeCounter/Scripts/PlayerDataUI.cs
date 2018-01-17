using UnityEngine;
using UnityEngine.UI;


public class PlayerDataUI : MonoBehaviour 
{

    #region フィールド

    private PlayerData _playerData;

    private Text lifeCountText;
    private Text poisonCountText;

    private Button lifeCountPlusOneButton;
    private Button lifeCountMinusOneButton;
    private Button lifeCountPlusFiveButton;
    private Button lifeCountMinusFiveButton;

    private Button poisonCountPlusOneButton;
    private Button poisonCountMinusOneButton;

    #endregion


    #region プロパティ

    public int LifeCount
    {
        set
        {
            if (value > 5)
            {
                lifeCountText.color = new Color(100f/255, 255f/255, 125f/255, 1f);
            }
            else
            {
                lifeCountText.color = new Color(255f/255, 100f/255, 100f/255, 1f);
            }
            if (value == int.MaxValue)
            {
                lifeCountText.text = "∞";
                return;
            }
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
    
    #endregion


    #region Unity メソッド

    /// <summary> 
    /// 初期化処理
    /// </summary>
    void Awake ()
	{
        lifeCountText = transform.Find("LifeCount/Text").GetComponent<Text>();
        poisonCountText = transform.Find("PoisonCount/Text").GetComponent<Text>();

        lifeCountPlusOneButton = transform.Find("LifeCount/Button/PlusOne").GetComponent<Button>();
        lifeCountPlusFiveButton = transform.Find("LifeCount/Button/PlusFive").GetComponent<Button>();

        lifeCountMinusOneButton = transform.Find("LifeCount/Button/MinusOne").GetComponent<Button>();
        lifeCountMinusFiveButton = transform.Find("LifeCount/Button/MinusFive").GetComponent<Button>();

        poisonCountPlusOneButton = transform.Find("PoisonCount/Button/PlusOne").GetComponent<Button>();
        poisonCountMinusOneButton = transform.Find("PoisonCount/Button/MinusOne").GetComponent<Button>();
    }

    #endregion


    #region public メソッド

    public void Init(Vector2 anchor, Vector2 position, Transform parent, PlayerData playerData)
    {
        GetComponent<RectTransform>().anchorMin = anchor;
        GetComponent<RectTransform>().anchorMax = anchor;
        transform.position = position;
        transform.SetParent(parent, false);
        transform.SetAsFirstSibling();

        lifeCountPlusOneButton.onClick.AddListener(() => playerData.AddLifeCount(1));
        lifeCountPlusFiveButton.onClick.AddListener(() => playerData.AddLifeCount(5));
        lifeCountMinusOneButton.onClick.AddListener(() => playerData.AddLifeCount(-1));
        lifeCountMinusFiveButton.onClick.AddListener(() => playerData.AddLifeCount(-5));

        poisonCountPlusOneButton.onClick.AddListener(() => playerData.AddPoisonCount(1));
        poisonCountMinusOneButton.onClick.AddListener(() => playerData.AddPoisonCount(-1));
    }

    #endregion

}