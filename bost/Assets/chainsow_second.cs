using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Spine.Unity;
using Spine;
public class chainsow_second : Kama_Compo

{
    private float currenttime = 0f;
    public string Nextattackname;
    public Tween attacks;
    private GameObject m_sound;
    private Damager damagess;
    private GameObject attackob;
    private Transform chainsow;
    // Start is called before the first frame update
    public override void firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {
        skeletonAnimation.timeScale = 2.4f;
        skeletonAnimation.AnimationState.SetAnimation(0, "slash18", false);

        currenttime = 0f;
        if (m_sound == null)
            m_sound = Instantiate(sounds, this.transform.position, Quaternion.identity);
        if (damagess == null)
            //Slash_first = parent.Find("sounds/Slash/Slash1").GetComponent<RandomAudioPlayer>();
            damagess = parent.Find("SkeletonUtility-SkeletonRoot/root/kama1").GetComponent<Damager>();
        if (attackob == null)
            attackob = parent.Find("SkeletonUtility-SkeletonRoot/root/AttackOb").gameObject;
        if (chainsow == null)
            chainsow = parent.Find("SkeletonUtility-SkeletonRoot/root/kama1/chainsow_0");
        DOVirtual.DelayedCall(0.4f, () => rb2d.velocity = new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x * 1f, 0f), false);
        DOVirtual.DelayedCall(0.4f, () => Playsound(m_sound.GetComponent<RandomAudioPlayer>()), false);
        damagess.damagemove = true;
        damagess.havemove = Damager.movestate.none;
        if (!chainsow.gameObject.activeSelf)
            chainsow.gameObject.SetActive(true);
        damagess.rengeki = true;
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
                    attackob.SetActive(false);
                    damagess.enabled = false;
                    DOVirtual.DelayedCall(0.4f, () => Playsound(Slash_second), false);

                }

            }



        }
        else
        {
            attackob.SetActive(false);
            damagess.enabled = false;
            animator.CrossFadeInFixedTime("idle", 0f);
            chainsow.gameObject.SetActive(false);
        }
    }
}
