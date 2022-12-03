using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGage_Manager : MonoBehaviour
{
    public Material argment;
    static public PowerGage_Manager Instance { get { return s_power; } }
    static protected PowerGage_Manager s_power;
    // Start is called before the first frame update
    void Start()
    {
        s_power = this;
        argment.SetVector("_Vector1", new Vector2(0f, 0f));
    }

    // Update is called once per frame
    public void Getpower()
    {
        Vector2 currenvalue = argment.GetVector("_Vector1");

        if (argment.GetVector("_Vector1").x<0)
            argment.SetVector("_Vector1", new Vector2(currenvalue.x+0.2f, currenvalue.y));
        if(argment.GetVector("_Vector1").x >0)
            argment.SetVector("_Vector1", new Vector2(0, 0));
    }

    public void Usepower()
    {
        Vector2 currenvalue = argment.GetVector("_Vector1");

        if (argment.GetVector("_Vector1").x > -1)
            argment.SetVector("_Vector1", new Vector2(currenvalue.x - 0.2f, currenvalue.y));
        if (argment.GetVector("_Vector1").x < -1)
            argment.SetVector("_Vector1", new Vector2(-1, 0));

    }

    public Vector2 Getcurrentpower()
    {
        return argment.GetVector("_Vector1");
    }
}
