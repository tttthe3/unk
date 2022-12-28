using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatcare : SceneLinkedSMB<Charactercontrolelr>
{
    int m_HashAirborneMeleeAttackState = Animator.StringToHash("push");
    float timer;

    public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        m_MonoBehaviour.skeletonAnimation.timeScale = 1.0f;
        m_MonoBehaviour.skeletonAnimation.AnimationState.SetAnimation(0, "eat_care", true);
        timer = 0f;

    }
    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (m_MonoBehaviour.LeftChecks())
            m_MonoBehaviour.ItemupdateframeLeft();
        else
            m_MonoBehaviour.ItemupdateframeRight();
    }

    public override void OnSLStatePreExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {



    }
}
