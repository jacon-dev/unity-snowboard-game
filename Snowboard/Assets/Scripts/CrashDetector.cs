using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem injuryEffect;
    private readonly float sceneLoadDelay = 1f;
    private bool alreadyInjured = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground" && alreadyInjured == false)
        {
            alreadyInjured = true;
            FindObjectOfType<PlayerController>().DisableControls();
            injuryEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke(nameof(ReloadScene), sceneLoadDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
