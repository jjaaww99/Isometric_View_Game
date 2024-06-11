using UnityEngine;

public class MonsterDeadState : MonsterBasicState
{
    public override void EnterState(MonsterStateManager monster)
    {
        // monster.ani.SetBool("Dead", true);
        monster.ani.enabled = false; // 애니메이터를 비활성화합니다.

        // 사망 상태 표시
        monster.isDead = true;

        monster.ragdoll.SetRagdollActive(true);
        monster.bodyCollider.enabled = false;
        monster.rigid.isKinematic = true;
        monster.nav.enabled = false;
        GameManager.instance.CoinSpawn(monster.transform.position);
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        if (monster.deadCount > 0)
        {
            monster.deadCount -= Time.deltaTime;
        }
        else
        {
            monster.gameObject.SetActive(false);
        }
    }

    public override void ExitState(MonsterStateManager monster)
    {
        
    }

}
