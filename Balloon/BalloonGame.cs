using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonGame : BaseMiniGame
{
    [SerializeField] GameObject[] imgCard = new GameObject[5];   //バルーンの画像
    [SerializeField] GameObject[] imgChange = new GameObject[5]; //バルーンの差分画像

    [SerializeField] AudioClip SE_Click;        //開始サウンド
    AudioSource myAudio;                        //自身の音源

    int idx;                                    //添え字用の変数
    public CountDownScript count;               //時間制限用のクラス

    public UpDownMove upDownMove;               //ポンプを上下に動かす用のクラス
    // Start is called before the first frame update
    void Start()
    {
        for (idx = 0; idx < imgCard.Length; idx++)
        {
            imgCard[idx].SetActive(true); //バルーンの非表示
            imgChange[idx].SetActive(false); //バルーン差分の非表示
        }

        myAudio = GetComponent<AudioSource>(); //自身の音源を取得
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームが終了したことを感知したら動かなくなる
        if (isEnd|| count.isCountDown)
        {
            return;
        }
        //動かすことが出来なくなったらゲームを終了するように反応させる
        if(upDownMove.isOut)
        {
            isEnd = true;
        }


    }
}
