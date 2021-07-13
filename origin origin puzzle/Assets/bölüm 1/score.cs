using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class score : MonoBehaviour
{
    Text s;
    public float score_miktar = 0;
    void Start()
    {
        s = GetComponent<Text>();
        astro_hareket.coins = 6;
    }

    // Update is called once per frame
    void Update()
    {
        score_miktar += Time.deltaTime*50;

       

        

        s.text = "Score:" + (((int)score_miktar));


        /*if ((astro_hareket.coins) % 5 == 0)
        {
            Debug.Log("oyun hizlaniyor!");
            camera_follow.hiz += 0.1f;

        } */
    }
}
