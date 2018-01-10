using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MTGSimpleLifeCounter;

public class ScreenManager : SingletonMonoBehaviour<ScreenManager> 
{

    #region フィールド

    #endregion


    #region プロパティ

    public static float DeviceScreenWidth
    {
        get
        {
            #if UNITY_EDITOR
                return Screen.width;

            #elif UNITY_ANDROID
                return Screen.currentResolution.width;

            #elif UNITY_IOS
                return Screen.currentResolution.width;

            #else
                return Screen.width;

            #endif
        }
    }

    public static float DeviceScreenHeight
    {
        get
        {
            #if UNITY_EDITOR
                return Screen.height;

            #elif UNITY_ANDROID
                return Screen.currentResolution.height;

            #elif UNITY_IOS
                return Screen.currentResolution.height;

            #else
                return Screen.height;

            #endif
        }
    }

    public static float DeviceAspectRatio
    {
        get
        {
            return DeviceScreenWidth / DeviceScreenHeight;
        }
    }

    public static float GameScreenScale
    {
        get
        {
            if(Define.ScreenAspectRatio > DeviceAspectRatio)
            {
                return DeviceScreenWidth / Define.ScreenWidth;
            }
            else if (Define.ScreenAspectRatio < DeviceAspectRatio)
            {
                return DeviceScreenHeight / Define.ScreenHeight;
            }
            return 1.0f;
        }
    }

    public static float GameScreenWidth
    {
        get
        {
            return Define.ScreenWidth * GameScreenScale;
        }
    }

    public static float GameScreenHeight
    {
        get
        {
            return Define.ScreenHeight * GameScreenScale;
        }
    }

    public static float BlackScreenWidth
    {
        get
        {
            return (DeviceScreenWidth - GameScreenWidth) * 0.5f;
        }
    }

    public static float BlackScreenHeight
    {
        get
        {
            return (DeviceScreenHeight - GameScreenHeight) * 0.5f;
        }
    }

    public static float BlackScreenUIWidth
    {
        get
        {
            return (DeviceScreenWidth - GameScreenWidth) * 0.5f * (Define.ScreenWidth / GameScreenWidth);
        }
    }

    public static float BlackScreenUIHeight
    {
        get
        {
            return (DeviceScreenHeight - GameScreenHeight) * 0.5f * (Define.ScreenHeight / GameScreenHeight);
        }
    }

    // public static Vector2 

    #endregion


    #region Unity メソッド

    /// <summary> 
    /// 初期化処理
    /// </summary>
    void Awake ()
	{
        InitSingleton();
    }
	
	/// <summary> 
	/// 更新前処理
	/// </summary>
	void Start () 
	{
        Debug.Log(DeviceScreenWidth + "*" + DeviceScreenHeight);
        Debug.Log(Screen.currentResolution.width);
        Debug.Log(Screen.width);

    }

    /// <summary> 
    /// 更新処理
    /// </summary>
    void Update () 
	{
		
	}
	
	#endregion


	#region メソッド

    public static Vector2 GameViewportToGameScreenPoint(Vector2 gameViewport)
    {
        float posX = GameScreenWidth * gameViewport.x;
        float posY = GameScreenHeight * gameViewport.y;

        return new Vector2(posX, posY);
    }

    public static Vector2 GameScreenToScreenPoint(Vector2 gameScreen)
    {
        float posX = BlackScreenWidth + gameScreen.x;
        float posY = BlackScreenHeight + gameScreen.y;

        return new Vector2(posX, posY);
    }

    public static Vector2 GameViewportToScreenPoint(Vector2 gameViewport)
    {
        return GameScreenToScreenPoint(GameViewportToGameScreenPoint(gameViewport));
    }

    public static Vector2 GameScreenToWorldPoint(Vector2 gameScreen)
    {
        return Camera.main.ScreenToWorldPoint(GameScreenToScreenPoint(gameScreen));
    }

    public static Vector2 GameViewportToWorldPoint(Vector2 gameViewport)
    {
        return Camera.main.ScreenToWorldPoint(GameViewportToScreenPoint(gameViewport));
    }

    #endregion

}
