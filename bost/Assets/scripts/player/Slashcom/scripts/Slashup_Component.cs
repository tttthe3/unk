using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired.ComponentControls;
using DG.Tweening;
using Spine.Unity;
using Spine;
public class Slashup_Component : Kama_Compo
{

    private float currenttime = 0f;
    public string Nextattackname;
    public Tween attacks;
    private GameObject m_sound;
    private Damager damagess;
    // Start is called before the first frame update
    private GameObject attackob;
    public override void firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {
        skeletonAnimation.timeScale = 2.9f;
        skeletonAnimation.AnimationState.SetAnimation(0, "rollingslash", false);
        Debug.Log("vib");
        currenttime = 0f;
        if (m_sound == null)
            m_sound = Instantiate(sounds, this.transform.position, Quaternion.identity);
        //Slash_first = parent.Find("sounds/Slash/Slash1").GetComponent<RandomAudioPlayer>();
        if (damagess == null)
            damagess = parent.Find("SkeletonUtility-SkeletonRoot/root/kama1").GetComponent<Damager>();
        if (attackob == null)
            attackob = parent.Find("SkeletonUtility-SkeletonRoot/root/AttackOb").gameObject;
        DOVirtual.DelayedCall(0.24f, () => rb2d.velocity = new Vector2(0f, 30f), false);
        damagess.damagemove = true;
        //rb2d.velocity = new Vector2(0f, 20f);
        //animator.CrossFadeInFixedTime("slash9", 0f);
        DOVirtual.DelayedCall(0.4f, () => Playsound(m_sound.GetComponent<RandomAudioPlayer>()), false);
        damagess.havemove = Damager.movestate.up;
        damagess.hituppower = 1900f;
        damagess.downstate = true;
    }

    public override void updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, Kama_Compo nextcompo, SkeletonAnimation skeletonAnimation)
    {
        currenttime += Time.deltaTime;

        if (currenttime < 0.7f)
        {
            damagess.enabled = true;
            attackob.SetActive(true);
            //joystick.SetVibration(2f,2f);

            if (currenttime > 0.3f)

                damagess.damagemove =false;


        }
        else
        {
            animator.CrossFadeInFixedTime("jumpdown", 0f);
            damagess.enabled = false;
            attackob.SetActive(false);
        }
        //damagess.damagemove = false;
    }

    public void delaymove()
    {

    }




}
