using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class JumpAttack : StateMachineBehaviour
{
    JWPlayerController player;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.GetComponent<JWPlayerController>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.animTrigger)
        {
            player.stateMachine.ChangeState(player.idle);
        }

        if (player.effectTrigger)
        {
            player.skillVFXs[2].gameObject.SetActive(true);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.skillVFXs[2].gameObject.SetActive(false);
    }
}

