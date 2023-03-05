using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Spine.Unity;
using Spine;
public class PowerSlash1 : Kama_Compo
{
    // Start is called before the first frame update
    private float currenttime = 0f;
    public string Nextattackname;
    private float chargetime = 0f;
    private GameObject m_sound;
    private Damager damagess;


    public override void Power_firstframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {
        if (m_sound == null)
            m_sound = Instantiate(sounds, this.transform.position, Quaternion.identity);
        if (damagess == null)
            damagess = parent.Find("SkeletonUtility-SkeletonRoot/root/kama1").GetComponent<Damager>();
        animator.CrossFadeInFixedTime("Powerslash_wait", 0f);
        DOVirtual.DelayedCall(0.4f, () => Playsound(m_sound.GetComponent<RandomAudioPlayer>()), false);
        PowerGage_Manager.Instance.Usepower();
        DOTween.Sequence().SetDelay(0.3f)
                          .Append(rb2d.transform.DOLocalMove(rb2d.transform.position + new Vector3(Charactercontrolelr.CCInstance.m_SpriteForward.x * 1f, 4f, 0f), 0.35f))
                          .Append(rb2d.transform.DOLocalMove(new Vector3(Charactercontrolelr.CCInstance.m_SpriteForward.x * 5f, -1f, 0f) + rb2d.transform.position, 0.1f));
        damagess.havemove = Damager.movestate.none;
    }
    public override void Power_updateframes(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {

        chargetime += Time.deltaTime;

        if (chargetime < 1.3f)
        {
            damagess.enabled = true;
        }
        else
        {
            animator.CrossFadeInFixedTime("idle", 0f);
            damagess.enabled = false;
            chargetime = 0f;
        }
    }
}
