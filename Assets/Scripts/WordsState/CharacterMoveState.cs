using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMoveState : WordsBaseState
{
    GameObject polar;
    public override void EnterState(WordsStateManager words)
    {
        polar = GameObject.Find("Polar");
    }

    public override void UpdateState(WordsStateManager words)
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, words.groundMask))
            {
                polar.GetComponent<NavMeshAgent>().SetDestination(hit.point);
            }
        }
    }
}
