using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPhysicsBase : StateMachineBehaviour
{
    protected JWPlayer player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.GetComponent<JWPlayer>();
        
        if(player.animationTrigger)
        {
            player.AnimationTrigger();
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.targetsInRange = Physics.OverlapSphere(player.basicAttackPoint.position, player.basicAttackRadius, player.enemyLayer);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.animationTrigger)
        {
            player.AnimationTrigger();
        }
    }

    protected virtual void Action()
    {
        
    }
}
