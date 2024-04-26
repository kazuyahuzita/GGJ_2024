using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBallGame : BaseMiniGame
{
    [SerializeField] GameObject MainSpriteRenderer;
    [SerializeField] GameObject MainSpriteRenderer1;
    [SerializeField] GameObject MainSpriteRenderer2;
    // publicで宣言し、inspectorで設定可能にする
    public Sprite HitSprite;
    public Sprite MoveSprite;
    public Sprite AttackSprite;
    //
    //マウスカーソルからのレイキャスト認識をするために
    private BoxCollider2D mainCollider0;
    private BoxCollider2D mainCollider1;
    private BoxCollider2D mainCollider2;
    private Sprite mainSprite0;
    private Sprite mainSprite1;
    private Sprite mainSprite2;


    [SerializeField] AudioClip SE_Click; //開始サウンド
    AudioSource myAudio; //自身の音源

    public bool isBallMove;
    int idx; //添え字用の変数
    public CountDownScript count;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>(); //自身の音源を取得

        mainCollider0 = MainSpriteRenderer.GetComponent<BoxCollider2D>();
        mainCollider1 = MainSpriteRenderer1.GetComponent<BoxCollider2D>();
        mainCollider2 = MainSpriteRenderer2.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd || count.isCountDown)
        {
            return;
        }

        //クリックしたらの判定の部分
        if (Input.GetMouseButtonDown(0))
        {
            //クリック座標をUnityのワールド座標系に変換
            Vector2 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //クリック位置から光を飛ばし、接触物体をhitInfoとして取得する。
            RaycastHit2D hitInfo = Physics2D.Raycast(clickPos, -Vector2.up);
            //hitInfoがコライダー形状を持つトランプか？
            if (hitInfo.collider)
            {
                myAudio.PlayOneShot(SE_Click);
                Vector2 Pos = hitInfo.transform.position; //現在位置を退避する。
                                                          //名前の末尾１文字を整数に変換し、黄色枠の配列imgChangeの[添え字]に用いる。
                idx = int.Parse(hitInfo.collider.gameObject.name.Substring(8, 1));

                
                if (hitInfo.collider == mainCollider0)
                {
                    // SpriteRenderのspriteを設定済みの他のspriteに変更
                    MainSpriteRenderer1.GetComponent<SpriteRenderer>().sprite = HitSprite;
                    isBallMove = true;
                    isEnd = true;                   //ミニゲームの終了
                }
                else if (hitInfo.collider == mainCollider1)
                {
                    // SpriteRenderのspriteを設定済みの他のspriteに変更
                    MainSpriteRenderer1.GetComponent<SpriteRenderer>().sprite = MoveSprite;
                    isEnd = true;                   //ミニゲームの終了

                }
                else if (hitInfo.collider == mainCollider2)
                {
                    // SpriteRenderのspriteを設定済みの他のspriteに変更
                    MainSpriteRenderer1.GetComponent<SpriteRenderer>().sprite = AttackSprite;
                    isEnd = true;                   //ミニゲームの終了

                }



            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
    public void SetScore(MiniGameScore score)
    {
        this.GameScore = score;
    }

}