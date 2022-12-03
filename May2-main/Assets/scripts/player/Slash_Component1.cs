using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
using Rewired;
using Rewired.ComponentControls;
using DG.Tweening;
public class Slash_Componet1 : AttackWrapper
{

    public WeaponSKill nextattck;


    private bool attackreset = false;
    public enum combstate { one, two, three }
    public combstate now = combstate.one;
    private Joystick joystick;
    private Damager damages;
    private float current;
    public float firsttimer;
    public float secondtimer;
    public float thirdtimer;
    float timer = 0f;
    public float chargetime;
    private GameObject WeaponParent;
    public RandomAudioPlayer Slash_first;
    public RandomAudioPlayer Slash_second;
    public RandomAudioPlayer Slash_Special;
    // Start is called before the first frame update
    private Slash_Componet1[] slashself;
    private Slash_Componet1 currentslash;

    private void Start()
    {
        currentslash = slashself[0];
    }
    public void Playsound(RandomAudioPlayer sound)
    {
        sound.PlayRandomSound();
    }


    public override void Firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent)
    {
        now = combstate.one;
       

        damages.enabled = false;

        if (!attackreset)

        {

            currentslash.firstframes(rb2d, newHorizontalMovement, animator, parent);
        }
    
    }

    public override void Updateframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent)
    {
       

        if (!attackreset)
        {
           currentslash.updateframes(rb2d,  newHorizontalMovement,  animator,  parent);
        }

        if (now == combstate.two)
        {
            if (current < 1f)
            {
                if (Playerinput.Instance.Attack.Down)
                {
                    damages.enabled = true;
                    if (current > 0.2f)
                    {

                        //animator.CrossFadeInFixedTime("slash4", 0f);
                        now = combstate.three;
                    }

                }

            }
            else
            {
                damages.enabled = false;
                now = combstate.one;
                animator.CrossFadeInFixedTime("idle", 0f);
                current = 0f;
            }
        }

        if (now == combstate.three)
        {
            if (current > 1f)
            {
                animator.CrossFadeInFixedTime("idle", 0f);
                now = combstate.one;
            }
        }

    }

    public override void Special_Firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, int set, Transform parent)
    {
        Vector2 power = new Vector2(-120f, 0f);
        power = power * Charactercontrolelr.CCInstance.m_SpriteForward.x;
        chargetime = 0f;
        if (set == 1)
        {
            //rb2d.AddForce(power, ForceMode2D.Impulse);
            //rb2d.velocity = new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x * newHorizontalMovement, 0f);
            animator.CrossFadeInFixedTime("Powerslash_wait", 0f);
            DOVirtual.DelayedCall(0.4f, () => Playsound(Slash_Special), false);
        }
        else if (set == 2)
        {
            rb2d.velocity = new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x * newHorizontalMovement * 0.4f, 0f);
            animator.CrossFadeInFixedTime("slash1", 0f);
        }
        else if (set == 3)
        {
            rb2d.velocity = new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x * newHorizontalMovement * 0.2f, 0f);
            animator.CrossFadeInFixedTime("slash1", 0f);
        }

    }
    

    public override void Air_Firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, int set, Transform parent)
    {
        damages = parent.Find("SkeletonUtility-SkeletonRoot/root/kama1").GetComponent<Damager>();
        timer = 0;
        damages.enabled = false;
        chargetime = 0f;
        if (set == 1)
        {
            damages.enabled = true;
            //rb2d.velocity = new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x * newHorizontalMovement, 0f);
            animator.CrossFadeInFixedTime("air_slash1", 0f);
            Charactercontrolelr.CCInstance.UpdateFacing();
            rb2d.gravityScale = 0f;
            rb2d.velocity = new Vector2(0f, 0f);
        }
        else if (set == 2)
        {
            rb2d.velocity = new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x * newHorizontalMovement * 0.4f, 0f);
            animator.CrossFadeInFixedTime("slash1", 0f);
        }
        else if (set == 3)
        {
            rb2d.velocity = new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x * newHorizontalMovement * 0.2f, 0f);
            animator.CrossFadeInFixedTime("slash1", 0f);
        }
    }

    public override void Air_Updateframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, int set)
    {

        if (set == 1)
        {

            //m_MonoBehaviour.UpdateJump();
            timer += Time.deltaTime;
            //Charactercontrolelr.CCInstance.loopAirHorizontalMovement(true, 1f);
            //m_MonoBehaviour.AirborneVerticalMovement();

            if (Charactercontrolelr.CCInstance.isWall)
            {
                Charactercontrolelr.CCInstance.wallrefect();
            }

            if (Charactercontrolelr.CCInstance.CheckForGrounded())
            {
                Debug.Log("go");
                rb2d.gravityScale = 6f;
                damages.enabled = false;
                Charactercontrolelr.CCInstance.Jumpdown();
                Charactercontrolelr.CCInstance.skeletonAnimation.timeScale = 1f;
            }

            //m_MonoBehaviour.getstate().Complete += delegate { m_MonoBehaviour.skeletonAnimation.AnimationState.SetAnimation(0, "jumpdown", false);  } ;
            if (timer > 0.6f)
            {
                rb2d.gravityScale = 6f;
                damages.enabled = false;
                Charactercontrolelr.CCInstance.Jumpdown();
                timer = 0f;
            }
        }
        else if (set == 2)
        {

        }
        else if (set == 3)
        {

        }
    }

    public virtual void firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent)
    {

    }

    public virtual void updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent)
    {

    }
}


