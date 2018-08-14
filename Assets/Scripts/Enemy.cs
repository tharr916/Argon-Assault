using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject deathFX;
    [SerializeField] private Transform parent;
    [SerializeField]
    int scorePerHit = 12; // TODO should this be associated with the enemy instead?

    private ScoreBoard _scoreBoard;

    // Use this for initialization
    void Start ()
	{
	    AddNonTriggerBoxCollider();
	    _scoreBoard = FindObjectOfType<ScoreBoard>();
	}

    private void OnParticleCollision(GameObject other)
    {
        _scoreBoard.ScoreHit(scorePerHit);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }

    private void AddNonTriggerBoxCollider()
    {
        DestroyExistingBoxColliders();
        Collider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
    }

    private void DestroyExistingBoxColliders()
    {
        if (gameObject.GetComponents<BoxCollider>().Length > 0)
        {
            foreach (var boxCollider in gameObject.GetComponents<BoxCollider>())
            {
                Destroy(boxCollider);
            }
        }
    }

    
}
