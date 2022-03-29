using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravWedge : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] bool changeRight;
    [SerializeField] bool changeToRoof;

    bool isVertical;
    bool isGrounded;
    bool canSwap = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isVertical = collision.gameObject.GetComponent<PlayerController>().GetIsVertical();
        isGrounded = collision.gameObject.GetComponent<PlayerController>().GetIsGrounded();

        //Switch to right wall
        if (isGrounded && changeRight && !isVertical && canSwap)
        {
            canSwap = false;

            //Change gravity direction
            Physics2D.gravity = new Vector2(9.81f, 0f);

            //Rotate camera
            mainCamera.transform.eulerAngles = new Vector3(0, 0, 90f);

            //Rotate player
            if (collision.gameObject.transform.rotation.z == 0)
            {
                collision.gameObject.transform.eulerAngles = new Vector3(0, 0, 90f);
            }
            else
            {
                collision.gameObject.transform.eulerAngles = new Vector3(0, 0, -90f);
            }

            //Set bools for player movement
            collision.gameObject.GetComponent<PlayerController>().SetIsVertical(true);
            collision.gameObject.GetComponent<PlayerController>().SetIsRight(true);

            StartCoroutine(CanSwapTimer());
        }

        //Switch to left wall
        if (isGrounded && !changeRight && !isVertical && canSwap)
        {
            canSwap = false;

            //Change gravity direction
            Physics2D.gravity = new Vector2(-9.81f, 0f);

            //Rotate camera
            mainCamera.transform.eulerAngles = new Vector3(0, 0, 90);

            //Rotate player
            if (collision.gameObject.transform.rotation.z == 0)
            {
                collision.gameObject.transform.eulerAngles = new Vector3(0, 0, -90);
            }
            else
            {
                collision.gameObject.transform.eulerAngles = new Vector3(0, 0, 90);
            }

            //Set bools for player movement
            collision.gameObject.GetComponent<PlayerController>().SetIsVertical(true);
            collision.gameObject.GetComponent<PlayerController>().SetIsRight(false);

            StartCoroutine(CanSwapTimer());
        }

        //Switch to ground
        if (isGrounded && isVertical && canSwap)
        {
            canSwap = false;

            //Change gravity direction
            Physics2D.gravity = new Vector2(0f, -9.81f);

            //Rotate camera
            mainCamera.transform.eulerAngles = Vector3.zero;

            //Rotate player
            if (changeToRoof)
            {
                collision.gameObject.transform.eulerAngles = new Vector3(0, 0, 180);
            }
            else
            {
                collision.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }

            //Set bools for player movement
            collision.gameObject.GetComponent<PlayerController>().SetIsVertical(false);
            collision.gameObject.GetComponent<PlayerController>().SetIsRight(false);

            StartCoroutine(CanSwapTimer());
        }
    }

    //Wait to set isVertical to true
    IEnumerator CanSwapTimer()
    {
        yield return new WaitForSeconds(1);
        canSwap = true;
    }
}