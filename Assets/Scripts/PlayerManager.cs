using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    private void Awake()
    {
        isGameOver = false;
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene("game");
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
            gameOverScreen.SetActive(true);
            AudioManager.instance.Stop("MusicaFondo");
        }
    }
}
