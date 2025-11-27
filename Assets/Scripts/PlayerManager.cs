using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;

    [Header("Referencias")]
    public timer timerScript;
    public TMPro.TMP_Text currentScoreText;
    public TMPro.TMP_Text bestScoreText;
    private void Awake()
    {
        isGameOver = false;
    }

   // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("MusicaFondo");
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        // Evitar que todo se ejecute más de una vez
        if (!gameOverScreen.activeSelf)
        {
            // Guardar tiempo de la partida
            timerScript.SaveTimeAsScore();

            // Mostrar la pantalla
            gameOverScreen.SetActive(true);

            // Música
            AudioManager.instance.Stop("MusicaFondo");

            // Actualizar textos
            MostrarTiempoActual();
            MostrarHighScore();
        }
    }

    private void MostrarTiempoActual()
    {
        float time = timerScript.timerElapsed;

        int min = (int)(time / 60f);
        int sec = (int)(time - min * 60f);
        int cen = (int)((time - (int)time) * 100f);

        currentScoreText.text = $"Sobreviviste: {min:00}:{sec:00}:{cen:00}";
    }

    private void MostrarHighScore()
    {
        float best = HighScoreManager.GetHighScore();

        int min = (int)(best / 60f);
        int sec = (int)(best - min * 60f);
        int cen = (int)((best - (int)best) * 100f);

        bestScoreText.text = $"High Score: {min:00}:{sec:00}:{cen:00}";
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene("game");
    }
}

