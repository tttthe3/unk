using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Eatmeat : Itemwrapper
{
    public GameObject Slider;
    public float timer = 0f;
    private RandomAudioPlayer m2_sound;
    // Start is called before the first frame update
    public override void firstframeLeft(Rigidbody2D rb2d, Animator animator,Transform parent)
    {
        if (m2_sound == null)
        {
            m2_sound = parent.Find("sounds/Eat_meat").GetComponent<RandomAudioPlayer>();
            m2_sound = Instantiate(m2_sound, this.transform.position, Quaternion.identity).GetComponent<RandomAudioPlayer>();
        }
        Slider = GameObject.Find("Playercanvas");
        Slider.transform.Find("Slider").gameObject.GetComponent<Slider>().value+=1;
        animator.CrossFadeInFixedTime("eat_care", 0f);
        DOVirtual.DelayedCall(0.1f, () => Playsound(m2_sound.GetComponent<RandomAudioPlayer>()), false);
    }

    public override void updateframeLeft(Rigidbody2D rb2d, Animator animator)
    {
        timer += Time.deltaTime;
        if (timer > 1f)
        {
            animator.CrossFadeInFixedTime("idle", 0f);
            timer = 0f;
        }
    }
    public override void endframeLeft()
    {
    }

    public override void firstframeRight(Rigidbody2D rb2d, Animator animator)
    {
        Slider = GameObject.Find("Playercanvas");
        Slider.transform.Find("Slider").gameObject.GetComponent<Slider>().value = 1;
        animator.CrossFadeInFixedTime("eat_care", 0f);
    }

    public override void updateframeRight(Rigidbody2D rb2d, Animator animator)
    {
        timer += Time.deltaTime;
        if (timer > 1f)
        {
            animator.CrossFadeInFixedTime("idle", 0f);
            timer = 0f;
        }
    }
    public override void endframeRight()
    {
    }

    public void Playsound(RandomAudioPlayer sound)
    {
        sound.PlayRandomSound();
    }
}