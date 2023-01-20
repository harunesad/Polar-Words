using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CamLook : MonoBehaviour
{
    public static CamLook cam;
    public GameObject firstPoint, secondPoint;
    private void Awake()
    {
        cam = this;
    }
    void Start()
    {
        //SecondPos();
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
        Vector3 pos = new Vector3(secondPoint.transform.position.x - 0.5f, transform.position.y, secondPoint.transform.position.z - 1);
        transform.DOMove(pos, 2).SetEase(Ease.Linear);
        transform.DORotate(new Vector3(45, 25, 0), 2).SetEase(Ease.Linear);
    }
}
