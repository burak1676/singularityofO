using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camera_follow : MonoBehaviour
{
    public GameObject targetObject;
    
    public float kuvvet_katsayisi = 0.1f;
   /* public float Speed_karsila = astro_hareket.speed; */
    public float speed2;
    public static float hiz = 0; //kamera h�z� buras� 500f ideal
    public static Transform transform_camera;

    public float zaman;
    public float zaman2;

    public static int sayac;

    












    Rigidbody2D camera_rigit; //rigitbody'e bu nesne ile ula��caz


    public void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("hero"))
        {
         SceneManager.LoadScene("GameOver");

        }

        astro_hareket.rb_astro.gravityScale = astro_hareket.astronot_genel_hiz;

    }









    private void Start()
    {
        camera_rigit = GetComponent<Rigidbody2D>(); //yukar�da tan�mlad���m�z nesnenin ve 'rb' referans de�erinin nereyi referans alaca��n� burada belirttik 
        sayac = 0;
        hiz = 0f; //Hizi buradan de�i�tir 400f
        hap_ters.hap_yutma = 0;
        astro_hareket.astro_hiz = 1f; 
        

    }


    // Update is called once per frame

    private void FixedUpdate()
    {
        zaman += Time.deltaTime;
        if (hap_ters.hap_yutma == 1) //yani true' ise 
        {
            zaman2 += Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 180); //opsiyon 1
            
            if (zaman2 > 3)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            /* transform.localScale = new Vector3(1, -1, 1); */
        }
        
      /*  
        if (zaman > 10 && sayac == 0)
        {
            sayac++;
            astro_hareket.astro_hiz *= 1.2f; //buradan kamera h�z� il birlikte astronot h�z�n�da art�rm�� olduk 
            hiz *= 1.250f;
            camera_rigit.velocity = transform.right * hiz * Time.deltaTime; 
            Debug.Log("Hizlan !!!");
            /*  astro_hareket.rb_astro.gravityScale = 1.25f; */
     //   }
       /* if (zaman > 15 && sayac == 1)
        {
            sayac++;
            astro_hareket.astro_hiz *= 1.2f; //buradan kamera h�z� il birlikte astronot h�z�n�da art�rm�� olduk

            hiz *= 1.250f;
            camera_rigit.velocity = transform.right * hiz * Time.deltaTime;
            Debug.Log("Hizlan !!!");
            /*  astro_hareket.rb_astro.gravityScale = 1.25f; */
     //   }
     /*   if (zaman > 20 && sayac == 2)
        {
            sayac++;
            astro_hareket.astro_hiz *= 1.1f;
            hiz *= 1.250f;
            camera_rigit.velocity = transform.right * hiz * Time.deltaTime;
            Debug.Log("Hizlan !!!");
            /*  astro_hareket.rb_astro.gravityScale = 1.25f; */
    //    }
     /*   if (zaman > 25 && sayac == 3)
        {
            sayac++;
            astro_hareket.astro_hiz *= 1.1f;
            hiz *= 1.200f;
            camera_rigit.velocity = transform.right * hiz * Time.deltaTime;
            Debug.Log("Hizlan !!!");
            /* astro_hareket.rb_astro.gravityScale = 3.5f; //h�zland��� i�in fazla y�kseliyor buna �nlem olarak geli�tirildi*/
      //  }
        /*
        if (zaman > 30 && sayac == 4)
        { //30.sn'de tuhaf bir itme oluyor 
            sayac++;
            astro_hareket.astro_hiz *= 1.1f;
            hiz *= 1.200f;
            camera_rigit.velocity = transform.right * hiz * Time.deltaTime;
            Debug.Log("Hizlan !!!");
            
        }
        if (zaman > 40 && sayac == 5)
        {
            sayac++;
            astro_hareket.astro_hiz *= 1.2f; //buradan kamera h�z� il birlikte astronot h�z�n�da art�rm�� olduk 
            hiz *= 1.5f;
            camera_rigit.velocity = transform.right * hiz * Time.deltaTime;
            Debug.Log("Hizlan !!!");
            // astro_hareket.rb_astro.gravityScale = 4.2f;
        }
        */
        camera_rigit.velocity = transform.right * hiz * Time.deltaTime; //problemin sebebi buras�


    }
    private void Update()
    {
        
    }
    void LateUpdate()//Update fonksiyonu �al��t�ktan hemen sonra �al���yor 
    {



        /*camera_rigit.AddForce(transform.right * kuvvet_katsayisi);
        transform.position = targetObject.transform.position + camera_payi; //camera ile cisim aras�na pay b�rakt�k */
    }
}










 









