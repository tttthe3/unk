using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class skillicon : MonoBehaviour
{
    //メニュー画面上でcurrentのアイコンのこのクラスを取得してItemhaveを見る

    public enum ItemHave { Have, None ,Can}
    public ItemHave itemhave = ItemHave.None;
    public Image currenticon;
    public GameObject lefticon;
    public GameObject righticon;
    public GameObject upicon;
    public GameObject downicon;
    public WeaponSKill skill;
    public WeaponSKill triggerskill;
    public string skillname;
    // Start is called before the first frame update
    private void OnEnable()
    {
        //トリガーとなるスキルを持ってたら色は変えないが選択可能にする。ポイントの質問が出る
        //currenticon= skill.GetIcon();
        if (triggerskill.Getflag())
        {
            itemhave = ItemHave.Can;
        }
    }

    public ItemHave GetIconstate()
    {
        return itemhave;
    }

    public GameObject Getlefticon() {

        return lefticon;
    }
    public GameObject Getrighticon()
    {

        return righticon;
    }
    public GameObject Getdownicon()
    {

        return downicon;
    }
    public GameObject Getupicon()
    {

        return upicon;
    }


    public WeaponSKill Getskill()
    {
        return skill;
    }

    public WeaponSKill Gettriggerskill()
    {
        return triggerskill;
    }
}
