using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using MTGSimpleLifeCounter;

public class PlayerData
{

    #region フィールド

    private int _lifeCount;
    private int _poisonCount;

    private PlayerDataUI _playerDataUI;

	#endregion


	#region プロパティ
	
    public int LifeCount
    {
        get
        {
            return _lifeCount;
        }
        set
        {
            _lifeCount = value;
            if (_lifeCount < Define.minLifeCount)
            {
                _lifeCount = Define.minLifeCount;
            }
            _playerDataUI.LifeCount = _lifeCount;
        }
    }

    public int PoisonCount
    {
        get
        {
            return _poisonCount;
        }
        set
        {
            _poisonCount = value;
            if (_poisonCount < Define.minPoisonCount)
            {
                _poisonCount = Define.minPoisonCount;
            }
            if (_poisonCount > Define.maxPoisonCount)
            {
                _poisonCount = Define.maxPoisonCount;
            }
            _playerDataUI.PoisonCount = _poisonCount;
        }
    }

    public PlayerDataUI PlayerDataUI { get; set; }

    #endregion


    #region コンストラクタ

    public PlayerData(PlayerDataUI playerDataUI)
    {
        _playerDataUI = playerDataUI;
        InitParameter();
    }

    #endregion


    #region メソッド

    public void InitParameter()
    {
        LifeCount = Define.initialLifeCount;
        PoisonCount = Define.minPoisonCount;
    }

    public void AddLifeCount(int addValue)
    {
        LifeCount += addValue;
    }

    public void AddPoisonCount(int addValue)
    {
        PoisonCount += addValue;
    }

    #endregion

}
