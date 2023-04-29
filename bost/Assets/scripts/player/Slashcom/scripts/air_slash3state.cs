using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class air_slash3state : SceneLinkedSMB<Charactercontrolelr>
{
    int m_HashAirborneMeleeAttackState = Animator.StringToHash("air_slash2");
    float timer;
    public GameObject effect1;
    public Vector3 effecthoise;
    public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0f;
        m_MonoBehaviour.skeletonAnimation.timeScale = 1.4f;
        m_MonoBehaviour.skeletonAnimation.AnimationState.SetAnimation(0, "air_slash3", false);
        Debug.Log("GGfall");
        m_MonoBehaviour.Attackfirstframe_air();
    }

    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        m_MonoBehaviour.Attackupdatefram_air();
     
    }

    public override void OnSLStatePreExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //m_MonoBehaviour.EffectDes(effect1);
        //if (m_MonoBehaviour.checkchangejump() == 2f)
        //  m_MonoBehaviour.JumpChange();

        m_MonoBehaviour.Attackendframe_air();
        m_MonoBehaviour.skeletonAnimation.timeScale = 1f;
        //  m_MonoBehaviour.DisableMeleeAttack();
        //m_MonoBehaviour.spineAnimation.AnimationState.SetAnimation(0, "nurt", true);


    }

}
