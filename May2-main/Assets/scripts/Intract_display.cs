using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Intract_display : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI icontext;
    public Collider2D Player;
    static public Intract_display Instance { get { return s_Intract_display; } }
    static protected Intract_display s_Intract_display;
    private void Start()
    {
        s_Intract_display = this;
        icon.gameObject.SetActive(false);
    }

    

    private void Update()
    {

        
       

       



    }

    public void Setword(string word)
    {
        icontext.text = word;

    }
}
