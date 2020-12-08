using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowShortRangeEnemy : StateMachineBehaviour
{

    private float speed;
    private float followDistance = 6f;
    private float safeDistance = 6f;
    private GameObject player;
    private GameObject thisEnemy;
    private GameObject safezone;

    public float scale = 0.3f;

    private float safedistance;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        thisEnemy = animator.gameObject;
        player = GameObject.FindWithTag("Player");
        safezone = GameObject.FindGameObjectWithTag("SafeZone");

        speed = thisEnemy.GetComponent<ShortRangePersonStats>().speed;
        followDistance = thisEnemy.GetComponent<ShortRangePersonStats>().followDistance;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(thisEnemy.transform.position, player.transform.position);
        
        if(safezone != null){
            safedistance = Vector3.Distance(thisEnemy.transform.position, safezone.transform.position);
        }
        //is withing follow range then move towards player
        if (distance <= followDistance)
        {
            thisEnemy.transform.position = Vector2.MoveTowards(thisEnemy.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("PlayerSeen", false);
        }

        if(safezone != null){
            if (safedistance <= safeDistance)
            {
                // thisEnemy.transform.position = Vector2.MoveTowards(thisEnemy.transform.position, safezone.transform.position, -1 * speed * Time.deltaTime);
            }
        }

        //check if need to move left
        if (thisEnemy.transform.position.x > player.transform.position.x)
        {
            //animator.SetBool("MovingLeft", true);
            //flip the enemy to look to the left
            Vector3 flip = new Vector3(-scale, scale, scale);
            thisEnemy.transform.localScale = flip;
        }
        else
        {
            //flip the enemy to look to the right
            Vector3 flip = new Vector3(scale, scale, scale);
            thisEnemy.transform.localScale = flip;
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
