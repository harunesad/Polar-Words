using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMoveState : WordsBaseState
{
    GameObject polar;
    GameObject clickObj;
    NavMeshAgent agent;
    Vector3 point;
    public override void EnterState(WordsStateManager words)
    {
        point = Vector3.zero;
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
                //point = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                clickObj = hit.transform.gameObject;
                Vector3 hitPos = hit.transform.position;
                point = new Vector3(hitPos.x, polar.transform.position.y, hitPos.z);
                agent.SetDestination(point);
                agent.isStopped = false;
            }
            if (clickObj == words.finishGround)
            {
                words.SwitchState(words.finishState);
            }
        }
        //if (Vector3.Distance(polar.transform.position, point) < 0.1f)
        //{
        //    words.ground.transform.parent.gameObject.layer = 3;
        //    words.SwitchState(words.clearState);
        //}
        if (polar.transform.position == point)
        {
            words.ground.transform.parent.gameObject.layer = 3;
            words.SwitchState(words.clearState);
        }
    }
}
