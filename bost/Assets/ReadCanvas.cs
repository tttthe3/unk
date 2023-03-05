using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class ReadCanvas : MonoBehaviour
{
    public BoxCollider2D selfcolid;
    public GameObject window;
    private bool during = false;
    public TextMeshProUGUI Playericon;
    public string icon;
    public RandomAudioPlayer sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       Intract_display.Instance.Setword(icon);
        if (collision.gameObject.tag == "Player") {
          
            if (Playerinput.Instance.Intract.Down && !during)
            {
                if(sound!=null)
                sound.PlayRandomSound();
                during = true;
                LockBotoon();
            }
            else if (Playerinput.Instance.Intract.Down && during)
            {
                Playericon.text = "";
                during = false;
                DeLockBotoon();
            }
        }
          
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (window != null)
            window.SetActive(false);
        Intract_display.Instance.Setword(""); ;
        if (collision.gameObject.tag == "Player")
        {
            
            during = false;
            DeLockBotoon();
        }
    }

    public void LockBotoon()
    {
        if(window!=null)
        window.SetActive(true);
        //Playerinput.Instance.ReleaseController(true);
        Playerinput.Instance.Pause.GainControl();
        Playerinput.Instance.Intract.GainControl();
    }

    public void DeLockBotoon()
    {
        
        Playerinput.Instance.GainControl();
        
    }

    // Update is called once per frame

}
