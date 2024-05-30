using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class MonsterIdleState : MonsterBasicState
{
    public override void EnterState(MonsterStateManager monster)
    {
        Debug.Log("지금 상태는 idle이야!");
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        monster.ChangeState(monster.deadState);
    }


    public override void OnCollisionEnter(MonsterStateManager monster)
    {
        
    }

}

