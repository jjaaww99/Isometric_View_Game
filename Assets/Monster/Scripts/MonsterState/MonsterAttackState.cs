using UnityEngine;
using UnityEngine.UI;

public class MonsterAttackState : MonsterBasicState
{
    
    public override void EnterState(MonsterStateManager monster)
    {
        monster.ani.SetBool("Attack", true);
       
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        monster.transform.LookAt(monster.targetPosition);
    }

    public override void ExitState(MonsterStateManager monster)
    {
        monster.ani.SetBool("Attack", false);
    }

}
