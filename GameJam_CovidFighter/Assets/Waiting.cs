using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waiting : StateMachineBehaviour
{
    private float speed;
    private float shootDistance;
    private float followDistance;
    private GameObject player;
    private GameObject thisEnemy;


    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        thisEnemy = animator.gameObject;
        player = GameObject.FindWithTag("Player");

        speed = thisEnemy.GetComponent<LongRangePersonStats>().speed;
        shootDistance = thisEnemy.GetComponent<LongRangePersonStats>().shootDistance;
        followDistance = thisEnemy.GetComponent<LongRangePersonStats>().followDistance;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        float distance = Vector3.Distance(thisEnemy.transform.position, player.transform.position);

        //if withing follow range but not shoot range than follow
        if ((distance <= followDistance) && (distance > shootDistance))
        {
            animator.SetBool("Moving", true);
        }
        else if (distance <= shootDistance)
        {
            animator.SetBool("Sneeze", true);
        }

    }
}
