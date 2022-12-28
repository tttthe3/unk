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
    private Slasher1 slash= new Slasher1();
    private Lans1 lans = new Lans1();
    private  CreateItem currentitem;
    private  AttackWrapper curretAttack; //丸ごと保存できるか後で検証
    public AttackWrapper[] Weapons;

    static public AttackWrapper Instance { get { return s_attack; } }
    static protected AttackWrapper s_attack;

    private  void Awake()
    {
        s_attack = this;

        Debug.Log(curretAttack);
        set = Itemset.none;
        
    }

      void Start()
    {
       
       
        //damaegeg.enabled = false;
    }
    public void WeaponSetter(string ItemName)
    {

       
       // for (int i = 0; i < Weapons.Length; i++)
           // {
           //     if (Weapons[i].WeaponName == ItemName)
           //     {
           //     if (!ItemDataBase.Instance.HasItem(ItemName))
            //        return;
              
                    curretAttack = Weapons[0]; //ここでdamagerとる
                curretAttack.GetComponent<Kama_Compo>().slashself = SkillManager.Instance.GetCombs(ItemName);
                 curretAttack.GetComponent<Kama_Compo>().air_slashself = SkillManager.Instance.air_GetCombs(ItemName);
        //    }

        //  }

        Debug.Log(curretAttack.GetComponent<Kama_Compo>().slashself);
        Debug.Log(SkillManager.Instance.GetCombs(ItemName));
        Debug.Log(ItemDataBase.Instance.HasItem(ItemName));

    }



    public void Setcombset()
    {

    }

    //ファーストアタックならslashself[0]を差し替え、2~4撃目ならコンボ増加数を見てupdatestate内の名前を書き換える＆slashselfの順番を変更する　フィニッシュならコンボ数＝に代入



    public Itemset ouptputstate()
    {
        return set;
    }
    public void firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent) {

        curretAttack.Firstframe(rb2d,  newHorizontalMovement,  animator,  parent);
        
    }
    public void updateframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent) {

        curretAttack.Updateframe (rb2d, newHorizontalMovement,  animator,  parent);
    }

    public void endframe(Animator animator) {
        if (curretAttack == null)
            return;
        curretAttack.EndFrame(animator);
    }

    public void special_firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, int set, Transform parent)
    {
        if (curretAttack == null)
            return;
        curretAttack.Special_Firstframe( rb2d,  newHorizontalMovement,  animator,  set, parent);
    }

    public void special_updateframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent)
    {
        curretAttack.Special_Updateframe( rb2d,  newHorizontalMovement,animator, parent);
    }

    public void Air_firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, int set, Transform parent)
    {
        if (curretAttack == null)
            return;
        curretAttack.Air_Firstframe(rb2d,  newHorizontalMovement,  animator,  set, parent);
    }

    public void Air_updateframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent)
    {
        curretAttack.Air_Updateframe( rb2d, newHorizontalMovement,  animator, parent);
    }


    //以下上書き用

    public virtual void Firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent)
    {

    }

    public virtual void Updateframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent)
    {

    }

    public virtual void EndFrame(Animator animator)
    {

    }

    public virtual void Air_Firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, int set, Transform parent)
    {

    }

    public virtual void Air_Updateframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent)
    {

    }

    public virtual void Special_Firstframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, int set, Transform parent)
    {

    }

    public virtual void Special_Updateframe(Rigidbody2D rb2d, float newHorizontalMovement, Animator animator, Transform parent)
    {

    }
}