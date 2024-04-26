using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyItem : MonoBehaviour
{
    private Vector3 defaultPos;

    public CountDownScript count;
    public Baby baby;

    private void Start()
    {
        defaultPos = transform.position;
    }

    //　押された時
    private void OnMouseDown()
    {
    }
    //　ドラッグされた時
    private void OnMouseDrag()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.position = ray.GetPoint(10f);
    }
    void Update()
    {
        if (baby.isOut || count.isCountDown) return;
    }

}
