using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Spine.Unity;
using Spine;
public class Chainsow_special : Kama_Compo
{
    // Start is called before the first frame update
    private float currenttime = 0f;
    public string Nextattackname;
    private float chargetime = 0f;
    private GameObject m_sound;
    private Damager damagess;
    private Transform chainsow;

    public override void Power_firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {
        skeletonAnimation.timeScale = 1.1f;
        chargetime = 0f;
        if (m_sound == null)
            m_sound = Instantiate(sounds, this.transform.position, Quaternion.identity);
        if (chainsow == null)
            chainsow = parent.Find("SkeletonUtility-SkeletonRoot/root/kama1/chainsow_0");
        animator.CrossFadeInFixedTime("chargewalk2", 0f);
        
        DOVirtual.DelayedCall(0.4f, () => Playsound(m_sound.GetComponent<RandomAudioPlayer>()), false);
        PowerGage_Manager.Instance.Usepower();
        skeletonAnimation.AnimationState.SetAnimation(0, "chargewalk5", false);
    }
    public override void Power_updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {

        chargetime += Time.deltaTime;

        if (chargetime < 0.92f)
        {  
            if(!chainsow.gameObject.activeSelf)
            chainsow.gameObject.SetActive(true);
            //skeletonAnimation.AnimationState.SetAnimation(0, "chainsow2", false);
        }
        else
        {
            AttackWrapper.Instance.SetSeprical_defaultattack("chainsow_first");
            chainsow.gameObject.SetActive(false);
            chainsow.GetComponent<chainso_contorller>().onoff = true;
            animator.CrossFadeInFixedTime("idle", 0f);
        }
    }
}
