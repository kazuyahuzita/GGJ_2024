using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchEffect : MonoBehaviour
{

    [SerializeField] GameObject[] imgChange = new GameObject[5]; //黄色い枠画像
    [SerializeField] GameObject[] imgCard = new GameObject[5]; //カード画像

    [SerializeField] AudioClip SE_Click; //開始サウンド
    AudioSource myAudio; //自身の音源

    int idx; //添え字用の変数
    [SerializeField] bool[] isClick =new bool[5];
    // Start is called before the first frame update
    void Start()
    {
        for (idx = 0; idx < imgCard.Length; idx++)
        {
            imgChange[idx].SetActive(false); //変更黄枠の非表示
            imgCard[idx].SetActive(true); //カードの非表示
            isClick[idx] = false;
        }

        myAudio = GetComponent<AudioSource>(); //自身の音源を取得
    }

    // Update is called once per frame
    void Update()
    {

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

                if (!isClick[idx])
                {
                    hitInfo.transform.position = new Vector2(Pos.x, Pos.y + 0.2f); //上に移動
                    imgChange[idx].SetActive(true); //黄色枠を表示
                    isClick[idx] = true;
                }
                else
                {
                    hitInfo.transform.position = new Vector2(Pos.x, Pos.y - 0.2f); //下に移動
                    imgChange[idx].SetActive(false); //黄色枠を非表示
                    isClick[idx] = false;
                }
            }
        }
    }
}
