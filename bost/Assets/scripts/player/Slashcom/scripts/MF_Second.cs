using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired.ComponentControls;
using DG.Tweening;
using Spine.Unity;
using Spine;
public class MF_Second : Kama_Compo
{ 
    private float currenttime = 0f;
    public string Nextattackname;
    public Tween attacks;
    private GameObject m_sound2;
    private Damager damagess;
    // Start is called before the first frame update
    public override void firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {
        skeletonAnimation.timeScale = 1.9f;
        skeletonAnimation.AnimationState.SetAnimation(0, "maFattack2", false);
        currenttime = 0f;
        if (m_sound2 == null)
            m_sound2 = Instantiate(sounds, this.transform.position, Quaternion.identity);
        //Slash_first = parent.Find("sounds/Slash/Slash1").GetComponent<RandomAudioPlayer>();
        damagess = parent.Find("SkeletonUtility-SkeletonRoot/root/mafrer6/mafrer10/mafrer11/mafrer12/mafrer13").GetComponent<Damager>();
        rb2d.velocity = new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x * newHorizontalMovement, 0f);
        DOVirtual.DelayedCall(0.4f, () => Playsound(m_sound2.GetComponent<RandomAudioPlayer>()), false);
        Debug.Log("second1");
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

            if (Playerinput.Instance.Attack.Down)
            {
                if (currenttime > 0.3f)
                {
                    damagess.enabled = false;
                    DOVirtual.DelayedCall(0.4f, () => Playsound(Slash_second), false);
                    if (nextattck.Getflag())
                    {

                        animator.CrossFadeInFixedTime("maFattack3", 0f);
                        Debug.Log("second3");
                        //ここでcurrentcombを変える
                        currenttime = 0;
                    }

                }

            }



        }
        else
        {
            //damagess.enabled = false;
            animator.CrossFadeInFixedTime("idle", 0f);
        }
    }
}
