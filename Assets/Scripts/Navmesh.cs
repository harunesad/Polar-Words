using UnityEngine;
using UnityEngine.AI;

public class Navmesh : MonoBehaviour
{
    public static Navmesh navmesh;
    public NavMeshSurface navMeshSurfaces;
    private void Awake()
    {
        navmesh = this;
    }
    ////private void Update()
    ////{
    ////    if (Input.GetKeyDown(KeyCode.Space))
    ////    {
    ////        NavMeshSurfaces();
    ////    }
    ////}
    public void NavMeshSurfaces()
    {
        navMeshSurfaces.BuildNavMesh();
    }
}
