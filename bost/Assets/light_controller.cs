using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class light_controller : MonoBehaviour
{
    public Light2D light;
    public enum lighttype {onoff,hold };
    public lighttype Lighttype;
    public float onofftime;
    private float currentime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Lighttype == lighttype.onoff)
        {

        }

    }
}
