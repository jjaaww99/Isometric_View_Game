using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterWanderState : MonsterBasicState
{
    public float wanderRadius = 2f;

    private Coroutine wanderCoroutine;

    public override void EnterState(MonsterStateManager monster)
    {
        monster.nav.enabled = true;
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        wanderCoroutine = monster.StartCoroutine(WanderCoroutine(monster));
    }

    public override void ExitState(MonsterStateManager monster)
    {

    }

    private IEnumerator WanderCoroutine(MonsterStateManager monster)
    {
        // 새로운 목적지 선택
        Vector3 newPos = RandomNavSphere(monster.transform.position, wanderRadius);
        monster.nav.SetDestination(newPos);

        // 한 번만 이동한 후 코루틴을 중지
        yield return null;
        monster.StopCoroutine(wanderCoroutine);
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist)
    {
        //구형으로 무작위 위치 생성    dist은 구형범위에 반지름이야 범위지
        Vector3 randomDirection = Random.insideUnitSphere * dist;

        //우리겜은 수직으로 이동못하니 y값을 잠구고
        randomDirection.y = 0;

        //현재 위치를 더해서 이동 지점을 만들고
        randomDirection += origin;

        //이동할 목적지 저장할 변수 만들고
        NavMeshHit navHit;

        // NavMesh.SamplePosition을 써서 radomDirection에 가까운 매쉬 위치를 찾고 변수에 저장하면
        NavMesh.SamplePosition(randomDirection, out navHit, dist, NavMesh.AllAreas);

        //목적지 완성
        return navHit.position;
    }

}