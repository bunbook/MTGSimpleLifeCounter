using UnityEngine;
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
            if (_lifeCount < Define.MinLifeCount)
            {
                _lifeCount = Define.MinLifeCount;
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
            if (_poisonCount < Define.MinPoisonCount)
            {
                _poisonCount = Define.MinPoisonCount;
            }
            if (_poisonCount > Define.MaxPoisonCount)
            {
                _poisonCount = Define.MaxPoisonCount;
            }
            _playerDataUI.PoisonCount = _poisonCount;
        }
    }

    #endregion


    #region コンストラクタ

    public PlayerData(PlayerDataUI playerDataUI)
    {
        _playerDataUI = playerDataUI;
        Init();
    }

    #endregion


    #region public メソッド

    public void Init()
    {
        LifeCount = Define.InitialLifeCount;
        PoisonCount = Define.MinPoisonCount;
    }

    public void AddLifeCount(int addValue)
    {
        if (LifeCount >= int.MaxValue - Mathf.Abs(addValue))
        {
            // int最大値考慮
            LifeCount = int.MaxValue;
            return;
        }
        LifeCount += addValue;
    }

    public void AddPoisonCount(int addValue)
    {
        PoisonCount += addValue;
    }

    #endregion

}
