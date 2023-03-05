using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder_Object : MonoBehaviour
{
    public BoxCollider2D col;
    public Rigidbody2D rb2d;
    public Transform targetpos;
    private bool HitPlayer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<IntractManager>().SetIntractItem("ladder");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<IntractManager>().SetnullItem();
        }

    }
    public void pushs()
    {

        ; if (Charactercontrolelr.CCInstance.GetAniState("push"))

        {
            rb2d.bodyType = RigidbodyType2D.Dynamic;
        }
        else
        {
            rb2d.bodyType = RigidbodyType2D.Kinematic;
            Vector3 curent = rb2d.velocity;
            rb2d.velocity = new Vector3(0f, curent.y, 0f);
        }
    }

    void Update()
    {
       // pushs();
    }

   

}
