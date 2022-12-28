using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
using TMPro;
public class Weapon_Config : MonoBehaviour
{

    private GameObject[] Icons;
    [SerializeField]
    GameObject[] ItemIcon;
    private enum Iconstate { Weapon, skill };
    public enum States { None, Mainset, Subset, Skilltree }
    public States states;
    Iconstate iconstate;
    int nowcolum = 0;
    int nowrow = 0;
    [SerializeField]
    GameObject Slash;

    [SerializeField]
    GameObject Lans;

    [SerializeField]
    GameObject Gunmer;

    [SerializeField]
    GameObject Configpanel;
    private int cout = 0;
    private int cout1 = 0;
    public GameObject currentselect;
    public GameObject firstselect;
    public GameObject currentMainselect;
    public GameObject MaiselectText_Choice;
    public GameObject MaiselectText_Skilltree;
    private Transform defpos;
    public GameObject Slector_Main;
    public GameObject Slector_Sub;
    public GameObject currentSubselect;
    public GameObject SubselectText_Left;
    public GameObject SubselectText_Right;

    public GameObject current_Skilltree;

   

    private void Start()
    {
        states = States.None;
        currentselect = firstselect;
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        currentselect = firstselect;

    }

    // Update is called once per frame
    void Update()
    {

        //if (!currentselect.GetComponent<EquipIcon>().Getskilltree().activeSelf&&states==States.Skilltree)
           // states = States.None;

        if (Playerinput.Instance.Select_Hoz.Value == 1 && cout1 == 0)
        {
            cout1 = 1;
            OnClickRight();

        }
        else if (Playerinput.Instance.Select_Hoz.Value < 0 && cout1 == 0)
        {
            cout1 = 1;
            OnClickLeft();
        }
        else if (Playerinput.Instance.Select_Vert.Value == 1 && cout == 0)
        {
            cout = 1;
            OnClickUp();

        }
        else if (Playerinput.Instance.Select_Vert.Value < 0 && cout == 0)
        {
            cout = 1;
            OnClickDown();
        }
         if (Playerinput.Instance.Skill.Down)
        {
            OnClickChoice();
        }

        if (Playerinput.Instance.Skill2.Down)
        {
            Reset2();
        }
        if(Playerinput.Instance.Select_Vert.Value == 0)
            cout = 0;
        if (Playerinput.Instance.Select_Hoz.Value == 0)
            cout1 = 0;

        Debug.Log(states);
    }

    private void GetAllChildObject(GameObject parents)
    {
        Icons = new GameObject[parents.transform.childCount-1];

        for (int i = 0; i < parents.transform.childCount-1; i++)
        {
            Icons[i] = parents.transform.GetChild(i).gameObject;
        }


    }

    public void OnClickUp()
    {
        if (states == States.None)
        {
            if (currentselect.GetComponent<EquipIcon>().Getupicon() == null)
                return;
            currentselect.GetComponent<Image>().DOPause();
            currentselect.GetComponent<Image>().DOColor(Color.white, 0f);
            currentselect = currentselect.GetComponent<EquipIcon>().Getupicon();

            currentselect.GetComponent<Image>().DOPause();
            currentselect.GetComponent<Image>().DOColor(Color.white, 0.1f);
            defpos = currentselect.transform;
            currentselect.GetComponent<Image>().DOColor(Color.black, 0.4f).SetLoops(-1, LoopType.Yoyo);
        }
        if (states == States.Mainset) 
        {
            currentMainselect.transform.position = MaiselectText_Choice.transform.position;

        }
        else if (states == States.Subset)
        {
            currentSubselect.transform.position = SubselectText_Right.transform.position;
        }
        cout = 1;
    }

    public void OnClickDown()
    {
        if (states == States.None)
        {
            if (currentselect.GetComponent<EquipIcon>().Getdownicon() == null)
                return;
            currentselect.GetComponent<Image>().DOPause();
            currentselect.GetComponent<Image>().DOColor(Color.white, 0f);
            currentselect = currentselect.GetComponent<EquipIcon>().Getdownicon();

            currentselect.GetComponent<Image>().DOPause();
            currentselect.GetComponent<Image>().DOColor(Color.white, 0.1f);
            defpos = currentselect.transform;
            currentselect.GetComponent<Image>().DOColor(Color.black, 0.4f).SetLoops(-1, LoopType.Yoyo);

        }
        if (states == States.Mainset)
        {
            currentMainselect.transform.position = MaiselectText_Skilltree.transform.position;

        }
        else if (states == States.Subset)
        {
            currentSubselect.transform.position = SubselectText_Left.transform.position;
        }
        cout = 1;

    }

    public void OnClickRight()
    {
        if (states == States.None)
        {
            if (currentselect.GetComponent<EquipIcon>().Getrighticon() == null)
                return;
            currentselect.GetComponent<Image>().DOPause();
            currentselect.GetComponent<Image>().DOColor(Color.white, 0f);
            currentselect = currentselect.GetComponent<EquipIcon>().Getrighticon();

            currentselect.GetComponent<Image>().DOPause();
            currentselect.GetComponent<Image>().DOColor(Color.white, 0.1f);
            defpos = currentselect.transform;
            currentselect.GetComponent<Image>().DOColor(Color.black, 0.4f).SetLoops(-1, LoopType.Yoyo);


            cout1 = 1;
        }
    }

