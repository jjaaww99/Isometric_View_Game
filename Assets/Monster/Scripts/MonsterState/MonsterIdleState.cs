using UnityEngine;

public class MonsterIdleState : MonsterBasicState
{
    
    public override void EnterState(MonsterStateManager monster)
    {
        
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        monster.chagetowandertime += Time.deltaTime;
        if(monster.chagetowandertime >= 2)
        {
            monster.nav.enabled = true;
            monster.bodyCollider.isTrigger = true;
        }
    }

    public override void ExitState(MonsterStateManager monster)
    {
        
    }

    
}

