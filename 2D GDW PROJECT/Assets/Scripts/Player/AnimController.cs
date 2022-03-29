using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    Animator Animator;
    public GameObject player;
    PlayerController playerC;

    string animPlaying = idle;

    const string walk = "Walk";
    const string flip = "flip";
    const string idle = "idle";

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        playerC = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckWalk();
        CheckSwitch();
        CheckIdle();
    }


    void CheckWalk()
    {
        if (playerC.GetIsWalking())
        {
            ChangeAnim(walk);
        }
        else
        {
            Animator.SetBool("IsWalking", false);
        }
    }

    void CheckSwitch()
    {
        if (playerC.GetIsFlip())
        {
            ChangeAnim(flip);
        }
    }

    void CheckIdle()
    {
        if (!playerC.GetIsWalking())
        {
            ChangeAnim(idle);
            Debug.Log("hii");
        }
    }

    void ChangeAnim(string incomingAnim)
    {
        if (incomingAnim == animPlaying)
        {
            return;
        }

        Animator.Play(incomingAnim);

        animPlaying = incomingAnim;



    }
}
