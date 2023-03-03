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
