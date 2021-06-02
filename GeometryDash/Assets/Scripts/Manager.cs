using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Manager : MonoBehaviour
{
   
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadLeve2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void LoadLeve3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void LoadLeve4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void LoadLeve5()
    {
        SceneManager.LoadScene("Level 5");
    }

    public void LoadSceneMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void LoadScenePlayerModels()
    {
        SceneManager.LoadScene("PlayerModels");
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
