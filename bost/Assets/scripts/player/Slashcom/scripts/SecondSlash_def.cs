using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired.ComponentControls;
using DG.Tweening;
using Spine.Unity;
using Spine;
public class SecondSlash_def : Kama_Compo
{
   
    private float currenttime = 0f;
    public string Nextattackname;
    public Tween attacks;
    private GameObject m_sound2;
    private Damager damagess;
    private GameObject attackob;
    public GameObject effects;
    private GameObject current_effects;
    public Vector3 effectpos;
    // Start is called before the first frame update
    public override void firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {
        effectpos = parent.position + new Vector3(Charactercontrolelr.CCInstance.m_SpriteForward.x * 6f, -1f, 0f);
        skeletonAnimation.timeScale = 2.7f;
        skeletonAnimation.AnimationState.SetAnimation(0, "slash16", false);
        currenttime = 0f;
        if (m_sound2 == null)
            m_sound2 = Instantiate(sounds, this.transform.position, Quaternion.identity);
        //Slash_first = parent.Find("sounds/Slash/Slash1").GetComponent<RandomAudioPlayer>();
        damagess = parent.Find("SkeletonUtility-SkeletonRoot/root/kama1").GetComponent<Damager>();
        if (attackob == null)
            attackob = parent.Find("SkeletonUtility-SkeletonRoot/root/AttackOb").gameObject;
        DOVirtual.DelayedCall(0.1f, () => rb2d.velocity = new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x * 5f, 0f),false);
        DOVirtual.DelayedCall(0.4f, () => Playsound(m_sound2.GetComponent<RandomAudioPlayer>()), false);
        damagess.havemove = Damager.movestate.next;
        damagess.force = 10f;
        damagess.hituppower = 500f;

        if (current_effects == null) { 
            current_effects = Instantiate(effects, effectpos, Quaternion.identity); 
            current_effects.transform.localScale = new Vector3(Charactercontrolelr.CCInstance.m_SpriteForward.x * 11f, 11f, 1f);
         }
        else
        {
            current_effects.transform.localScale = new Vector3(Charactercontrolelr.CCInstance.m_SpriteForward.x * -11f, 12f, 1f);
            current_effects.transform.position = effectpos;
            current_effects.SetActive(true);
        }
        if (current_effects != null && !current_effects.activeSelf)
        {
            current_effects.transform.localScale = new Vector3(Charactercontrolelr.CCInstance.m_SpriteForward.x * -11f, 12f, 1f);
            current_effects.transform.position = effectpos;
            current_effects.SetActive(true);
        }
    }

    // Update is called once per frame
    public override void updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, Kama_Compo nextcompo, SkeletonAnimation skeletonAnimation)
    {
        currenttime += Time.deltaTime;
        Debug.Log("second3");
        if (currenttime < 0.5f)
        {
            damagess.enabled = true;
            //joystick.SetVibration(2f,2f);
            attackob.SetActive(true);
            if (Playerinput.Instance.Attack.Down)
            {

                nextname = "slash4";
                current_effects.SetActive(false);
                if (currenttime > 0.1f)
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
            current_effects.SetActive(false);
            damagess.enabled = false;
            animator.CrossFadeInFixedTime("idle", 0f);
        }
    }
}
