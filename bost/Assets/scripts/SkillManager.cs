﻿using System.Collections;
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
    public Kama_Compo[] Lances;

    public Kama_Compo[] air_defaultslash;
    public Kama_Compo[] air_maf;
    public Kama_Compo[] air_special;
    public Kama_Compo[] air_chains;
    public Kama_Compo[] air_Lances;

    public Kama_Compo[] power_defaultslash;
    public Kama_Compo[] power_maf;
    public Kama_Compo[] power_special;
    public Kama_Compo[] power_chains;
    public Kama_Compo[] power_Lances;

    public Dictionary<string,Kama_Compo[]> list = new Dictionary<string, Kama_Compo[]>();  //slash mafrer special twinの各コンボセット　stringが一致するものをcurrentに設定したりする
    public Dictionary<string, Kama_Compo[]> air_list = new Dictionary<string, Kama_Compo[]>();
    public Dictionary<string, Kama_Compo[]> special_list = new Dictionary<string, Kama_Compo[]>();
    [SerializeField]
    private List<WeaponSKill> haveitemList = new List<WeaponSKill>();

    // Start is called before the first frame update
    void Start()
    {
        s_SkillBase = this;
        Skillpoint = 11;
        list.Add("defaultslash",defaultslash);
        list.Add("maf", maf);
        list.Add("knife", chains);
        list.Add("special", special);
        list.Add("Lances", Lances);

        air_list.Add("defaultslash", air_defaultslash);
        air_list.Add("maf", air_maf);
        air_list.Add("knife", air_chains);
        air_list.Add("special", air_special);
        air_list.Add("Lances", air_Lances);

        special_list.Add("defaultslash", power_defaultslash);
        special_list.Add("maf", power_maf);
        special_list.Add("knife", chains);
        special_list.Add("special", power_chains);
        special_list.Add("Lances", power_Lances);
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

    public Kama_Compo[] air_GetCombs(string Wazamei)
    {
        air_list.TryGetValue(Wazamei, out Kama_Compo[] comb);

        return comb;

    }

    public Kama_Compo[] special_GetCombs(string Wazamei)
    {
        special_list.TryGetValue(Wazamei, out Kama_Compo[] comb);

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
