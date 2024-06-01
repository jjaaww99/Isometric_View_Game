using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttack : AnimPhysicsBase
{

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.targetsInRange = Physics.OverlapSphere(player.transform.position, player.jumpAttackRadius, player.enemyLayer);

        if (player.damageTrigger)
        {
            Action();
        }
    }

    protected override void Action()
    {
        foreach (var target in player.targetsInRange)
        {
            Rigidbody rb = target.GetComponent<Rigidbody>();

            Vector3 direction = (target.transform.position - player.transform.position).normalized;

            if (rb != null)
            {
                rb.AddForce((direction + target.transform.up * 10).normalized);
            }
        }
    }
}
