using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GalacticCrusadeVolTwo;
using UnityEngine.SceneManagement;

public class GameOverMenue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameOverScreen();

    }

    private void GameOverScreen()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
