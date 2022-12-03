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
    public Kama_Compo[] slashself1;
    public Kama_Compo[] slashself2;
    public Kama_Compo[] slashself3;
    public Kama_Compo[] Power_slashself;
    private Kama_Compo currentslash = null;
    private Kama_Compo power_currentslash = null;
    private Kama_Compo Nextslash = null;
    public Kama_Compo Attack_Nestslash;
    public Kama_Compo Intract_Nestslash;
    private bool statechnager=false;
    public string selfname;
    public string nextname;
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

    public void SetComponent(Kama_Compo[] setcompo)
    {
        slashself = setcompo;
    }


    public override void Firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent)
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        if (clipInfo[0].clip.name=="idle")
            currentslash = slashself[0];
        if (currentslash == null)
            currentslash = slashself[0];
        Debug.Log(statechnager);
       
        

        {
            Debug.Log(currentslash);
            currentslash.firstframes(rb2d, newHorizontalMovement, animator, parent);
        }

    }

    public override void Updateframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent)
    {

        Debug.Log(currentslash);
        //if (currentslash.statechnager)
        {
            currentslash.updateframes(rb2d, newHorizontalMovement, animator, parent, currentslash);
            Debug.Log(currentslash);
        }

    }

    public override void EndFrame( Animator animator)
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        currentslash.endframes();
        statechnager = true;
        statechnager = true;
        if (statechnager)
        {


                Debug.Log(statechnager);
                for (int i = 0; i < slashself.Length; i++)
                {
                    Debug.Log(currentslash.selfname);
                
                    if (currentslash.nextname == slashself[i].selfname)
                    {
                        currentslash = slashself[i];

                        return;
                        Debug.Log(currentslash.selfname);
                        Debug.Log(clipInfo[0].clip.name);
                    }
                }
            
            // currentslash = slashself[1];
            statechnager = false;
        }
        Debug.Log(statechnager);
    }

    public override void Special_Firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, int set, Transform parent)
    {
        if (PowerGage_Manager.Instance.Getcurrentpower().x < -0.8)
            return;
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        if (clipInfo[0].clip.name == "idle")
            power_currentslash = Power_slashself[0];
        if (currentslash == null)
            power_currentslash = Power_slashself[0];
        power_currentslash.Power_firstframes(rb2d,newHorizontalMovement,animator, parent);

    }
    public override void Special_Updateframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent)
    {

        power_currentslash.Power_updateframes(rb2d, newHorizontalMovement, animator, parent);
    }

    public override void Air_Firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, int set, Transform parent)
    {
      
    }

    public override void Air_Updateframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, int set)
    {

       
    }

    public virtual void firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent)
    {

    }

    public virtual void updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, Kama_Compo nextcompo)
    {

    }

    public virtual void Power_firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent)
    {

    }

    public virtual void Power_updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent)
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




