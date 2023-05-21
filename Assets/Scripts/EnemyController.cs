using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GalacticCrusadeVolTwo
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform rightbulletSpawnPos;
        [SerializeField] private Transform leftbulletSpawnPos;
        [SerializeField] private float speed;
        [SerializeField] private int lives;
        private double spawnPause;


        // Start is called before the first frame update
        void Start()
        {
            spawnPause = -1;


        }

        // Update is called once per frame
        void Update()
        {
            Shoot();
            movement();
            DestroyEnemy();

        }
        private void DestroyEnemy()
        {
            Destroy(this.gameObject, 15f);
            if (lives <= 0)
            {
                Destroy(gameObject);
                LevelManager.score += 1;
            }
        }

        private void Shoot()
        {

            if (spawnPause < 0)
            {


                Instantiate(bullet, rightbulletSpawnPos.transform.position, Quaternion.identity);
                Instantiate(bullet, leftbulletSpawnPos.transform.position, Quaternion.identity);

                spawnPause = 1.0;
            }

            spawnPause -= Time.deltaTime;

        }


        void movement()
        {
            transform.position += new Vector3(0, -3 * Time.deltaTime, 0);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
                LevelManager.score += 1;

            }

            if (collision.gameObject.CompareTag("Shield"))
            {
                ShieldControl.shieldLives -= 1;
                Destroy(gameObject);
                LevelManager.score += 1;

            }

            if (collision.gameObject.CompareTag("PlayerBullet"))
            {
                lives -= 1;

            }
        }
    }
}