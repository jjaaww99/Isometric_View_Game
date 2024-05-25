using UnityEngine;
using UnityEngine.AI;

public class JWPlayer : MonoBehaviour
{
    public Camera mainCamera; // 메인 카메라
    public NavMeshAgent playerAgent; // 플레이어의 NavMeshAgent
    public LayerMask clickableLayer; // 클릭 가능한 레이어 (터레인)

    private void Awake()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭 시
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayer))
            {
                // 클릭한 지점의 월드 좌표를 얻습니다.
                Vector3 targetPosition = hit.point;

                // NavMeshAgent를 사용하여 플레이어를 클릭한 지점으로 이동시킵니다.
                playerAgent.SetDestination(targetPosition);
            }
        }
    }
}
