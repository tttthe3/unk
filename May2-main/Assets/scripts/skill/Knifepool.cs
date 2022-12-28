using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knifepool : ObjectPool<Knifepool, KnifeObject, Vector2>
{
   
    static protected Dictionary<GameObject, Knifepool> s_PoolInstances = new Dictionary<GameObject, Knifepool>();
    private void Awake()
    {
        //This allow to make Pool manually added in the scene still automatically findable & usable
        if (prefab != null && !s_PoolInstances.ContainsKey(prefab))
            s_PoolInstances.Add(prefab, this);
    }

    private void OnDestroy()
    {
        s_PoolInstances.Remove(prefab);
    }

    static public Knifepool GetObjectPool(GameObject prefab, int initialPoolCount = 10)
    {
        Knifepool objPool = null;
        if (!s_PoolInstances.TryGetValue(prefab, out objPool))
        {
            GameObject obj = new GameObject(prefab.name + "_Pool");
            objPool = obj.AddComponent<Knifepool>();
            objPool.prefab = prefab;
            objPool.initialPoolCount = initialPoolCount;

            s_PoolInstances[prefab] = objPool;
        }

        return objPool;
    }

}

public class KnifeObject : PoolObject<Knifepool, KnifeObject, Vector2>
{
    public Transform transform;
    public Rigidbody2D rigidbody2D;
    public SpriteRenderer spriteRenderer;
    public Knife_Move Gem;
   

    protected override void SetReferences()
    {
        transform = instance.transform;
        rigidbody2D = instance.GetComponent<Rigidbody2D>();
        spriteRenderer = instance.GetComponent<SpriteRenderer>();
        Gem = instance.GetComponent <Knife_Move>();
        Gem.bulletPoolObject = this;
        Gem.mainCamera = GameObject.Find("Cameras/Main Camera").GetComponent<Camera>();
    }

    public override void WakeUp(Vector2 position)
    {
        transform.position = position;
        instance.SetActive(true);
    }

    public override void Sleep()
    {
        instance.SetActive(false);
    }

}



