using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Playables;
using UnityEngine.Timeline;
public class MovieCHoce : MonoBehaviour
{
    public Text choice1;
    public Text choice2;
    private int cout = 0;
    private int current = 0;
    private TimelineAsset Tracks;
    public PlayableDirector targetmovie;
    private bool Select=false ;
    public GameObject text1;
    public GameObject text2;
    // Start is called before the first frame update
    void Start()
    {
        Tracks = targetmovie.playableAsset as TimelineAsset;
    }

    // Update is called once per frame
    void Update()
    {
        if (Playerinput.Instance.Select_Vert.Value == 1)
        {
            current = 0;
            OnClickDown();

        }
        else if (Playerinput.Instance.Select_Vert.Value < 0)
        {
            current = 1;
            OnClickUp();
          
        }
        else if (Playerinput.Instance.Intract.Down&&Select)
        {
             OnClickChoice();
        }

    }

    public void OnClickUp()
    {
        choice2.DOPause();
        choice2.DOColor(Color.white, 0.1f); ;
        choice1.DOColor(Color.black, 1f).SetLoops(-1, LoopType.Yoyo);


    }

    public void OnClickDown()
    {
        choice1.DOPause();
        choice1.DOColor(Color.white, 0.1f); ;
        choice2.DOColor(Color.black, 1f).SetLoops(-1, LoopType.Yoyo);


    }

    public void OnClickChoice()
    {
      
            if (current == 0)
            {
                IEnumerable<TrackAsset> tracks = Tracks.GetOutputTracks();
                foreach (TrackAsset track in tracks)
                {
                if (track.name == "Text Switcher Track (4)")
                    text1.SetActive(false);
                
                       // track.muted = true;
                }
            }
            else
            {
                IEnumerable<TrackAsset> tracks = Tracks.GetOutputTracks();
                foreach (TrackAsset track in tracks)
                {
                    if (track.name == "Text Switcher Track (5)")
                    text2.SetActive(false);
                //track.muted = true;
            }
            }
            this.gameObject.SetActive(false);
        Select = false;
        }

    public void Onselect()
    {
        Select = true;
    }
}

    

