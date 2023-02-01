using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class WordsSelectState : WordsBaseState
{
    CamLook camLook;
    public override void EnterState(WordsStateManager words)
    {
        camLook = GameObject.FindObjectOfType<CamLook>().GetComponent<CamLook>();
    }

    public override void UpdateState(WordsStateManager words)
    {
        if (words.finishGround.layer == 6)
        {
            words.point = new Vector3(words.finishGround.transform.position.x, words.polar.transform.position.y, words.finishGround.transform.position.z);
            words.camLook.enabled = true;
            words.SwitchState(words.finishState);
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, words.wordMask) && camLook.enabled == false)
            {
                hit.transform.GetComponent<Renderer>().material.color = Color.green;

                words.ýnputWord.text = words.ýnputWord.text + hit.transform.name;

                words.words.Add(hit.transform.gameObject);
                hit.transform.gameObject.layer = 9;
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, words.wordSelectMask) && camLook.enabled == false)
            {
                hit.transform.gameObject.layer = 3;
                hit.transform.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);

                var word = words.ýnputWord.text.ToCharArray();

                for (int i = 0; i < word.Length; i++)
                {
                    words.myWord.Add(word[i].ToString());
                }

                words.myWord.Remove(hit.transform.name);
                words.ýnputWord.text = "";

                for (int i = 0; i < words.myWord.Count; i++)
                {
                    words.ýnputWord.text = words.ýnputWord.text + words.myWord[i];
                }
                words.myWord.Clear();
                words.words.Remove(hit.transform.gameObject);
            }
        }
    }
}
