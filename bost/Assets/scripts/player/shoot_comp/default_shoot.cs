using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using DG.Tweening;
using Spine.Unity;

public class default_shoot :Shoot_Component
{

    private float currenttime = 0f;
    private float resettime = 0f;
    public string Nextattackname;
    public Tween attacks;
    private GameObject G_sound;
    private Damager damagess;
    // Start is called before the first frame update
    private Joystick stick;
    private GameObject orb;
    private float hitplus = 0.5f;
    private float reset = 0.2f;
    private bullet1_pool pools;
    public GameObject chargeffects;
    private bool chargeon;
    private GameObject chargeorb;
    public override void firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {
         skeletonAnimation.timeScale = 3f;
        currenttime = 0f;
        if (G_sound == null)
            G_sound = Instantiate(sounds, this.transform.position, Quaternion.identity);
        //Slash_first = parent.Find("sounds/Slash/Slash1").GetComponent<RandomAudioPlayer>();
        if (orb==null)
           orb = parent.Find("SkeletonUtility-SkeletonRoot/root/orb").gameObject;
        if (chargeorb == null)
            chargeorb = parent.Find("SkeletonUtility-SkeletonRoot/root/chargeorb").gameObject;
        DOVirtual.DelayedCall(0.4f, () => Playsound(G_sound.GetComponent<RandomAudioPlayer>()), false);
        if (pools == null)
            pools = parent.gameObject.GetComponent<bullet1_pool>();
         chargeon = true;
    }

    public override void updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, Shoot_Component nextcompo, SkeletonAnimation skeletonAnimation)
    {
        currenttime += Time.deltaTime;
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
       // if (currenttime > 3f)
           // chargeorb.SetActive(true);
        if(clipInfo[0].clip.name == "idle"|| clipInfo[0].clip.name == "run" || clipInfo[0].clip.name == "jumpdown" || clipInfo[0].clip.name == "jumpup") {
            if (Playerinput.Instance.Intract.Up)
            {
                if (G_sound == null)
                    G_sound = Instantiate(sounds, this.transform.position, Quaternion.identity);
                skeletonAnimation.timeScale = 3f;
                if (orb == null)
                    orb = parent.Find("SkeletonUtility-SkeletonRoot/root/orb").gameObject;
                if (pools == null)
                    pools = parent.gameObject.GetComponent<bullet1_pool>();
                animator.CrossFadeInFixedTime("boltshoot1", 0f);
                if(!orb.activeSelf)
                orb.SetActive(true);
                DOVirtual.DelayedCall(0.4f, () => Playsound(G_sound.GetComponent<RandomAudioPlayer>()), false);
                skeletonAnimation.AnimationState.SetAnimation(0, "boltshoot1", false);
                bullet_Object bullets = pools.Pop(new Vector3(parent.transform.position.x, parent.transform.position.y + Random.Range(-1, 1), parent.transform.position.z));
                bullets.rigidbody2D.velocity = new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x == 1 ? 110f : -110f, 0f);
            }
        }
        else if(clipInfo[0].clip.name== "boltshoot1")
        {
            resettime += Time.deltaTime;
            if (resettime > 0.3f)
            {
                animator.CrossFadeInFixedTime("idle", 0f);
                resettime = 0f;
                currenttime = 0f;
            }
        }
        

    }




}
