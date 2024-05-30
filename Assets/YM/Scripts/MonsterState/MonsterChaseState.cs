using UnityEngine;

public class MonsterChaseState : MonsterBasicState
{

    public override void EnterState(MonsterStateManager monster)
    {
        Debug.Log("지금 상태는 추격 상태야!");
        monster.ani.SetBool("Walk", true);
        monster.nav.isStopped = false;
    }


    public override void UpdateState(MonsterStateManager monster)
    {
        monster.nav.SetDestination(monster.target.position);
        monster.rigid.velocity = Vector3.zero;
        monster.rigid.angularVelocity = Vector3.zero;

    }

    public override void ExitState(MonsterStateManager monster)
    {
        monster.ani.SetBool("Walk", false);
    }

    public override void OnTriggerEnter(MonsterStateManager monster, Collider collider)
    {
        GameObject other = collider.gameObject;
        if(collider.CompareTag("Player"))
        {
            monster.ChangeState(monster.attackState);
        }
    }

    public override void OnTriggerExit(MonsterStateManager monster, Collider collider)
    {
        
    }

    
}
