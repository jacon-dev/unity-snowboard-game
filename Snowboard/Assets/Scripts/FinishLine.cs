using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private readonly float sceneLoadDelay = 0.5f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Invoke(nameof(LoadNextScene), sceneLoadDelay);
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(0);
    }
}
