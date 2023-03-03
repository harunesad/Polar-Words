using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CamLook : MonoBehaviour
{
    public static CamLook cam;
    WordsStateManager wordsState;
    public GameObject firstPoint, secondPoint;
    private void Awake()
    {
        cam = this;
        wordsState = FindObjectOfType<WordsStateManager>();
    }
    //private void OnEnable()
    //{
    //    //if (wordsState.currentState == wordsState.selectState)
    //    //{
    //    //    SecondPos();
    //    //}
    //    //if (wordsState.currentState == wordsState.clearState)
    //    //{
    //    //    FirstPos();
    //    //}
    //    //SecondPos();
    //}
    public void FirstPos()
    {
        Vector3 pos = new Vector3(0, 5, 0);
        transform.DOMove(pos, 2).SetEase(Ease.Linear);
        transform.DORotate(new Vector3(90, 0, 0), 2).SetEase(Ease.Linear).OnComplete(
        () =>
        {
            wordsState.SwitchState(wordsState.selectState);
            //this.enabled = false;
        });
    }
    public void SecondPos() 
    {
        Vector3 pos = new Vector3(secondPoint.transform.position.x - 0.5f, transform.position.y, secondPoint.transform.position.z - 1);
        transform.DOMove(pos, 2).SetEase(Ease.Linear);
        transform.DORotate(new Vector3(45, 45, 0), 2).SetEase(Ease.Linear).OnComplete(
            () =>
            {
                //wordsState.SwitchState(wordsState.fillingState);
                //if (wordsState.currentState == wordsState.finishState)
                //{
                //    wordsState.agent.SetDestination(wordsState.point);
                //}
                //if (wordsState.currentState == wordsState.selectState)
                //{
                //    wordsState.SwitchState(wordsState.fillingState);
                //}
                wordsState.SwitchState(wordsState.fillingState);
                //this.enabled = false;
            });
    }
}
