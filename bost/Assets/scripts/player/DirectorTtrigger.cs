using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;


   
    public class DirectorTtrigger : MonoBehaviour, IDataPersister
    {
        public enum TriggerType
        {
            Once, Everytime,
        }
    　　
    　　public enum triggercond
           {collid,intract,talk,continues }
        [Tooltip("This is the gameobject which will trigger the director to play.  For example, the player.")]
        public GameObject triggeringGameObject;
        public PlayableDirector director;
        public TriggerType triggerType;
        public triggercond triggercondtion;
        public UnityEvent OnDirectorPlay;
        public UnityEvent OnDirectorFinish;
        [HideInInspector]
        public DataSettings dataSettings;
        public Flag_content finishflag;
        public Flag_content BeforeMovieFlag;
        protected bool m_AlreadyTriggered;
        public GameObject Nextmovie;
         public StoryFlag flags;

    void Start()
    {
        Debug.Log(this.gameObject.name);
        if (flags.GetFlag() == true)
        {
            director.time = director.duration;
            OnDirectorPlay = null;
            this.gameObject.SetActive(false);
        }


    }
        void OnEnable()
        {
            PersistentDataManager.RegisterPersister(this);

        if (triggercondtion == triggercond.continues)
            StartCoroutine(startMovie(5));

    }

        void OnDisable()
        {
            PersistentDataManager.UnregisterPersister(this);
        }

    public void delaystart()
    {
        
    }

    void Update()
    {
        
        {
            Debug.Log(this.gameObject.name);
        }
        

        

    }

    public void Eventcall()
    {
        if (!flags.GetFlag())
        {
            director.Play();
            m_AlreadyTriggered = true;
            OnDirectorPlay.Invoke();
        }
    }

        void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("play");
        if (triggercondtion == triggercond.collid)
        {
            if (other.gameObject != triggeringGameObject)
                return;
            Debug.Log("play");
            Debug.Log(triggerType);
            if (triggerType == TriggerType.Once && m_AlreadyTriggered|| flags.GetFlag())
                return;

            Debug.Log("play");
                director.Play();
                m_AlreadyTriggered = true;
                OnDirectorPlay.Invoke();
            

        }

        }
   

         void OnTriggerStay2D(Collider2D other) {
        if (triggercond.intract == triggercondtion)
        {
            Intract_display.Instance.Setword("確認する");
            if (other.gameObject != triggeringGameObject)
                return;

            if (triggerType == TriggerType.Once && m_AlreadyTriggered)
                return;

            if (Playerinput.Instance.Intract.Down)
            {
                director.Play();
                m_AlreadyTriggered = true;
                OnDirectorPlay.Invoke();
               // Invoke("FinishInvoke", (float)director.duration);
            }
        }
        
    
         }

    public void Isdone()
    {
        finishflag.flag = true;
        if (flags != null)
        {
            flags.SetFlag();
            //Story_FlagList.Instance.FlagAllLoad();
           // Story_FlagList.Instance.SetActive_Event();
        }
    }


    public void playmovie()
    {
        director.Play();
        m_AlreadyTriggered = true;
        OnDirectorPlay.Invoke();
        Invoke("FinishInvoke", (float)director.duration);

    }

        void cutinmovie()
        {
        OnDirectorPlay.Invoke();
        director.Play();
        Invoke("FinishInvoke", (float)director.duration);
    }
        public void FinishInvoke()
        {
        //finishflag.flag = true;
        OnDirectorFinish.Invoke();
        }

        public void OverrideAlreadyTriggered(bool alreadyTriggered)
        {
            m_AlreadyTriggered = alreadyTriggered;
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
            return new Data<bool>(m_AlreadyTriggered);
        }

        public void LoadData(Data data)
        {
            Data<bool> directorTriggerData = (Data<bool>)data;
            m_AlreadyTriggered = directorTriggerData.value;
        }

    public void startnext()
    {

    }

    IEnumerator startMovie(int delay)
    {
        yield return new WaitForSeconds(delay);
        director.Play();
      
       
    }

    public void playconst()
    {
        director.Play();
        //StartCoroutine(startMovie(4));
    }

    public void timescalecontroller(float time)
    {
        
    }
}
