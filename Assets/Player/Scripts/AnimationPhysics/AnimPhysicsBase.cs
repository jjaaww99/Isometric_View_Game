using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPhysicsBase : StateMachineBehaviour
{
    protected JWPlayerController player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.GetComponent<JWPlayerController>();
        
        if(player.damageTrigger)
        {
            player.ToggleDamageTrigger();
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.damageTrigger)
        {
            player.ToggleDamageTrigger();
        }
    }

    protected virtual void Effect()
    {
        
    }
}
