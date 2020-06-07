using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    //temporary till we add user interface to start the game
    public void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
