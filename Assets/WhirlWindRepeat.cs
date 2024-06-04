using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhirlWindRepeat : StateMachineBehaviour
{
    JWPlayerController player;
    Quaternion rotation;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.GetComponent<JWPlayerController>();
        player.skillVFXs[1].SetActive(true);
        rotation = player.transform.rotation;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.transform.rotation = rotation;

        if(Input.GetKeyDown(KeyCode.W)) 
        {
            return;
        }

        if(Input.GetKeyUp(KeyCode.W)) 
        {
            animator.SetBool("WhirlWindReapeat", false);
            animator.SetBool("Skill", false);
            player.stateMachine.ChangeState(player.idle);
            player.skillVFXs[1].SetActive(false);

        }

        if (Input.GetMouseButton(1)) 
        {
            player.nav.SetDestination(player.targetPosition);
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
