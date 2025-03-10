using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private ParticleSystem particlesys;
    public float heatlh= 4f;

    public static int NumberofEnemies=0;

    void Start()
    {
        particlesys = GetComponentInChildren<ParticleSystem>();
        NumberofEnemies++;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude>heatlh)
        {
            Die();
        }
    }

    void Die()
    {
        particlesys.Play();
        Destroy(gameObject,0.1f);  
        NumberofEnemies--;
        if (NumberofEnemies<=0)
        {
            StartCoroutine(GameOverNow());
            Debug.Log("Herkes öldü");
        }  
    }
    IEnumerator GameOverNow()
    {
        yield return new WaitForSeconds(3f);
        Bus_System.CallGameOver();
        Debug.Log("gameoverienumarator");
    }
}
