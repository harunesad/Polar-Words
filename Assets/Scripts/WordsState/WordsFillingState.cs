using UnityEngine;
using DG.Tweening;

public class WordsFillingState : WordsBaseState
{
    int _index;
    public override void EnterState(WordsStateManager words)
    {
        GameObject ice = words.words[_index].transform.GetChild(0).gameObject;
        if (words.ground != ice && words.finishGround != ice)
        {
            ice.transform.DOScale(new Vector3(0.5f, 0.5f, 1), 0.6f).SetEase(Ease.Linear);
            ice.transform.DOMoveY(0.12f, 0.6f).SetEase(Ease.Linear).OnComplete(
        () =>
        {
            _index++;
            if (_index == words.words.Count)
            {
                _index = 0;
                words.startGround.transform.GetChild(0).gameObject.layer = 7;
                words.SwitchState(words.moveState);
                return;
            }
            words.SwitchState(words.fillingState);
        });
        }
        else if (words.ground == ice || words.finishGround == ice)
        {
            _index++;
            words.SwitchState(words.fillingState);
        }
    }

    public override void UpdateState(WordsStateManager words)
    {

    }
}
