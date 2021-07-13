using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayPlatform : MonoBehaviour

{
    int sayac;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        sayac++;
        if (sayac == 2 && collision.gameObject.CompareTag("hero") )
        {

            SceneManager.LoadScene("Main");

        }
    }


}
