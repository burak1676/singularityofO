using System.Collections; //Namespaces : kod içerisinde kullanacaðýmýz çeþitli unsurlar 
using System.Collections.Generic;
using UnityEngine; //unity ile haberleþebilmek için gerekli olan fonksiyonlarýn sýnýflarýn bulunduðu namespace'dir 
using UnityEngine.SceneManagement;
public class astro_hareket : MonoBehaviour //MonoBehavior'dan türetilmiþ aslýnda sizin eklediðiniz her bir c# dosyasý arkada hazýr bir c# dosyasýndan türetülüp buraya konuluyor
{
    public AudioSource ads;
    
    public AudioSource adsUfo;
    public AudioSource adsHap;
    Animator animator;
    public GameObject canbar;
    public float benzin;
    public static float astronot_genel_hiz = 1f;
    public float yatay=1000;
    protected Joystick joystick;
    protected Joybutton joybutton;
    static Renderer rend;
    public bool isDead = false;
    public static int coins;
    public static float hiz_katsayisi = 0.3f; //kofti
    public float gravity_scale = 1f;
    public static Rigidbody2D rb_astro; //Astronotumun üzerinde bir rigitbody var evet fakat ben ona oyun içersinden kod içersinden nasýl müdehale edeceðim rigit body cinsinden bir referans sayesinde 
    public SpriteRenderer sprite;
    int kontrol = 0; //false 
    public float kuvvet_katsayisi_uydunun = 5f;
    public static float astro_hiz = astronot_genel_hiz;

    public float benzin_miktar;
    

    public static float speed=1f; //hýzý buradan ayarlayabilirsiniz.
    // Start is called before the first frame update
    void Start() //guncelleme methodlarýndan herhangi birisi çaðýrýlmadan önce start fonksiyonu çaðýrýlýr oyun baþladýðýnda sadece ve sadece bir kez çalýþacak fonksiyonlarýn yerleþtirildiði yer
    {
        animator = GetComponent<Animator>();
        astronot_genel_hiz = 1f;
        gravity_scale = 1f;
        isDead = false;
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
        // örneðin oyun baþlangýç müziði
        rend = GetComponent<Renderer>();
        sprite = GetComponent<SpriteRenderer>();
        benzin_miktar = 1f;
        hiz_katsayisi = 0.3f;
    }

    // Update is called once per frame
    void Update()// Oyun baþlatýldýktan sonraki aþamalarda her bir oyun karesini oluþturulmasý için her seferinde bu update fonksiyonu çalýþtýrýlýr frame baþlarken çalýþtýrýlýr
    {
        rb_astro = GetComponent<Rigidbody2D>();
        /* speed = rb.velocity.magnitude; */ //anlýk olarak hýz almak için
        benzin = 1;
    }

    private void FixedUpdate()
    {
        animator.SetBool("yere_indi", false);
       /* if (benzin_miktar > 0)
        {
            benzin_miktar -= 0.0001f;
            canbar.transform.localScale = new Vector3(benzin_miktar, 1, 1);
        }*/
        

        /*hiz_katsayisi = 0.3f;*/
        float yatay = Input.GetAxis("Horizontal"); //Yatay diye bir deðiþken oluþturduk buna da Input'dan gelen horizontali atadýk amaç ekranda sað sol tuþlarýna basarak bir karakteri harket ettirmek 
                                                   //Yatayda olan hareketlerimizi tanýmlamak için input managerden alan girdileri alacaðýmýz bir komut ýnput manager'de name kýsmýnda yazan Horizontal'ý kullandýk
        float dikey = Input.GetAxis("Vertical");

        
        if(benzin_miktar <= 0)
        {
            astro_hiz = 0f;
            hiz_katsayisi = 0f;
            astronot_genel_hiz = 0f;
            gravity_scale = 10f;
        }

       /* Input.GetAxis("Horizontal"); // Bunu if ile kullanarak -1'e ve +1'e eþit olduðu durumlar için butonlar olusturabilir hýzlanmayan astronotu hýzlandýrabilirsin video kaydettin dinle unuttuysan */

       /* if (joystick.Horizontal > 0)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1);
            transform.position += new Vector3(astro_hiz * hiz_katsayisi, 0, 0); //x ekseninde hýzlanma
        }
        else if (joystick.Horizontal < 0)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1);
            transform.position += new Vector3(-astro_hiz * hiz_katsayisi, 0, 0); //x ekseninde hýzlanma
        } */

        /*if(dikey>0)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
        else if (dikey < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }*/

        Debug.Log(yatay); //Console.WriteLine' a benzer mantýkta bunun unity kütüphanesindeki karþýlýðýda Debug.Log()'dur . Bunun baþka çýktýlar veren çeþitleri de vardýr.
                          //frameler arasýndaki zaman farkýnýn eþit olmasýný saðlar. Bu kod sayesinde horizontal deðiþkeni unity ekranýnda rahat bir þekilde okuyoruz. Peki bu horizontal deðiþkeni nasýl deðerlendirecez 


       /* transform.position += new Vector3(yatay * hiz_katsayisi, 0, 0); */// iliþkili nesnenin mevcut konumunu tutan 'transform.position' deðiþkene ulaþýyoruz. Sonra bunun deðerini deðiþtirmek için üzerine gelip veri yapýsýna bakýyoruz 
                                                                        //Vector3 olduðunu öðrendikten sonra konumu deðiþtirmek için Debug.Log'un etki ettiði yatay deðiþkenini x'eksenine referans olarak koyuyoruz ve astronot nesnemizi a-d ve <-  -> yön tuþlarýyla hareket ettirebilir bir hale sokuyoruz.

        //Deðerler çok hýzlý bir þekilde deðiþtiði için ýþýnlanma olarak adlandýrýlan durumla karþýlaþýyoruz bunu düzenlemek için ise þunu yapmalýyýz. transform.position '+=' new Vector3(yatay, 0, 0);

        transform.position += new Vector3(0, speed * hiz_katsayisi, 0); //zýplama

        
       /* transform.position += new Vector3(joystick.Horizontal * hiz_katsayisi, 0, 0); //x ekseninde hýzlanma */


    }

