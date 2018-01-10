using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MTGSimpleLifeCounter;

public class ScreenController : MonoBehaviour 
{

    #region フィールド

    GameObject blackScreenPrefab;

	#endregion


	#region プロパティ
	
	#endregion


	#region Unity メソッド
	
	/// <summary> 
	/// 初期化処理
	/// </summary>
	void Awake ()
	{
        blackScreenPrefab = (GameObject)Resources.Load("Prefabs/BlackScreenPrefab");

        InitScreen();
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
        // ios考慮してダイアログとかボタン設置した方がいいかも？
        #if UNITY_STANDALONE_WIN
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        #elif UNITY_STANDALONE_OSX
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        #endif
    }

    #endregion


    #region メソッド

    void InitScreen()
    {
        // UICanvasの基準となる解像度を定義値に設定
        CanvasScaler canvasScaler = GameObject.Find("Canvas").GetComponent<CanvasScaler>();
        if (canvasScaler)
        {
            canvasScaler.referenceResolution = new Vector2(Define.ScreenWidth, Define.ScreenHeight);
        }

        if (ScreenManager.DeviceAspectRatio == Define.ScreenAspectRatio) return;

        // GameObjectの大きさは解像度の縦を基準に変更されるので、
        // 横を基準としたい画面の際は（横を基準とした大きさに）補正をかけ直す
        if (ScreenManager.DeviceAspectRatio < Define.ScreenAspectRatio)
        {
            Camera mainCamera = Camera.main;
            float deviceScale = Define.ScreenAspectRatio / ScreenManager.DeviceAspectRatio;
            mainCamera.orthographicSize *= deviceScale;
            Debug.Log("Scaled");
        }

        // 黒帯生成
        // 横
        // if (Define.ScreenAspectRatio > ScreenManager.DeviceAspectRatio)
        if (ScreenManager.BlackScreenWidth != 0)
        {
            GameObject parent = GameObject.Find("Canvas");

            Vector3 pos = new Vector3(Define.ScreenWidth * 0.5f + ScreenManager.BlackScreenUIWidth * 0.5f, 0.0f, 0.0f);

            GameObject blackScreenLeft = Instantiate(blackScreenPrefab) as GameObject;
            GameObject blackScreenRight = Instantiate(blackScreenPrefab) as GameObject;

            blackScreenLeft.transform.position = pos;
            blackScreenRight.transform.position = -pos;

            Debug.Log(blackScreenLeft.transform.position);
            Debug.Log(blackScreenRight.transform.position);

            blackScreenRight.GetComponent<RectTransform>().sizeDelta = new Vector2(ScreenManager.BlackScreenUIWidth, Define.ScreenHeight);
            blackScreenLeft.GetComponent<RectTransform>().sizeDelta = new Vector2(ScreenManager.BlackScreenUIWidth, Define.ScreenHeight);

            blackScreenRight.transform.SetParent(parent.transform, false);
            blackScreenLeft.transform.SetParent(parent.transform, false);
        }
        // 縦
        // else if (Define.ScreenAspectRatio < ScreenManager.DeviceAspectRatio)
        else if(ScreenManager.BlackScreenHeight != 0)
        {
            GameObject parent = GameObject.Find("Canvas");

            Vector2 pos = new Vector2(0, Define.ScreenHeight * 0.5f + ScreenManager.BlackScreenUIHeight * 0.5f);
            
            GameObject blackScreenLeft = Instantiate(blackScreenPrefab) as GameObject;
            GameObject blackScreenRight = Instantiate(blackScreenPrefab) as GameObject;

            blackScreenLeft.transform.position = pos;
            blackScreenRight.transform.position = -pos;

            blackScreenRight.GetComponent<RectTransform>().sizeDelta = new Vector2(Define.ScreenWidth, ScreenManager.BlackScreenUIHeight);
            blackScreenLeft.GetComponent<RectTransform>().sizeDelta = new Vector2(Define.ScreenWidth, ScreenManager.BlackScreenUIHeight);

            blackScreenRight.transform.SetParent(parent.transform, false);
            blackScreenLeft.transform.SetParent(parent.transform, false);
            
        }
    }

	#endregion

}
