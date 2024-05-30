using UnityEngine;

public class MonsterChaseState : MonsterBasicState
{

    public override void EnterState(MonsterStateManager monster)
    {
        Debug.Log("지금 상태는 추격 상태야!");
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        nav.SetDestination(GameManager.instance.player.transform.position);
    }

    

    public override void OnCollisionEnter(MonsterStateManager monster)
    {

    }
}
