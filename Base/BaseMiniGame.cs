using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�~�j�Q�[���̌��ʃ^�C�v
public enum MiniGameResultType
{
	Success,
	Excite,
	Failure,
};

//�~�j�Q�[���̌��ʂ�\���\����
[System.Serializable]
public struct MiniGameScore
{
	public int score;  //����̓��_
	public MiniGameResultType type;    //����or���s����
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

	//�V���b�^�[���J�����Ƃ��ɌĂ΂�鏉�����֐�
	public virtual void OnInit() { }

	//�~�j�Q�[���̌��ʂ�Ԃ��֐�
	public MiniGameScore GetScore() => GameScore;

	public virtual float GetTimeLimit() => timeLimit;
	public virtual string GetSubject() => subject;
	public virtual float GetWaitTime() => waitTime;
	public bool IsEnd() => isEnd;
}
