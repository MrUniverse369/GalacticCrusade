using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GalacticCrusadeVolTwo
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private PlayerController pRef;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            CameraMovement();
        }

        private void CameraMovement()
        {
            transform.position += new Vector3(0, pRef.YSpeed * Time.deltaTime, 0); ;
        }
    }
}