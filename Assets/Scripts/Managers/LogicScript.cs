using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;

    public GameObject[] Nitro;
    
    public int maxNitroCount = 3;
    public int nitroCount = 0;

    public bool isGameRunning = false;

    
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    
    public void addNitro(int NitroToAdd)
    {
        if (nitroCount <= maxNitroCount)
        {
            nitroCount += NitroToAdd;

            if (nitroCount > maxNitroCount)
            {
                nitroCount = maxNitroCount;
            }

            for (int i = 0; i < nitroCount; i++)
            {
                Nitro[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }           
        } 
    }

    public void removeNitro(int NitroToRemove)
    {
        if(nitroCount > 0)
        {
            nitroCount -= NitroToRemove;
            if (nitroCount < 0)
            {
                nitroCount = 0;
            }

            Nitro[nitroCount].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

            /*for (int i = maxNitroCount - 1; i >= nitroCount; i--)
            {
                Nitro[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            }*/

        }
    }

    public bool isNitroAvailable()
    {
        return nitroCount > 0;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isGameRunning = true;
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        isGameRunning = false;
    }       

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Nitro = new GameObject[] {
            GameObject.FindGameObjectWithTag("Nitro1"), 
            GameObject.FindGameObjectWithTag("Nitro2"), 
            GameObject.FindGameObjectWithTag("Nitro3")
        };
        gameOverScreen.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
