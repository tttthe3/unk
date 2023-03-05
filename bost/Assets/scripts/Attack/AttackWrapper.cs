using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
public class AttackWrapper : MonoBehaviour
{


    public enum Itemset {slash,lance,hummer,none }; //これをプレイヤーに八つける。colidも使用できる
    public Itemset set;
    private int NowLevel;
    private Lans1 lans = new Lans1();
    private  CreateItem currentitem;
    private  AttackWrapper curretAttack; //丸ごと保存できるか後で検証
    private AttackWrapper curretAttack_Gun;
    public AttackWrapper[] Weapons;
    public string leftitem;
    public string rightitem;

    static public AttackWrapper Instance { get { return s_attack; } }
    static protected AttackWrapper s_attack;

    private  void Awake()
    {
        s_attack = this;

        Debug.Log("nazo");
        set = Itemset.none;
        
        //if(curretAttack==null)
            //curretAttack = Weapons[0];
    }

      void Start()
    {
        if (curretAttack_Gun == null)
            curretAttack_Gun = Weapons[1];
        //damaegeg.enabled = false;
    }
    public void WeaponSetter(string ItemName)
    {

        if (curretAttack_Gun == null)
            curretAttack_Gun = Weapons[1];

        // for (int i = 0; i < Weapons.Length; i++)
        // {
        //     if (Weapons[i].WeaponName == ItemName)
        //     {
        //     if (!ItemDataBase.Instance.HasItem(ItemName))
        //        return;
        if (curretAttack == null)
            curretAttack = Weapons[0]; //ここでdamagerとる
                 curretAttack.GetComponent<Kama_Compo>().slashself = SkillManager.Instance.GetCombs(ItemName);
                 curretAttack.GetComponent<Kama_Compo>().air_slashself = SkillManager.Instance.air_GetCombs(ItemName);
                 curretAttack.GetComponent<Kama_Compo>().Power_slashself = SkillManager.Instance.special_GetCombs(ItemName);

  
//    }

        //  }

        Debug.Log(curretAttack.GetComponent<Kama_Compo>().slashself);
        Debug.Log(SkillManager.Instance.GetCombs(ItemName));
        Debug.Log(ItemDataBase.Instance.HasItem(ItemName));
    }

    public void SetSeprical_defaultattack(string name)
    {
       // curretAttack.GetComponent<Kama_Compo>().SetComponent();

        for (int i = 0; i < curretAttack.GetComponent<Kama_Compo>().slashself.Length; i++)
        {
            if (curretAttack.GetComponent<Kama_Compo>().slashself[i].selfname == name)
            {
                curretAttack.GetComponent<Kama_Compo>().slashself[0] = null;
                curretAttack.GetComponent<Kama_Compo>().slashself[0] = curretAttack.GetComponent<Kama_Compo>().slashself[i];
                return;
            }
        }
    }
    public void SetSeprical_Reset(string name)
    {
        Debug.Log(curretAttack.GetComponent<Kama_Compo>().slashself[0].name);
        curretAttack.GetComponent<Kama_Compo>().SetComponent2();
       // setleftitem();
       // setrightitem();
       // for (int i = 0; i < curretAttack.GetComponent<Kama_Compo>().slashself.Length; i++)
       // {
       //    Debug.Log(curretAttack.GetComponent<Kama_Compo>().slashself[0].name);
       //    if (curretAttack.GetComponent<Kama_Compo>().slashself[i].selfname == name)
       //  {
       //      
       //      curretAttack.GetComponent<Kama_Compo>().slashself[0] = curretAttack.GetComponent<Kama_Compo>().slashself[i];
       //     return;
       // }
       // }
    }

    public void setleftitem_name(string name)
    {
        if (leftitem == null)
            leftitem = "default_slash";
        else
            leftitem = name;
        Debug.Log(leftitem);
    }
    public void setrightitem_name(string name)
    {
        if (rightitem == null)
            rightitem = "default_slash";
        else
            rightitem = name;
        Debug.Log(rightitem);
    }
    public string getleftitem_name()
    {
        return leftitem;
    }

    public string getrightitem_name()
    {
        return rightitem;
    }

