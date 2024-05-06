using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class progress : MonoBehaviour
{

    //public int nextScene = 1;
    public void NextLevel()
    {
        // This should work. Not sure why it doesn't
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        SceneManager.LoadScene("Scenes/tut2");
        Debug.Log("This should have loaded the next level");
    }
    public void NextLevel1()
    {

        SceneManager.LoadScene("Scenes/tut3");
        Debug.Log("This should have loaded the next level");
    }

    public void NextLevel2()
    {

        SceneManager.LoadScene("Scenes/tut4");
        Debug.Log("This should have loaded the next level");
    }

    public void NextLevel3()
    {

        SceneManager.LoadScene("Scenes/tut5");
        Debug.Log("This should have loaded the next level");
    }

    public void NextLevel4()
    {

        SceneManager.LoadScene("Scenes/tut6");
        Debug.Log("This should have loaded the next level");
    }

    public void NextLevel5()
    {

        SceneManager.LoadScene("Scenes/tut7");
        Debug.Log("This should have loaded the next level");
    }

    public void startFirstLevel()
    {
        SceneManager.LoadScene("Scenes/MainScene");
        Debug.Log("This should start the first level");
    }
}