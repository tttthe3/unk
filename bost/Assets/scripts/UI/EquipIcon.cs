using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
using TMPro;
public class EquipIcon : MonoBehaviour
{
    public enum ItemHave { Have, None, Can }
    public enum Icontyepe { Main,Special,Sub}
    public ItemHave itemhave = ItemHave.None;
    public Icontyepe C_icontype = Icontyepe.Main;
    public Image currenticon;
    public GameObject lefticon;
    public GameObject righticon;
    public GameObject upicon;
    public GameObject downicon;
    public WeaponSKill skill;
    public CreateItem Itemdata;
    public WeaponSKill triggerskill;
    public string skillname;
    public Image selfImage;
    public GameObject myskilltree;
        private void OnEnable()
        {
        if(ItemDataBase.Instance.HasItem(skillname))
            if (C_icontype == Icontyepe.Sub)
            {
                Debug.Log("find");
                currenticon.sprite = ItemDataBase.Instance.GetItemData(skillname).GetSprite();
            }
            //トリガーとなるスキルを持ってたら色は変えないが選択可能にする。ポイントの質問が出る
            //currenticon= skill.GetIcon();
           // if (triggerskill.Getflag())
            {
              //  itemhave = ItemHave.Can;
              //  selfImage = triggerskill.GetIcon();
            }
        }

    public ItemHave GetIconstate()
    {
        return itemhave;
    }

    public Icontyepe GetIcontypee()
    {
        return C_icontype;
    }

    public GameObject Getlefticon()
    {

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

    public GameObject Getskilltree()
    {

        return myskilltree;
    }


    public WeaponSKill Getskill()
    {
        return skill;
    }

    public WeaponSKill Gettriggerskill()
    {
        return triggerskill;
    }

    public string Getskillnamel()
    {
        return skillname;
    }
}
