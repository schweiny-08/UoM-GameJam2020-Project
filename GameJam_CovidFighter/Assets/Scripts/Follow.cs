using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : StateMachineBehaviour
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

        //checking if it should run away or towards player
        if (distance <= runDistance)
        {
            thisEnemy.transform.position = Vector2.MoveTowards(thisEnemy.transform.position, player.transform.position, -1 * speed * Time.deltaTime);
        }
        //move towards player
        else
        {
            thisEnemy.transform.position = Vector2.MoveTowards(thisEnemy.transform.position, player.transform.position, speed * Time.deltaTime);
            animator.SetBool("RunAway", false);
        }

        //if withing follow range but not shoot range than follow
        if ((distance > followDistance))
        {
            animator.SetBool("Moving", false);
            animator.SetBool("MovingLeft", false);
        }
        else if ((distance <= shootDistance) && (distance >= runDistance))
        {
            animator.SetBool("Sneeze", true);
            animator.SetBool("Moving", false);
            animator.SetBool("MovingLeft", false);
        }

        //check if need to move left
        if (thisEnemy.transform.position.x > player.transform.position.x)
        {
            //animator.SetBool("MovingLeft", true);
            //flip the enemy to look to the left
            Vector3 flip = new Vector3(-1, 1, 1);
            thisEnemy.transform.localScale = flip;
        }
        else
        {
            //flip the enemy to look to the right
            Vector3 flip = new Vector3(1, 1, 1);
            thisEnemy.transform.localScale = flip;
        }
    }
}
