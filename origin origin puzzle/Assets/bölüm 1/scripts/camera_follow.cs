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
    public static float hiz = 0; //kamera hýzý burasý 500f ideal
    public static Transform transform_camera;

    public float zaman;
    public float zaman2;

    public static int sayac;

    












    Rigidbody2D camera_rigit; //rigitbody'e bu nesne ile ulaþýcaz


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
        camera_rigit = GetComponent<Rigidbody2D>(); //yukarýda tanýmladýðýmýz nesnenin ve 'rb' referans deðerinin nereyi referans alacaðýný burada belirttik 
        sayac = 0;
        hiz = 0f; //Hizi buradan deðiþtir 400f
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
            astro_hareket.astro_hiz *= 1.2f; //buradan kamera hýzý il birlikte astronot hýzýnýda artýrmýþ olduk 
            hiz *= 1.250f;
            camera_rigit.velocity = transform.right * hiz * Time.deltaTime; 
            Debug.Log("Hizlan !!!");
            /*  astro_hareket.rb_astro.gravityScale = 1.25f; */
     //   }
       /* if (zaman > 15 && sayac == 1)
        {
            sayac++;
            astro_hareket.astro_hiz *= 1.2f; //buradan kamera hýzý il birlikte astronot hýzýnýda artýrmýþ olduk

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
            /* astro_hareket.rb_astro.gravityScale = 3.5f; //hýzlandýðý için fazla yükseliyor buna önlem olarak geliþtirildi*/
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
            astro_hareket.astro_hiz *= 1.2f; //buradan kamera hýzý il birlikte astronot hýzýnýda artýrmýþ olduk 
            hiz *= 1.5f;
            camera_rigit.velocity = transform.right * hiz * Time.deltaTime;
            Debug.Log("Hizlan !!!");
            // astro_hareket.rb_astro.gravityScale = 4.2f;
        }
        */
        camera_rigit.velocity = transform.right * hiz * Time.deltaTime; //problemin sebebi burasý


    }
    private void Update()
    {
        
    }
    void LateUpdate()//Update fonksiyonu çalýþtýktan hemen sonra çalýþýyor 
    {



        /*camera_rigit.AddForce(transform.right * kuvvet_katsayisi);
        transform.position = targetObject.transform.position + camera_payi; //camera ile cisim arasýna pay býraktýk */
    }
}










 









