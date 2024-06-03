using UnityEngine;

public class MonsterDeadState : MonsterBasicState
{
    public override void EnterState(MonsterStateManager monster)
    {
        monster.ani.SetBool("Dead", true);
    }


    public override void UpdateState(MonsterStateManager monster)
    {
        if(monster.deadCount > 0)
        {
            Debug.Log(monster.deadCount);
            monster.deadCount -= Time.deltaTime;
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

    
}
