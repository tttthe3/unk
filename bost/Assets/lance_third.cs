using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using DG.Tweening;
using Spine.Unity;
using Spine;
public class lance_third : Kama_Compo

{
    private float currenttime = 0f;
    public string Nextattackname;
    public Tween attacks;
    private GameObject m_sound;
    private Damager damagess;
    private GameObject attackob;
    // Start is called before the first frame update
    public override void firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {
        skeletonAnimation.timeScale = 1.4f;
        skeletonAnimation.AnimationState.SetAnimation(0, "lans5", false);

        currenttime = 0f;
        if (m_sound == null)
            m_sound = Instantiate(sounds, this.transform.position, Quaternion.identity);
        if (damagess == null)
            //Slash_first = parent.Find("sounds/Slash/Slash1").GetComponent<RandomAudioPlayer>();
            damagess = parent.Find("SkeletonUtility-SkeletonRoot/root/lance1").GetComponent<Damager>();
        if (attackob == null)
            attackob = parent.Find("SkeletonUtility-SkeletonRoot/root/AttackOb").gameObject;
        DOVirtual.DelayedCall(0.4f, () => rb2d.velocity = new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x * 9f, 7f), false);
        DOVirtual.DelayedCall(0.4f, () => Playsound(m_sound.GetComponent<RandomAudioPlayer>()), false);
        damagess.damagemove = true;
        damagess.havemove = Damager.movestate.diagonal;
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
                   
                    

                }

            }



        }
        else
        {
            attackob.SetActive(false);
            damagess.enabled = false;
            animator.CrossFadeInFixedTime("idle", 0f);
        }
    }
}

