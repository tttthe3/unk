using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using DG.Tweening;

public class FIrstSlash : Kama_Compo
{
 
    private float currenttime=0f;
    public string Nextattackname;
    public Tween attacks;
    private GameObject m_sound;
    private Damager damagess;
    // Start is called before the first frame update
    private Joystick stick;

    public override void firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent)
    {
        //stick= parent.Find("Vibration").GetComponent<Joystick>();
        //if (stick.supportsVibration)
            Debug.Log("vib");
        currenttime = 0f;
        if(m_sound==null)
        m_sound = Instantiate(sounds, this.transform.position, Quaternion.identity);
        //Slash_first = parent.Find("sounds/Slash/Slash1").GetComponent<RandomAudioPlayer>();
        if(damagess==null)
        damagess = parent.Find("SkeletonUtility-SkeletonRoot/root/kama1").GetComponent<Damager>();
        Debug.Log(damagess);
        rb2d.velocity = new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x * newHorizontalMovement, 0f);
        animator.CrossFadeInFixedTime("slash1", 0f);
        DOVirtual.DelayedCall(0.4f, () => Playsound(m_sound.GetComponent<RandomAudioPlayer>()), false);

    }

    public override void updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, Kama_Compo nextcompo)
    {
        currenttime += Time.deltaTime;
       
            if (currenttime < 0.7f)
            {
                damagess.enabled = true;
                //joystick.SetVibration(2f,2f);

                if (Playerinput.Instance.Attack.Down)
                {
                    if (currenttime > 0.3f)
                    {
                        //damagess.enabled = false;
                        DOVirtual.DelayedCall(0.4f, () => Playsound(Slash_second), false);
                    if (nextattck.Getflag())
                    {
                        
                        Debug.Log("fat");
                        //Setstatechage(nextcompo);
                       
                        currenttime = 0;
                        animator.CrossFadeInFixedTime("slash2", 0f);
                        damagess.enabled = false;
                        Debug.Log("fat2232");
                        //ここでcurrentcombを変える

                    }

                    }

            }
           

            

        }
        else
        {
            animator.CrossFadeInFixedTime("idle", 0f);
            damagess.enabled = false;
        }
        Debug.Log("fat22faffe32");
    }

    public void delaymove()
    {

    }




}
