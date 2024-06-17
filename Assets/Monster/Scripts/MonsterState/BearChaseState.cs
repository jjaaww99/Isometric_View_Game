using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BearChaseState : MonsterChaseState
{
    private bool roar = true;

    public override void EnterState(MonsterStateManager monster)
    {
       if(roar)
            monster.StartCoroutine(Roar(monster));
       else
            base.EnterState(monster);
    }


    public override void UpdateState(MonsterStateManager monster)
    {
        base.UpdateState(monster);
    }

    public override void ExitState(MonsterStateManager monster)
    {
        base.ExitState(monster);
    }

    private IEnumerator Roar(MonsterStateManager monster)
    {
        monster.transform.LookAt(monster.target);
        monster.ani.SetTrigger("Roar");
        monster.nav.isStopped = true;
        yield return new WaitForSeconds(1.5f);
        roar = false;
        base.EnterState(monster);
    }

    private void SlowNearbyEnemies(MonsterStateManager monster)
    {
        //플레이어 이속 감소 로직
        //플레이어쪽에 메서드만들면 가져다 사용하는걸로
    }

}
