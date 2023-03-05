using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFIrst_ground : SceneLinkedSMB<Charactercontrolelr>
{

    public GameObject effect1;
    public Vector3 effecthoise;
    public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //EffectMaker.CCInstance.Initeffect(effect1, m_MonoBehaviour.GetPos());

        m_MonoBehaviour.updateface2();
    }
    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        //EffectMaker.CCInstance.Initeffect(effect1, m_MonoBehaviour.GetPos());
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

        //m_MonoBehaviour.EffectDes(effect1);

    }
}

