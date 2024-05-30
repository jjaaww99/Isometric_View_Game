using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class MonsterBasicState
{
    public string monsterName;    // 개체 이름
    public int maxHp;             // 최대 체력
    public int currentHp;         // 현재 체력
    public float speed;           // 이동속도
    public float atk;             // 공격력
    public BoxCollider attackArea;    //공격 범위

    public NavMeshAgent nav;
    public Rigidbody rigid;
    //private LayerMask playerLayerMask;

    public Collider bodycollider;
    public Animator ani;
    public MonsterDB monsterDB;
    public bool isChase;
    public bool isAttack;

    public abstract void EnterState(MonsterStateManager monster);

    public abstract void UpdateState(MonsterStateManager monster);

    public abstract void OnCollisionEnter(MonsterStateManager monster);


}
