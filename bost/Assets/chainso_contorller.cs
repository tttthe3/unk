using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chainso_contorller : MonoBehaviour
{
    public bool onoff;
    public float limit;
    private float current;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (onoff)
        {
            current += Time.deltaTime;
            if (limit < current)
            {
                AttackWrapper.Instance.SetSeprical_Reset("slash1");
                current = 0f;
                onoff = false;
            }
        }
    }
}
