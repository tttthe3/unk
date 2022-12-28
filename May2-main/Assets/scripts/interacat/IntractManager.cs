using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
public class IntractManager : MonoBehaviour
{
    static public IntractManager Instance { get { return s_Intract; } }
    static protected IntractManager s_Intract;
    [SerializeField]
    private InteractWrapper[] Itemlist;
    private InteractWrapper currentitem;


    [SerializeField]
    private Dictionary<string, InteractWrapper> Itemsetter = new Dictionary<string, InteractWrapper>(); 

    private bool push_trigger = false;
    private bool Laddr_trigger = false;
    private bool evevate = false;
    private bool open_trigger;
    private bool talk_trigger;
    // Start is called before the first frame update
    void Start()
    {
        currentitem = null;
        s_Intract = this;

        Itemsetter.Add("push",Itemlist[0]);
        Itemsetter.Add("ladder", Itemlist[1]);

    }



    private void FixedUpdate()
    {

       // if (push_trigger)
        {
       //     currentitem = Itemlist[0];

        }
    //    else if (Laddr_trigger)
        {
      //      currentitem = Itemlist[1];
        }
       // else
       // { currentitem = null; }
    }

    public void SetIntractItem(string name)
    {
        Itemsetter.TryGetValue(name, out InteractWrapper comb);

        if (comb == null)
            return ;

        currentitem = comb;
       
    }

    public void SetnullItem()
    {
        currentitem = null;
    }

    public string getIntractname()
    {
        if (currentitem == null)
            return "";
        else
        return currentitem.name;
    }
    public void Firstframe(Rigidbody2D rb2d, Animator animator, Transform parent)
    {
        if (currentitem == null)
            return;
        currentitem.firstframe(rb2d,animator,parent);

    }
    public void Updateframe(Rigidbody2D rb2d, Animator animator,SkeletonAnimation animation)
    {
        
        currentitem.updateframe(rb2d, animator,animation);
    }

    public void Endframe()
    {
    }
}
