using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_special : SceneLinkedSMB<Charactercontrolelr>
{
    public GameObject effect1;
    public Vector3 effecthoise;
    public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //m_MonoBehaviour.Attackupdatefram_special();

    }

    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        m_MonoBehaviour.PowerAttacksupdate();

    }

    public override void OnSLStatePreExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        m_MonoBehaviour.skeletonAnimation.timeScale = 1f;


    }

}
