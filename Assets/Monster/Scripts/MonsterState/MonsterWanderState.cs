using UnityEngine;
using UnityEngine.AI;

public class MonsterWanderState : MonsterBasicState
{
    bool isWandering = false;
    float timer = 0;
    float wanderTimer = 2f; // 배회 타이머 (초 단위)
    float wanderRadius = 4f; // 배회 반경

    public override void EnterState(MonsterStateManager monster)
    {
        monster.nav.enabled = true;
        // 초기화 작업: 필요에 따라 초기화 작업 추가
        InitializeNavAgent(monster.nav);
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        // 배회 타이머 업데이트
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            monster.nav.isStopped = false;
            // 새로운 위치를 설정하고 이동
            Vector3 newPos = RandomNavSphere(monster.transform.position, wanderRadius, NavMesh.AllAreas);
            monster.nav.SetDestination(newPos);

            timer = 0f;

            monster.ani.SetBool("Wander", true);
            isWandering = true;
        }

        // 목표 지점에 도달했는지 확인
        if (isWandering && !monster.nav.pathPending)
        {
            if (monster.nav.remainingDistance <= monster.nav.stoppingDistance)
            {
                if (!monster.nav.hasPath || monster.nav.velocity.sqrMagnitude == 0f)
                {
                    // 목표 지점에 도달했으면 배회 애니메이션 종료
                    monster.ani.SetBool("Wander", false);
                    isWandering = false;
                }
            }
        }
    }

    public override void ExitState(MonsterStateManager monster)
    {
        if (monster.isDead == false)
        {
            monster.ani.SetBool("Wander", false);
            monster.nav.isStopped = true;
            isWandering = false;
        }
        // 상태 종료 시 작업: 예를 들어 애니메이션을 종료하고 배회 상태를 초기화
    }

    // 랜덤한 위치로 이동하는 메서드
    private Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * dist;
        randomDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    // NavMeshAgent 설정 초기화 메서드
    private void InitializeNavAgent(NavMeshAgent nav)
    {
        nav.updatePosition = true;
        nav.updateRotation = true;
        nav.isStopped = true;
    }
}


