using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sneeze : StateMachineBehaviour
{
    private float speed;
    private float shootDistance;
    private float followDistance;
    private float runDistance;
    private GameObject player;
    private GameObject thisEnemy;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        thisEnemy = animator.gameObject;
        player = GameObject.FindWithTag("Player");

        speed = thisEnemy.GetComponent<LongRangePersonStats>().speed;
        shootDistance = thisEnemy.GetComponent<LongRangePersonStats>().shootDistance;
        followDistance = thisEnemy.GetComponent<LongRangePersonStats>().followDistance;
        runDistance = thisEnemy.GetComponent<LongRangePersonStats>().runDistance;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(thisEnemy.transform.position, player.transform.position);

        //if withing follow range but not shoot range than follow
        if ((distance > shootDistance))
        {
            animator.SetBool("Sneeze", false);
            
        }

        if ((distance <= runDistance))
        {
            animator.SetBool("Moving", true);
            animator.SetBool("RunAway", true);
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
