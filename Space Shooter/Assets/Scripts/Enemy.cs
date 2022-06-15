using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField]GameObject enemyExplosion;
    [SerializeField]GameObject enemyHitEffect;

    public int EnemyHealth = 100;
    [SerializeField]TextMeshProUGUI EnemyHealthText;
    [SerializeField]int scorePerHit = 25;
    [SerializeField]int scorePerKill = 50;

    ScoreBoard scoreBoard;
    GameObject parentGameObject;
    PlayerControls playerControls;

    void Start() 
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        playerControls = FindObjectOfType<PlayerControls>(); 
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        
    }
    void Update() 
    {
        EnemyHealthText.text = EnemyHealth.ToString();       
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    public void ProcessHit()
    {
        
        if(EnemyHealth > 0)
        {
            GameObject HitVFX = Instantiate(enemyHitEffect, transform.position, Quaternion.identity);
            HitVFX.transform.parent = parentGameObject.transform;
            EnemyHealth = EnemyHealth - playerControls.LaserDamage;
            ProcessScoreIncrease();
        }

        if(EnemyHealth <= 0)
        {
            ProcessKill();
        }
    }

    public void ProcessKill()
    {
        GameObject vfx = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
        scoreBoard.IncreaseScore(scorePerKill);
    }

    public void ProcessScoreIncrease()
    {
        scoreBoard.IncreaseScore(scorePerHit);
    }
}
