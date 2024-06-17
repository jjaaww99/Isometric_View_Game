using UnityEngine;

public class MonsterHitState : MonsterBasicState
{
    float time = 0f;
    public override void EnterState(MonsterStateManager monster)
    {
        monster.ani.SetTrigger("Hit");
        monster.nav.isStopped = true;
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        time += Time.deltaTime;
        if(time > 1)
        {
            monster.isHit = false;
        }
    }

    public override void ExitState(MonsterStateManager monster)
    {
        monster.nav.isStopped = false;
    }


    
}