    public void setleftitem()
    {
        curretAttack.GetComponent<Kama_Compo>().slashself = SkillManager.Instance.GetCombs(leftitem);
        curretAttack.GetComponent<Kama_Compo>().air_slashself = SkillManager.Instance.air_GetCombs(leftitem);
        curretAttack.GetComponent<Kama_Compo>().special_slashself = SkillManager.Instance.special_GetCombs(leftitem);
    }
    public void setrightitem()
    {
        Debug.Log(rightitem);
        curretAttack.GetComponent<Kama_Compo>().slashself = SkillManager.Instance.GetCombs(rightitem);
        curretAttack.GetComponent<Kama_Compo>().air_slashself = SkillManager.Instance.air_GetCombs(rightitem);
        curretAttack.GetComponent<Kama_Compo>().special_slashself = SkillManager.Instance.special_GetCombs(rightitem);
    }

    public string getleftitem_name0()
    {
       return   curretAttack.GetComponent<Kama_Compo>().slashself[0].selfname;
    }


    //ファーストアタックならslashself[0]を差し替え、2~4撃目ならコンボ増加数を見てupdatestate内の名前を書き換える＆slashselfの順番を変更する　フィニッシュならコンボ数＝に代入



    public Itemset ouptputstate()
    {
        return set;
    }
    public void firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent,SkeletonAnimation skeltonAnimation) {

        curretAttack.Firstframe(rb2d,  newHorizontalMovement,  animator,  parent,skeltonAnimation);
        
    }
    public void updateframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation) {
        if (curretAttack == null)
            return;
        curretAttack.Updateframe (rb2d, newHorizontalMovement,  animator,  parent, skeletonAnimation);
    }

    public void endframe(Animator animator) {
        if (curretAttack == null)
            return;
        curretAttack.EndFrame(animator);
    }

    public void firstframe_gun(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeltonAnimation)
    {

        curretAttack_Gun.Firstframe(rb2d, newHorizontalMovement, animator, parent, skeltonAnimation);

    }
    public void updateframe_gun(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {
        if (curretAttack_Gun == null)
            return;
        curretAttack_Gun.Updateframe(rb2d, newHorizontalMovement, animator, parent, skeletonAnimation);
    }

    public void endframe_gun(Animator animator)
    {
        if (curretAttack == null)
            return;
        curretAttack_Gun.EndFrame(animator);
    }


    public void special_firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, int set, Transform parent, SkeletonAnimation skeletonAnimation)
    {
        if (curretAttack == null)
            return;
        curretAttack.Special_Firstframe( rb2d,  newHorizontalMovement,  animator,  set, parent, skeletonAnimation);
    }

    public void special_updateframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {
        curretAttack.Special_Updateframe( rb2d,  newHorizontalMovement,animator, parent,  skeletonAnimation);
    }

    public void Air_firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, int set, Transform parent,SkeletonAnimation skeletonAnimation)
    {
        Debug.Log(curretAttack);
       // if (curretAttack == null)
          //  return;
        curretAttack.Air_Firstframe(rb2d,  newHorizontalMovement,  animator,  set, parent, skeletonAnimation);
    }

    public void Air_updateframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent)
    {
        Debug.Log(curretAttack);
        curretAttack.Air_Updateframe( rb2d, newHorizontalMovement,  animator, parent);
    }
    public void air_endframe(Animator animator)
    {
        if (curretAttack == null)
            return;
        curretAttack.Air_EndFrame(animator);
    }

    //以下上書き用

    public virtual void Firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent,SkeletonAnimation skeletonAnimation)
    {

    }

    public virtual void Updateframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent,SkeletonAnimation skeletonAnimation)
    {

    }

    public virtual void EndFrame(Animator animator)
    {

    }

    public virtual void Air_Firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, int set, Transform parent,SkeletonAnimation skeletonAnimation)
    {

    }

    public virtual void Air_Updateframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent)
    {

    }

    public virtual void Air_EndFrame(Animator animator)
    {

    }

    public virtual void Special_Firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, int set, Transform parent, SkeletonAnimation skeletonAnimation)
    {

    }

    public virtual void Special_Updateframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent, SkeletonAnimation skeletonAnimation)
    {

    }

    public virtual void Special_EndFrame(Animator animator)
    {

    }
}