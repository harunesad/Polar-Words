using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WordsClearState : WordsBaseState
{
    public override void EnterState(WordsStateManager words)
    {
        //GameObject.Destroy(words.ground);
        Debug.Log(words.ground.name);
        Debug.Log(words.words[0].transform.GetChild(1).name);
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
            words.words[0].transform.GetChild(1).DOMoveY(-0.25f, 1).OnComplete(
                () =>
                {
                    words.words.RemoveAt(0);
                    words.SwitchState(words.clearState);
                });
        }
    }

    public override void UpdateState(WordsStateManager words)
    {
        
    }
}
