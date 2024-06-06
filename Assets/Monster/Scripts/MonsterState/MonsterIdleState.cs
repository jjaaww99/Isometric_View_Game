using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.XR;

public class MonsterIdleState : MonsterBasicState
{
    
    public override void EnterState(MonsterStateManager monster)
    {
        
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        monster.idleTowanderTime -= Time.deltaTime;
        if (monster.idleTowanderTime < 0)
        {
            monster.ChangeState(monster.wanderState);
            monster.idleTowanderTime = 3;
        }
    }

    public override void ExitState(MonsterStateManager monster)
    {

    }

}