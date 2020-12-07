using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCured : StateMachineBehaviour
{

    public float speed = 4f;
    public float scale = 0.3f;


    private GameObject player;
    private GameObject thisCured;
    private GameObject safezone;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        thisCured = animator.gameObject;
        player = GameObject.FindWithTag("Player");
        safezone = GameObject.FindGameObjectWithTag("SafeZone");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        thisCured.transform.position = Vector2.MoveTowards(thisCured.transform.position, player.transform.position, speed * Time.deltaTime);

        //check if need to move left
        if (thisCured.transform.position.x > player.transform.position.x)
        {
            //animator.SetBool("MovingLeft", true);
            //flip the enemy to look to the left
            Vector3 flip = new Vector3(-scale, scale, scale);
            thisCured.transform.localScale = flip;
        }
        else
        {
            //flip the enemy to look to the right
            Vector3 flip = new Vector3(scale, scale, scale);
            thisCured.transform.localScale = flip;
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
