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
    [SerializeField] int health = 300;
    [SerializeField] int damagePerHit = 100;


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
        ProcessHit();

        if (health <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        // Add Score & reduce health
        scoreBoard.AddScore(scorePerHit);
        health = health - damagePerHit;

        // todo add hit fx
    }

    private void KillEnemy()
    {
        // spawn death FX
        GameObject fx = Instantiate(DeathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parentObj;
        // Destory Enemy
        Destroy(gameObject);
    }
}
