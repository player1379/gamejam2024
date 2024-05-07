using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// <summary>
public class GameManager
{
    private static GameManager instance = new GameManager();
    private GameManager() { }
    public static GameManager Instance
    {
        get { return instance; }
    }

    /// <summary>
	/// 天数
	/// </summary>
	private int mDay = 1;
    public int Day
    {
        set { mDay = value; }
        get { return mDay; }
    }

    /// <summary>
	/// 声望等级
	/// </summary>
	private int mWordLv = 1;
    public int WordLv
    {
        set { mWordLv = value; }
        get { return mWordLv; }
    }

    /// <summary>
	/// 金钱数
	/// </summary>
	private int mMoney;
    public int Money
    {
        set { mMoney = value; }
        get { return mMoney; }
    }

    /// <summary>
    /// 体力值
    /// </summary>
    private int mFTG;
    public int FTG
    {
        set { mFTG = value; }
        get { return mFTG; }
    }

    /// <summary>
    /// 气泡玩法是否重新开始
    /// </summary>
    private bool mBubbleGameIsStart;
    public bool BubbleGameIsStart
    {
        set { mBubbleGameIsStart = value; }
        get { return mBubbleGameIsStart; }
    }


}

