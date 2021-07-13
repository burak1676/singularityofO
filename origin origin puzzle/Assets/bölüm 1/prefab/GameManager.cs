using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*Game Manager'a heryerden ulaþmak istediðimiz için namespace vermiyoruz*/
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {

        SingeltonThisGameObject(); // Bu singelton design patternidir. 
    }

    private void SingeltonThisGameObject()
    {
        if (Instance == null)
        {
            Instance = this; // Instance diye bir propery var ve biz ona bu class'ý referance veriyoruz. Bu class'ýn referancesini instance'ye atýyorum yani artýk null deðil 
            DontDestroyOnLoad(this.gameObject); //GameManager'ýn içinde olduðu gameobject'i yok etme demiþ olduk. 

        }
        else
        {

            Destroy(this.gameObject); //GameManager'ýn içinde olduðu ikinci bir obje'de varsa onu yok et demiþ olduk.

        }
    }


    public void RestartGame()
    {
        StartCoroutine(RestartGameAsync());
    }


    private IEnumerator RestartGameAsync()
    {
        yield return SceneManager.LoadSceneAsync("Main"); //yield return - > Bu method bittikten sonra çalýþmaya devam edecek. 
    }


}