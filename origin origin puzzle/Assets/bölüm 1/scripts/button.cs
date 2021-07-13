using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    bool sol, sag;
    

    

    void Start()
    {
        astro_hareket.astro_hiz = astro_hareket.astronot_genel_hiz;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(sol)
        {
            transform.localScale = new Vector3(1.084042f, 1.084042f, 1);
            transform.position += new Vector3(-astro_hareket.astro_hiz * astro_hareket.hiz_katsayisi, 0, 0);
        }
        if(sag)
        {
            transform.localScale = new Vector3(1.084042f, 1.084042f, 1);
            transform.position += new Vector3(astro_hareket.astro_hiz * astro_hareket.hiz_katsayisi, 0, 0);
        }


        

    }
    public void solbas()
    {
        sol = true;
    }

    public void solcek()
    {
        sol = false;
    }

    public void sagbas()
    {
        sag = true;
    }

    public void sagcek()
    {
        sag = false;

    }

   



}
