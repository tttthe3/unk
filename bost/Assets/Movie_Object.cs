using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movie_Object : MonoBehaviour
{
    public Flag_content finishflag;
    public Transform AfterMoive_Position;

    private void Start()
    {
        if (finishflag.flag)
            this.transform.position = AfterMoive_Position.position;

    }

}
