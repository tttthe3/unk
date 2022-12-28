using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAF_attack2 : SceneLinkedSMB<Charactercontrolelr>
{
    public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        m_MonoBehaviour.skeletonAnimation.timeScale = 1.9f;
        m_MonoBehaviour.skeletonAnimation.AnimationState.SetAnimation(0, "maFattack2", false);
        m_MonoBehaviour.Attackfirstframe();


    }
    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        m_MonoBehaviour.SetHorizontalMovement(70f * 0.3f * 1f);


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
