using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.Events;
public class skilltree_Controller : MonoBehaviour
{
    private GameObject[] Icons;
    [SerializeField]
    GameObject[] ItemIcon;
    public enum Getskillselect { Choose, Select };
    public Getskillselect skillselect;
    private int cout = 0;
    private int cout1 = 0;
    public GameObject firstselect;
    public GameObject currentselect;
    public Image NGpanel;
    public Image OKpanel;
    int inputcount = 0;
    float timer = 0f;
    public TextMeshProUGUI Skillname;
    public TextMeshProUGUI Skillinfo;
    public UnityEvent holdstart;
    public UnityEvent holdend;
    int i = 0;
    private bool inputon = false;
    private bool duringmovie = false;
    private Transform defpos;
    public Gradient COLORS;
    public Image pickskill;
    private Image skillmove;

    public AudioSource getaudio;
    public AudioSource moves;
    public AudioSource cantget;

    public GameObject EqiipCOnfig;
    // Start is called before the first frame update
    void Start()
    {
        
        currentselect = firstselect;
        currentselect.GetComponent<Image>().DOColor(Color.black, 1f).SetLoops(-1, LoopType.Yoyo);
        defpos = currentselect.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Playerinput.Instance.Select_Hoz.Value == 1 && cout1 == 0)
        {
            cout1 = 1;
            timer = 0f;
            i = 0;
            OnClickRight();

        }
        else if (Playerinput.Instance.Select_Hoz.Value < 0 && cout1 == 0)
        {
            cout1 = 1;
            timer = 0f;
            i = 0;
            OnClickLeft();
        }

        if (Playerinput.Instance.Select_Vert.Value == 1 && cout1 == 0)
        {
            cout1 = 1;
            timer = 0f;
            i = 0;
            OnClickRight();

        }
        else if (Playerinput.Instance.Select_Vert.Value  < 0 && cout1 == 0)
        {
            cout1 = 1;
            timer = 0f;
            i = 0;
            OnClickLeft();
        }

        else if (Playerinput.Instance.Skill.Held)
        {
             OnClickChoice();
        }
        if (Playerinput.Instance.Skill.Down)
        {
            currentselect.GetComponent<Image>().DOPause();
            if (!currentselect.GetComponent<skillicon>().Getskill().Getflag())
            {
                pickskill.gameObject.transform.position = currentselect.transform.position;
                pickskill.gameObject.SetActive(true);
            }
            inputon = true;
        }

        if (Playerinput.Instance.Skill.Up)
        {
            
            //currentselect.GetComponent<Image>().DOColor(Color.black, 0.4f).SetLoops(-1, LoopType.Yoyo);
            inputon = false;
        }
        if (Playerinput.Instance.Skill2.Down && inputcount == 0)
        {
            Reset();
        }
        if (Playerinput.Instance.Select_Vert.Value == 0)
            cout = 0;
        if (Playerinput.Instance.Select_Hoz.Value == 0)
            cout1 = 0;

        if (Playerinput.Instance.Skill2.Down)
        {
            EqiipCOnfig.SetActive(true);
            this.gameObject.SetActive(false);
        }

