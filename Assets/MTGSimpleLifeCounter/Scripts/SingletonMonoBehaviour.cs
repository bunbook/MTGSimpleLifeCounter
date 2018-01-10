using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ジェネリックなシングルトンクラス
/// http://naichilab.blogspot.jp/2013/11/unitymanager.html
/// </summary>
/// <typeparam name="T"></typeparam>

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{

    #region フィールド

    private static T instance;

	#endregion


	#region プロパティ

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));

                if (instance == null)
                {
                    Debug.LogError(typeof(T) + "is nothing");
                }
            }

            return instance;
        }
    }

    #endregion


    #region プロパティ

    public void InitSingleton()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    #endregion

    /// <summary>
    /// 使用例
    /// </summary>
    /*
    using UnityEngine;

    public class AudioManager : SingletonMonoBehaviour<AudioManager>
    {

        public void Awake()
        {
            if (this != Instance)
            {
                Destroy(this);
                return;
            }

            DontDestroyOnLoad(this.gameObject);
        }

    }
    */

}
