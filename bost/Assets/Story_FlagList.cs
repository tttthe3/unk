using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;

public class Story_FlagList : MonoBehaviour
{
    //ストーリー章毎のフラグを管理。フラグで指定されたタイミングでそう読み込みをして、falseを見つけたらそのイベントをinit＆１つ前を消去する。
    //フラグをOnする＆オブジェクトの消去

    public ObjectFlag[] First;
    public ObjectFlag[] Second;
    public ObjectFlag[] Third;
    public ObjectFlag[] Forth;

    private ObjectFlag currentFlag;
    private GameObject currentObject;
    static public Story_FlagList Instance { get { return s_Story_FlagList; } }
    static protected Story_FlagList s_Story_FlagList;

    private Transform parent_events;

    private void Awake()
    {
        s_Story_FlagList = this;
        parent_events = GameObject.Find("Directors").transform;
        Debug.Log(parent_events);
    }

    private void Start()
    {
        FlagAllLoad();
    }
    public void FlagAllLoad()
    {
        for (int i = 0; i < First.Length; i++)
        {
            if (First[i].GetFlag()&& !First[i+1].GetFlag())
            {
                currentFlag = First[i];
                Debug.Log(currentFlag);
                return;
            }
        }

        for (int i = 0; i < Second.Length; i++)
        {
            if (Second[i].GetFlag() && !Second[i + 1].GetFlag())
            {
                currentFlag = Second[i];
                return;
            }
        }

        for (int i = 0; i <Third.Length; i++)
        {
            if (Third[i].GetFlag() && !Third[i + 1].GetFlag())
            {
                currentFlag = Third[i];
                return;
            }
        }

        for (int i = 0; i <Forth.Length; i++)
        {
            if (Forth[i].GetFlag() && !Forth[i + 1].GetFlag())
            {
                currentFlag = Forth[i];
                return;
            }
        }
    }

    public void ProceddFlag()
    {

    }

    public void InitEvent()
    {
        if (currentFlag.GetInit_KindofLoad() == ObjectFlag.Init_KindofLoad.None)
            return;
        else if (currentFlag.GetInit_KindofLoad() == ObjectFlag.Init_KindofLoad.AfterEvent)
        {
            Addressables.LoadAssetAsync<GameObject>(currentFlag.GetInit_Objectname()).Completed += handle =>
            {
                currentObject = handle.Result;
                Debug.Log(handle.Result);
                Instantiate(currentObject, currentFlag.GetInstPos(), Quaternion.identity);
            };
            
        }
        else if (currentFlag.GetInit_KindofLoad() == ObjectFlag.Init_KindofLoad.SceneMove)
        {
            if(SceneManager.GetActiveScene().name== currentFlag.GetInit_Load_Scenename())
            {
                SceneManager.sceneLoaded += SceneLoaded_Init; 
            }
        }
        else if (currentFlag.GetInit_KindofLoad() == ObjectFlag.Init_KindofLoad.Stagemove)
        {

        }

    }

    public void SetActive_Event()
    {
        if (currentFlag.GetInit_KindofLoad() == ObjectFlag.Init_KindofLoad.None)
            return;
        else if (currentFlag.GetInit_KindofLoad() == ObjectFlag.Init_KindofLoad.AfterEvent)
        {
            currentObject = parent_events.Find(currentFlag.GetInit_Objectname()).gameObject;
            Debug.Log(currentObject);
            if (!currentObject.activeSelf)
                currentObject.SetActive(true);

        }
        else if (currentFlag.GetInit_KindofLoad() == ObjectFlag.Init_KindofLoad.SceneMove)
        {
            if (SceneManager.GetActiveScene().name == currentFlag.GetInit_Load_Scenename())
            {
                SceneManager.sceneLoaded += SceneLoaded_Init;
            }
        }
        else if (currentFlag.GetInit_KindofLoad() == ObjectFlag.Init_KindofLoad.Stagemove)
        {

        }

    }


    void SceneLoaded_Init(Scene scene,LoadSceneMode mode)
    {
        currentObject = Instantiate(currentFlag.GetInitObject(), currentFlag.GetInstPos(), Quaternion.identity);
        SceneManager.sceneLoaded -= SceneLoaded_Init;
    }

    public void DestroyObject()
    {
        if (currentFlag.GetDelete_KindofLoad() == ObjectFlag.Delete_KindofLoad.None)
            return;
        else if (currentFlag.GetDelete_KindofLoad() == ObjectFlag.Delete_KindofLoad.AfterEvent)
        {
            Destroy(currentObject);
        }
        else if (currentFlag.GetDelete_KindofLoad() == ObjectFlag.Delete_KindofLoad.SceneMove)
        {
            if (SceneManager.GetActiveScene().name == currentFlag.GetInit_Load_Scenename())
            {
                SceneManager.sceneLoaded += SceneLoaded_Init;
            }
        }
        else if (currentFlag.GetDelete_KindofLoad() == ObjectFlag.Delete_KindofLoad.Stagemove)
        {

        }
    }
    void SceneLoaded_Dest(Scene scene, LoadSceneMode mode)
    {
        Destroy(currentObject);
        SceneManager.sceneLoaded -= SceneLoaded_Dest;
    }



}
