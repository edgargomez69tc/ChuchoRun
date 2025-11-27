using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighScoreManager
{
    private const string HighScoreKey = "HighScore";

    public static float GetHighScore()
    {
        return PlayerPrefs.GetFloat(HighScoreKey, 0f);
    }

    public static void SaveHighScore(float value)
    {
        
        if (value > GetHighScore())
        {
            PlayerPrefs.SetFloat(HighScoreKey, value);
            PlayerPrefs.Save();
        }
    }
    public static string FormatTime(float timeSeconds)
    {
        int minutes = (int)(timeSeconds / 60f);
        int seconds = (int)(timeSeconds - minutes * 60f);
        int cents = (int)((timeSeconds - (int)timeSeconds) * 100f);

        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, cents);
    }
}
