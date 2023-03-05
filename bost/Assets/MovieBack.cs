using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MovieBack : MonoBehaviour
{
    public Image[] Background;
    public Image currentImage;
    public int currentnumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeImage()
    {
        currentnumber++;
        currentImage = Background[currentnumber];;
    }
}
