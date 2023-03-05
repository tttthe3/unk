using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_sound : MonoBehaviour
{

    public RandomAudioPlayer audio;
    public AudioSource audios;
    public float soundlooptime;
    float timer = 0f;
    private bool isground;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
            isground = true;
       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
      
            isground = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isground&&Charactercontrolelr.CCInstance.GetAniState("run"))
        {
            soundcycle();
        }
    }

     public void soundcycle()
    {

        
        timer += Time.deltaTime;
        if (timer > soundlooptime)
        {
            Debug.Log("ground2");
            audio.PlayRandomSound();
            timer = 0f;
        }
    }
}
