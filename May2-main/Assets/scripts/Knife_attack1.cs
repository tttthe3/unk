using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife_attack1 : SceneLinkedSMB<Charactercontrolelr>
{
    public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("fat333");
       
        m_MonoBehaviour.skeletonAnimation.timeScale = 1.9f;
        m_MonoBehaviour.skeletonAnimation.AnimationState.SetAnimation(0, "knife_attack1", false);
       
    }
    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        
        m_MonoBehaviour.SetHorizontalMovement(1f * 0.2f * 1f);

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
        m_MonoBehaviour.skeletonAnimation.timeScale = 1f;


    }
}