    public void OnClickLeft()
    {
        if (states == States.None)
        {
            if (currentselect.GetComponent<EquipIcon>().Getlefticon() == null)
                return;
            currentselect.GetComponent<Image>().DOPause();
            currentselect.GetComponent<Image>().DOColor(Color.white, 0f);
            currentselect = currentselect.GetComponent<EquipIcon>().Getlefticon();

            currentselect.GetComponent<Image>().DOPause();
            currentselect.GetComponent<Image>().DOColor(Color.white, 0.1f);
            defpos = currentselect.transform;
            currentselect.GetComponent<Image>().DOColor(Color.black, 0.4f).SetLoops(-1, LoopType.Yoyo);


            cout1 = 1;
        }
    }

    //SCがONになっている＆スキルボックス全リストのうち、使うものを上書きする（差し替えは面倒）ゲームロード時はSCの装備有無を確認してから、並べ替え捜査にかける
    public void OnClickChoice() //トリガースキルの状態のみ管理　残りポイントを見てcurrentkamaに追加する　各スキルのnextattacknameを変更する　SCの更新のみkamapの野良べ替えはattackwrapper
    {
        if (states == States.None)
        {
            if (currentselect.GetComponent<EquipIcon>().GetIcontypee() == EquipIcon.Icontyepe.Main)
            {
                 Slector_Main.transform.position = currentselect.transform.position;
                 Slector_Main.SetActive(true);
                 states = States.Mainset;
                currentMainselect.transform.position = MaiselectText_Choice.transform.position;
                Debug.Log("weapon");
                return;

            }
            if(currentselect.GetComponent<EquipIcon>().GetIcontypee() == EquipIcon.Icontyepe.Sub)
            {
                Slector_Sub.transform.position = currentselect.transform.position;
                Slector_Sub.SetActive(true);
                states = States.Subset;
                currentSubselect.transform.position = SubselectText_Left.transform.position;
                return;
            }

        }
        if(states == States.Mainset)
        {
            if(currentMainselect.transform.position == MaiselectText_Choice.transform.position)
            {
                //アタックセット
                AttackWrapper.Instance.WeaponSetter(currentselect.GetComponent<EquipIcon>().Getskillnamel());
                states = States.None;
                Debug.Log("weapon");
                 Slector_Main.SetActive(false);
            }

            if (currentMainselect.transform.position == MaiselectText_Skilltree.transform.position)
            {
                //スキルツリー開く
                currentselect.GetComponent<EquipIcon>().Getskilltree().SetActive(true);
                states = States.Skilltree;
                this.gameObject.SetActive(false);
            }
        }
        if(states == States.Subset)
        {
            if (currentSubselect.transform.position == SubselectText_Left.transform.position)
            {
                ItemUseManager.Instance.WeaponLeftSetter(currentselect.GetComponent<EquipIcon>().Getskillnamel());
                states = States.None;
               
                Slector_Main.SetActive(false);
            }

            if (currentSubselect.transform.position == SubselectText_Right.transform.position)
            {
                //アタックセット
                ItemUseManager.Instance.WeaponrightSetter(currentselect.GetComponent<EquipIcon>().Getskillnamel());
                states = States.None;
               
                Slector_Main.SetActive(false);
            }

        }

    }

    

    void fadeout(int rest)
    {

        for (int i = 0; i < ItemIcon.Length; i++)
        {

            ItemIcon[i].GetComponent<TextMeshProUGUI>().DOFade(0f, 1f);



        }

    }

    private void OnDisable()
    {
        //ItemIcon[nowcolum].GetComponent<Image>().DOPause();
        //Icons[nowrow].GetComponent<Image>().DOPause();
        nowcolum = 0;
        nowrow=0;
        iconstate =Iconstate.Weapon;
        currentMainselect.SetActive(false);

    }

    public void Reset2()
    {
        if (states == States.None)
        {
            this.gameObject.SetActive(false);
            return;


        }
        if (states == States.Mainset)
        {
           
                Slector_Main.SetActive(false);
                states = States.None;
                return;
        }

           
        
        if (states == States.Skilltree)
        {
            currentselect.GetComponent<EquipIcon>().Getskilltree().SetActive(false) ;
            states = States.None;
        }

    }

    public void Reset()
    {
        if (iconstate == Iconstate.Weapon && StartMenu.menuInstance.Getcursolreturn() == StartMenu.cursolstate.sleep) {
            StartMenu.menuInstance.OnReset();
            return;
        }

        if(iconstate == Iconstate.skill)
        {
            ItemIcon[nowcolum].transform.DOMoveX(ItemIcon[nowcolum].transform.position.x + 90f, 0.2f);
            Icons[nowrow].GetComponent<Image>().DOPause();
            Icons[nowrow].GetComponent<Image>().DOColor(Color.white, 0f);
            nowrow = 0;
            iconstate = Iconstate.Weapon;
        }
        
    }

}
