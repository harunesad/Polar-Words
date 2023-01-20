using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CamLook : MonoBehaviour
{
    public GameObject firstPoint, secondPoint;
    void Start()
    {
        SecondPos();
    }
    void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * 3);
    }
    public void FirstPos()
    {

    }
    public void SecondPos() 
    {
        Vector3 pos = new Vector3(secondPoint.transform.position.x, transform.position.y, secondPoint.transform.position.z - 1);
        transform.DOMove(pos, 2).SetEase(Ease.Linear);
    }
}
