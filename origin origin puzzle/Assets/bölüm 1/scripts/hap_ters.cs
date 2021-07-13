using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hap_ters : MonoBehaviour 
{
    public static int hap_yutma = 0; //false

    
    
    // Start is called before the first frame update
    void Start()
    {
        

    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "hero")
        {
            Debug.Log("Ters_Don");

            

            Destroy(this.gameObject);
            hap_yutma = 1; //true

            

            



        }
    }
}
