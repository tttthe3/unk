using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired.ComponentControls;
using DG.Tweening;
using Spine.Unity;
using Spine;
public class SecondSlash : Kama_Compo
{
   
    private float currenttime = 0f;
    public string Nextattackname;
    public Tween attacks;
    private GameObject m_sound2;
    private Damager damagess;
    private GameObject attackob;
    // Start is called before the first frame update
    public override void firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {
        skeletonAnimation.timeScale = 1.7f;
        skeletonAnimation.AnimationState.SetAnimation(0, "throw_slash", false);
        currenttime = 0f;
        if (m_sound2 == null)
            m_sound2 = Instantiate(sounds, this.transform.position, Quaternion.identity);
        //Slash_first = parent.Find("sounds/Slash/Slash1").GetComponent<RandomAudioPlayer>();
        damagess = parent.Find("SkeletonUtility-SkeletonRoot/root/kama1").GetComponent<Damager>();
        if (attackob == null)
            attackob = parent.Find("SkeletonUtility-SkeletonRoot/root/AttackOb").gameObject;
        DOVirtual.DelayedCall(0.5f, () => rb2d.velocity = new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x * 25f, 12f),false);
        DOVirtual.DelayedCall(0.4f, () => Playsound(m_sound2.GetComponent<RandomAudioPlayer>()), false);
        damagess.havemove = Damager.movestate.up;
        damagess.hituppower = 500f;
    }

    // Update is called once per frame
    public override void updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, Kama_Compo nextcompo, SkeletonAnimation skeletonAnimation)
    {
        currenttime += Time.deltaTime;
        Debug.Log("second3");
        if (currenttime < 1.2f)
        {
            damagess.enabled = true;
            //joystick.SetVibration(2f,2f);
            attackob.SetActive(true);
            if (Playerinput.Instance.Attack.Down)
            {
                if (currenttime > 0.2f)
                {
                    attackob.SetActive(false);
                    damagess.enabled = false;
                    DOVirtual.DelayedCall(0.4f, () => Playsound(Slash_second), false);
                    //if (nextattck.Getflag())
                    {
                       
                        animator.CrossFadeInFixedTime("slash4", 0f);
                        Debug.Log("second3");
                        //ここでcurrentcombを変える
                        currenttime = 0;
                    }

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
