using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : AnimPhysicsBase
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.targetsInRange = Physics.OverlapSphere(player.basicAttackPoint.position, player.basicAttackRadius, player.enemyLayer);
        
        if (player.animationTrigger)
        {
            Action();
        }
    }

    protected override void Action()
    {
        foreach (var target in player.targetsInRange)
        {
            Vector3 direction = target.transform.position - player.transform.position;

            Rigidbody rb = target.GetComponent<Rigidbody>();

            if (target != null)
            {
                rb.AddForce(direction.normalized * player.rbForce, ForceMode.Impulse);
            }
        }
    }
}