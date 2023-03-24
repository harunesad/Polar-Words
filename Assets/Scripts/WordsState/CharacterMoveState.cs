using UnityEngine;


public class CharacterMoveState : WordsBaseState
{
    GameObject _clickObj;
    bool _walking;
    public override void EnterState(WordsStateManager words)
    {
        if (UIManager.uIManager.skillActive)
        {
            for (int i = words.words.Count - 1; i > 0; i--)
            {
                if (words.ground.transform.parent.gameObject != words.words[i])
                {
                    words.words[i].layer = 0;
                    words.iceWords.Add(words.words[i]);
                    //GameObject.Instantiate(words.snowEffect, words.words[i].transform.position + Vector3.up * 6.5f, Quaternion.identity);
                }
            }
            for (int i = words.words.Count - 1; i > 0; i--)
            {
                if (words.words[i] != words.ground.transform.parent.gameObject)
                {
                    words.words.RemoveAt(i);
                }
            }
        }

        words.point = Vector3.zero;
        words.agent.isStopped = true;
        words.firstGround = words.ground;
        words.startGround.transform.GetChild(0).gameObject.layer = 7;
        _walking = false;
        Navmesh.navmesh.NavMeshSurfaces();
        for (int i = words.words.Count - 1; i > 0; i--)
        {
            if (words.words[i] != words.ground.transform.parent.gameObject && words.words[i].transform.GetChild(0).gameObject.layer == 6 || words.finishGround.transform.GetChild(0).gameObject.layer == 6)
            {
                _walking = true;
            }
        }

        foreach (var iceWords in words.iceWords)
        {
            if (words.iceWords.Count > 0 && iceWords.transform.GetChild(0).gameObject.layer == 6)
            {
                _walking = true;
            }
        }
        if (UIManager.uIManager.skillActive && _walking == false)
        {
            words.firstGround = null;
            UIManager.uIManager.skillActive = false;
            GameObject.Destroy(UIManager.uIManager.snow, 2f);
            UIManager.uIManager.snow.GetComponent<ParticleSystem>().startSize = 0;
            words.SwitchState(words.snowGlobeState);
        }
        if (UIManager.uIManager.skillActive == false && _walking == false)
        {
            words.startGround.transform.GetChild(0).gameObject.layer = 6;
            words.SwitchState(words.clearGroundState);
        }
    }

    public override void UpdateState(WordsStateManager words)
    {
        if (Input.GetMouseButtonDown(0) && words.agent.isStopped)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, words.groundMask))
            {
                _clickObj = hit.transform.gameObject;
                Vector3 hitPos = hit.transform.position;
                words.point = new Vector3(hitPos.x, words.polar.transform.position.y, hitPos.z);
                words.agent.isStopped = false;
            }
            if (_clickObj.transform.parent.gameObject == words.finishGround)
            {
                words.SwitchState(words.finishState);
                return;
            }
            words.agent.gameObject.GetComponent<Animator>().SetBool("Walk",true);
            words.agent.SetDestination(words.point);
        }
        Vector3 newPoint = new Vector3(words.point.x, words.polar.transform.position.y, words.point.z);
        if (Vector3.Distance(words.polar.transform.position, newPoint) < 0.1f)
        {
            words.agent.gameObject.GetComponent<Animator>().SetBool("Walk",false);
            if (UIManager.uIManager.skillActive)
            {
                UIManager.uIManager.skillActive = false;
                GameObject.Destroy(UIManager.uIManager.snow, 2f);
                UIManager.uIManager.snow.GetComponent<ParticleSystem>().startSize = 0;
                words.SwitchState(words.snowGlobeState);
                return;
            }
            words.SwitchState(words.clearState);
        }
    }
}
