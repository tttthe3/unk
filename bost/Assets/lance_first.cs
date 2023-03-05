using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using DG.Tweening;
using Spine.Unity;
using Spine;
public class lance_first : Kama_Compo
{
    // Start is called before the first frame update

    private float currenttime = 0f;
    public string Nextattackname;
    public Tween attacks;
    private GameObject m_sound;
    private Damager damagess;
    // Start is called before the first frame update
    private Joystick stick;
    private GameObject attackob;
    public override void firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {
        skeletonAnimation.timeScale = 1.9f;
        skeletonAnimation.AnimationState.SetAnimation(0, "lans1", false);
        Debug.Log("vib");
        currenttime = 0f;
        if (m_sound == null)
            m_sound = Instantiate(sounds, this.transform.position, Quaternion.identity);
        //Slash_first = parent.Find("sounds/Slash/Slash1").GetComponent<RandomAudioPlayer>();
        if (damagess == null)
            damagess = parent.Find("SkeletonUtility-SkeletonRoot/root/lance1").GetComponent<Damager>();
        if (attackob == null)
            attackob = parent.Find("SkeletonUtility-SkeletonRoot/root/AttackOb").gameObject;
        Debug.Log(damagess);
        rb2d.velocity = new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x * 10f, 0f);
        animator.CrossFadeInFixedTime("lance_first", 0f);
        DOVirtual.DelayedCall(0.4f, () => Playsound(m_sound.GetComponent<RandomAudioPlayer>()), false);
        damagess.havemove = Damager.movestate.none;
        nextname = "lance_second";
    }

    public override void updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, Kama_Compo nextcompo, SkeletonAnimation skeletonAnimation)
    {
        currenttime += Time.deltaTime;

        if (currenttime < 0.7f)
        {
            damagess.enabled = true;
            attackob.SetActive(true);
           

            if (Playerinput.Instance.Select_Hoz.Value==-1)
            {
                if (AttackWrapper.Instance.getleftitem_name() == "Lances")
                {
                    nextname = "lance_second";
                }
                else
                {
                    AttackWrapper.Instance.setleftitem();
                    nextname = AttackWrapper.Instance.getleftitem_name0();
                    Debug.Log(nextname);
                }
            }

            Debug.Log(nextname);

            if (Playerinput.Instance.Attack.Down)
            {
                
                Debug.Log(AttackWrapper.Instance.getrightitem_name());
                if (currenttime > 0.2f)
                {
                    //damagess.enabled = false;
                    DOVirtual.DelayedCall(0.4f, () => Playsound(Slash_second), false);
                    //if (nextattck.Getflag())
                    {
                        //Setstatechage(nextcompo);
                        attackob.SetActive(false);
                        currenttime = 0;
                        Debug.Log(nextname);
                        animator.CrossFadeInFixedTime(nextname, 0f);
                        damagess.enabled = false;
                        //ここでcurrentcombを変える

                    }

                }

            }
          

        }
        else
        {
            animator.CrossFadeInFixedTime("idle", 0f);
            damagess.enabled = false;
            attackob.SetActive(false);
        }
    }

    public void delaymove()
    {

    }




}

