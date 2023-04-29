﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using DG.Tweening;
using Spine.Unity;
using Spine;
public class FIrstSlash : Kama_Compo
{
 
    private float currenttime=0f;
    public string Nextattackname;
    public Tween attacks;
    private GameObject m_sound;
    private Damager damagess;
    // Start is called before the first frame update
    private Joystick stick;
    private GameObject attackob;
    private Transform chainsow;
    private float hitplus=0.5f;
    private float reset = 0.2f;
    public GameObject effects;
    private GameObject current_effects;
    public Vector3 effectpos;
    public override void firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {
        effectpos =parent.position + new Vector3(Charactercontrolelr.CCInstance.m_SpriteForward.x*5f,-1f,0f);
        skeletonAnimation.timeScale = 3.9f;
        skeletonAnimation.AnimationState.SetAnimation(0, "slash17", false);
        currenttime = 0f;
        if(m_sound==null)
        m_sound = Instantiate(sounds, this.transform.position, Quaternion.identity);
        //Slash_first = parent.Find("sounds/Slash/Slash1").GetComponent<RandomAudioPlayer>();
        if (chainsow == null)
            chainsow = parent.Find("SkeletonUtility-SkeletonRoot/root/kama1/chainsow_0");
        if (damagess==null)
        damagess = parent.Find("SkeletonUtility-SkeletonRoot/root/kama1").GetComponent<Damager>();
        if (current_effects == null)
        {
            current_effects = Instantiate(effects, effectpos, Quaternion.identity);
            current_effects.transform.localScale = new Vector3(Charactercontrolelr.CCInstance.m_SpriteForward.x * 11f, 11f, 1f);
        }
        else
        {
            current_effects.transform.localScale = new Vector3(Charactercontrolelr.CCInstance.m_SpriteForward.x * 11f, 11f, 1f);
            current_effects.transform.position = effectpos;
            current_effects.SetActive(true);
        }
        if (current_effects != null && !current_effects.activeSelf)
        {
            current_effects.transform.localScale = new Vector3(Charactercontrolelr.CCInstance.m_SpriteForward.x * 11f, 11f, 1f);
            current_effects.transform.position = effectpos;
            current_effects.SetActive(true);
        }
        if (attackob == null)
        attackob = parent.Find("SkeletonUtility-SkeletonRoot/root/AttackOb").gameObject;
        rb2d.velocity = new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x *10f, 0f);
        animator.CrossFadeInFixedTime("slash1", 0.1f);
        DOVirtual.DelayedCall(0.4f, () => Playsound(m_sound.GetComponent<RandomAudioPlayer>()), false);
        damagess.force = 10f;
        damagess.havemove = Damager.movestate.next;
        damagess.rengeki = false;
    }

    public override void updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, Kama_Compo nextcompo, SkeletonAnimation skeletonAnimation)
    {
        currenttime += Time.deltaTime;

      
            if (currenttime < 0.8f)
            {

            
            damagess.enabled = true;
                attackob.SetActive(true);
               //joystick.SetVibration(2f,2f);
            
                if (Playerinput.Instance.Attack.Down)
                {
                
                    if (currenttime > 0.1f&& currenttime < 0.4f)
                    { 
                    nextname = "slash2-2";
                    current_effects.SetActive(false);
                    //damagess.enabled = false;
                    DOVirtual.DelayedCall(0.4f, () => Playsound(Slash_second), false);
                    if (nextattck.Getflag())
                    {
                        //Setstatechage(nextcompo);
                        attackob.SetActive(false);
                        currenttime = 0;
                        animator.CrossFadeInFixedTime("slash2",  0f);
                        damagess.enabled = false;
                        //ここでcurrentcombを変える

                    }

                    }else if(currenttime > 0.4f&& currenttime < 0.8f)
                {
                    nextname = "slash2";
                    current_effects.SetActive(false);
                    DOVirtual.DelayedCall(0.4f, () => Playsound(Slash_second), false);
                   // if (nextattck.Getflag())
                    {
                        //Setstatechage(nextcompo);
                        attackob.SetActive(false);
                        currenttime = 0;
                        animator.CrossFadeInFixedTime("slash2", 0f);
                        damagess.enabled = false;
                        //ここでcurrentcombを変える

                    }
                }

            }
            else if (Playerinput.Instance.Dash.Down)
            {//damagess.enabled = false;
                nextname = "slash9";
                current_effects.SetActive(false);
                DOVirtual.DelayedCall(0.4f, () => Playsound(Slash_second), false);
                currenttime = 0;
                animator.CrossFadeInFixedTime("slash9", 0f);
                damagess.enabled = false;
                Debug.Log(nextname);
            }

            }
        else
        {
            current_effects.SetActive(false);
            animator.CrossFadeInFixedTime("idle", 0f);
            damagess.enabled = false;
            attackob.SetActive(false);
        }
    }

    public void delaymove()
    {

    }




}
