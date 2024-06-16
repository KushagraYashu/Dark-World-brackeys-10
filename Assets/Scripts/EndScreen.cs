using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public GameObject creditsScreen;

    public bool yes = false;
    
    public TextMeshProUGUI timer;

    public float timerVal;

    private void Start()
    {
        timerVal = GetComponent<PipeBehaviour>().delayTime;
    }

    private void Update()
    {
        if(timerVal > 0 && yes)
        {
            timerVal -= Time.deltaTime;
            timer.text = timerVal.ToString("F2");
        }
       
    }

    public void Credits()
    {
        creditsScreen.SetActive(true);
    }

    public void Next(GameObject next)
    {
        next.SetActive(true);
    }

}
