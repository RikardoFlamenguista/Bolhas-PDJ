using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenusController : MonoBehaviour
{

    private string currentScene;

    public void Restart()
    {
        currentScene = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentScene);


    }
}
