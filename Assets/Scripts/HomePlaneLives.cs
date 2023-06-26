using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HomePlaneLives : MonoBehaviour
{
    public Text HomePlanetLivesCount;


    public static int shieldCount;
    // Start is called before the first frame update
    void Start()
    {
        shieldCount = 10;
        HomePlanetLivesCount.text = "HomePlanetShield:" + shieldCount;
    }

    // Update is called once per frame
    void Update()
    {
        HomePlanetLivesCount.text = "HomePlanetShield:" + shieldCount;

    }
}
