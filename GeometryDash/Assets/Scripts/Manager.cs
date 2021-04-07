using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Manager : MonoBehaviour
{
   
    public void LoadScene0()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadSceneMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
