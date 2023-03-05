using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
public class GEM_move : MonoBehaviour
{
    public GEMObject bulletPoolObject;
    private Transform target;
    private bool trigger = false;
    
    // Start is called before the first frame update
    private void OnEnable()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        //addforces();
    }
    public void ReturnToPool()
    {
        bulletPoolObject.ReturnToPool();
    }

    void FixedUpdate()
    {
       if(this.gameObject.activeSelf&&trigger)
        {
            addforces();
            trigger = true;
        }

    }

    public void holdgem()
    {
        DOTween.Sequence().Append(bulletPoolObject.transform.DOLocalMove(new Vector3(bulletPoolObject.transform.position.x + Random.Range(5, 5), bulletPoolObject.transform.position.y + Random.Range(2, 2), bulletPoolObject.transform.position.z), .2f, false))
                           .SetDelay(2f)
                           .Append(DOVirtual.DelayedCall(0f, () => trigger =true, false));
    }

    private void addforces()
    {
        var power = new Vector3(Random.Range(-3f,3f),15f,0f);
        bulletPoolObject.rigidbody2D.AddForce(power);
    }

    



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ReturnToPool();
            PowerGage_Manager.Instance.Getpower();
        }
    }

}
