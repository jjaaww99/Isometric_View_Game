using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class MonsterBasicState
{

    public abstract void EnterState(MonsterStateManager monster);

    public abstract void UpdateState(MonsterStateManager monster);

    public abstract void ExitState(MonsterStateManager monster);

    public abstract void OnTriggerEnter(MonsterStateManager monster,Collider collider);

    public abstract void OnTriggerStay(MonsterStateManager monster, Collider collider);

    public abstract void OnTriggerExit(MonsterStateManager monster,Collider collider);


}
