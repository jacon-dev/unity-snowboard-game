using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] ParticleSystem finishEffect;
    private readonly float sceneLoadDelay = 1f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke(nameof(LoadNextScene), sceneLoadDelay);
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(0);
    }
}
