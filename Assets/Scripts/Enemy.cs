using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject deathFX;
    [SerializeField] private Transform parent;


    // Use this for initialization
    void Start ()
	{
	    AddNonTriggerBoxCollider();
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

    private void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
