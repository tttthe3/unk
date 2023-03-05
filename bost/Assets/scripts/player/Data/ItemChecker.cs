using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.UI;
public class ItemChecker : MonoBehaviour
{
    [SerializeField]
    CreateItem Iteminfromation;

    public UnityEvent Itemget;
    public UnityEvent Endevent;
    public Canvas Itemshow;
    public Image Itemicon;
    public Text text1;
    public Text text2;
    public Image checkicon;
    public Gradient iconcolor;
    private bool Endtrigger = false;
    public RandomAudioPlayer sound1;
    public RandomAudioPlayer sound2;
    public ObjectFlag storyFlag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Iteminfromation.GetKindofItem() == CreateItem.KindofItem.Weapon)
            {
                ItemDataBase.Instance.AddItem(Iteminfromation);
                Itemicon.sprite = Iteminfromation.GetSprite();
                
                text1.text = Iteminfromation.getinfomation();
                text2.text = Iteminfromation.getitemname();
                //InputStop();
                Itemget.Invoke();
            }
            else
                ItemDataBase.Instance.AddItem_Use(Iteminfromation);

        }
    }

    private void Update()
    {
        if (Endtrigger)
        {
            if (Playerinput.Instance.Intract.Down)
            {
                checkicon.DOKill();
                Itemshow.gameObject.SetActive(false);
                Endtrigger = false;
                Endevent.Invoke();
                this.gameObject.SetActive(false);
                if (storyFlag != null)
                {
                    storyFlag.SetFlag();
                   // Story_FlagList.Instance.InitEvent();
                    Story_FlagList.Instance.SetActive_Event();
                }

            }
        }
    }

    public void Itemgetsho()
    {
        Itemshow.gameObject.SetActive(true);
        DOTween.Sequence().Append(DOVirtual.DelayedCall(0f, () => InputStop(), false))
                          .SetDelay(1f)
                          .Append(DOVirtual.DelayedCall(0f, () => sound2.PlayRandomSound(), false))
                          .SetDelay(4f)
                          .Append(checkicon.DOGradientColor(iconcolor, 1f))
                          .Join(DOVirtual.DelayedCall(0f, () => InputGain(), false));
       
    }

    public void InputStop()
    {
       
        sound1.PlayRandomSound();
    }

    public void InputGain()
    {
        Playerinput.Instance.GainControl();
        Endtrigger = true;
        //this.gameObject.SetActive(false);
    }
}
 