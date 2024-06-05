using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhirlWindStart : StateMachineBehaviour
{
    

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Input.GetKey(KeyCode.W))
        {
            animator.SetBool("WhirlWindReapeat", true);
        }
    }

    
}
