using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet1_pool : ObjectPool<bullet1_pool, bullet_Object, Vector2>
{

    static protected Dictionary<GameObject, bullet1_pool> s_PoolInstances = new Dictionary<GameObject, bullet1_pool>();
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

    static public bullet1_pool GetObjectPool(GameObject prefab, int initialPoolCount = 10)
    {
        bullet1_pool objPool = null;
        if (!s_PoolInstances.TryGetValue(prefab, out objPool))
        {
            GameObject obj = new GameObject(prefab.name + "_Pool");
            objPool = obj.AddComponent<bullet1_pool>();
            objPool.prefab = prefab;
            objPool.initialPoolCount = initialPoolCount;

            s_PoolInstances[prefab] = objPool;
        }

        return objPool;
    }

}

public class bullet_Object : PoolObject<bullet1_pool, bullet_Object, Vector2>
{
    public Transform transform;
    public Rigidbody2D rigidbody2D;
    public SpriteRenderer spriteRenderer;
    public Bullet1_move Gem;


    protected override void SetReferences()
    {
        transform = instance.transform;
        rigidbody2D = instance.GetComponent<Rigidbody2D>();
        spriteRenderer = instance.GetComponent<SpriteRenderer>();
        Gem = instance.GetComponent<Bullet1_move>();
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



