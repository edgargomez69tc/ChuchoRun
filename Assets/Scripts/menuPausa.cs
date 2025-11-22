using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPausa : MonoBehaviour
{
    [SerializeField] private GameObject bPausa;
    [SerializeField] private GameObject menPausa;
    private bool juegoPausa = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausa)
            {
                resum();
            }
            else
            {
                pause();
            }
        }
    }

    public void pause()
    {
        juegoPausa = true;
        Time.timeScale = 0f;
        bPausa.SetActive(false);
        menPausa.SetActive(true);
    }

    public void resum()
    {
        juegoPausa = false;
        Time.timeScale = 1f;
        bPausa.SetActive(true);
        menPausa.SetActive(false);
    }

    public void restart()
    {
        juegoPausa = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void exit()
    {
        Debug.Log("Pal Menu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        //Application.Quit();
    }
}
