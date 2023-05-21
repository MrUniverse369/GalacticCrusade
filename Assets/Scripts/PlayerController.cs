using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GalacticCrusadeVolTwo
{

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float ySpeed;
        [SerializeField] private float xSpeed;
        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform bulletPos;
        [SerializeField] private Transform bulletPosTwo;
        [SerializeField] private GameObject shieldRef;
        [SerializeField] private Transform LeftBullet1;
        [SerializeField] private Transform LeftBullet2;
        [SerializeField] private Transform rightBullet1;
        [SerializeField] private Transform rightBullet2;
        [SerializeField] private double powerUpCoolDown;
        [SerializeField] private double rapidFireLifeTime;
        private bool rapidFireOn;
        static public bool shieldOn;
        static public bool powerObtained;
        public static int pLives;
        private double spawnPause;
        private float xAxis;
        private Vector3 vel;
        bool stopHmovement;
        public bool PlayerShot { get; set; }
        public float XSpeed
        {
            get { return xSpeed; }
            set { xSpeed = value; }
        }
        public float YSpeed
        {
            get { return ySpeed; }
            set { ySpeed = value; }
        }


        // Start is called before the first frame update
        void Start()
        { 
            pLives = 5;
            rb2d = GetComponent<Rigidbody2D>();
            stopHmovement = false;
            spawnPause = -1;
            shieldOn = false;
            powerUpCoolDown = -1;
            rapidFireOn = false;
        }

        // Update is called once per frame
        void Update()
        {
            ShieldPowerUp();
            PlayerMovement();
            PlayerDeath();

            if (rapidFireOn && rapidFireLifeTime > 0)
            {
                PowerUpShoot();
                rapidFireLifeTime -= 1 * Time.deltaTime;
            }
            else
            {
                rapidFireLifeTime = 0;
                rapidFireOn = false;
            }


            if (spawnPause <= 0)
            {

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("Space Bar pressed");
                    Shoot();
                    spawnPause = 0.3;

                }
            }

            if (spawnPause <= 0)
            {
                Shoot();
                spawnPause = 0.3;
            }


            spawnPause -= Time.deltaTime;
        }
        private void PowerUpShoot()
        {
            if (powerUpCoolDown < 0)
            {
                Instantiate(bullet, LeftBullet1.transform.position, Quaternion.identity);
                Instantiate(bullet, LeftBullet2.transform.position, Quaternion.identity);
                Instantiate(bullet, rightBullet1.transform.position, Quaternion.identity);
                Instantiate(bullet, rightBullet2.transform.position, Quaternion.identity);
                powerUpCoolDown = 2;
            }

            powerUpCoolDown -= 10 * Time.deltaTime;
        }


        private void ShieldPowerUp()
        {
            if (shieldOn)
            {
                shieldRef.SetActive(true);
            }
        }

        private void PlayerDeath()
        {
            if (pLives <= 0)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
        private void PlayerMovement()
        {
            //player should always be consistently moving forwards at a set pace;
            transform.position += new Vector3(0, ySpeed * Time.deltaTime);
            xAxis = Input.GetAxisRaw("Horizontal");
            vel = new Vector3(xAxis * xSpeed * Time.deltaTime, rb2d.velocity.y);
            if (!stopHmovement)
            {
                transform.position += vel;
            }

        }

        private void Shoot()
        {


            Instantiate(bullet, bulletPos.transform.position, Quaternion.identity);
            // Instantiate(bullet, bulletPosTwo.transform.position, Quaternion.identity);




        }



        // make it so when player hits the wall the vel on the
        // left side is 0 and they can only move the to the right side 
        private void OnTriggerEnter2D(Collider2D collision)

        {
            if (collision.gameObject.CompareTag("ShieldPickUp"))
            {
                Debug.Log("SHIELD PICKED UP !!");
                shieldOn = true;
                ShieldControl.shieldLives = 5;
                powerObtained = true;
            }

            if (collision.gameObject.CompareTag("RapidFirePickUp"))
            {
                Debug.Log("GUN PICKED UP !!");
                rapidFireOn = true;
                //ShieldControl.shieldLives = 5;
                rapidFireLifeTime = 15;
                powerObtained = true;
            }

            if (collision.gameObject.CompareTag("Enemy") && shieldOn != true)
            {
                Debug.Log("Enemy HIT ME !");
                pLives -= 1;
            }

            if (collision.gameObject.CompareTag("EnemyBullet") && shieldOn != true)
            {
                Debug.Log("Enemy SHOT ME !");
                pLives -= 1;
            }

            //check to see if i have reached the edge of the screen and touched the invisble walls;
            if (xAxis < 1 && collision.gameObject.CompareTag("LeftWall"))
            {
                Debug.Log("We have hit the left wall");
                stopHmovement = true;

            }

            if (xAxis == 1 && collision.gameObject.CompareTag("RightWall"))
            {
                Debug.Log("We have hit the Right wall");
                stopHmovement = true;

            }


        }


        private void OnTriggerStay2D(Collider2D collision)
        {
            if (xAxis < 1 && collision.gameObject.CompareTag("LeftWall"))
            {
                Debug.Log("We have hit the left wall");
                stopHmovement = true;

            }

            if (xAxis == 1 && collision.gameObject.CompareTag("RightWall"))
            {
                Debug.Log("We have hit the Right wall");
                stopHmovement = true;

            }


            //stop player from going off map 

            if (collision.gameObject.CompareTag("LeftWall"))
            {
                if (xAxis >= 0)
                {
                    stopHmovement = false;
                }
            }

            if (collision.gameObject.CompareTag("RightWall"))
            {
                if (xAxis <= 0)
                {
                    stopHmovement = false;
                }
            }



        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            stopHmovement = false;
        }

    }
}