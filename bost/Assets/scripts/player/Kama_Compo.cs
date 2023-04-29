using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
using Rewired;
using Rewired.ComponentControls;
using DG.Tweening;
public class Kama_Compo : AttackWrapper
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
    public Kama_Compo[] slashself;
    public Kama_Compo[] special_slashself;
    public Kama_Compo[] air_slashself;
    Playerinput.InputButoon type;
    private Kama_Compo selfkari;
    private int weappon_change=0;

    public Kama_Compo[] Power_slashself;
    private Kama_Compo currentslash = null;
    private Kama_Compo power_currentslash = null;
    private Kama_Compo Air_currentslash = null;
    private Kama_Compo Nextslash = null;
    public Kama_Compo Attack_Nestslash;
    public Kama_Compo Intract_Nestslash;
    private bool statechnager=false;
    public string selfname;
    public string nextname;
    public string[] nextAttack_name;
    public Kama_Compo defalutfirst;
    public string nextname2;
    public Kama_Compo[] C_slashself;
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

    public void SetComponent()
    {
        selfkari.slashself=slashself;
       
    }

    public void SetComponent2()
    {
        slashself[0] = defalutfirst;

    }


    public override void Firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        if (clipInfo[0].clip.name=="idle")
            currentslash = slashself[0];
        if (currentslash == null)
            currentslash = slashself[0];

        {
            Debug.Log(currentslash);
            currentslash.firstframes(rb2d, newHorizontalMovement, animator, parent,skeletonAnimation);

        }

    }

    public override void Updateframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {
        if (Playerinput.Instance.Dash.Held)
        {
            Debug.Log("few");
            weappon_change = 1;
        }
        else if (Playerinput.Instance.Jump.Held)
        {
            Debug.Log("few");
            weappon_change = 0;
        }

        //if (currentslash.statechnager)
        {
            currentslash.updateframes(rb2d, newHorizontalMovement, animator, parent, currentslash,  skeletonAnimation);
            Debug.Log(currentslash);
        }

    }

    public override void EndFrame( Animator animator)
    {
        Debug.Log(currentslash);
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        currentslash.endframes();
        statechnager = true;

  

        Debug.Log(currentslash.nextname);
        if (statechnager)
        {
            for (int i = 0; i < slashself.Length; i++)
            {
                if (slashself[i] == null)
                    return;

                   if (currentslash.nextname == slashself[i].selfname)
                   {
                       currentslash = slashself[i];
                    Debug.Log("tr422");
                    Debug.Log(currentslash.nextname);
                    return;
                   }
            }
            // currentslash = slashself[1];
            statechnager = false;
        }

       

    }

    public override void Special_Firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, int set, Transform parent, SkeletonAnimation skeletonAnimation)
    {
        if (PowerGage_Manager.Instance.Getcurrentpower().x < -0.8)
            return;

        if (Playerinput.Instance.PowerAttack.Down)
            {
                 power_currentslash = Power_slashself[0];  //ステート遷移必須
                 power_currentslash.Power_firstframes(rb2d, newHorizontalMovement, animator, parent, skeletonAnimation);
                 return;
            }else if(Playerinput.Instance.Skill2.Down)
            {
                 if(Power_slashself[1]!=null)
                  power_currentslash = Power_slashself[1];
                  power_currentslash.Power_firstframes(rb2d, newHorizontalMovement, animator, parent, skeletonAnimation);
                   return;
               }
              else if (Playerinput.Instance.Skill2.Down&& Playerinput.Instance.PowerAttack.Down)
            {
               if (Power_slashself[2] != null)
                  power_currentslash = Power_slashself[2];
                  power_currentslash.Power_firstframes(rb2d, newHorizontalMovement, animator, parent, skeletonAnimation);
                  return;

                 }
     　　　   //アニメーター遷移

       // if (PowerGage_Manager.Instance.Getcurrentpower().x < -0.8)
       //     return;
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
       // if (clipInfo[0].clip.name == "idle")
       //  //   power_currentslash = Power_slashself[0];
       // if (currentslash == null)
       //     power_currentslash = Power_slashself[0];
      //  power_currentslash.Power_firstframes(rb2d,newHorizontalMovement,animator, parent, skeletonAnimation);

    }
    public override void Special_Updateframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {
        Debug.Log(power_currentslash.nextname);
        power_currentslash.Power_updateframes(rb2d, newHorizontalMovement, animator, parent,  skeletonAnimation);
    }

    public override void Special_EndFrame(Animator animator)
    {

        power_currentslash.Power_endframes(animator);

        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        power_currentslash.endframes();
        statechnager = true;



        Debug.Log(currentslash.nextname);
        if (statechnager)
        {
            for (int i = 0; i < slashself.Length; i++)
            {
                if (Power_slashself[i] == null)
                    return;

                if (power_currentslash.nextname == Power_slashself[i].selfname)
                {
                    power_currentslash = Power_slashself[i];
                    return;
                }
            }
            // currentslash = slashself[1];
            statechnager = false;
        }
    }

    public override void Air_Firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, int set, Transform parent,SkeletonAnimation skeletonAnimation)
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        if (clipInfo[0].clip.name == "idle"|| clipInfo[0].clip.name == "jumpup" || clipInfo[0].clip.name == "jumpdown")
            Air_currentslash = air_slashself[0];
        if (Air_currentslash == null)
            Air_currentslash = air_slashself[0];
        
        {

           Air_currentslash.air_firstframes(rb2d, newHorizontalMovement, animator, parent,skeletonAnimation);
            Debug.Log(Air_currentslash);
        }
    }

    public override void Air_Updateframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {


        //if (currentslash.statechnager)
        {
            Air_currentslash.air_updateframes(rb2d, newHorizontalMovement, animator, parent);

        }
        Debug.Log(Air_currentslash);
    }

    public override void Air_EndFrame(Animator animator)
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Air_currentslash.endframes();
        statechnager = true;

        if (statechnager)
        {
            for (int i = 0; i < air_slashself.Length; i++)
            {
                if (air_slashself[i] == null)
                    return;

                if (Air_currentslash.nextname == air_slashself[i].selfname)
                {
                    Air_currentslash = air_slashself[i];
                    Debug.Log("tr422");
                    Debug.Log(Air_currentslash.nextname);
                    return;
                }

            }
            // currentslash = slashself[1];
            statechnager = false;
        }
        Debug.Log(statechnager);
    }

    public virtual void firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {

    }

    public virtual void updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, Kama_Compo nextcompo, SkeletonAnimation skeletonAnimation)
    {

    }
    public virtual void air_firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent,SkeletonAnimation skeletonAnimation)
    {

    }

    public virtual void air_updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent)
    {

    }


    public virtual void Power_firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {

    }

    public virtual void Power_updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent,SkeletonAnimation skeletonAnimation)
    {

    }

    public virtual void Power_endframes( Animator animator)
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

    public void SetnextAttack(Kama_Compo current,string nextnames)
    {
        current.nextname = nextnames;
    }
}




