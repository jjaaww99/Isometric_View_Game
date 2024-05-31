using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttack : AnimPhysicsBase
{
    private float elapsedTime;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.targetsInRange = Physics.OverlapSphere(player.transform.position, player.jumpAttackRadius, player.enemyLayer);

        if (player.animationTrigger)
        {
            Action();
        }
        else
        {
            elapsedTime = 0; 
        }
    }

    protected override void Action()
    {
        elapsedTime += Time.deltaTime;

        foreach (var target in player.targetsInRange)
        {
            Rigidbody rb = target.GetComponent<Rigidbody>();

            Vector3 direction = (target.transform.position - player.transform.position).normalized;

            float force = Mathf.Lerp(player.rbForce, 0, elapsedTime);

            if (rb != null)
            {
                rb.AddForce((direction * force).normalized);
            }
        }
    }
}
