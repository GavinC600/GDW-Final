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
    const string dash = "dash";
    const string falling = "falling";


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
        CheckDead();
        
    }


    void CheckWalk()
    {
        if (playerC.GetIsWalking())
        {
            Animator.SetBool("IsWalking", true);
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
            Animator.SetBool("IsFlip", true);
        }
        else
        {
            Animator.SetBool("IsFlip", false);
        }
    }


    void CheckIdle()
    {
        if (!playerC.GetIsWalking())
        {
            Animator.SetBool("IsWalking", false);
        }
    }

    void CheckDead()
    {
        if (playerC.GetIsDead())
        {
            Animator.SetBool("IsDead", true);
        }
    }

    //void ChangeAnim(string incomingAnim)
    //{
    //    if (incomingAnim == animPlaying)
    //    {
    //        return;
    //    }

    //    Animator.Play(incomingAnim);

    //    animPlaying = incomingAnim;
    //}
}