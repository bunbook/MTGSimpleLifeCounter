using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using MTGSimpleLifeCounter;

// こいつManagerにしてLayOut情報持たせていいのでは
// 後UI系はいい感じに位置設定できるクラス継承させたい
public class UIController : MonoBehaviour 
{

    #region フィールド

    private GameObject playerDataUIPrefab;

    private List<PlayerDataUI> playerDataUIs;
    private List<PlayerData> playerDatas;


    private PlayerDataUI playerDataUI1;
    private PlayerDataUI playerDataUI2;
    private PlayerData playerData1;
    private PlayerData playerData2;

    private Transform screen;

    private Button diceRollButton;
    private Button resetButton;
    private Button changeLayoutButton;

    private GameObject confirmationWindow;
    private Button confirmationYesButton;
    private Button confirmationNoButton;

    private GameObject diceRollWindow;
    private DiceRollControll diceRollController;

    private GameObject playerDicesUIPrefab;
    private List<PlayerDicesUI> playerDicesUIs;



    #endregion


    #region プロパティ

    #endregion


    #region Unity メソッド

    /// <summary> 
    /// 初期化処理
    /// </summary>
    void Awake ()
	{
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        screen = GameObject.Find("Canvas/Screen").transform;

        playerDataUIPrefab = (GameObject)Resources.Load("Prefabs/PlayerDataUI");

        // playerDataUIs = Enumerable.Repeat(Instantiate(playerDataUIPrefab).GetComponent<PlayerDataUI>(), Define.PlayerNum).ToList();
        playerDataUIs = Enumerable.Range(0, Define.PlayerNum).Select(x => Instantiate(playerDataUIPrefab).GetComponent<PlayerDataUI>()).ToList();

        playerDatas = Enumerable.Range(0, Define.PlayerNum).Select(x => new PlayerData(this.playerDataUIs[x])).ToList();

        playerDataUIs[0].Init(new Vector2(0, 0.5f), new Vector2(285, 0), screen.transform, playerDatas[0]);
        playerDataUIs[1].Init(new Vector2(1, 0.5f), new Vector2(-285, 0), screen.transform, playerDatas[1]);

        /*
        playerDataUI1 = Instantiate(playerDataUIPrefab).GetComponent<PlayerDataUI>();
        playerDataUI2 = Instantiate(playerDataUIPrefab).GetComponent<PlayerDataUI>();
        playerData1 = new PlayerData(playerDataUI1);
        playerData2 = new PlayerData(playerDataUI2);
        
        playerDataUI1.Init(new Vector2(0, 0.5f), new Vector2(350, 0), canvas.transform, playerData1);
        playerDataUI2.Init(new Vector2(1, 0.5f), new Vector2(-350, 0), canvas.transform, playerData2);
        */

        diceRollButton = screen.Find("Button/DiceRoll").GetComponent<Button>();
        resetButton = screen.Find("Button/Reset").GetComponent<Button>();
        changeLayoutButton = screen.Find("Button/ChangeLayout").GetComponent<Button>();

        confirmationWindow = screen.Find("Window/Confirmation").gameObject;
        confirmationYesButton = confirmationWindow.transform.Find("Button/Yes").GetComponent<Button>();
        confirmationNoButton = confirmationWindow.transform.Find("Button/No").GetComponent<Button>();

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
        resetButton.onClick.AddListener(() => confirmationWindow.SetActive(true));
        confirmationYesButton.onClick.AddListener(Reset);
        confirmationNoButton.onClick.AddListener(() => confirmationWindow.SetActive(false));
        
        confirmationWindow.SetActive(false);

        diceRollButton.onClick.AddListener(OpenCloseDiceRollWindow);
        diceRollWindow.SetActive(false);
    }

    /// <summary> 
    /// 更新処理
    /// </summary>
    void Update () 
	{
		
	}
	
	#endregion


	#region メソッド
	
    public void Reset()
    {
        playerDatas[0].InitParameter();
        playerDatas[1].InitParameter();
        confirmationWindow.SetActive(false);
        
        // playerData1.InitParameter();
        // playerData2.InitParameter();
    }

    public void OpenCloseDiceRollWindow()
    {
        diceRollController.StartRoll();
        diceRollWindow.SetActive(!diceRollWindow.activeSelf);
    }

    #endregion

}
