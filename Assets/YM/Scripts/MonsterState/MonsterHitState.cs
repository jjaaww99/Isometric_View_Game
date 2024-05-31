using UnityEngine;

public class MonsterHitState : MonsterBasicState
{
    //피격 유지 시간
    float hittingtime = 1.5f;

    public override void EnterState(MonsterStateManager monster)
    {
        monster.ani.SetTrigger("Hit");
        monster.nav.isStopped = true;
        hittingtime = 1.5f;
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        hittingtime -= Time.deltaTime;
        if (monster.currentHp <= 0)
        {
            monster.ChangeState(monster.deadState);
        }
        if (hittingtime <= 0)
        {
            monster.ChangeState(monster.idleState);
        }
    }
    public override void ExitState(MonsterStateManager monster)
    {
       
    }

    public override void OnTriggerEnter(MonsterStateManager monster, Collider collider)
    {
    
    }

    public override void OnTriggerStay(MonsterStateManager monster, Collider collider)
    {

    }

    public override void OnTriggerExit(MonsterStateManager monster, Collider collider)
    {
      
    }

    
}
