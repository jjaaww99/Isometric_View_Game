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
        player.damageTrigger = true;

        if (Input.GetMouseButtonDown(1)) 
        {
            player.nav.SetDestination(player.targetPosition);
        }

        if (Input.GetKey(player.skillKeyCodes[player.skill.index]))
        {
            return;
        }

        if(Input.GetKeyUp(player.skillKeyCodes[player.skill.index])) 
        {
            animator.SetBool("WhirlWindRepeat", false);

            player.stateMachine.ChangeState(player.idle);

            player.skillVFXs[1].SetActive(false);
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
