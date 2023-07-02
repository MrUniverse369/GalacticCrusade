using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GalacticCrusadeVolTwo
{
    public class MainMenue : MonoBehaviour
    {

        [SerializeField] private GameObject playerRef;
        [SerializeField] private GameObject pauseMenueUI;
        [SerializeField] private GameObject gameOverUI;
        static public bool resumeGame = true;


        private void Start()
        {

        }


        public void RestartGame()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }

        public void LoadLevelOne()
        {
            SceneManager.LoadScene(1);
        }

        public void LoadMainMenue()
        {
            SceneManager.LoadScene(0);
            resumeGame = true;
        }



        public void EndGame()
        {
            Application.Quit();
            Debug.Log("Application Closed");
        }

        private void Update()
        {


            if (Input.GetKey(KeyCode.Escape))
            {
                Time.timeScale = 0;
                resumeGame = false;
                pauseMenueUI.SetActive(true);
                Debug.Log("PauseMenueActives");
            }
            if (resumeGame)
            {
                Time.timeScale = 1f;
            }
            if (HomePlaneLives.shieldCount < 1 || PlayerController.pLives < 1)
            {
                gameOverUI.SetActive(true);
                Debug.Log("Game over Ui is On ");
            }
        }
    }
}