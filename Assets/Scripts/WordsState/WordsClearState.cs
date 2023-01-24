using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WordsClearState : WordsBaseState
{
    CamLook camLook;
    public override void EnterState(WordsStateManager words)
    {
        camLook = GameObject.FindObjectOfType<CamLook>().GetComponent<CamLook>();

        //Debug.Log(words.ground.name);
        //Debug.Log(words.words[0].transform.GetChild(1).name);
        if (words.words.Count == 0)
        {
            //words.SwitchState(words.selectState);
            Debug.Log("sss");
            words.ýnputWord.text = "";
            words.ground.transform.parent.gameObject.layer = 0;
            camLook.enabled = true;
        }
        if (words.words[0].transform.GetChild(1).gameObject.layer == words.ground.layer)
        {
            Debug.Log(words.ground.name);
            words.words[0].GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
            words.words.RemoveAt(0);
            words.SwitchState(words.clearState);
            //return;
        }
        else
        {
            words.words[0].GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
            words.words[0].transform.GetChild(1).gameObject.layer = 7;
            words.words[0].transform.GetChild(1).DOMoveY(-0.25f, 1).OnComplete(
                () =>
                {
                    //words.words[0].layer = 7;
                    Navmesh.navmesh.NavmeshSurface();
                    words.words.RemoveAt(0);
                    words.SwitchState(words.clearState);
                });
        }
    }

    public override void UpdateState(WordsStateManager words)
    {
        
    }
}
