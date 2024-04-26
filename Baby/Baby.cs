using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{
    public GameObject baby;             //赤ちゃんの元画像
    public BaseMiniGame game;           //継承元のクラス

    [Header("結果に応じたスコアを送る用の変数")] public  MiniGameScore score;         
    public MiniGameScore score1;        
    public MiniGameScore score2;        
    

    public Sprite babyImage;        //赤ちゃんの元画像
    public Sprite fatImage;         //太った画像
    public Sprite NormalImage;      //何もなっていない画像
    public Sprite machoImage;       //ムキムキな画像

    public AudioSource myAudio;     //自身の音源（Startで定義している）

    public AudioClip SE_Muscle;     //マッチョになった時のSE
    public AudioClip SE_Rough;      //太ってしまった時のSE

    public bool isOut;              //処理が終わったことを知らせる
    public bool isAudio;            //SEや音楽が重ならないようにする
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>(); //自身の音源を取得

        baby.GetComponent<SpriteRenderer>().sprite = babyImage; 
        //初期化
        isOut = false;
        isAudio = false;
    }

    // Update is called once per frame
    void Update()
    {
        //isOutがtrueになったら何も起こさないようにしている
        if (isOut) return;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //プレイヤーが近付けたアイテムにより画像とスコアの変化を
        //そして、SEを鳴らし、ゲーム終了を伝えている


        if(collision.gameObject.tag == "Normal")
        {
            baby.GetComponent<SpriteRenderer>().sprite = NormalImage;
            Destroy(collision.gameObject);
            game.GameScore = score;
            if (!isAudio)
            {
                myAudio.PlayOneShot(SE_Rough);
                isAudio = true;
            }

            isOut = true;
        }
        else if(collision.gameObject.tag == "Fat")
        {
            baby.GetComponent<SpriteRenderer>().sprite = fatImage;
            Destroy(collision.gameObject);
            game.GameScore = score1;

            isOut = true;
        }
        else if(collision.gameObject.tag == "macho")
        {
            baby.GetComponent<SpriteRenderer>().sprite = machoImage;
            Destroy(collision.gameObject);
            game.GameScore = score2;
            if (!isAudio)
            {
                myAudio.PlayOneShot(SE_Muscle);
                isAudio = true;
            }

            isOut = true;
        }
    }
}
