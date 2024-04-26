using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonGame : BaseMiniGame
{
    [SerializeField] GameObject[] imgCard = new GameObject[5];   //�o���[���̉摜
    [SerializeField] GameObject[] imgChange = new GameObject[5]; //�o���[���̍����摜

    [SerializeField] AudioClip SE_Click;        //�J�n�T�E���h
    AudioSource myAudio;                        //���g�̉���

    int idx;                                    //�Y�����p�̕ϐ�
    public CountDownScript count;               //���Ԑ����p�̃N���X

    public UpDownMove upDownMove;               //�|���v���㉺�ɓ������p�̃N���X
    // Start is called before the first frame update
    void Start()
    {
        for (idx = 0; idx < imgCard.Length; idx++)
        {
            imgCard[idx].SetActive(true); //�o���[���̔�\��
            imgChange[idx].SetActive(false); //�o���[�������̔�\��
        }

        myAudio = GetComponent<AudioSource>(); //���g�̉������擾
    }

    // Update is called once per frame
    void Update()
    {
        //�Q�[�����I���������Ƃ����m�����瓮���Ȃ��Ȃ�
        if (isEnd|| count.isCountDown)
        {
            return;
        }
        //���������Ƃ��o���Ȃ��Ȃ�����Q�[�����I������悤�ɔ���������
        if(upDownMove.isOut)
        {
            isEnd = true;
        }


    }
}
