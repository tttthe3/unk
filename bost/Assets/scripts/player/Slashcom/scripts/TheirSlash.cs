﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired.ComponentControls;
using DG.Tweening;
using Spine.Unity;
using Spine;
public class TheirSlash : Kama_Compo

{
    private float reset = 0.01f;
    private float currenttime = 0f;
    public string Nextattackname;
    public Tween attacks;
    private GameObject m_sound;
    private Damager damagess;
    private GameObject attackob;
    public GameObject effects;
    private GameObject current_effects;
    public Vector3 effectpos;
    // Start is called before the first frame update
    public override void firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {
        effectpos = parent.position + new Vector3(Charactercontrolelr.CCInstance.m_SpriteForward.x * 6f, -1f, 0f);
        skeletonAnimation.timeScale = 2.4f;
       skeletonAnimation.AnimationState.SetAnimation(0, "slash18", false);

        currenttime = 0f;
        if (m_sound == null)
            m_sound = Instantiate(sounds, this.transform.position, Quaternion.identity);
        if (damagess == null)
            //Slash_first = parent.Find("sounds/Slash/Slash1").GetComponent<RandomAudioPlayer>();
            damagess = parent.Find("SkeletonUtility-SkeletonRoot/root/kama1").GetComponent<Damager>();
        if (attackob == null)
            attackob = parent.Find("SkeletonUtility-SkeletonRoot/root/AttackOb").gameObject;
        DOVirtual.DelayedCall(0.4f, () => rb2d.velocity = new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x * 1f, 0f), false);
        DOVirtual.DelayedCall(0.4f, () => Playsound(m_sound.GetComponent<RandomAudioPlayer>()), false);
        damagess.damagemove = true;
        damagess.havemove = Damager.movestate.diagonal;
        if (current_effects == null)
            current_effects = Instantiate(effects, effectpos, Quaternion.identity);
        else
        {
            current_effects.transform.localScale = new Vector3(Charactercontrolelr.CCInstance.m_SpriteForward.x * 11f, 12f, 1f);
            current_effects.transform.position = effectpos;
            current_effects.SetActive(true);
        }
        if (current_effects != null && !current_effects.activeSelf)
        {
            current_effects.transform.localScale = new Vector3(Charactercontrolelr.CCInstance.m_SpriteForward.x * 11f, 12f, 1f);
            current_effects.transform.position = effectpos;
            current_effects.SetActive(true);
        }
    }
    // Update is called once per frame
    public override void updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, Kama_Compo nextcompo, SkeletonAnimation skeletonAnimation)
    {
        currenttime += Time.deltaTime;
        if (currenttime < 0.9f)
        {
          
                attackob.SetActive(true);
            damagess.enabled = true;
            //joystick.SetVibration(2f,2f);

            if (Playerinput.Instance.Attack.Down)
            {
                if (currenttime > 0.3f)
                {
                    current_effects.SetActive(false);
                    attackob.SetActive(false);
                    damagess.enabled = false;
                    //DOVirtual.DelayedCall(0.4f, () => Playsound(Slash_second), false);
                    if (nextattck.Getflag())
                    {
                        Debug.Log("second33333");
                      //  animator.CrossFadeInFixedTime("slash4", 0f);
                       
                        //ここでcurrentcombを変える
                        currenttime = 0;
                    }

                }

            }



        }
        else
        {
            current_effects.SetActive(false);
            attackob.SetActive(false);
            damagess.enabled = false;
            animator.CrossFadeInFixedTime("idle", 0f);
        }
    }
}
