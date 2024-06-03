using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class MonsterIdleState : MonsterBasicState
{
    public override void EnterState(MonsterStateManager monster)
    {
        monster.nav.isStopped = true;
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        if (monster.isChase == true)
        {
            monster.ChangeState(monster.chaseState);
        }
    }

    public override void ExitState(MonsterStateManager monster)
    {

    }


    
}