using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMoveState : WordsBaseState
{
    GameObject clickObj;
    public override void EnterState(WordsStateManager words)
    {
        words.point = Vector3.zero;
        words.agent.isStopped = true;

        for (int i = 0; i < words.words.Count; i++)
        {
            if (words.words[i] != words.ground.transform.parent.gameObject && words.words[i].transform.GetChild(0).gameObject.layer == 6)
            {
                return;
            }
        }
        words.start.layer = 6;
        words.SwitchState(words.clearGroundState);
    }

    public override void UpdateState(WordsStateManager words)
    {
        if (Input.GetMouseButtonDown(0) && words.agent.isStopped == true)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, words.groundMask))
            {
                clickObj = hit.transform.gameObject;
                Vector3 hitPos = hit.transform.position;
                words.point = new Vector3(hitPos.x, words.polar.transform.position.y, hitPos.z);
                words.agent.isStopped = false;
            }
            if (clickObj == words.finishGround)
            {
                words.SwitchState(words.finishState);
                //words.camLook.enabled = true;
                return;
            }
            else
            {
                words.agent.SetDestination(words.point);
            }
        }
        Vector3 newPoint = new Vector3(words.point.x, words.polar.transform.position.y, words.point.z);
        if (Vector3.Distance(words.polar.transform.position, newPoint) < 0.1f)
        {
            if (words.ground == words.beforeToFinish)
            {
                words.agent.SetDestination(words.finishGround.transform.position);
            }
            else
            {
                words.ground.transform.parent.gameObject.layer = 3;
                words.SwitchState(words.clearState);
            }
        }
    }
}