        skillinfo();
        Debug.Log(inputon);
        Debug.Log(duringmovie);
    }

    public void inputFIX()
    {
        Playerinput.Instance.Select_Hoz.ReleaseControl(true);
        Playerinput.Instance.Select_Vert.ReleaseControl(true);
    }

    public void inputOPEN()
    {
        Playerinput.Instance.Select_Hoz.GainControl();
        Playerinput.Instance.Select_Vert.GainControl();
    }


    public void OnClickLeft()
    {
        moves.Play();
        if (currentselect.GetComponent<skillicon>().Getlefticon() == null)
            return;
       
            currentselect.GetComponent<Image>().DOPause();
            currentselect = currentselect.GetComponent<skillicon>().Getlefticon();
        if (!currentselect.GetComponent<skillicon>().Getskill().Getflag())
        {
            currentselect.GetComponent<Image>().DOPause();
            currentselect.GetComponent<Image>().DOColor(Color.white, 0.1f);
            defpos = currentselect.transform;
            currentselect.GetComponent<Image>().DOColor(Color.black, 0.4f).SetLoops(-1, LoopType.Yoyo);
        }
        else {
            
            currentselect.GetComponent<Image>().DOColor(Color.red, 0.1f);

        }
        cout1 = 1;
    }

    public void OnClickRight()
    {
        moves.Play();
        if (currentselect.GetComponent<skillicon>().Getrighticon() == null)
            return;
        currentselect.GetComponent<Image>().DOPause();
        currentselect = currentselect.GetComponent<skillicon>().Getrighticon();
        if (!currentselect.GetComponent<skillicon>().Getskill().Getflag())
        {
            currentselect.GetComponent<Image>().DOPause();
            currentselect.GetComponent<Image>().DOColor(Color.white, 0.1f);
            defpos = currentselect.transform;
            currentselect.GetComponent<Image>().DOColor(Color.black, 0.4f).SetLoops(-1, LoopType.Yoyo);
        }
        else
        {
            currentselect.GetComponent<Image>().DOColor(Color.red, 0.1f);
        }
        cout1 = 1;
    }

    public void OnClickup()
    {
        moves.Play();
        if (currentselect.GetComponent<skillicon>().Getupicon() == null)
            return;
        currentselect.GetComponent<Image>().DOPause();
        currentselect = currentselect.GetComponent<skillicon>().Getupicon();

        currentselect.GetComponent<Image>().DOPause();
        currentselect.GetComponent<Image>().DOColor(Color.white, 0.1f);
        defpos = currentselect.transform;
        currentselect.GetComponent<Image>().DOColor(Color.black, 0.4f).SetLoops(-1, LoopType.Yoyo);
        cout1 = 1;
    }

    public void OnClickdown()
    {
        moves.Play();
        if (currentselect.GetComponent<skillicon>().Getdownicon() == null)
            return;
        currentselect.GetComponent<Image>().DOPause();
        currentselect = currentselect.GetComponent<skillicon>().Getdownicon();

        currentselect.GetComponent<Image>().DOPause();
        currentselect.GetComponent<Image>().DOColor(Color.white, 0.1f);
        defpos = currentselect.transform;
        currentselect.GetComponent<Image>().DOColor(Color.black, 0.4f).SetLoops(-1, LoopType.Yoyo);
        cout1 = 1;
    }
    public void OnClickChoice()
    {
        if (SkillManager.Instance.GetSkillpoint() < currentselect.GetComponent<skillicon>().Getskill().Getneedpoint()){
            cantget.Play();
            return;
        }
            if (SkillManager.Instance.GetSkillpoint() > currentselect.GetComponent<skillicon>().Getskill().Getneedpoint() && currentselect.GetComponent<skillicon>().Gettriggerskill().Getflag()&& !currentselect.GetComponent<skillicon>().Getskill().Getflag())
            {
            if (inputon || duringmovie)
                holdstart.Invoke();

            if (Playerinput.Instance.Skill.Held)
            {
                timer += Time.deltaTime;
                if (!duringmovie)
                {
                    pickskill.transform.position = currentselect.transform.position;
                   pickskill.transform.localScale = new Vector3(pickskill.transform.localScale.x + Time.unscaledDeltaTime * 1f, pickskill.transform.localScale.y + Time.unscaledDeltaTime * 1f, 1);
                }
                if (pickskill.transform.localScale.x>1.5)
                {
                    pickskill.gameObject.SetActive(false);
                    pickskill.transform.localScale = new Vector3(0.2f, 0.2f, 1);
                    currentselect.GetComponent<skillicon>().Getskill().Setflag(true); //スキル取得フラグを立てる（貯前スキルとってるかの確認）
                    DelaySetMovement2();
                    SkillManager.Instance.UseSkillpoint(currentselect.GetComponent<skillicon>().Getskill().Getneedpoint());
                    Debug.Log(SkillManager.Instance.GetSkillpoint());
                    timer = 0;
                   
                    return;
                }
                inputOPEN();
                return;
            }
          
            timer = 0f;
            i = 0;
            }
        timer = 0f;
        i = 0;

    }

    public void Reset()
    {
        inputcount++;

        if (skillselect == Getskillselect.Select)
        {
            if (NGpanel.gameObject.activeSelf)
            {
                NGpanel.gameObject.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f);
                NGpanel.gameObject.SetActive(false);
                skillselect = Getskillselect.Choose;
            }

            if (OKpanel.gameObject.activeSelf)
            {
                OKpanel.gameObject.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f);
                OKpanel.gameObject.SetActive(false);
                skillselect = Getskillselect.Choose;
            }
        }

            else 
        {
            //this.gameObject.SetActive(false);
            return;
        }


    }

    public void DelaySetMovement()
    {
        Debug.Log("eeee");
        //DOVirtual.DelayedCall(delay, () => SetMovement(newMovement), false);
        var tween1 = currentselect.transform.DOShakePosition(2f,33,30,1,false,false);
        var tween2 = DOVirtual.DelayedCall(0f,()=>setmovietrigger(false),false);
        var tween4 = DOVirtual.DelayedCall(0f, () => setmovietrigger(true), false);
        var tween5 = DOVirtual.DelayedCall(0f, () => inputOPEN(), false);
        //var tween6 = DOVirtual.DelayedCall(0f, () => setcolortomove(), false);
        // var tween2 = currentselect.transform.DOLocalMove(new Vector3(0f, 2f, 0f) + rb2d.transform.position, 0.2f);
        var tween3 = currentselect.GetComponent<Image>().DOColor(Color.green, 2f);
        DOTween.Sequence().Append(tween2).Append(tween1).Join(tween3).SetDelay(3).Append(tween4).Append(tween5);
    }

    public void DelaySetMovement2()
    {

        DOTween.Sequence().Append(DOVirtual.DelayedCall(0f, () => setmovietrigger(true), false))
                          //.Join(currentselect.transform.DOShakePosition(2f, 30, 30, 0, false, true))
                          .Join(currentselect.GetComponent<Image>().DOGradientColor(COLORS, 2f))
                          .Join(currentselect.transform.DOScale(new Vector3(2.5f, 2.5f, 1f), 0.2f))
                          .Join(DOVirtual.DelayedCall(0f, () => playsound(getaudio), false))
                          .SetDelay(0.3f)
                          .Append(currentselect.transform.DOScale(new Vector3(1.6f, 1.6f, 1f),2f))
                          .Append(DOVirtual.DelayedCall(0f, () => setmovietrigger(false), false))
                          .Append(DOVirtual.DelayedCall(0f, () => inputOPEN(), false));
    }

    public void setmovietrigger(bool trigger)
    {
        duringmovie = trigger;
    }

    public void playsound(AudioSource source)
    {
        source.Play();
    }

    public void setcolortomove()
    {
        currentselect.transform.DOShakePosition(2f, 33, 10, 1, false, false);
        currentselect.GetComponent<Image>().DOColor(Color.green, 4f);
    }

    public void skillinfo()
    {
        if (currentselect.GetComponent<skillicon>().Getskill().Getflag())
        {
            Skillinfo.text = "取得済";
            return;
        }
        if (SkillManager.Instance.GetSkillpoint() > currentselect.GetComponent<skillicon>().Getskill().Getneedpoint() && currentselect.GetComponent<skillicon>().Gettriggerskill().Getflag())
        {
            Skillinfo.text = "長押しで取得";
            return;
        }
        if (SkillManager.Instance.GetSkillpoint() < currentselect.GetComponent<skillicon>().Getskill().Getneedpoint() && currentselect.GetComponent<skillicon>().Gettriggerskill().Getflag())
        {
            Skillinfo.text = "ポイント不足";
            return;
        }
        if ( !currentselect.GetComponent<skillicon>().Gettriggerskill().Getflag())
        {
            Skillinfo.text = "取得不可";
            return;
        }
        
    }
}
