using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhirlWindStart : StateMachineBehaviour
{
    

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        JWPlayerController player = animator.GetComponent<JWPlayerController>();

        if (Input.GetKey(player.skillKeyCodes[player.skill.index]))
        {
            animator.SetBool("WhirlWindRepeat", true);
        }
    }

    
}
