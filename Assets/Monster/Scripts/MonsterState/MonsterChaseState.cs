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
        //   monster.nav.SetDestination(GameManager.instance.player.transform.position);

        JWPlayer player = GameObject.FindGameObjectWithTag("Player").GetComponent<JWPlayer>();
        monster.nav.SetDestination(player.transform.position);
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

    
}
