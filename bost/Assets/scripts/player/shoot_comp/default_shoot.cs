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
    public GameObject effects;
    private GameObject current_effects;
    private Transform lefthand;
    public GameObject shotorb;
    private GameObject current_shotorb;
    public Vector3 effectpos;
    public override void firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {
        effectpos = parent.position + new Vector3(Charactercontrolelr.CCInstance.m_SpriteForward.x * 6f, -1f, 0f);
        if (lefthand == null)
            lefthand = parent.Find("SkeletonUtility-SkeletonRoot/root/body/body2/body3/righthand/righthand2/righthand3");
        currenttime = 0f;
        if (G_sound == null)
            G_sound = Instantiate(sounds, this.transform.position, Quaternion.identity);
        //Slash_first = parent.Find("sounds/Slash/Slash1").GetComponent<RandomAudioPlayer>();
        if (pools == null)
            pools = parent.gameObject.GetComponent<bullet1_pool>();
         chargeon = false;
        if (current_effects == null)
        {
            current_effects = Instantiate(effects, lefthand.position, Quaternion.identity, lefthand);
            Debug.Log(current_effects);        }
        else
        {
            current_effects.SetActive(true);
        }
        if (current_effects != null && !current_effects.activeSelf)
        {
            current_effects.SetActive(true);
        }
    }

    public override void updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, Shoot_Component nextcompo, SkeletonAnimation skeletonAnimation)
    {
        

        if (currenttime > 3f&&!chargeon)
        {
            
            chargeon = true;
            DOTween.Sequence().Append(DOVirtual.DelayedCall(0f, () => current_effects.transform.DOScale(new Vector3(1.5f, 2f, 1f), 0.3f), false))
                              .Append(DOVirtual.DelayedCall(0.1f, () => current_effects.GetComponent<SpriteRenderer>().DOColor(Color.red, 0.1f), false))
                              .Append(DOVirtual.DelayedCall(0f, () => current_effects.transform.DOScale(new Vector3(2f, 3f, 1f), 0.3f), false));
        }

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
                if (pools == null)
                    pools = parent.gameObject.GetComponent<bullet1_pool>();
                if (clipInfo[0].clip.name == "jumpdown" || clipInfo[0].clip.name == "jumpup")
                {
                    DOVirtual.DelayedCall(0.0f, () => rb2d.velocity=new Vector2(0f, 0f), false);
                    DOVirtual.DelayedCall(0.0f, () => rb2d.AddForce(new Vector2(0f, 900f)), false);
                    effectpos = parent.position + new Vector3(Charactercontrolelr.CCInstance.m_SpriteForward.x * 6f, 2f, 0f);
                }
                animator.CrossFadeInFixedTime("boltshoot1", 0f);

                
                if (current_shotorb == null)
                    current_shotorb = Instantiate(shotorb, effectpos, Quaternion.identity);
                else
                {
                    current_shotorb.transform.localScale = new Vector3(Charactercontrolelr.CCInstance.m_SpriteForward.x * -1f, 1f, 1f);
                    current_shotorb.transform.position = effectpos;
                    current_shotorb.SetActive(true);
                }
                if (current_shotorb != null && !current_shotorb.activeSelf)
                {
                    current_shotorb.transform.localScale = new Vector3(Charactercontrolelr.CCInstance.m_SpriteForward.x * -1f, 1f, 1f);
                    current_shotorb.transform.position = effectpos;
                    current_shotorb.SetActive(true);
                }




                DOVirtual.DelayedCall(0.4f, () => Playsound(G_sound.GetComponent<RandomAudioPlayer>()), false);
                skeletonAnimation.AnimationState.SetAnimation(0, "boltshoot1", false);
                bullet_Object bullets = pools.Pop(new Vector3(parent.transform.position.x, parent.transform.position.y + Random.Range(-1, 1), parent.transform.position.z));
                bullets.rigidbody2D.velocity = new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x == 1 ? 110f : -110f, 0f);
                current_effects.GetComponent<SpriteRenderer>().DOColor(Color.white, 0.1f);
                current_effects.SetActive(false);
                chargeon = false;
            }
        }
        else if(clipInfo[0].clip.name== "boltshoot1")
        {
            resettime += Time.deltaTime;
            if (resettime > 0.4f)
            {
                skeletonAnimation.timeScale = 3f;
                animator.CrossFadeInFixedTime("idle", 0f);
                current_effects.SetActive(false);
                resettime = 0f;
                current_effects.GetComponent<SpriteRenderer>().DOColor(Color.white, 0.1f);
                currenttime = 0f;
                chargeon = false;
                current_shotorb.SetActive(false);
            }
        }
        

    }




}
