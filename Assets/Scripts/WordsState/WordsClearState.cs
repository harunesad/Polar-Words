using UnityEngine;
using DG.Tweening;

public class WordsClearState : WordsBaseState
{
    int _index;
    public override void EnterState(WordsStateManager words)
    {
        if (words.words[_index] == words.ground.transform.parent.gameObject || words.words[_index] == words.finishGround.transform.parent.gameObject)
        {
            words.words[_index].GetComponent<Renderer>().materials[1].color = words.firstColor;
            _index++;
            words.SwitchState(words.clearState);
        }
        else
        {
            words.words[_index].GetComponent<Renderer>().materials[1].color = words.firstColor;
            words.words[_index].gameObject.layer = 3;

            words.words[_index].transform.GetChild(0).gameObject.layer = 7;
            words.words[_index].transform.GetChild(0).DOScale(new Vector3(0.01f, 0.01f, 0.01f), 0.6f).SetEase(Ease.Linear);
            words.words[_index].transform.GetChild(0).DOMoveY(-0.25f, 0.6f).SetEase(Ease.Linear).OnComplete(
                () =>
                {
                    words.words.RemoveAt(_index);
                    if (words.words.Count == 2 && words.words.Contains(words.ground.transform.parent.gameObject))
                    {
                        _index = 0;
                        words.inputWord.text = "";
                        words.ground.transform.parent.gameObject.layer = 0;
                        words.finishGround.transform.GetChild(0).gameObject.layer = 7;
                        CamLook.cam.FirstPos();
                        return;
                    }
                    if (words.words.Count == 1 && !words.words.Contains(words.ground.transform.parent.gameObject))
                    {
                        _index = 0;
                        words.inputWord.text = "";
                        words.ground.transform.parent.gameObject.layer = 0;
                        words.finishGround.transform.GetChild(0).gameObject.layer = 7;
                        CamLook.cam.FirstPos();
                        return;
                    }
                    words.SwitchState(words.clearState);
                });
        }
    }

    public override void UpdateState(WordsStateManager words)
    {
        
    }
}
