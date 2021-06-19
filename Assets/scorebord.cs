using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class scorebord : MonoBehaviour
{
    public TMP_Text TimeDisplay;
    public TMP_Text ScoreDisplay;
    public int sTime = 0;
    public int score = 0;
    public bool stop = false;

    public static scorebord instance { get; private set; }

   
    private void Start()
    {
        instance = this;
        StartCoroutine(TimeCount());
    }

    public void ScoreUpdate()
    {
        score += 10;
        ScoreDisplay.text = score.ToString();
    }

    IEnumerator TimeCount()
    {
        while (!stop)
        {

            TimeDisplay.text = sTime.ToString();

            yield return new WaitForSeconds(1f);

            sTime++;

        }
    }

}
