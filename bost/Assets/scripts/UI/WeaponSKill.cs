using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
[Serializable]
[CreateAssetMenu(fileName = "Skill", menuName = "Make_WeaponSkill")]
public class WeaponSKill : ScriptableObject
{
    public enum KindofWeapon
    {
        Slash,Lans,Hunmer
    }

    public enum Kindofskill
    {
        Passive,Active
    }

    public enum Combtype
    {
        First,midum,Finish
    }

    public enum KindofSkill
    {
       NewAttack,Attackplus,CombPlus
    }

    [SerializeField]
    private KindofWeapon kindofWeapon;



    [SerializeField]
    private Kindofskill kindofSkill;
    [SerializeField]
    private Combtype COMB;


    [SerializeField]
    private string Skillname;

    [SerializeField]
    private string Information;

    [SerializeField]
    private bool getflag;

    [SerializeField]
    private Image icon;

    [SerializeField]
    private int needpoint;

    [SerializeField]
    private int CombNumber;
    public Kindofskill GetKindofSkill()
    {
        return kindofSkill;
    }

    public KindofWeapon GetKindofWeapon()
    {
        return kindofWeapon;
    }

    public Combtype GetCOMB()
    {
        return COMB;
    }

    public string GetSKillname()
    {
        return Skillname;
    }
    public string GetSKillInfo()
    {
        return Information;
    }

    public int Getneedpoint()
    {
        return needpoint;
    }

    public int GetCcombnumber()
    {
        return CombNumber;
    }

    public Image GetIcon()
    {
        return icon;
    }

    public bool Getflag()
    {
        return getflag;
    }

    public void Setflag(bool Getflag)
    {
        getflag=Getflag;
    }
}
