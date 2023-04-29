using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movie_Object : MonoBehaviour
{
    public Flag_content finishflag;
    public StoryFlag flag;
    public Transform AfterMoive_Position;

    private void Start()
    {
        if (finishflag.flag)
            this.transform.position = AfterMoive_Position.position;
        if (flag.GetFlag())
            this.transform.position = AfterMoive_Position.position;

    }

}
