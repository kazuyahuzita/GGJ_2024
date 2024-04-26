using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ヒーローのミニゲームの爆弾管理と点数の制御をしている

public class MoveBurstObject : MonoBehaviour
{

    public BaseMiniGame game;

    [Header("結果に応じたスコアを送る用の変数")] public MiniGameScore score;
    public MiniGameScore score1;
    public MiniGameScore score2;

    //爆弾が移動する速度
    [SerializeField] float MoveSpeed = 4.0f;
    //爆弾が移動する間隔
    [SerializeField] int direction =1;

    //サイズ変更用の変数
    [SerializeField] float SizeX =1;
    [SerializeField] float SizeY =1;

    [SerializeField] GameObject Bomb;
    [SerializeField] GameObject EffectImage;
    //移動する二地点のTransform
    [SerializeField] private Transform _LeftEdge;
    [SerializeField] private Transform _RightEdge;
    // publicで宣言し、inspectorで設定可能にする
    //dart:砂煙
    public Sprite DartSprite;
    public Sprite BurstSprite;
    public Sprite BigBurstSprite;
    public Sprite NoneSprite;
    //爆弾を落とすためにリジッドボディを触った時だけ追加
    Rigidbody2D rdbody2D;
    //CenterPositionにあるGameObjectと比較してポイントを判定させる
    [SerializeField] GameObject CenterPosition;
    [SerializeField] bool isBurst;
    //BaseGameにIsEndを送るために、BurstMiniGameに送るよう
    public bool isOut;

    public AudioSource audio;       //自身の音源を取得
    public AudioClip SE_Dart;       //砂煙が出たときのSE
    public AudioClip SE_Burst;      //上手く爆発したときのSE
    public AudioClip SE_BigBurst;   //最高に上手く爆発できた時のSE
    bool isAudio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        rdbody2D = GetComponent<Rigidbody2D>();
        EffectImage.SetActive(false);
        //初期化
        isBurst = false;
        isAudio = false;
    }
    //クリックしたら落ちる仕組みに
    void OnMouseDown()
    {
        rdbody2D.gravityScale = 5.0f;
        var alpha = Bomb.GetComponent<SpriteRenderer>().color.a;
        alpha -= 0.2f * Time.deltaTime;
        MoveSpeed = 0.0f;
    }


    private void Update()
    {
        //コードを短くするために変数の追加
        var posX = transform.position.x;
        var posY = transform.position.y;
        var centerPosX = CenterPosition.transform.position.x;

        //落ちた場所に応じて爆発の結果を変化させる
        if (transform.position.y < -2.8f)
        {
            //真ん中に近いと最高の状態になる
            if (Mathf.Abs(posX - centerPosX) > 0.0f && Mathf.Abs(posX - centerPosX) <= 2.0f)
            {
                EffectImage.SetActive(true);

                EffectImage.GetComponent<SpriteRenderer>().sprite = BigBurstSprite;
                if (!isAudio)
                {
                    audio.PlayOneShot(SE_BigBurst);
                    isAudio = true;
                }

                game.GameScore = score2;
                isOut = true;

            }
            //少し離れたところだとまあまあな爆発に
            else if (Mathf.Abs(posX - centerPosX) > 2.0f && Mathf.Abs(posX - centerPosX) <= 4.0f)
            {
                EffectImage.SetActive(true);

                EffectImage.GetComponent<SpriteRenderer>().sprite = BurstSprite;
                if (!isAudio)
                {
                    audio.PlayOneShot(SE_Burst);
                    isAudio = true;
                }

                game.GameScore = score1;
                isOut = true;
            }
            //離れすぎると上手く爆発できない結果に
            else if (Mathf.Abs(posX - centerPosX) > 4.0f)
            {
                EffectImage.SetActive(true);

                EffectImage.GetComponent<SpriteRenderer>().sprite = DartSprite;
                if (!isAudio)
                {
                    audio.PlayOneShot(SE_Dart);
                    isAudio = true;
                }

                game.GameScore = score;
                isOut = true;

            }
        }

    }
    private void FixedUpdate()
    {
        var PosY = transform.position.y;

        //爆弾が端まで動いたら逆向きに移動するようにする
        if (transform.position.x >= _RightEdge.position.x)
            direction = -1;
        if (transform.position.x <= _LeftEdge.position.x)
            direction = 1;
        transform.position = new Vector3(transform.position.x + MoveSpeed * Time.fixedDeltaTime * direction, PosY, 0);

        //爆弾を常に移動しているようにする
        var bombScale = Bomb.transform.localScale;
        SizeX = Mathf.Sin(SizeX);
        SizeY =Mathf.Sin(SizeY);
        bombScale = new Vector3(SizeX, SizeY, 1f);

    }
}