    void Awake()
    {

    }


    /* private void OnCollisionEnter2D(Collision2D collision)//2D fizik fonksiyonlarý tarafýndan hesaplanýp geri döndürülen çarpýþma ayracý. Hangi cisimler çarpýþýyor ne kadar süre çarpýþýyor bunun gibi tüm fizik hesaplarýnýn sonuçlarý
     {                                                      // Bu Collesion2D sýnýfýndan üretilen collision nesnesi içersinde bize geri döndürülüyor 
         Debug.Log("Astronot carpti");
     }//Çarpýþma baþladýðýnda ne yapýlacaðý altýna yazýlýr 
     */


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "platform")
        {
            Debug.Log("denenefsdfasdfsasdasfsdfasdfasdfdasfasdfsdfasfasfdasdfasfsfsf");
            animator.SetBool("yere_indi", true);
            ads.Play();
            
        }
        

        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       
        


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            
        
        if(collision.tag == "coins")
        {
            if ( benzin_miktar < 1f)
            {
                coins++;
                benzin_miktar += 0.05f;
                Debug.Log("Coin toplandi !!! ");
                // Tepkimeye giren gameObject'e eriþip yok ediyoruz  
                                               //rend.material.color = Color.black;//
                canbar.transform.localScale = new Vector3(benzin_miktar, 1, 1);

                adsHap.Play();

            }
            
            Destroy(collision.gameObject);


        }
        if(collision.tag == "ufo" && kontrol == 0)
        {
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; //statik olan öðeyi Dynamic yapar 
            rb_astro.gravityScale = -1f; 
            kontrol = 1;
            adsUfo.Play();

        }
        
        else if(collision.tag == "ufo" && kontrol == 1)
        {
            
            rb_astro.gravityScale = gravity_scale; //normal gravity scale'si 
            
            kontrol = 0;
        }
        if (collision.tag == "uydu" && kontrol == 0)
        {
           
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; //statik olan öðeyi Dynamic yapar 
              rb_astro.gravityScale = -1f; 
            kontrol = 1;
            
            
        } 

        else if (collision.tag == "uydu" && kontrol == 1)
        {
           
            rb_astro.gravityScale = gravity_scale; //normal gravity scale'si 
            kontrol = 0;
            /*speed =+ rb.velocity.magnitude; Iþýnlama  */
        }
        if(collision.tag == "uydunun_platformu" )
        {
            rb_astro.gravityScale = gravity_scale; //normal gravity scale'si 
        }  

        if (collision.tag == "background")
        {
            //burada is dead true yap 

            isDead = true;
            SceneManager.LoadScene("GameOver");


        }




    }
   /* private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ufo")
        {
            Debug.Log("Burasi calisti");
            transform.position = new Vector3(transform.position.x, transform.position.y, 5);
            sprite.sortingOrder = -5; //order'in layer deðiþti 

        }

        
    }*/



   

}

