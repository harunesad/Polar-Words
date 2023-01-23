using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navmesh : MonoBehaviour
{
    public static Navmesh navmesh;
    public NavMeshSurface[] navMeshSurfaces;
    WordsStateManager wordsState;
    private void Awake()
    {
        navmesh = this;
    }
    void Start()
    {
        //wordsState = FindObjectOfType<WordsStateManager>();
    }
    void Update()
    {
        //if (wordsState.currentState == wordsState.fillingState)
        //{
        //    for (int i = 0; i < navMeshSurfaces.Length; i++)
        //    {
        //        navMeshSurfaces[i].BuildNavMesh();
        //    }
        //}
    }
    public void NavmeshSurface()
    {
        for (int i = 0; i < navMeshSurfaces.Length; i++)
        {
            navMeshSurfaces[i].BuildNavMesh();
        }
    }
}