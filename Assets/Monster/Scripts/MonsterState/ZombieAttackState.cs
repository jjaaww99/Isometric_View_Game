public class ZombieAttackState : MonsterAttackState
{
    private bool biteCheck = false; //공격이 bite인지 확인

    public override void EnterState(MonsterStateManager monster)
    {
        if (monster.currentHp <= monster.maxHp / 2)
            Bite(monster);
        else
            base.EnterState(monster);

    }

    public override void UpdateState(MonsterStateManager monster)
    {
        base.UpdateState(monster);


    }

    public override void ExitState(MonsterStateManager monster)
    {
        if (biteCheck)
        {
            BiteExit(monster);
        }
        else
            base.ExitState(monster);
    }

    private void Bite(MonsterStateManager monster)
    {
        biteCheck = true;
        monster.ani.SetBool("Bite", true);
    }

    private void BiteExit(MonsterStateManager monster)
    {
        biteCheck = false;
        monster.ani.SetBool("Bite", false);
    }

    //bite해서 플레이어에게 데미지를 주면 좀비는 피를 회복하는 로직 필요함

}
