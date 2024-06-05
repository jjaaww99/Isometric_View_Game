using UnityEngine;
using UnityEngine.UI;

public class MonsterChaseState : MonsterBasicState
{

    public override void EnterState(MonsterStateManager monster)
    {
        monster.nav.isStopped = false;
        monster.ani.SetBool("Chase", true);
    }


    public override void UpdateState(MonsterStateManager monster)
    {
        monster.nav.SetDestination(monster.target.position);
        monster.rigid.velocity = Vector3.zero;
        monster.rigid.angularVelocity = Vector3.zero;
    }

    public override void ExitState(MonsterStateManager monster)
    {
        monster.nav.isStopped = true;
        monster.ani.SetBool("Chase", false);
    }

    
}
