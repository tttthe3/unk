using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using DG.Tweening;
using Spine.Unity;
public class Bullet1s : MonoBehaviour
{
    private GameObject m_sound;
    private Joystick stick;
    public GameObject orb;
    private float currenttime = 0f;
    private float resettime = 0f;
    private bullet1_pool pools;
    public GameObject chargeffects;
    // Start is called before the first frame update
    void Start()
    {
        currenttime = 0f;
        //Slash_first = parent.Find("sounds/Slash/Slash1").GetComponent<RandomAudioPlayer>();
        if (!orb.activeSelf)
            orb.SetActive(true);

        if (pools == null)
            pools = this.gameObject.GetComponent<bullet1_pool>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
