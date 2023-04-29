using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired.ComponentControls;
using DG.Tweening;
using Spine.Unity;
public class Air_slash1 : Kama_Compo
{

    private float currenttime = 0f;
    public string Nextattackname;
    public Tween attacks;
    private GameObject m_sound;
    private Damager damagess;
    public GameObject effects;
    private GameObject current_effects;
    public Vector3 effectpos;
    // Start is called before the first frame update

    // Start is called before the first frame update
    public override void air_firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent,SkeletonAnimation skeletonAnimation)
    {
        effectpos = parent.position + new Vector3(Charactercontrolelr.CCInstance.m_SpriteForward.x * 1f, -1f, 0f);
        skeletonAnimation.timeScale = 2.4f;
        skeletonAnimation.AnimationState.SetAnimation(0, "air_slash5", false);
        currenttime = 0f;
        if (m_sound == null)
            m_sound = Instantiate(sounds, this.transform.position, Quaternion.identity);
        //Slash_first = parent.Find("sounds/Slash/Slash1").GetComponent<RandomAudioPlayer>();
        if (damagess == null)
            damagess = parent.Find("SkeletonUtility-SkeletonRoot/root/kama1").GetComponent<Damager>();
        if (current_effects == null)
        {
            current_effects = Instantiate(effects, effectpos, Quaternion.identity);
            current_effects.transform.localScale = new Vector3(Charactercontrolelr.CCInstance.m_SpriteForward.x * -4f, 4f, 1f);
            current_effects.transform.position = effectpos;
        }
        else
        {
            current_effects.transform.localScale = new Vector3(Charactercontrolelr.CCInstance.m_SpriteForward.x * -4f, 4f, 1f);
            current_effects.transform.position = effectpos;
            current_effects.SetActive(true);
        }
        if (current_effects != null && !current_effects.activeSelf)
        {
            current_effects.transform.localScale = new Vector3(Charactercontrolelr.CCInstance.m_SpriteForward.x * -4f, 4f, 1f);
            current_effects.transform.position = effectpos;
            current_effects.SetActive(true);
        }
        Debug.Log(damagess);
        rb2d.velocity = new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x * newHorizontalMovement, 15f);
        animator.CrossFadeInFixedTime("air_slash1", 0f);
        DOVirtual.DelayedCall(0.4f, () => Playsound(m_sound.GetComponent<RandomAudioPlayer>()), false);
        damagess.havemove = Damager.movestate.hold;
    }

    public override void air_updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent)
    {
        currenttime += Time.deltaTime;
        rb2d.velocity = new Vector2(0f, 0f);
        if (currenttime < 0.6f)
        {
            damagess.enabled = true;
            //joystick.SetVibration(2f,2f);
            rb2d.velocity = new Vector2(0f, 0f);
            if (Playerinput.Instance.Attack.Down)
            {
                if (currenttime > 0.2f)
                {
                    damagess.enabled = false;
                    DOVirtual.DelayedCall(0.4f, () => Playsound(Slash_second), false);
                    //if (nextattck.Getflag())
                    {

                                DOVirtual.DelayedCall(0.4f, () => Playsound(Slash_second), false);
                                    currenttime = 0;
                                    animator.CrossFadeInFixedTime("air_slash3", 0f);
                                    damagess.enabled = false;
                        current_effects.SetActive(false);
                        //ここでcurrentcombを変える


                    }

                }

            }




        }
        else
        {
            animator.CrossFadeInFixedTime("jumpdown", 0f);
            damagess.enabled = false;
            current_effects.SetActive(false);
        }
        Debug.Log("fat22faffe32");
    }

}
