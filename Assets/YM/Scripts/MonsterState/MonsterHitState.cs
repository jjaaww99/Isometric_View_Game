using UnityEngine;

public class MonsterHitState : MonsterBasicState
{
    public override void EnterState(MonsterStateManager monster)
    {
        Debug.Log("지금은 피격 상태야");
        monster.ani.SetTrigger("Hit");
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        //플레이어 공격만큼 체력 감소
        //만약 체력이 0이하로 떨어지면 사망상태로 변경
        if (monster.currentHp <= 0)
        {
            monster.ChangeState(monster.deadState);
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
