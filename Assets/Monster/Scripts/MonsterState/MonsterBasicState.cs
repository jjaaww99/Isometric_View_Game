using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class MonsterBasicState
{

    public abstract void EnterState(MonsterStateManager monster);

    public abstract void UpdateState(MonsterStateManager monster);

    public abstract void ExitState(MonsterStateManager monster);

}
