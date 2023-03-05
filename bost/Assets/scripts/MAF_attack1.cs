using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAF_attack1 : SceneLinkedSMB<Charactercontrolelr>
{
    public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        m_MonoBehaviour.skeletonAnimation.timeScale = 1.2f;
        m_MonoBehaviour.skeletonAnimation.AnimationState.SetAnimation(0, "maFattack1", false);
    

     
    }
    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        m_MonoBehaviour.SetHorizontalMovement(2f * 0.3f * 1f);
      

    }

    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

      
        m_MonoBehaviour.Attackupdateframe();

    }

    public override void OnSLStatePreExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.Attackendframe();
     
  

    }
}
