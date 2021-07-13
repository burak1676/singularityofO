using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneMotoru : MonoBehaviour
{
  public void playGecis()
    {

        SceneManager.LoadScene("Main");

    }


    public void optionsGecis()
    {

        // SceneManager.LoadScene("Options");

    }


    public void exitGecis()
    {
        Application.Quit();


    }


    public void menuGecis()
    {
        SceneManager.LoadScene("Main Menu");


    }

}
