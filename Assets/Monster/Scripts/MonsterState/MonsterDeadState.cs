using UnityEngine;

public class MonsterDeadState : MonsterBasicState
{
    float DestroyCount = 3.0f; //사망 후 사라지는 시간
    
    public override void EnterState(MonsterStateManager monster)
    {
        monster.ani.SetBool("Dead", true);
    }


    public override void UpdateState(MonsterStateManager monster)
    {
        if(DestroyCount > 0)
        {
            DestroyCount -= Time.deltaTime;
        }
        else
        {
            UnityEngine.GameObject gameObject = monster.gameObject;
            gameObject.SetActive(false);
        }
    }

    public override void ExitState(MonsterStateManager monster)
    {

    }

    public override void OnTriggerEnter(MonsterStateManager monster, Collider collider)
    {
        
    }

    public override void OnTriggerStay(MonsterStateManager monster, Collider collider)
    {

    }

    public override void OnTriggerExit(MonsterStateManager monster, Collider collider)
    {
       
    }

    
}
