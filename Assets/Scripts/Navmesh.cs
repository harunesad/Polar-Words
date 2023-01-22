using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navmesh : MonoBehaviour
{
    public NavMeshSurface[] navMeshSurfaces;
    WordsStateManager wordsState;
    void Start()
    {
        wordsState = FindObjectOfType<WordsStateManager>();
    }
    void Update()
    {
        if (wordsState.currentState == wordsState.fillingState)
        {
            for (int i = 0; i < navMeshSurfaces.Length; i++)
            {
                navMeshSurfaces[i].BuildNavMesh();
            }
        }
    }
}
