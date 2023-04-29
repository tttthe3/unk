using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack1 : SceneLinkedSMB<EnemyBehaviour>
{

    float timer = 0f;
    public GameObject effect1;
    public Vector3 effecthoise;
    public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.skeletonAnimation.timeScale = 1.9f;
        m_MonoBehaviour.skeletonAnimation.AnimationState.SetAnimation(0, m_MonoBehaviour.Plusstatename + "attack", true);
        // m_MonoBehaviour.Effectmaker(effect1, effecthoise);
        m_MonoBehaviour.Arm.enabled = true;
    }

    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;

        // We do this explicitly here instead of in the enemy class, that allow to handle obstacle differently according to state
        // (e.g. look at the ChomperRunToTargetSMB that stop the pursuit if there is an obstacle) 
        float dist = m_MonoBehaviour.speed;
        //if (m_MonoBehaviour.CheckForObstacle(dist))
        {

        }
        if (timer > 1.1f)
            m_MonoBehaviour.setidle();

        //m_MonoBehaviour.ScanForPlayer();
        Debug.Log("attack3");
        if(m_MonoBehaviour.arimlimit<timer)
        m_MonoBehaviour.Arm.enabled = false;
    }



    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.skeletonAnimation.timeScale = 1.0f;
        // m_MonoBehaviour.EffectDes(effect1);
        timer = 0f;
    }
}

