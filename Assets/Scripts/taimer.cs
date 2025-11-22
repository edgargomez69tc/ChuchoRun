using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    private float timerElapsed;
    private int minute, seco, cents;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timerElapsed += Time.deltaTime;
        minute = (int)(timerElapsed / 60f);
        seco = (int)(timerElapsed - minute * 60f);
        cents = (int)((timerElapsed - (int)timerElapsed) * 100f);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minute, seco, cents);
    }
}