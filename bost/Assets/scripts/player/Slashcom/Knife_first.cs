using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using DG.Tweening;
using Spine.Unity;
using Spine;
public class Knife_first : Kama_Compo
{
    private float currenttime = 0f;
    public string Nextattackname;
    public Tween attacks;
    private GameObject m_sound;
    private Damager damagess;
    // Start is called before the first frame update
    private Joystick stick;
    private Knifepool pools;

    public override void firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {
        skeletonAnimation.timeScale = 1.9f;
        skeletonAnimation.AnimationState.SetAnimation(0, "knife_attack1", false);
        currenttime = 0f;
        if (m_sound == null)
            m_sound = Instantiate(sounds, this.transform.position, Quaternion.identity);
        //Slash_first = parent.Find("sounds/Slash/Slash1").GetComponent<RandomAudioPlayer>();
        if (pools == null)
           pools = parent.gameObject.GetComponent<Knifepool>();
        rb2d.velocity = new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x * newHorizontalMovement, 0f);
        animator.CrossFadeInFixedTime("knife_attack1", 0f);
        DOVirtual.DelayedCall(0.4f, () => Playsound(m_sound.GetComponent<RandomAudioPlayer>()), false);

        for (int i = 0; i < 2; i++)
        {
            
            KnifeObject bullets = pools.Pop(new Vector3( parent.transform.position.x, parent.transform.position.y+Random.Range(-3, 3), parent.transform.position.z));
            bullets.rigidbody2D.velocity = new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x==1 ? 30f : -30f, 0f);
        }

      


    }

    public override void updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, Kama_Compo nextcompo, SkeletonAnimation skeletonAnimation)
    {
        currenttime += Time.deltaTime;

        if (currenttime < 0.6f)
        {
          

            if (Playerinput.Instance.Attack.Down)
            {
                if (currenttime > 0.2f)
                {
                   
                    DOVirtual.DelayedCall(0.4f, () => Playsound(Slash_second), false);
                    if (nextattck.Getflag())
                    {
                        currenttime = 0;
                        animator.CrossFadeInFixedTime("knife_attack2", 0f);
                        

                        //ここでcurrentcombを変える

                    }

                }

            }




        }
        else
        {
            animator.CrossFadeInFixedTime("idle", 0f);
           
        }
        Debug.Log("fat22faffe32");
    }
}
