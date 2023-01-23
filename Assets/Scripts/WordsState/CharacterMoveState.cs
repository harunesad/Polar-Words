using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMoveState : WordsBaseState
{
    GameObject polar;
    NavMeshAgent agent;
    Vector3 point;
    public override void EnterState(WordsStateManager words)
    {
        polar = GameObject.Find("Polar");
        agent = polar.GetComponent<NavMeshAgent>();
        agent.isStopped = true;
    }

    public override void UpdateState(WordsStateManager words)
    {
        if (Input.GetMouseButtonDown(0) && agent.isStopped == true)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, words.groundMask))
            {
                point = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                agent.SetDestination(point);
                agent.isStopped = false;
                //Debug.Log(point);
            }
        }
        //Debug.Log(Vector3.Distance(polar.transform.position, point));
        if (Vector3.Distance(polar.transform.position, point) < 0.1f)
        {
            //polar.AddComponent<PolarCollision>();
            words.ground.layer = 7;
            words.SwitchState(words.clearState);
            //words.ground = collision.gameObject;
        }
    }
}