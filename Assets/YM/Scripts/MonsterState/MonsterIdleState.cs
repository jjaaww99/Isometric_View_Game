using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class MonsterIdleState : MonsterBasicState
{
    public override void EnterState(MonsterStateManager monster)
    {
        Debug.Log("지금 상태는 idle이야");
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

    public override void OnTriggerEnter(MonsterStateManager monster, Collider collider)
    {

    }

    public override void OnTriggerExit(MonsterStateManager monster, Collider collider)
    {

    }

}