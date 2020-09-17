using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneManager :MonoBehaviour
{
    
    public void Loadlevel1() {
     
        UnityEngine.SceneManagement.SceneManager.LoadScene("level1");
    }
    public void Loadlevel2()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("level2");
      
    }
    public void Loadlevel3()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("level3");
    }
    public void Quit()
    {

        Application.Quit();
    }
}
