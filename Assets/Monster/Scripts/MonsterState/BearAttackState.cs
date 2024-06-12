public class BearAttackState : MonsterAttackState
{
    public override void EnterState(MonsterStateManager monster)
    {
        base.EnterState(monster);

        Roar(monster);
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        base.UpdateState(monster);


    }

    public override void ExitState(MonsterStateManager monster)
    {
        base.ExitState(monster);


    }

    private void Roar(MonsterStateManager monster)
    {
        monster.ani.SetTrigger("Roar");
        SlowNearbyEnemies(monster);
    }

    private void SlowNearbyEnemies(MonsterStateManager monster)
    {
        //플레이어 이속 감소 로직
    }

}
