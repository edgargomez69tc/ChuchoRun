using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class vidaJugador : MonoBehaviour
{
    public static int vida = 3;
    public static int vidaMaxima = 3;

    public Image[] bolillos;
    private GameObject checkPoint;
    public Sprite fullBolillo;
    public Sprite emptyBolillo;


 
    private void Awake()
    {
        vida = vidaMaxima;
    }

    void Start()
    {
       

        checkPoint = GameObject.FindGameObjectWithTag("checkPoint");

        
    }

    void Update()
    {
        foreach (Image img in bolillos)
        {
            img.sprite = emptyBolillo;
        }

        for (int i = 0; i < vida; i++)
        {
            bolillos[i].sprite = fullBolillo;
        }
      
    }
}