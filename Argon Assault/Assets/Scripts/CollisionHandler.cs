using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // ok to use this one in this script as long as its the only script using scene loading

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 5f;
    [SerializeField] GameObject deathFX;
    [SerializeField] MeshRenderer meshRenderer;


    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        Invoke("ReloadScene", levelLoadDelay);
    }
    
    private void StartDeathSequence()
    {
        FindObjectOfType<PlayerController>().ChangeAliveState();
        deathFX.SetActive(true);
        meshRenderer.enabled = false;
    }

    private void ReloadScene()  // string referenced
    {
        SceneManager.LoadScene(1);
    }
}
