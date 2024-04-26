using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ヒーローのミニゲームの画像や音声を担当している

public class BurstMiniGame : BaseMiniGame
{

    [SerializeField] GameObject[] imgCard = new GameObject[5];   //ヒーローの画像
    [SerializeField] GameObject[] imgChange = new GameObject[5]; //ヒーローの画像差分(用意できなかった)

    [SerializeField] AudioClip SE_Click;    //開始サウンド
    AudioSource myAudio;                    //自身の音源
    public MoveBurstObject bomb;            //ボムの画像
    int idx;                                //添え字用の変数
    public CountDownScript count;           //時間制限を管理する

    // Start is called before the first frame update
    void Start()
    {
        for (idx = 0; idx < imgCard.Length; idx++)
        {
            imgCard[idx].SetActive(true);       //ヒーローの画像の非表示
            imgChange[idx].SetActive(false);    //ヒーローの画像差分の非表示
        }

        myAudio = GetComponent<AudioSource>(); //自身の音源を取得
    }

    // Update is called once per frame
    void Update()
    {
        //isEndか時間が過ぎたら何もしないようにする
        if (isEnd || count.isCountDown)
        {
            return;
        }

        //時間制限を用いているため、その反応を送るために継承元のisEndを変更している
        if(bomb.isOut)
        {
            isEnd = true;
        }

    }
}
