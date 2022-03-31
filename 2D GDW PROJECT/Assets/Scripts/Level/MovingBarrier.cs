using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBarrier : MonoBehaviour
{
    public Transform customPivotRight;
    public Transform customPivotLeft;

    float rotationSpeed = 90;

    bool isVertical;
    bool isRight;

    void Update()
    {
        isVertical = GameObject.Find("Player").GetComponent<PlayerController>().GetIsVertical();
        isRight = GameObject.Find("Player").GetComponent<PlayerController>().GetIsRight();

        //Rotate Right
        if (isVertical && isRight)
        {
            transform.RotateAround(customPivotRight.transform.position, -Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        //Rotate Left
        if (isVertical && !isRight)
        {
            transform.RotateAround(customPivotLeft.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}