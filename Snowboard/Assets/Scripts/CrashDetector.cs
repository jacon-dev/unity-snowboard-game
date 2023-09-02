using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem injuryEffect;
    private readonly float sceneLoadDelay = 0.5f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            injuryEffect.Play();
            Invoke(nameof(ReloadScene), sceneLoadDelay);            
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
