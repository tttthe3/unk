﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpdown : SceneLinkedSMB<Charactercontrolelr>
{
    public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.skeletonAnimation.timeScale = 1f;
        //m_MonoBehaviour.skeletonAnimation.AnimationState.SetAnimation(0, "jumpdown", false);
       // m_MonoBehaviour.DownAirHorizontalMovement(-100f, 1.2f);
        m_MonoBehaviour.jumpdownset();
    }

    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.Airwall();
        m_MonoBehaviour.UpdateFacing();
        if (m_MonoBehaviour.iswallcheck() == false)
        {
            //m_MonoBehaviour.UpdateJump();

            m_MonoBehaviour.loopAirHorizontalMovement(true, 1f);
        }
        //m_MonoBehaviour.AirborneVerticalMovement();
       //m_MonoBehaviour.jumpgrud();
        if (m_MonoBehaviour.iswallcheck())
        {
           
           m_MonoBehaviour.wallrefect();
        }
        Debug.Log(m_MonoBehaviour.CheckForGrounded());
        if (m_MonoBehaviour.CheckForGrounded())
        {
            m_MonoBehaviour.jummptoground();
            m_MonoBehaviour.skeletonAnimation.timeScale = 1f;
        }
       // if (m_MonoBehaviour.checkchangejump() == 2f)
          
       // m_MonoBehaviour.JumpChange();
        if (m_MonoBehaviour.CheckForMeleeAttackInput())
        {
            m_MonoBehaviour.Attackfirstframe_air();
        }
        m_MonoBehaviour.groiundfilter();
        if (Playerinput.Instance.Intract.Down)
            m_MonoBehaviour.Attackfirstframe_Gun();

        m_MonoBehaviour.Attackupdateframe_Gun();
    }

    public override void OnSLStatePreExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
