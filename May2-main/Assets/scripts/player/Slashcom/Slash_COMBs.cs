using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired.ComponentControls;
using DG.Tweening;

public class Slash_COMBs : Kama_Compo
{
    private bool statechange = false;
    private Damager damages;
    public WeaponSkills Nextattacks;
    private float current=0f;
    public string Nextattackname;
    public Tween attacks;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent)
    {
        statechange = false;
        current = 0f;
        Slash_first = parent.Find("sounds/Slash/Slash1").GetComponent<RandomAudioPlayer>();
        Slash_second = parent.Find("sounds/Slash/Slash2").GetComponent<RandomAudioPlayer>();
        Slash_Special = parent.Find("sounds/Slash/Slash_Special").GetComponent<RandomAudioPlayer>();
        damages = parent.Find("SkeletonUtility-SkeletonRoot/root/kama1").GetComponent<Damager>();
        rb2d.velocity = new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x * newHorizontalMovement, 0f);
        animator.CrossFadeInFixedTime("slash1", 0f);
        DOVirtual.DelayedCall(0.4f, () => Playsound(Slash_first), false);

    }

    public override void updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent,Kama_Compo currentcomb)
    {
        current += Time.deltaTime;
       
            if (current < 0.5f)
            {
                damages.enabled = true;
                //joystick.SetVibration(2f,2f);

                if (Playerinput.Instance.Attack.Down)
                {
                    if (current > 0.3f)
                    {
                        damages.enabled = false;
                        DOVirtual.DelayedCall(0.4f, () => Playsound(Slash_second), false);
                    if (nextattck.Getflag())
                    {
                        animator.CrossFadeInFixedTime("slash2", 0f);
                        currentcomb.Setstatechage(Nextattackname);
                        //ここでcurrentcombを変える
                        current = 0;
                    }

                    }

                }

            

        }
    }

    public void delaymove()
    {

    }

    public WeaponSkills Getskill()
    {
        return Nextattacks;
    }

    public bool getstatechage()
    {
        return statechange;
    }
}
