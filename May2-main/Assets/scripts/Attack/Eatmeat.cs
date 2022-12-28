using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Eatmeat : Itemwrapper
{
    public GameObject Slider;
    public float timer = 0f;
    // Start is called before the first frame update
    public override void firstframeLeft(Rigidbody2D rb2d, Animator animator,Transform parent)
    {
        Slider = GameObject.Find("Playercanvas");
        Slider.transform.Find("Slider").gameObject.GetComponent<Slider>().value+=1;
        animator.CrossFadeInFixedTime("eat_care", 0f);
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
}