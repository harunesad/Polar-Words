using UnityEngine;
using DG.Tweening;

public class CamLook : MonoBehaviour
{
    public static CamLook cam;
    WordsStateManager _wordsState;
    public GameObject firstPoint;
    private void Awake()
    {
        cam = this;
        _wordsState = FindObjectOfType<WordsStateManager>();
    }
    public void FirstPos()
    {
        Vector3 pos = new Vector3(0, 5, -0.78f);
        transform.DOMove(pos, 2).SetEase(Ease.Linear);
        transform.DORotate(new Vector3(90, 0, 0), 2).SetEase(Ease.Linear).OnComplete(
        () =>
        {
            _wordsState.SwitchState(_wordsState.selectState);
        });
    }
    public void SecondPos()
    {
        Vector3 pointPos = firstPoint.transform.position;
        Vector3 pos = new Vector3(pointPos.x, transform.position.y,pointPos.z - 1);
        transform.DOMove(pos, 2).SetEase(Ease.Linear);
        transform.DORotate(new Vector3(45, 30, 0), 2).SetEase(Ease.Linear).OnComplete(
            () =>
            {
                _wordsState.SwitchState(_wordsState.fillingState);
            });
    }
}
