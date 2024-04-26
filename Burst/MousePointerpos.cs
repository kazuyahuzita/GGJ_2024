using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MousePointerpos : MonoBehaviour
{
    Vector3 mousePos, pos; //マウスとゲームオブジェクトの座標データを格納

    void Update()
    {
        //マウスの座標を取得する
        mousePos = Input.mousePosition;
        //スクリーン座標をワールド座標に変換する
        pos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10f));
        //ワールド座標をゲームオブジェクトの座標に設定する
        transform.position = pos;
    }
}
