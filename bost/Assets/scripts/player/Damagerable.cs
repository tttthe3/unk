using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using Cinemachine;
using DG.Tweening;

public class Damagerable : MonoBehaviour, IDataPersister
{
    [Serializable]
    public class HealthEvent : UnityEvent<Damagerable>
    { }

    [Serializable]
    public class DamageEvent : UnityEvent<Damager, Damagerable>
    { }

    [Serializable]
    public class HealEvent : UnityEvent<int, Damagerable>
    { }

   
    public int startingHealth = 5;                                  //初期化×
    public bool invulnerableAfterDamage = true;
    public float invulnerabilityDuration;
    public float invulnerabilityDuration_dash;
    public bool disableOnDeath = false;
    [Tooltip("An offset from the obejct position used to set from where the distance to the damager is computed")]
    public Vector2 centreOffset = new Vector2(0f, 1f);
    public HealthEvent OnHealthSet;
    public DamageEvent OnTakeDamage;
    public DamageEvent OnDie;
    public HealEvent OnGainHealth;
    public RandomAudioPlayer damagedsound;
    public CinemachineImpulseSource impulse;
    public float invulnerabel_timers;
    [HideInInspector]


  
    protected bool m_Invulnerable;
    protected float m_InulnerabilityTimer;
    protected int m_CurrentHealth;
    protected Vector2 m_DamageDirection;
    protected bool m_ResetHealthOnSceneReload;
    public DataSettings dataSettings;
    public int CurrentHealth
    {
        get { return m_CurrentHealth; }
    }

    void OnEnable()
    {
        PersistentDataManager.RegisterPersister(this);
        Damager damager = GetComponentInChildren<Damager>();

        m_CurrentHealth = startingHealth;

        OnHealthSet.Invoke(this);
        impulse = this.gameObject.GetComponent<Cinemachine.CinemachineImpulseSource>();
        DisableInvulnerability();
    }

    void OnDisable()
    {
        PersistentDataManager.UnregisterPersister(this);
    }

    

    void Update()
        
    {
        invulnerabel_timers = m_InulnerabilityTimer;


        if (m_Invulnerable)
        {
            m_InulnerabilityTimer -= Time.deltaTime;

            if (m_InulnerabilityTimer <= 0f)
            {
                m_Invulnerable = false;
            }
        }
    }

    public void EnableInvulnerability(bool ignoreTimer = false)
    {
        m_Invulnerable = true;
        //technically don't ignore timer, just set it to an insanly big number. Allow to avoid to add more test & special case.
        m_InulnerabilityTimer = ignoreTimer ? float.MaxValue : invulnerabilityDuration;
    }

    public void DisableInvulnerability()
    {
        m_Invulnerable = false;
    }

    public Vector2 GetDamageDirection()
    {
        return m_DamageDirection;
    }

    public void TakeDamage(Damager damager, bool ignoreInvincible = false)
    {
        Debug.Log(m_CurrentHealth);
        if ((m_Invulnerable && !ignoreInvincible) || m_CurrentHealth <= 0)
            return;
        
       

        if (damagedsound != null)

        {
            Debug.Log("imp");
            damagedsound.PlayRandomSound();
            impulse.GenerateImpulse();
        }
        //we can reach that point if the damager was one that was ignoring invincible state.
        //We still want the callback that we were hit, but not the damage to be removed from health.
        if (!m_Invulnerable)
        {
            m_CurrentHealth -= damager.damage;
           
            OnHealthSet.Invoke(this);
            EnableInvulnerability();
        }

        m_DamageDirection = transform.position + (Vector3)centreOffset - damager.transform.position;
        //impulse.GenerateImpulse();
        OnTakeDamage.Invoke(damager, this);
        
        if (m_CurrentHealth <= 0)
        {
            OnDie.Invoke(damager, this);
            m_ResetHealthOnSceneReload = true;
            EnableInvulnerability();
            if (disableOnDeath) gameObject.SetActive(false);
        }
    }

    public void damagemove(Damager.movestate state)
    {
        Debug.Log(this.gameObject.transform);
        if (state == Damager.movestate.up)
            this.gameObject.transform.DOMove(new Vector3(0f, 10f, 0f), 1).SetRelative(true);
        else if (state == Damager.movestate.next)
            this.gameObject.transform.DOMove(new Vector3(2f * Charactercontrolelr.CCInstance.m_SpriteForward.x, 0f, 0f), 1).SetRelative(true);
        else if (state == Damager.movestate.diagonal)
            this.gameObject.transform.DOMove(new Vector3(2f * Charactercontrolelr.CCInstance.m_SpriteForward.x, 4f, 0f), 1).SetRelative(true);
        else if (state == Damager.movestate.none)
        { }

    }

    public void damagemove2(Damager.movestate state,Damager damager)
    {
        Debug.Log(this.gameObject.transform);
        if (state == Damager.movestate.up)
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, damager.hituppower));
        else if (state == Damager.movestate.next)
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x*damager.force, 0f));
        else if (state == Damager.movestate.diagonal)
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Charactercontrolelr.CCInstance.m_SpriteForward.x * 900f, 800f));
        else if (state == Damager.movestate.none)
        { }

    }
    
    public void fixdamagetimer(Damager damager)
    {
        if(damager.fixdamagetimer!=0f)
        invulnerabilityDuration = damager.fixdamagetimer;
    }

    public void GainHealth(int amount)
    {
        m_CurrentHealth += amount;

        if (m_CurrentHealth > startingHealth)
            m_CurrentHealth = startingHealth;

        OnHealthSet.Invoke(this);

        OnGainHealth.Invoke(amount, this);
    }

    public void SetHealth(int amount)
    {
        m_CurrentHealth = amount;

        if (m_CurrentHealth <= 0)
        {
            OnDie.Invoke(null, this);
            m_ResetHealthOnSceneReload = true;
            EnableInvulnerability();
            if (disableOnDeath) gameObject.SetActive(false);
        }

        OnHealthSet.Invoke(this);
    }

    public DataSettings GetDataSettings()
    {
        return dataSettings;
    }

    public void SetDataSettings(string dataTag, DataSettings.PersistenceType persistenceType)
    {
        dataSettings.dataTag = dataTag;
        dataSettings.persistenceType = persistenceType;
    }

    public Data SaveData()
    {
        return new Data<int, bool>(CurrentHealth, m_ResetHealthOnSceneReload);
    }

    public void LoadData(Data data)
    {
        Data<int, bool> healthData = (Data<int, bool>)data;
        m_CurrentHealth = healthData.value1 ? startingHealth : healthData.value0;
        OnHealthSet.Invoke(this);
    }

    public void dashinvul(bool ignoreTimer = false)
    {
        m_Invulnerable = true;
        //technically don't ignore timer, just set it to an insanly big number. Allow to avoid to add more test & special case.
        m_InulnerabilityTimer = ignoreTimer ? float.MaxValue : invulnerabilityDuration_dash;
    }
}


