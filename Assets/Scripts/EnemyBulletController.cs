using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GalacticCrusadeVolTwo
{
    public class EnemyBulletController : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            transform.position += new Vector3(0, -4 * Time.deltaTime, 0);
            Destroy(this.gameObject, 3f);

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
            }

            if (collision.gameObject.CompareTag("PlayerBullet"))
            {
                Destroy(gameObject);
            }

            if (collision.gameObject.CompareTag("Shield"))
            {
                ShieldControl.shieldLives -= 1;
                Destroy(gameObject);
            }
        }
    }
}