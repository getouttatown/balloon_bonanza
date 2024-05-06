using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{

    //public int nextScene = 1;
    public void PlayGame()
    {
        // This should work. Not sure why it doesn't
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        SceneManager.LoadScene("Scenes/tut1");
        Debug.Log("This should have loaded the next level");
    }

    public void PlayLevelDesigner()
    {
        SceneManager.LoadScene("Scenes/LevelDesigner");
        Debug.Log("This should have loaded the next level");
    }
}
