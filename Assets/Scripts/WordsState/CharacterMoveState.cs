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
        words.firstGround = words.ground;
        words.ground.layer = 6;
        for (int i = words.words.Count - 1; i > 0; i--)
        {
            Debug.Log(words.words[i]);
            Debug.Log(words.ground.transform.parent.gameObject);
            Debug.Log(words.words[i].transform.GetChild(0).gameObject.layer);
            if (words.words[i] != words.ground.transform.parent.gameObject && words.words[i].transform.GetChild(0).gameObject.layer == 6)
            {
                Debug.Log("sadaaaa");
                return;
            }
        }
        if (Button.button.buttonClickCount == 1)
        {
            Button.button.buttonClickCount++;
            //words.firstGround = words.ground;
            words.SwitchState(words.snowGlobeState);
            return;
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
            //if (words.ground == words.beforeToFinish)
            //{
            //    words.agent.SetDestination(words.finishGround.transform.position);
            //}
            //else
            //{
            //    words.ground.transform.parent.gameObject.layer = 3;
            //    words.SwitchState(words.clearState);
            //}
            //words.ground.transform.parent.gameObject.layer = 3;
            //if (words.fish != null)
            //{
            //    words.fish.SetActive(false);
            //}
            if (Button.button.buttonClickCount == 1)
            {
                Button.button.buttonClickCount++;
                words.SwitchState(words.snowGlobeState);
                return;
            }
            words.SwitchState(words.clearState);
        }
    }
}
