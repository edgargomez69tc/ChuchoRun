using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestTimeDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text bestTimeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float bestTime = HighScoreManager.GetHighScore();
        bestTimeText.text = "High Score: " + HighScoreManager.FormatTime(bestTime);
    }
}
