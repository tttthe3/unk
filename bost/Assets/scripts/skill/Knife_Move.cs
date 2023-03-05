using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife_Move : MonoBehaviour
{
    public KnifeObject bulletPoolObject;
    private Transform target;
    private bool trigger = false;
    // Start is called before the first frame update

    public bool destroyWhenOutOfView = true;
    public bool spriteOriginallyFacesLeft;

    public float timeBeforeAutodestruct = -1.0f;

    protected SpriteRenderer m_SpriteRenderer;
 

    const float k_OffScreenError = 0.01f;

    protected float m_Timer;

    public Camera mainCamera;

    private void OnEnable()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
       
        m_Timer = 0.0f;
    }

    public void ReturnToPool()
    {
        bulletPoolObject.ReturnToPool();
        
    }


    void FixedUpdate()
    {
        if (destroyWhenOutOfView)
        {
            Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);
            bool onScreen = screenPoint.z > 0 && screenPoint.x > -k_OffScreenError &&
                            screenPoint.x < 1 + k_OffScreenError && screenPoint.y > -k_OffScreenError &&
                            screenPoint.y < 1 + k_OffScreenError;
            if (!onScreen)
                bulletPoolObject.ReturnToPool();
        }

        if (timeBeforeAutodestruct > 0)
        {
            m_Timer += Time.deltaTime;
            if (m_Timer > timeBeforeAutodestruct)
            {
                bulletPoolObject.ReturnToPool();
            }
        }
    }

    public void OnHitDamageable(Damager origin, Damagerable damageable)
    {
        FindSurface(origin.LastHit);
    }

    public void OnHitNonDamageable(Damager origin)
    {
        FindSurface(origin.LastHit);
    }

    protected void FindSurface(Collider2D collider)
    {
        Vector3 forward = spriteOriginallyFacesLeft ? Vector3.left : Vector3.right;
        
        
    }
}
