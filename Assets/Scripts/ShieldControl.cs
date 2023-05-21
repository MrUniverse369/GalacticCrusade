using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GalacticCrusadeVolTwo
{
    public class ShieldControl : MonoBehaviour
    {
        public static int shieldLives = 6;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //
            transform.Rotate(new Vector3(0, 0, 250 * Time.deltaTime));
            if (shieldLives <= 0)
            {
                gameObject.SetActive(false);
                PlayerController.shieldOn = false;
            }


        }
    }
}