using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour
{
    [SerializeField] public float angle;
    public float count;
    [SerializeField] float countMax;
    private Vector2 startPos;
    private float startAngle;

    private void Start()
    {
    }
    private void OnMouseDown()
    {
        startPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        startAngle = transform.eulerAngles.z;
    }
    private void OnMouseDrag()
    {
        Vector2 endPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Vector2.SignedAngle(startPos, endPos);
        transform.rotation = Quaternion.Euler(0, 0, startAngle + angle);

    }

    private void Update()
    {
        if (count >= countMax)
        {
            return;
        }
        if (angle >= 170.0f)
        {
            count++;

        }
    }
}

