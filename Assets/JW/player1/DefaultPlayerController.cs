using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class DefaultPlayerController : MonoBehaviour
{
    public Camera mainCamera;
    public NavMeshAgent playerAgent;
    public Animator anim;
    public LayerMask clickableLayer;

    private void Awake()
    {
        mainCamera = Camera.main;
        playerAgent = GetComponentInChildren<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }


    public Ray ray;
    public RaycastHit hit;
    public Vector3 targetPosition;
    void Update()
    {

        AnimationController();

        if (Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayer))
            {
                targetPosition = hit.point;

                playerAgent.SetDestination(targetPosition);

                Vector3 direction = (targetPosition - playerAgent.transform.position).normalized;

                Quaternion lookDirection = Quaternion.LookRotation(direction);

                playerAgent.transform.rotation = lookDirection;
            }
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetTrigger("Evade");
        }
    }

    void AnimationController()
    {
        anim.SetBool("Move", IsMoving());
    }

    [SerializeField] private bool isMoving => IsMoving();

    private bool IsMoving()
    {
        // 에이전트가 이동 중인지 확인
        if (playerAgent.pathPending) return true;  // 경로를 계산 중인 경우
        if (playerAgent.remainingDistance > playerAgent.stoppingDistance) return true;  // 목적지까지 남은 거리가 stoppingDistance보다 큰 경우
        if (playerAgent.velocity.sqrMagnitude > 0.1f * 0.1f) return true;  // 에이전트가 움직이고 있는 경우

        return false;  // 그 외의 경우에는 이동 중이 아님
    }

}
