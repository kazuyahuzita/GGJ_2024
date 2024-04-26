using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBallMove : MonoBehaviour
{
    [SerializeField] BaseBallGame baseBallGame;
    [SerializeField,Range(1,10)] float movePositionXSpeed;
    [SerializeField,Range(1,10)] float movePositionYSpeed;
    [SerializeField,Range(100,300)] float moveRotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(baseBallGame.isBallMove)
        {
            transform.position -= new Vector3(movePositionXSpeed * Time.deltaTime, -movePositionYSpeed * Time.deltaTime, 0);
            transform.Rotate(0, 0, moveRotationSpeed * Time.deltaTime);

        }
        transform.position +=new Vector3 (movePositionXSpeed * Time.deltaTime,0,0);
        transform.Rotate(0, 0, moveRotationSpeed * Time.deltaTime);
    }
}
