using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostOPen : MonoBehaviour
{
    public Canvas Saves;
    public GameObject skills;
    public GameObject savepanel;
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {

            if (Playerinput.Instance.Intract.Down )
            {
                Saves.gameObject.SetActive(true);
                Playerinput.Instance.ReleaseController(true);
                Playerinput.Instance.Select_Hoz.GainControl();
                Playerinput.Instance.Select_Vert.GainControl();
                Playerinput.Instance.Skill.GainControl();
                Playerinput.Instance.Skill2.GainControl();
                Playerinput.Instance.Intract.GainControl();
            }
      
            }
        }



}



