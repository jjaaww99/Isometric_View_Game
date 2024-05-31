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

    public override void OnTriggerEnter(MonsterStateManager monster, Collider collider)
    {
        //플레이어의 공격에 닿았을때
        //피격상태로 전환
        //if (collider.CompareTag("PlayerAttack"))
        //{
        //    Debug.Log("플레이어의 공격에 맞음. 피격 상태로 전환");
        //    monster.ChangeState(monster.hitState);
        //}
    }

    public override void OnTriggerStay(MonsterStateManager monster, Collider collider)
    {

    }

    public override void OnTriggerExit(MonsterStateManager monster, Collider collider)
    {

    }

    
}