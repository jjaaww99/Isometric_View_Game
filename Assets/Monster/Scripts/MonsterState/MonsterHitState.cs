using UnityEngine;

public class MonsterHitState : MonsterBasicState
{
    //피격 유지 시간
    float hittingtime = 1.5f;

    public override void EnterState(MonsterStateManager monster)
    {
        monster.ani.SetTrigger("Hit");
        monster.nav.isStopped = true;
    }

    public override void UpdateState(MonsterStateManager monster)
    {
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


    
}
