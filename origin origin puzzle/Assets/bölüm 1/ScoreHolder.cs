using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHolder : MonoBehaviour
{
    Text score;
    Text Highscore;
  
    public int highscore=0;
   

    // Start is called before the first frame update


    private void Awake()
    {
        
        if((astro_hareket.coins-6) > highscore)
        {
            
            highscore = (astro_hareket.coins-6);


        }


    }


    void Start()
    {
        score = GetComponent<Text>();
        Highscore = GetComponent<Text>();


        if (tag == "highscore")
        {

        Highscore.text = " " + highscore;


        }
        else if(tag == "score")
        {

        score.text = " "+ (astro_hareket.coins-6);
        }
        
        
    }

    
}
