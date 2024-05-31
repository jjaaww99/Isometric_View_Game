using UnityEngine;
using UnityEngine.UI;

public class MonsterAttackState : MonsterBasicState
{
    float attacktime = 2f;  //공격하는 시간
    
    public override void EnterState(MonsterStateManager monster)
    {
        monster.ani.SetBool("Attack", true);
        monster.attackArea.enabled = true;
        attacktime = 2f;
    }

    public override void UpdateState(MonsterStateManager monster)
    {

        //attacktime -= Time.deltaTime;
        //if (attacktime < 0)
        //{
        //    monster.ChangeState(monster.chaseState);
        //}
    }

    public override void ExitState(MonsterStateManager monster)
    {
        monster.ani.SetBool("Attack", false);
        monster.attackArea.enabled = false;
    }

    public override void OnTriggerEnter(MonsterStateManager monster, Collider collider)
    {
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
        if (collider.CompareTag("Player"))
        {
            monster.ChangeState(monster.chaseState);
        }
    }

    
}
