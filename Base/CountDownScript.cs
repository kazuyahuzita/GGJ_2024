using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownScript : MonoBehaviour
{
    //　カウントダウン数字を表示するテキスト
    private Image countDownImage;
    [SerializeField] float timer;
    public bool isCountDown;
    void Start()
    {
        countDownImage = GameObject.Find("CountDownImage").GetComponent<Image>();
        StartCoroutine(CountDown());
    }

    //　カウントダウン表示
    IEnumerator CountDown()
    {
        //他オブジェクトを止める
        isCountDown = true;
        countDownImage.enabled = true;
        //画像を表示する
        //３秒待つ
        yield return new WaitForSeconds(timer);  //1秒待つ
        

        //文字を非表示にする
        countDownImage.enabled = false;
        //他オブジェクトを動かせるようにする
        isCountDown = false;
    }
}
