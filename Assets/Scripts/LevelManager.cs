using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GalacticCrusadeVolTwo
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject pRef;
        [SerializeField] private GameObject enemyRef;
        [SerializeField] private Transform enemySpawnPos;
        [SerializeField] private GameObject tileRef;
        [SerializeField] private Transform tileSpawnPos;
        [SerializeField] private Transform camPos;
        [SerializeField] private GameObject shieldRef;
        [SerializeField] private GameObject rapidFireRef;
        [SerializeField] private Transform powerUpSpawnPos;
        [SerializeField] private double spawnDelayShield;
        [SerializeField] private double spawnDelayRapid;
        [SerializeField] private Image playerHealthUI;
        [SerializeField] private Sprite playHealthFull;
        [SerializeField] private Sprite playerHealth80;
        [SerializeField] private Sprite playerHealth60;
        [SerializeField] private Sprite playerHealth40;
        [SerializeField] private Sprite playerHealth20;
        [SerializeField] private Sprite playerHealth0;
        [SerializeField] private AudioClip itemPickSound;
        [SerializeField] private AudioClip pointGainedSound;
        public static int score;
        int sNum;
        private AudioSource aSref;
        private double lastSpawnPause;
        private GameObject[] tilePieces;
        [SerializeField] private double enemySpawnDelay;
        private double TileSpawnPause;
        private float randNum;
        // Start is called before the first frame update
        void Start()
        {
            aSref = GetComponent<AudioSource>();
            tilePieces = new GameObject[20];
            EnemySpawn();
            enemySpawnDelay = -1;
            lastSpawnPause = 4;
            spawnDelayRapid = 30;
            spawnDelayShield = 10;
            randNum = 0;
            tileRef = Instantiate(tileRef, tileSpawnPos.transform.position += new Vector3(0, 0, 0), Quaternion.identity);
            sNum = 0;

        }

        // Update is called once per frame
        void Update()
        {
            EnemySpawn();
            TileSpawn();
            PowerUpSpawn();
            UpdateHealth();
            PlaySoundEffects();
        }

        private void PlaySoundEffects()
        {
            if (PlayerController.powerObtained)
            {
                aSref.clip = itemPickSound;
                aSref.Play();
                PlayerController.powerObtained = false;
            }
            // not ideal re do this later suffice solution
            // for now basically we are checking to see if the player
            // has gained a point and then playing the sound if they do 
            if (score >= sNum)
            {
                aSref.clip = pointGainedSound;
                aSref.volume = 1f;
                aSref.Play();
                sNum = score + 1;
                Debug.Log("Pointgainedsound");
            }

        }
        private void UpdateHealth()
        {
            switch (PlayerController.pLives)
            {
                case 0:
                    playerHealthUI.sprite = playerHealth0;
                    break;
                case 1:
                    playerHealthUI.sprite = playerHealth20;
                    break;
                case 2:
                    playerHealthUI.sprite = playerHealth40;
                    break;
                case 3:
                    playerHealthUI.sprite = playerHealth60;
                    break;
                case 4:
                    playerHealthUI.sprite = playerHealth80;
                    break;
                case 5:
                    playerHealthUI.sprite = playHealthFull;
                    break;
                default:
                    break;
            }
        }
        private void EnemySpawn()
        {


            if (enemySpawnDelay < 0)
            {
                randNum = Random.Range(-6, 6);
                Instantiate(enemyRef, enemySpawnPos.transform.position = new Vector3(randNum, camPos.transform.position.y + 10, 0), Quaternion.identity);

                if (pRef.transform.position.y > 50)
                {
                    enemySpawnDelay = 1.5f;
                    lastSpawnPause = enemySpawnDelay;
                }

                if (pRef.transform.position.y > 100)
                {
                    enemySpawnDelay = 1.0f;
                    lastSpawnPause = enemySpawnDelay;
                }
                if (pRef.transform.position.y > 150)
                {
                    enemySpawnDelay = 1f;
                    lastSpawnPause = enemySpawnDelay;
                }
                if (pRef.transform.position.y > 250)
                {
                    enemySpawnDelay = 0.7f;
                    lastSpawnPause = enemySpawnDelay;
                }
                else { enemySpawnDelay = lastSpawnPause; }



            }

            enemySpawnDelay -= Time.deltaTime;

        }



        private void PowerUpSpawn()
        {


            if (spawnDelayShield < 0)
            {
                randNum = Random.Range(-6, 6);
                Instantiate(shieldRef, powerUpSpawnPos.transform.position = new Vector3(randNum, camPos.transform.position.y + 10, 0), Quaternion.identity);
                spawnDelayShield = Random.Range(50, 150);
            }

            spawnDelayShield -= Time.deltaTime;


            if (spawnDelayRapid < 0)
            {
                randNum = Random.Range(-6, 6);
                Instantiate(rapidFireRef, powerUpSpawnPos.transform.position = new Vector3(randNum, camPos.transform.position.y + 10, 0), Quaternion.identity);
                spawnDelayRapid = Random.Range(30, 100);


            }


            spawnDelayRapid -= Time.deltaTime;

        }


        private void TileSpawn()
        {


            if (TileSpawnPause < 0)
            {
                tileRef = Instantiate(tileRef, tileSpawnPos.transform.position += new Vector3(0, 14.5f, 0), Quaternion.identity);
                TileSpawnPause = 10;
            }


            TileSpawnPause -= Time.deltaTime;
        }


    }



}