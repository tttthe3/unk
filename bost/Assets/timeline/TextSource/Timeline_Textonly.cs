using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using DG.Tweening;
public class Timeline_Textonly : MonoBehaviour
{
    public TextMeshProUGUI Singletext;
    public List<string> singles;
    private string current_direc;
    public int current;
    private bool up;
    private bool reload = false;
    public Image pushbotton;
    public PlayableDirector playableDirector;
    private TimelineAsset Tracks;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
       

        if (playableDirector.playableGraph.GetRootPlayable(0).GetSpeed()==0 && Playerinput.Instance.Intract.Down)
        {

            playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(1);
            pushbotton.DOColor(Color.white, 0f);
            pushbotton.DOPause();
        }
    }




    public void OnClickChoice()
    {
        SetselectdocC();
        if (current == 0)
        {
            up = true;

        }
        else
            up = false;



    }

    public void Setdirectory(string direc)
    {
        current_direc = direc;
    }



    public void Textload_1line(string directory)
    {
        reload = false;
        Singletext.gameObject.SetActive(true);
  

        using (var fs = new StreamReader(directory + ".txt", System.Text.Encoding.GetEncoding("UTF-8")))
        {
            while (fs.Peek() != -1)
                singles.Add(fs.ReadLine());
        }


        //Singletext.text = singles[0];
        //Name.text = names[0];
    }

    public void loadcomand()
    {
        reload = false;
        if (TalkCOmmand.Instance.CommandCheck(singles[0]))
        {
            singles.RemoveAt(0);
        }
    }

    public void updatestext()
    {
        singles.RemoveAt(0);
        Singletext.text = singles[0];
    }

    public void updatestext4()
    {
        singles.RemoveAt(0);
        Singletext.text = "";
        Singletext.DOText(singles[0], 2).SetEase(Ease.OutQuart);
    }

    public void updatestext2()
    {
        singles.RemoveAt(0);
    }

    public void updatestext3()
    {
        Singletext.text = "";
        //Singletext.text = singles[0];

        Singletext.DOText(singles[0], 2).SetEase(Ease.OutQuart);

    }
    public void selectdoc()


    {
        if (singles[0] == "ActiveSelect")

        {
            Singletext.text = "";
            singles.RemoveAt(0);

            Singletext.gameObject.SetActive(false);

            playableDirector.Pause();
        }
    }

    public void puase()
    {
        pushbotton.gameObject.SetActive(true);
        pushbotton.DOColor(Color.black, 0.8f).SetLoops(-1, LoopType.Yoyo);
       // if (singles[0] != "endcontext")
            playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(0);
         //playableDirector.Pause();

    }

    public void skiptime(float times)
    {
        if (singles[0] != "endcontext")
            playableDirector.playableGraph.GetRootPlayable(0).SetTime(times);
    }

    public void SetselectdocA(string setA)
    {
        if (!reload)
            reload = true;
        else
            return;
        singles.Clear();
        Debug.Log(current);

        if (current == 1)
        {
            using (var fs = new StreamReader(setA + "1/" + current_direc + "-1.txt", System.Text.Encoding.GetEncoding("UTF-8")))
            {
                while (fs.Peek() != -1)
                    singles.Add(fs.ReadLine());
            }


        }
        else if (current == 0)
        {
            using (var fs = new StreamReader(setA + "2/" + current_direc + "-2.txt", System.Text.Encoding.GetEncoding("UTF-8")))
            {
                while (fs.Peek() != -1)
                    singles.Add(fs.ReadLine());
            }



            Debug.Log(singles[0]);
        }


        Singletext.text = singles[0];

    }

    public void SetselectdocC()
    {
        string setA;
        if (!reload)
            reload = true;
        else
            return;
        if (current == 1)
            setA = singles[2];
        else
            setA = singles[3];
        singles.Clear();

        Debug.Log(setA);
        if (current == 1)
        {

            using (var fs = new StreamReader(setA + "-1.txt", System.Text.Encoding.GetEncoding("UTF-8")))
            {
                while (fs.Peek() != -1)
                    singles.Add(fs.ReadLine());
            }



        }
        else if (current == 0)
        {

            using (var fs = new StreamReader(setA + "-2.txt", System.Text.Encoding.GetEncoding("UTF-8")))
            {
                while (fs.Peek() != -1)
                    singles.Add(fs.ReadLine());
            }



            Debug.Log(singles[0]);
        }
        Singletext.gameObject.SetActive(true);

        Singletext.text = singles[0];

    }


    public void SetselectdocB(string setA)
    {
        if (up)
        {
            using (var fs = new StreamReader(setA, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                while (fs.Peek() != -1)
                    singles.Add(fs.ReadLine());
            }


        }
    }




    // Update is called once per frame

}
