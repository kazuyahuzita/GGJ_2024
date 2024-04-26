using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アタッチすれば、触れたら色が変化するようにできる
/// </summary>
public class GameObjectUI : MonoBehaviour
{
    public CountDownScript count;   //カウントダウンクラスの追加

    [SerializeField] GameObject imgChange; //黄色い枠画像
    [SerializeField] bool isOut;
    private void Start()
    {
        imgChange.SetActive(false);
        isOut = false;
    }

    private void Update()
    {
        if (isOut || count.isCountDown) return;
    }

    void OnMouseEnter()
    {
        imgChange.SetActive(true);
        this.GetComponent<SpriteRenderer>().color += new Color(0.1f, 0.1f, 0.1f, 0);
        isOut = true;
    }
    void OnMouseExit()
    {
        imgChange.SetActive(false);
        this.GetComponent<SpriteRenderer>().color -= new Color(0.1f, 0.1f, 0.1f, 0);
        isOut = true;
    }
}
