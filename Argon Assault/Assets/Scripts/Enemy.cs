using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject DeathFX;
    [SerializeField] Transform parentObj;

    [Header("Score System)")]
    ScoreBoard scoreBoard;
    [SerializeField] int scorePerHit = 100;


    // Start is called before the first frame update
    void Start()
    {
        AddEnemyBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddEnemyBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        // spawn death FX
        GameObject fx = Instantiate(DeathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parentObj;

        // Add Score
        scoreBoard.AddScore(scorePerHit);

        // Destory Enemy
        Destroy(gameObject);
    }
}
