using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagReader_text : MonoBehaviour
{


    public Flag_content_List refList;
    public Flag_content[] refcontent;
    public StoryFlag[] Needflag; 
    public enum eventtype { text,init,destroy};
    public eventtype[] Eventtype;
    public TextEvent initevent; //このフラグリストからおこしうるイベント数
    public bool istrigger =false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (initevent.Flagscheck()&&!initevent.GetEventState())
        {        
            if (initevent.Geteventtype() == TextEvent.eventstate.text)
            {
                initevent.SetEventState(true);
               Event_Wrapper.Instance.TextChange(initevent.Gettargetname(), initevent.GetTextref());
            }
        }
    }

    public void flagaction()
    {
        for(int i=0;i<Needflag.Length; i++)
        {
            if (Needflag[i].GetFlag() == false)
                return;
            else
            {
                if(i==Needflag.Length-1)
                istrigger = true;
            }
        }

        if(istrigger==true)
        {




        }

    }
}
