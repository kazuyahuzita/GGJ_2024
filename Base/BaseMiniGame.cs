using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ミニゲームの結果タイプ
public enum MiniGameResultType
{
	Success,
	Excite,
	Failure,
};

//ミニゲームの結果を表す構造体
[System.Serializable]
public struct MiniGameScore
{
	public int score;  //今回の得点
	public MiniGameResultType type;    //成功or失敗判定
}

public class BaseMiniGame : MonoBehaviour
{
	public MiniGameScore GameScore;

	[SerializeField] protected float timeLimit;
	[SerializeField] protected string subject;
	[SerializeField] protected float waitTime;

    internal void SetScore(MiniGameScore score)
    {
        throw new NotImplementedException();
    }

    [SerializeField] protected bool isEnd;

	//シャッターが開いたときに呼ばれる初期化関数
	public virtual void OnInit() { }

	//ミニゲームの結果を返す関数
	public MiniGameScore GetScore() => GameScore;

	public virtual float GetTimeLimit() => timeLimit;
	public virtual string GetSubject() => subject;
	public virtual float GetWaitTime() => waitTime;
	public bool IsEnd() => isEnd;
}
