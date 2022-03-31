using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class GravWedge : MonoBehaviour
{
    bool canSwap = true;
    bool canTrigger = true;
    Transform playerTransform;

    [SerializeField] private PlayerController _playerController;
    [SerializeField] private ERotationStates newrotationState;

    // sets transform variable for fixing movement
    private void Awake()
    {
        playerTransform = _playerController.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTrigger)
        {
            if (collision.gameObject.CompareTag("Player") && canSwap)
            {
                canSwap = false;
                StartCoroutine(CanSwapTimer());
                _playerController.ChangeGravity(newrotationState);
                playerTransform.localScale = new Vector3(playerTransform.localScale.x * -1, 1, 1);

                canTrigger = false;
            }
        }
    }

    private IEnumerator CanSwapTimer()
    {
        yield return new WaitForSeconds(1);
        canSwap = true;
    }
}