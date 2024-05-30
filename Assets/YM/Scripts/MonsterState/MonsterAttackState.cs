using UnityEngine;

public class MonsterAttackState : MonsterBasicState
{
    public override void EnterState(MonsterStateManager monster)
    {
        Debug.Log("지금 상태는 공격 상태야");
        monster.ani.SetBool("Attack", true);
        monster.nav.isStopped = true;
        monster.attackArea.enabled = true;
    }

    public override void UpdateState(MonsterStateManager monster)
    {

    }

    public override void ExitState(MonsterStateManager monster)
    {
        monster.ani.SetBool("Attack", false);
        monster.attackArea.enabled = false;
    }

    public override void OnTriggerEnter(MonsterStateManager monster, Collider collider)
    {
       
    }

    public override void OnTriggerExit(MonsterStateManager monster, Collider collider)
    {
        GameObject other = collider.gameObject;
        if(collider.CompareTag("Player"))
        {
            monster.ChangeState(monster.chaseState);
        }
    }

}
