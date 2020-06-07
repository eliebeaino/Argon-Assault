using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

        void Start()
    {
        Invoke("LoadFirstScene", 15f);
    }


    //temporary till we add user interface to start the game
    void LoadFirstScene()  
    {
        SceneManager.LoadScene(1);
    }
}
