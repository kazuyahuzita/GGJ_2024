using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabySimulatorGame : BaseMiniGame
{
    [SerializeField] GameObject[] imgCard = new GameObject[5]; //カード画像
    [SerializeField] GameObject[] imgChange = new GameObject[5]; //枠画像

    [SerializeField] AudioClip SE_Click; //開始サウンド
    AudioSource myAudio; //自身の音源

    int idx; //添え字用の変数
    public CountDownScript count;
    public Baby baby;
    // Start is called before the first frame update
    void Start()
    {
        for (idx = 0; idx < imgCard.Length; idx++)
        {
            imgCard[idx].SetActive(true); //カードの非表示
            imgChange[idx].SetActive(false); //変更枠の非表示
        }

        myAudio = GetComponent<AudioSource>(); //自身の音源を取得
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd|| count.isCountDown)
        {
            return;
        }
        if(baby.isOut)
        {
            isEnd = true;
        }
    }
    public void SetScore(MiniGameScore score)
    {
        this.GameScore = score;
    }

}
