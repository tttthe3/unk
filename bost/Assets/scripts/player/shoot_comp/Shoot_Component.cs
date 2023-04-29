using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
using Rewired;
using Rewired.ComponentControls;
using DG.Tweening;

public class Shoot_Component : AttackWrapper
{

    public WeaponSKill nextattck;


    private bool attackreset = false;


    private Joystick joystick;
    public Damager damages;

    float timer = 0f;

    private GameObject WeaponParent;
    public GameObject sounds;
    public RandomAudioPlayer Slash_first;
    public RandomAudioPlayer Slash_second;
    public RandomAudioPlayer Slash_Special;
    // Start is called before the first frame update
    public Shoot_Component[] slashself;
    public Shoot_Component[] air_slashself;


    public Shoot_Component[] Power_slashself;
    private Shoot_Component currentslash = null;
    private Shoot_Component power_currentslash = null;
    private Shoot_Component Air_currentslash = null;


    private bool statechnager = false;
    public string selfname;
    public string nextname;




    //private Kama_Compo currentslash = new Kama_Compo();
    //今のアニメーター名が次の攻撃のどっちかなら切り替え

    private void OnEnable()
    {
        Debug.Log(currentslash);
        currentslash = null;
    }

    public void Playsound(RandomAudioPlayer sound)
    {
        sound.PlayRandomSound();
    }


    public override void Firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        if (currentslash == null)
            currentslash = slashself[0];

        {
            Debug.Log(currentslash);
            currentslash.firstframes(rb2d, newHorizontalMovement, animator, parent, skeletonAnimation);

        }

    }

    public override void Updateframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {

        //if (currentslash.statechnager)
        {

            if (currentslash == null)
                currentslash = slashself[0];
                currentslash.updateframes(rb2d, newHorizontalMovement, animator, parent, currentslash, skeletonAnimation);
        }

    }

    public override void EndFrame(Animator animator)
    {
        Debug.Log(currentslash);
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        currentslash.endframes();
        statechnager = true;



    }


    public override void Air_Firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, int set, Transform parent, SkeletonAnimation skeletonAnimation)
    {

        if (Air_currentslash == null)
            Air_currentslash = air_slashself[0];

        {

            Air_currentslash.air_firstframes(rb2d, newHorizontalMovement, animator, parent, skeletonAnimation);
        }
    }

    public override void Air_Updateframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {


        //if (currentslash.statechnager)
        {
            Air_currentslash.air_updateframes(rb2d, newHorizontalMovement, animator, parent,  skeletonAnimation);

        }
        Debug.Log(Air_currentslash);
    }

    public override void Air_EndFrame(Animator animator)
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Air_currentslash.endframes();
        statechnager = true;


    }

    public virtual void firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {

    }

    public virtual void updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, Shoot_Component nextcompo, SkeletonAnimation skeletonAnimation)
    {

    }
    public virtual void air_firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {

    }

    public virtual void air_updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {

    }





    private void endframes()
    {


        Debug.Log(statechnager);
    }

    public string GetStatename(string name)
    {
        return name;
    }


    public bool getstatechage()
    {
        return statechnager;
    }

    public void Setstatechage(Kama_Compo nextAttack)
    {
        Debug.Log(currentslash);
        currentslash = slashself[1];
        Debug.Log(currentslash);
    }

    public void SetnextAttack(Kama_Compo current, string nextnames)
    {
        current.nextname = nextnames;
    }
}

