using System.Collections;
using System.Collections.Generic;
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
        words.camLook = GameObject.FindObjectOfType<CamLook>().GetComponent<CamLook>();

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
                //point = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                clickObj = hit.transform.gameObject;
                Vector3 hitPos = hit.transform.position;
                words.point = new Vector3(hitPos.x, words.polar.transform.position.y, hitPos.z);
                //words.agent.SetDestination(point);
                words.agent.isStopped = false;
            }
            if (clickObj == words.finishGround)
            {
                words.camLook.enabled = true;
                words.SwitchState(words.finishState);
            }
            else
            {
                words.agent.SetDestination(words.point);
            }
        }
        //if (Vector3.Distance(polar.transform.position, point) < 0.1f)
        //{
        //    words.ground.transform.parent.gameObject.layer = 3;
        //    words.SwitchState(words.clearState);
        //}
        if (words.polar.transform.position.x == words.point.x && words.polar.transform.position.z == words.point.z)
        {
            words.ground.transform.parent.gameObject.layer = 3;
            words.SwitchState(words.clearState);
        }
    }
}
