using UnityEngine;
using UnityEngine.UI;

public class MonsterChaseState : MonsterBasicState
{

    public override void EnterState(MonsterStateManager monster)
    {
        monster.nav.isStopped = false;
        monster.ani.SetBool("Walk", true);
    }


    public override void UpdateState(MonsterStateManager monster)
    {
        monster.nav.SetDestination(monster.target.position);
        monster.rigid.velocity = Vector3.zero;
        monster.rigid.angularVelocity = Vector3.zero;
        if(monster.isChase==false)
        {
            monster.ChangeState(monster.idleState);
        }
    }

    public override void ExitState(MonsterStateManager monster)
    {
        monster.nav.isStopped = true;
        monster.ani.SetBool("Walk", false);
    }

    public override void OnTriggerEnter(MonsterStateManager monster, Collider collider)
    {
        ////플레이어의 공격에 닿았을때
        ////피격상태로 전환
        //if (collider.CompareTag("PlayerAttack"))
        //{
        //    Debug.Log("플레이어의 공격에 맞음. 피격 상태로 전환");
        //    monster.ChangeState(monster.hitState);
        //}
        if (collider.CompareTag("Player"))
        {
            monster.ChangeState(monster.attackState);
        }
        
    }

    public override void OnTriggerStay(MonsterStateManager monster, Collider collider)
    {

    }

    public override void OnTriggerExit(MonsterStateManager monster, Collider collider)
    {
        
    }

    
}
