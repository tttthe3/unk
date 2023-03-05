using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using DG.Tweening;
public class TimelineText_manager : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Singletext;
    public TextMeshProUGUI select1;
    public TextMeshProUGUI select2;
    public List<string> singles;
    public List<string> names;
    private string current_direc;
    public int current;
    private bool up;
    private bool reload=false;
    public Image pushbotton;
    public PlayableDirector playableDirector;
    private TimelineAsset Tracks;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (select1.gameObject.activeSelf && select2.gameObject.activeSelf)
        {
            if (Playerinput.Instance.Select_Vert.Value == -1)
            {
                current = 0;
                OnClickDown();

            }
            else if (Playerinput.Instance.Select_Vert.Value == 1)
            {
                current = 1;
                OnClickUp();

            }
            else if (Playerinput.Instance.Intract.Down)
            {
                OnClickChoice();
                playableDirector.Resume();
            }
        }

        if (playableDirector.state == PlayState.Paused && Playerinput.Instance.Intract.Down)
        {

            playableDirector.Resume();
            pushbotton.DOColor(Color.white, 0f);
            pushbotton.DOPause();
        }
    }

    public void OnClickUp()
    {
        select2.DOPause();
        select2.DOColor(Color.white, 0.1f); ;
        select1.DOColor(Color.black, 1f).SetLoops(-1, LoopType.Yoyo);


    }

    public void OnClickDown()
    {
        select1.DOPause();
        select1.DOColor(Color.white, 0.1f); ;
        select2.DOColor(Color.black, 1f).SetLoops(-1, LoopType.Yoyo);


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
        Name.gameObject.SetActive(true);

        using (var fs = new StreamReader(directory+".txt", System.Text.Encoding.GetEncoding("UTF-8")))
        {
            while (fs.Peek() != -1)
                singles.Add(fs.ReadLine());
        }

        using (var fs = new StreamReader(directory + "_Name.txt", System.Text.Encoding.GetEncoding("UTF-8")))
        {
            while (fs.Peek() != -1)
               names.Add(fs.ReadLine());
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
            names.RemoveAt(0);
        }
    }

    public void updatestext()
    {
        singles.RemoveAt(0);
        Singletext.text = singles[0];
        names.RemoveAt(0);
        Name.text = names[0];
    }

    public void updatestext2()
    {
        singles.RemoveAt(0);
        names.RemoveAt(0);
    }

    public void updatestext3()
    {
        Singletext.text = "";
        //Singletext.text = singles[0];
        Name.text = names[0];

        Singletext.DOText(singles[0], 2).SetEase(Ease.OutQuart);

    }
        public void selectdoc()

       
    {
        if (singles[0] == "ActiveSelect")

        {
            Singletext.text = "";
            singles.RemoveAt(0);
            names.RemoveAt(0); //１行消して選択肢表示
            select1.text = singles[0];
            select2.text = singles[1];

            select1.gameObject.SetActive(true);
            select2.gameObject.SetActive(true);
            Singletext.gameObject.SetActive(false);
            Name.gameObject.SetActive(false);
            playableDirector.Pause();
        }
    }

    public void puase()
    {
        pushbotton.gameObject.SetActive(true);
        pushbotton.DOColor(Color.black, 0.8f).SetLoops(-1, LoopType.Yoyo);
        if(singles[0]!="endcontext")
        playableDirector.Pause();
        
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
        names.Clear();
        Debug.Log(current);

        if (current==1)
        {
            using (var fs = new StreamReader(setA + "1/"+current_direc + "-1.txt", System.Text.Encoding.GetEncoding("UTF-8")))
            { 
                while (fs.Peek() != -1)
                    singles.Add(fs.ReadLine());
            }

            using (var fs = new StreamReader(setA + "1/" + current_direc + "-1_Name.txt", System.Text.Encoding.GetEncoding("UTF-8")))
            {
                while (fs.Peek() != -1)
                    names.Add(fs.ReadLine());
            }

 
        }
        else if (current == 0)
        {
            using (var fs = new StreamReader(setA + "2/" + current_direc + "-2.txt", System.Text.Encoding.GetEncoding("UTF-8")))
            {
                while (fs.Peek() != -1)
                    singles.Add(fs.ReadLine());
            }

            using (var fs = new StreamReader(setA + "2/" + current_direc + "-2_Name.txt", System.Text.Encoding.GetEncoding("UTF-8")))
            {
                while (fs.Peek() != -1)
                    names.Add(fs.ReadLine());
            }

            Debug.Log(singles[0]);
        }


        Singletext.text = singles[0]; 
        Name.text = names[0];
    }

    public void SetselectdocC()
    {
        string setA;
        if (!reload)
            reload = true;
        else
            return;
        if(current==1)
         setA = singles[2] ;
        else
          setA = singles[3];
        singles.Clear();
        names.Clear();
        Debug.Log(setA);
        if (current == 1)
        {
            
            using (var fs = new StreamReader(setA + "-1.txt", System.Text.Encoding.GetEncoding("UTF-8")))
            {
                while (fs.Peek() != -1)
                    singles.Add(fs.ReadLine());
            }

            using (var fs = new StreamReader(setA  + "-1_Name.txt", System.Text.Encoding.GetEncoding("UTF-8")))
            {
                while (fs.Peek() != -1)
                    names.Add(fs.ReadLine());
            }


        }
        else if (current == 0)
        {
           
            using (var fs = new StreamReader(setA + "-2.txt", System.Text.Encoding.GetEncoding("UTF-8")))
            {
                while (fs.Peek() != -1)
                    singles.Add(fs.ReadLine());
            }

            using (var fs = new StreamReader(setA  + "-2_Name.txt", System.Text.Encoding.GetEncoding("UTF-8")))
            {
                while (fs.Peek() != -1)
                    names.Add(fs.ReadLine());
            }

            Debug.Log(singles[0]);
        }
        select1.gameObject.SetActive(false);
        select2.gameObject.SetActive(false);
        Singletext.gameObject.SetActive(true);
        Name.gameObject.SetActive(true);

        Singletext.text = singles[0];
        Name.text = names[0];
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

            using (var fs = new StreamReader(setA, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                while (fs.Peek() != -1)
                    names.Add(fs.ReadLine());
            }
        }
    }



    public void Textload_Slect1(string directory)
    {
        using (var fs = new StreamReader(directory, System.Text.Encoding.GetEncoding("UTF-8")))
        {
            while (fs.Peek() != -1)
                select1.text = fs.ReadLine();
        }
    }
    public void Textload_Slect2(string directory)
    {
        using (var fs = new StreamReader(directory, System.Text.Encoding.GetEncoding("UTF-8")))
        {
            while (fs.Peek() != -1)
                select2.text = fs.ReadLine();
        }
    }

    // Update is called once per frame
    
}
