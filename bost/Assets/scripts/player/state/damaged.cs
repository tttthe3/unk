﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damaged: SceneLinkedSMB<Charactercontrolelr>
{
    public GameObject effect1;
    float timer;
    public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.skeletonAnimation.timeScale = 1.2f;
        Debug.Log("damaged");
        m_MonoBehaviour.skeletonAnimation.AnimationState.SetAnimation(0, "dameged3", false);
        m_MonoBehaviour.damagedMovement(true,1f);
        timer = 0f;
    }

    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (m_MonoBehaviour.IsFalling())
            m_MonoBehaviour.CheckForGrounded();
        m_MonoBehaviour.UpdateJump();

        timer += Time.deltaTime;
        if (timer > 0.35f)
            m_MonoBehaviour.Locomotionchange();
    }

    public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.Locomotionchange();
        m_MonoBehaviour.skeletonAnimation.timeScale = 1f;
    }
}

