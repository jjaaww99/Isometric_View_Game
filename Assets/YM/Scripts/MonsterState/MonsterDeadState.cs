using UnityEngine;

public class MonsterDeadState : MonsterBasicState
{
    float DestroyCount = 3.0f;
    

    public override void EnterState(MonsterStateManager monster)
    {
        Animator ani = monster.GetComponent<Animator>();
        ani.SetBool("Dead", true);
    }

    public override void UpdateState(MonsterStateManager monster)
    {
        Debug.Log("»ç¸Á »óÅÂ");
        if(DestroyCount > 0)
        {
            DestroyCount -= Time.deltaTime;
        }
        else
        {
            GameObject gameObject = monster.gameObject;
            gameObject.SetActive(false);
        }
    }

    

    public override void OnCollisionEnter(MonsterStateManager monster)
    {

    }

}
