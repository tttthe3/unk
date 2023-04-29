using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Spine.Unity;
using Spine;
public class chainsow_first : Kama_Compo
{

    private float currenttime = 0f;
    public string Nextattackname;
    public Tween attacks;
    private GameObject m_sound;
    private Damager damagess;
    // Start is called before the first frame update
    private GameObject attackob;
    private Transform chainsow;
    private float hitplus = 0.5f;
    private float reset = 0.2f;
    public override void firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {
        skeletonAnimation.timeScale = 3.9f;
        skeletonAnimation.AnimationState.SetAnimation(0, "slash17", false);
        Debug.Log("vib");
        currenttime = 0f;
        if (m_sound == null)
            m_sound = Instantiate(sounds, this.transform.position, Quaternion.identity);
        //Slash_first = parent.Find("sounds/Slash/Slash1").GetComponent<RandomAudioPlayer>();
        if (damagess == null)
            damagess = parent.Find("SkeletonUtility-SkeletonRoot/root/kama1").GetComponent<Damager>();
        if (attackob == null)
            attackob = parent.Find("SkeletonUtility-SkeletonRoot/root/AttackOb").gameObject;
        if (chainsow == null)
            chainsow = parent.Find("SkeletonUtility-SkeletonRoot/root/kama1/chainsow_0");
        Debug.Log(damagess);
        rb2d.velocity = new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x * 10f, 0f);
        animator.CrossFadeInFixedTime("slash1", 0.1f);
        DOVirtual.DelayedCall(0.4f, () => Playsound(m_sound.GetComponent<RandomAudioPlayer>()), false);
        damagess.havemove = Damager.movestate.none;
        if (!chainsow.gameObject.activeSelf)
            chainsow.gameObject.SetActive(true);
        damagess.rengeki = true;
        chainsow.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

    }

    public override void updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, Kama_Compo nextcompo, SkeletonAnimation skeletonAnimation)
    {
        currenttime += Time.deltaTime;


        if (currenttime < 1.2f)
        {
            {
                if (damagess.hitcheckhold && reset - Time.deltaTime > 0f)
                {
                    skeletonAnimation.timeScale = 0.3f;
                    currenttime = currenttime - Time.deltaTime * 0.3f;
                }
                else
                {
                    reset = 0.2f;
                    damagess.hitcheckhold = false;
                    skeletonAnimation.timeScale = 3.9f;

                }
            }
            damagess.enabled = true;
            attackob.SetActive(true);
            //joystick.SetVibration(2f,2f);

            if (Playerinput.Instance.Attack.Down)
            {
                nextname = "chainsow_second";
                if (currenttime > 0.2f)
                {
                    //damagess.enabled = false;
                    DOVirtual.DelayedCall(0.4f, () => Playsound(Slash_second), false);
                    //if (nextattck.Getflag())
                    {
                        //Setstatechage(nextcompo);
                        attackob.SetActive(false);
                        currenttime = 0;
                        animator.CrossFadeInFixedTime("chainsow_second", 0f);
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
            chainsow.gameObject.GetComponent<SpriteRenderer>().color = new Color(0f,0f,0f,0f);
        }
    }

    public void delaymove()
    {

    }




}
