using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using MTGSimpleLifeCounter;

public class UIController : MonoBehaviour 
{

    #region フィールド

    private Transform screen;

    private GameObject playerDataUILeftPrefab;
    private GameObject playerDataUIRightPrefab;
    private List<PlayerDataUI> playerDataUIs;
    private List<PlayerData> playerDatas;
    
    private Button resetButton;
    private GameObject confirmationWindow;
    private Button confirmationYesButton;
    private Button confirmationNoButton;

    private Button diceRollButton;
    private GameObject diceRollWindow;
    private DiceRollControll diceRollController;
    private GameObject playerDicesUIPrefab;
    private List<PlayerDicesUI> playerDicesUIs;

    #endregion


    #region Unity メソッド

    /// <summary> 
    /// 初期化処理
    /// </summary>
    void Awake ()
	{
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        screen = GameObject.Find("Canvas/Screen").transform;

        // プレイヤーデータ関連
        playerDataUILeftPrefab = (GameObject)Resources.Load("Prefabs/PlayerDataUILeft");
        playerDataUIRightPrefab = (GameObject)Resources.Load("Prefabs/PlayerDataUIRight");

        playerDataUIs = new List<PlayerDataUI>();
        playerDataUIs.Add(Instantiate(playerDataUILeftPrefab).GetComponent<PlayerDataUI>());
        playerDataUIs.Add(Instantiate(playerDataUIRightPrefab).GetComponent<PlayerDataUI>());
        playerDatas = Enumerable.Range(0, Define.PlayerNum).Select(x => new PlayerData(this.playerDataUIs[x])).ToList();

        playerDataUIs[0].Init(new Vector2(0, 0.5f), new Vector2(285, 0), screen.transform, playerDatas[0]);
        playerDataUIs[1].Init(new Vector2(1, 0.5f), new Vector2(-285, 0), screen.transform, playerDatas[1]);

        // リセットボタン関連
        resetButton = screen.Find("Button/Reset").GetComponent<Button>();
        confirmationWindow = screen.Find("Window/Confirmation").gameObject;
        confirmationYesButton = confirmationWindow.transform.Find("Button/Yes").GetComponent<Button>();
        confirmationNoButton = confirmationWindow.transform.Find("Button/No").GetComponent<Button>();

        // ダイスロール関連
        diceRollButton = screen.Find("Button/DiceRoll").GetComponent<Button>();
        diceRollWindow = screen.Find("Window/DiceRoll").gameObject;
        diceRollController = GameObject.Find("DiceRollController").GetComponent<DiceRollControll>();

        playerDicesUIPrefab = (GameObject)Resources.Load("Prefabs/PlayerDicesUI");
        playerDicesUIs = Enumerable.Range(0, Define.PlayerNum).Select(x => Instantiate(playerDicesUIPrefab).GetComponent<PlayerDicesUI>()).ToList();

        playerDicesUIs[0].Init(new Vector2(0, 0.5f), new Vector2(230, 0), diceRollWindow.transform);
        playerDicesUIs[1].Init(new Vector2(1, 0.5f), new Vector2(-230, 0), diceRollWindow.transform);

        diceRollController.Init(playerDicesUIs);
    }

    /// <summary> 
    /// 更新前処理
    /// </summary>
    void Start () 
	{
        resetButton.onClick.AddListener(ShowHideConfirmationWIndow);

        confirmationYesButton.onClick.AddListener(Reset);
        confirmationNoButton.onClick.AddListener(() => confirmationWindow.SetActive(false));
        confirmationWindow.SetActive(false);

        diceRollButton.onClick.AddListener(ShowHideDiceRollWindow);
        diceRollWindow.SetActive(false);
    }
	
	#endregion


	#region public メソッド
	
    public void Reset()
    {
        playerDatas[0].Init();
        playerDatas[1].Init();
        confirmationWindow.SetActive(false);
    }

    public void ShowHideConfirmationWIndow()
    {
        confirmationWindow.SetActive(!confirmationWindow.activeSelf);
        confirmationWindow.transform.SetAsLastSibling();
    }

    public void ShowHideDiceRollWindow()
    {
        diceRollController.StartRoll();
        diceRollWindow.SetActive(!diceRollWindow.activeSelf);
        diceRollWindow.transform.SetAsLastSibling();
    }

    #endregion

}
