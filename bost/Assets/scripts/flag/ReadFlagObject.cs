using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadFlagObject : MonoBehaviour
{

    public StoryFlag[] ActivateFlags;
    public enum Activetype { None, AfterEvent, SceneMove };
    public Activetype m_activetype;
    private bool istrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ActivateFlags.Length; i++)
        {
            if (ActivateFlags[i].GetFlag() == false)
                return;
            else
                if (i == ActivateFlags.Length - 1)
                istrigger = true;
        }
        if (istrigger == true)
        {
            if (m_activetype == Activetype.SceneMove|| m_activetype == Activetype.AfterEvent)
            {
                if (this.transform.GetChild(0).gameObject.activeSelf)
                    this.transform.GetChild(0).gameObject.SetActive(true);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetActive_Event()
    {
        for (int i = 0; i < ActivateFlags.Length; i++)
        {
            if (ActivateFlags[i].GetFlag() == false)
                return;
            else
                if (i == ActivateFlags.Length - 1)
                istrigger = true;
        }

        if (istrigger == true)
        {
            if (m_activetype == Activetype.None)
                return;
            else if (m_activetype == Activetype.AfterEvent)
            {
                // currentObject = parent_events.Find(currentFlag.GetInit_Objectname()).gameObject;
                if (!this.transform.GetChild(0).gameObject.activeSelf)
                    this.transform.GetChild(0).gameObject.SetActive(true);

            }

        }
    }
}


