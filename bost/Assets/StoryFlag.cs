using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "StoryFlag", menuName = "Createstoryflag")]


public class ObjectFlag :ScriptableObject
{
    //フラグリストに載せる個別のフラグ。呼び出すオブジェクトと
    public enum Init_KindofLoad
    {
       SceneMove,AfterEvent,Stagemove,None
    }

    public enum Delete_KindofLoad
    {
        SceneMove, AfterEvent, Stagemove,None
    }

    [SerializeField]
    private string Flagobject_directory; //オブジェクトのディレクトリ
    [SerializeField]
    private bool Flag; //フラグ

    [SerializeField]
    private Init_KindofLoad Init_Loadtype; //シーン移動時にロードするか、イベント直後にロードするか、ステージ移動でロードするか  同じシーン内なら後者２つ、元からステージにあるタイプはロード不要

    [SerializeField]
    private string Init_Load_Scenename; //シーン移動の場合、対象のシーン名

    [SerializeField]
    private Delete_KindofLoad delete_Loadtype;

    [SerializeField]
    private Vector3 InstPos;

    [SerializeField]
    private GameObject InitObject;

    [SerializeField]
    private string InitObjectname;


    public string GetFlagobject_directory()
    {
        return Flagobject_directory;
    }

    public bool GetFlag()
    {
        return Flag;
    }

    public Init_KindofLoad GetInit_KindofLoad()
    {
        return Init_Loadtype;
    }

    public string GetInit_Load_Scenename()
    {
        return Init_Load_Scenename;
    }

    public Delete_KindofLoad GetDelete_KindofLoad()
    {
        return delete_Loadtype;
    }

    public Vector3 GetInstPos()
    {
        return InstPos;
    }

    public GameObject GetInitObject()
    {
        return InitObject;
    }
    public string GetInit_Objectname()
    {
        return InitObjectname;
    }



    public void SetFlag()
    {
       Flag=true;
    }

}
