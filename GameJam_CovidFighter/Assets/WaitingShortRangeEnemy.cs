﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingShortRangeEnemy : StateMachineBehaviour
{

    private float speed;
    private float followDistance;
    private GameObject player;
    private GameObject thisEnemy;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        thisEnemy = animator.gameObject;
        player = GameObject.FindWithTag("Player");

        speed = thisEnemy.GetComponent<ShortRangePersonStats>().speed;
        followDistance = thisEnemy.GetComponent<ShortRangePersonStats>().followDistance;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(thisEnemy.transform.position, player.transform.position);

        //if withing follow range but not shoot range than follow
        if ((distance < followDistance))
        {
            animator.SetBool("PlayerSeen", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
