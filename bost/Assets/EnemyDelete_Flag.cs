using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyDelete_Flag : MonoBehaviour
{
    
    public StoryFlag flags;
    private Transform[] children;
    private bool activeone;
    public UnityEvent OnDestory;
    int activecount = 0;
    void Start()
    {
        children = new Transform[this.transform.childCount];
        for (var i = 0; i < children.Length; ++i)
        {
            children[i] = this.transform.GetChild(i);
        }
        Debug.Log(children.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkchildren()
    {
        for (var i = 0; i < children.Length; ++i)
        {
            if (children[i].gameObject.activeSelf)
                activecount++;
           
        }
        Debug.Log(activecount);
        if (activecount == 1)
        {
            flags.SetFlag();
            OnDestory.Invoke();
        }
        else
            activecount = 0;
          
    }
}
