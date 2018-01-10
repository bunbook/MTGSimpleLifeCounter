using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : SingletonMonoBehaviour<AppManager> 
{

    #region フィールド

    PlayerDataUI _playerDataUI1;
    PlayerDataUI _playerDataUI2;

    [SerializeField]
    GameObject playerDataUIprefab;

    #endregion


    #region プロパティ

    public static PlayerData PlayerData1 { get; set; }
    public static PlayerData PlayerData2 { get; set; }

    public PlayerDataUI PlayerDataUI1
    {
        get
        {
            return _playerDataUI1;
        }
        set
        {
            _playerDataUI1 = value;
        }
    }

    public PlayerDataUI PlayerDataUI2
    {
        get
        {
            return _playerDataUI2;
        }
        set
        {
            _playerDataUI2 = value;
        }
    }

    #endregion


    #region Unity メソッド

    /// <summary> 
    /// 初期化処理
    /// </summary>
    void Awake ()
	{
        InitSingleton();

        InitData();

        PlayerDataUI1 = GameObject.Find("Canvas/PlayerDataUI1").GetComponent<PlayerDataUI>();
        // PlayerDataUI1 = Instantiate(playerDataUIprefab).GetComponent<PlayerDataUI>();
        // PlayerDataUI1.name = "PlayerDataUI1";

        PlayerDataUI2 = GameObject.Find("Canvas/PlayerDataUI2").GetComponent<PlayerDataUI>();
        // PlayerDataUI1 = Instantiate(playerDataUIprefab).GetComponent<PlayerDataUI>();
        // PlayerDataUI1.name = "PlayerDataUI1";

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
	
    public static void InitData()
    {
        //PlayerData1 = new PlayerData();
        //PlayerData2 = new PlayerData();
    }

    public static void InitParamator()
    {
        PlayerData1.InitParameter();
        PlayerData2.InitParameter();
    }

    #endregion

}
