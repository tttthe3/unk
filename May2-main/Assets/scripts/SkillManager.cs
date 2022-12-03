using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    static protected SkillManager s_SkillBase;
    static public SkillManager Instance { get { return s_SkillBase; } }

    public WeaponSKill[] Slash;
    public WeaponSKill[] Lans;
    public WeaponSKill[] Hunmer ;
    public List<WeaponSKill> Current = new List<WeaponSKill>();
    public List<Kama_Compo>  havelist_Comb = new List<Kama_Compo>();
    public int Skillpoint = 11;
    public Kama_Compo[] defaultslash;
    public Kama_Compo[] maf;
    public Kama_Compo[] special;
    public Kama_Compo[] chains;
    public Dictionary<string,Kama_Compo[]> list = new Dictionary<string, Kama_Compo[]>();  //slash mafrer special twinの各コンボセット　stringが一致するものをcurrentに設定したりする
    [SerializeField]
    private List<WeaponSKill> haveitemList = new List<WeaponSKill>();

    // Start is called before the first frame update
    void Start()
    {
        s_SkillBase = this;
        Debug.Log(Slash[0]);
        Skillpoint = 11;
        list.Add("defaultslash",defaultslash);
        list.Add("maf", maf);
        list.Add("chains", chains);
        list.Add("special", special);
    }
    public WeaponSKill GetSkill(string name)
    {
        int hitnumber = 0;

        if (haveitemList.Count == 0)
            return null;

        for(int i = 0; i < haveitemList.Count; i++)
        {
            if (haveitemList[i].GetSKillname() == name)
            {
                hitnumber = i;
                break;
            }
        }
        if (hitnumber == haveitemList.Count - 1)
        return null;

        return haveitemList[hitnumber];
        
    }

    public void Add_SkillList(WeaponSKill skill)
    {
        haveitemList.Add(skill);
    }

    public void GetCurrentSKill(WeaponSKill skill)
    {
        Current.Add(skill);
    }

    public void RemoveCurrentSKill(WeaponSKill skill)
    {
        Current.Remove(skill);
    }

    public void AddCombs(string Wazamei,Kama_Compo[] combset)
    {
        
        list.Add(Wazamei,combset);
    }

    public Kama_Compo[] GetCombs(string Wazamei)
    {
        list.TryGetValue(Wazamei, out Kama_Compo[] comb);

        return comb;
        
    }


    // Update is called once per frame
    public WeaponSKill GetSLash_SkillList(int number)
    {
        return Slash[number];
    }

    public WeaponSKill[] GetSLash_SkillLists()
    {
        return Slash;
    }

    public void SkillpointPlus()
    {
        Skillpoint++;
    }

    public void UseSkillpoint(int neddpoint)
    {
        Skillpoint = Skillpoint - neddpoint;
    }

    public int GetSkillpoint()
    {
        return Skillpoint;
    }
}
