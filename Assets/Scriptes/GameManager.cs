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
	/// ����
	/// </summary>
	private int mDay = 1;
    public int Day
    {
        set { mDay = value; }
        get { return mDay; }
    }

    /// <summary>
	/// �����ȼ�
	/// </summary>
	private int mWordLv = 1;
    public int WordLv
    {
        set { mWordLv = value; }
        get { return mWordLv; }
    }

    /// <summary>
	/// ��Ǯ��
	/// </summary>
	private int mMoney;
    public int Money
    {
        set { mMoney = value; }
        get { return mMoney; }
    }

    /// <summary>
    /// ����ֵ
    /// </summary>
    private int mFTG;
    public int FTG
    {
        set { mFTG = value; }
        get { return mFTG; }
    }

    /// <summary>
    /// �����淨�Ƿ����¿�ʼ
    /// </summary>
    private bool mBubbleGameIsStart;
    public bool BubbleGameIsStart
    {
        set { mBubbleGameIsStart = value; }
        get { return mBubbleGameIsStart; }
    }


}

