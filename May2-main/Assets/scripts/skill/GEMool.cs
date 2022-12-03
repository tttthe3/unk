using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GEMool : ObjectPool<GEMool,GEMObject,Vector2>
{
    static protected Dictionary<GameObject, GEMool> s_PoolInstances = new Dictionary<GameObject, GEMool>();
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

    static public GEMool GetObjectPool(GameObject prefab, int initialPoolCount = 10)
    {
        GEMool objPool = null;
        if (!s_PoolInstances.TryGetValue(prefab, out objPool))
        {
            GameObject obj = new GameObject(prefab.name + "_Pool");
            objPool = obj.AddComponent<GEMool>();
            objPool.prefab = prefab;
            objPool.initialPoolCount = initialPoolCount;

            s_PoolInstances[prefab] = objPool;
        }

        return objPool;
    }

}
public class GEMObject : PoolObject<GEMool, GEMObject, Vector2>
{
    public Transform transform;
    public Rigidbody2D rigidbody2D;
    public SpriteRenderer spriteRenderer;
    public GEM_move Gem;

    protected override void SetReferences()
    {
        transform = instance.transform;
        rigidbody2D = instance.GetComponent<Rigidbody2D>();
        spriteRenderer = instance.GetComponent<SpriteRenderer>();
        Gem = instance.GetComponent<GEM_move>();
        Gem.bulletPoolObject = this;
       
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

