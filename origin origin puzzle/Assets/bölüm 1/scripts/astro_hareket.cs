using System.Collections; //Namespaces : kod i�erisinde kullanaca��m�z �e�itli unsurlar 
using System.Collections.Generic;
using UnityEngine; //unity ile haberle�ebilmek i�in gerekli olan fonksiyonlar�n s�n�flar�n bulundu�u namespace'dir 
using UnityEngine.SceneManagement;
public class astro_hareket : MonoBehaviour //MonoBehavior'dan t�retilmi� asl�nda sizin ekledi�iniz her bir c# dosyas� arkada haz�r bir c# dosyas�ndan t�ret�l�p buraya konuluyor
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
    public static Rigidbody2D rb_astro; //Astronotumun �zerinde bir rigitbody var evet fakat ben ona oyun i�ersinden kod i�ersinden nas�l m�dehale edece�im rigit body cinsinden bir referans sayesinde 
    public SpriteRenderer sprite;
    int kontrol = 0; //false 
    public float kuvvet_katsayisi_uydunun = 5f;
    public static float astro_hiz = astronot_genel_hiz;

    public float benzin_miktar;
    

    public static float speed=1f; //h�z� buradan ayarlayabilirsiniz.
    // Start is called before the first frame update
    void Start() //guncelleme methodlar�ndan herhangi birisi �a��r�lmadan �nce start fonksiyonu �a��r�l�r oyun ba�lad���nda sadece ve sadece bir kez �al��acak fonksiyonlar�n yerle�tirildi�i yer
    {
        animator = GetComponent<Animator>();
        astronot_genel_hiz = 1f;
        gravity_scale = 1f;
        isDead = false;
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
        // �rne�in oyun ba�lang�� m�zi�i
        rend = GetComponent<Renderer>();
        sprite = GetComponent<SpriteRenderer>();
        benzin_miktar = 1f;
        hiz_katsayisi = 0.3f;
    }

    // Update is called once per frame
    void Update()// Oyun ba�lat�ld�ktan sonraki a�amalarda her bir oyun karesini olu�turulmas� i�in her seferinde bu update fonksiyonu �al��t�r�l�r frame ba�larken �al��t�r�l�r
    {
        rb_astro = GetComponent<Rigidbody2D>();
        /* speed = rb.velocity.magnitude; */ //anl�k olarak h�z almak i�in
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
        float yatay = Input.GetAxis("Horizontal"); //Yatay diye bir de�i�ken olu�turduk buna da Input'dan gelen horizontali atad�k ama� ekranda sa� sol tu�lar�na basarak bir karakteri harket ettirmek 
                                                   //Yatayda olan hareketlerimizi tan�mlamak i�in input managerden alan girdileri alaca��m�z bir komut �nput manager'de name k�sm�nda yazan Horizontal'� kulland�k
        float dikey = Input.GetAxis("Vertical");

        
        if(benzin_miktar <= 0)
        {
            astro_hiz = 0f;
            hiz_katsayisi = 0f;
            astronot_genel_hiz = 0f;
            gravity_scale = 10f;
        }

       /* Input.GetAxis("Horizontal"); // Bunu if ile kullanarak -1'e ve +1'e e�it oldu�u durumlar i�in butonlar olusturabilir h�zlanmayan astronotu h�zland�rabilirsin video kaydettin dinle unuttuysan */

       /* if (joystick.Horizontal > 0)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1);
            transform.position += new Vector3(astro_hiz * hiz_katsayisi, 0, 0); //x ekseninde h�zlanma
        }
        else if (joystick.Horizontal < 0)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1);
            transform.position += new Vector3(-astro_hiz * hiz_katsayisi, 0, 0); //x ekseninde h�zlanma
        } */

        /*if(dikey>0)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
        else if (dikey < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }*/

        Debug.Log(yatay); //Console.WriteLine' a benzer mant�kta bunun unity k�t�phanesindeki kar��l���da Debug.Log()'dur . Bunun ba�ka ��kt�lar veren �e�itleri de vard�r.
                          //frameler aras�ndaki zaman fark�n�n e�it olmas�n� sa�lar. Bu kod sayesinde horizontal de�i�keni unity ekran�nda rahat bir �ekilde okuyoruz. Peki bu horizontal de�i�keni nas�l de�erlendirecez 


       /* transform.position += new Vector3(yatay * hiz_katsayisi, 0, 0); */// ili�kili nesnenin mevcut konumunu tutan 'transform.position' de�i�kene ula��yoruz. Sonra bunun de�erini de�i�tirmek i�in �zerine gelip veri yap�s�na bak�yoruz 
                                                                        //Vector3 oldu�unu ��rendikten sonra konumu de�i�tirmek i�in Debug.Log'un etki etti�i yatay de�i�kenini x'eksenine referans olarak koyuyoruz ve astronot nesnemizi a-d ve <-  -> y�n tu�lar�yla hareket ettirebilir bir hale sokuyoruz.

        //De�erler �ok h�zl� bir �ekilde de�i�ti�i i�in ���nlanma olarak adland�r�lan durumla kar��la��yoruz bunu d�zenlemek i�in ise �unu yapmal�y�z. transform.position '+=' new Vector3(yatay, 0, 0);

        transform.position += new Vector3(0, speed * hiz_katsayisi, 0); //z�plama

        
       /* transform.position += new Vector3(joystick.Horizontal * hiz_katsayisi, 0, 0); //x ekseninde h�zlanma */


    }

    void Awake()
    {

    }


    /* private void OnCollisionEnter2D(Collision2D collision)//2D fizik fonksiyonlar� taraf�ndan hesaplan�p geri d�nd�r�len �arp��ma ayrac�. Hangi cisimler �arp���yor ne kadar s�re �arp���yor bunun gibi t�m fizik hesaplar�n�n sonu�lar�
     {                                                      // Bu Collesion2D s�n�f�ndan �retilen collision nesnesi i�ersinde bize geri d�nd�r�l�yor 
         Debug.Log("Astronot carpti");
     }//�arp��ma ba�lad���nda ne yap�laca�� alt�na yaz�l�r 
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
                // Tepkimeye giren gameObject'e eri�ip yok ediyoruz  
                                               //rend.material.color = Color.black;//
                canbar.transform.localScale = new Vector3(benzin_miktar, 1, 1);

                adsHap.Play();

            }
            
            Destroy(collision.gameObject);


        }
        if(collision.tag == "ufo" && kontrol == 0)
        {
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; //statik olan ��eyi Dynamic yapar 
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
           
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; //statik olan ��eyi Dynamic yapar 
              rb_astro.gravityScale = -1f; 
            kontrol = 1;
            
            
        } 

        else if (collision.tag == "uydu" && kontrol == 1)
        {
           
            rb_astro.gravityScale = gravity_scale; //normal gravity scale'si 
            kontrol = 0;
            /*speed =+ rb.velocity.magnitude; I��nlama  */
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
            sprite.sortingOrder = -5; //order'in layer de�i�ti 

        }

        
    }*/



   

}

