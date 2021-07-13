using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public astro_hareket BirdScript;
    public GameObject Borular;
    public GameObject kirmizi;
    public GameObject yesil;
    public float xEkseni,xEkseni2;
    public float time;
    public float yEkseni;
    public float fark;
    
    private void Start()
    {
        
        StartCoroutine(SpawnObject(time));
    }



    public IEnumerator SpawnObject(float time)
    {
        while (!BirdScript.isDead)
        {
            int renk = Random.Range(1, 4);
            if (renk == 1)
            {
                Instantiate(Borular, new Vector3(Random.Range(xEkseni, xEkseni2), Random.Range(-yEkseni, yEkseni), 0), Quaternion.identity);
                yield return new WaitForSeconds(time);
                xEkseni += fark;
                xEkseni2 += fark;
            }
            if (renk == 2)
            {
                Instantiate(kirmizi, new Vector3(Random.Range(xEkseni, xEkseni2), Random.Range(-yEkseni, yEkseni), 0), Quaternion.identity);
                yield return new WaitForSeconds(time);
                xEkseni += fark;
                xEkseni2 += fark;
            }
            else
            {
                Instantiate(yesil, new Vector3(Random.Range(xEkseni, xEkseni2), Random.Range(-yEkseni, yEkseni), 0), Quaternion.identity);
                yield return new WaitForSeconds(time);
                xEkseni += fark;
                xEkseni2 += fark;
            }

        }
    }
}