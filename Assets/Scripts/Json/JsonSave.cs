using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonSave : MonoBehaviour
{
    public static JsonSave json;
    public SaveObject so;
    private void Awake()
    {
        json = this;
    }
    private void Start()
    {
        //so.fishCount = 0;
        //for (int i = 0; i < so.levelFinish.Count; i++)
        //{
        //    so.levelFinish[i].fishState = false;
        //    so.levelFinish[i].levelState = false;
        //}
        //Save();
        Load();
    }
    public void Save()
    {
        SaveManager.Save(so);
    }
    public void Load()
    {
        so = SaveManager.Load();
    }
}
