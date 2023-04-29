using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class vibsample : MonoBehaviour
{
    private Player player0;
    int motor = 0;
    float moterleevl = 1f;
    float duration = 2f;
    // Start is called before the first frame update
    void Start()
    {
        player0 = ReInput.players.GetPlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Playerinput.Instance.Dash.Down)
            player0.SetVibration(motor,moterleevl,duration);
    }
}
