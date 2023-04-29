using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Savepoint_confg : MonoBehaviour
{
    public enum States { None, Mainset, Subset, Skilltree, LR }
    public States states;
    public GameObject Selecter;
    public GameObject currentselect;
    public Image seletimage;
    public GameObject firstselect;
    private int cout = 0;
    public Canvas Skillmaps;
    public Canvas travwel;
    // Start is called before the first frame update
    void Start()
    {
        currentselect = firstselect;
    }

    private void OnEnable()
    {
        currentselect = firstselect;
    }

    // Update is called once per frame
    void Update()
    {
     if (Playerinput.Instance.Select_Vert.Value == 1 && cout == 0)
        {
            cout = 1;
            OnClickUp();

        }
        else if (Playerinput.Instance.Select_Vert.Value < 0 && cout == 0)
        {
            cout = 1;
            OnClickDown();
        }
        if (Playerinput.Instance.Skill.Down)
        {
            OnClickChoice();
        }


        if (Playerinput.Instance.Select_Vert.Value == 0)
            cout = 0;

    }

    public void OnClickUp()
    {

        if (currentselect.GetComponent<config_icon>().upicon == null)
            return;
        currentselect = currentselect.GetComponent<config_icon>().upicon;
        seletimage.transform.position = currentselect.transform.position;
        //currentselect.GetComponent<Image>().DOColor(Color.black, 0.4f).SetLoops(-1, LoopType.Yoyo);

        cout = 1;
    }

    public void OnClickDown()
    {
     
        
            if (currentselect.GetComponent<config_icon>().downicon == null)
                return;
            currentselect = currentselect.GetComponent<config_icon>().downicon;
            seletimage.transform.position = currentselect.transform.position;
            //currentselect.GetComponent<Image>().DOColor(Color.black, 0.4f).SetLoops(-1, LoopType.Yoyo);

            cout = 1;

        
    }

    public void OnClickChoice() 
    {
        if (currentselect.GetComponent<config_icon>().panel == null)
            Skillmaps.gameObject.SetActive(false);
        currentselect.GetComponent<config_icon>().panel.SetActive(true);
        this.gameObject.SetActive(false);


    }
}
