using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�q�[���[�̃~�j�Q�[���̉摜�≹����S�����Ă���

public class BurstMiniGame : BaseMiniGame
{

    [SerializeField] GameObject[] imgCard = new GameObject[5];   //�q�[���[�̉摜
    [SerializeField] GameObject[] imgChange = new GameObject[5]; //�q�[���[�̉摜����(�p�ӂł��Ȃ�����)

    [SerializeField] AudioClip SE_Click;    //�J�n�T�E���h
    AudioSource myAudio;                    //���g�̉���
    public MoveBurstObject bomb;            //�{���̉摜
    int idx;                                //�Y�����p�̕ϐ�
    public CountDownScript count;           //���Ԑ������Ǘ�����

    // Start is called before the first frame update
    void Start()
    {
        for (idx = 0; idx < imgCard.Length; idx++)
        {
            imgCard[idx].SetActive(true);       //�q�[���[�̉摜�̔�\��
            imgChange[idx].SetActive(false);    //�q�[���[�̉摜�����̔�\��
        }

        myAudio = GetComponent<AudioSource>(); //���g�̉������擾
    }

    // Update is called once per frame
    void Update()
    {
        //isEnd�����Ԃ��߂����牽�����Ȃ��悤�ɂ���
        if (isEnd || count.isCountDown)
        {
            return;
        }

        //���Ԑ�����p���Ă��邽�߁A���̔����𑗂邽�߂Ɍp������isEnd��ύX���Ă���
        if(bomb.isOut)
        {
            isEnd = true;
        }

    }
}
