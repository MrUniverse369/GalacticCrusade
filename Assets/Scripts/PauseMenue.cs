using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GalacticCrusadeVolTwo
{
    public class PauseMenue : MonoBehaviour

    {

        private void Start()
        {
        }

        private GameObject pauseMenue;


        //  private void GameOverScreen()
        //    {
        //   if (PlayerController.pLives <= 0)
        // {
        //  Time.timeScale = 0;
        //  gameOverScreen.SetActive(true);
        //   }
        // else { gameOverScreen.SetActive(false); }
        // }


        public void RestartGame()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }

        public void LoadMainMenue()
        {
            SceneManager.LoadScene(0);
            MainMenue.resumeGame = true;
        }

        public void ResumeGame()
        {
            MainMenue.resumeGame = true;
            Time.timeScale = 1;
            gameObject.SetActive(false);

        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Time.timeScale = 0;
                MainMenue.resumeGame = false;
                this.gameObject.SetActive(true);
            }
        }
    }
}
