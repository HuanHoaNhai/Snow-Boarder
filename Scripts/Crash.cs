using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    [SerializeField] ParticleSystem CrashEffect;
    [SerializeField] float loadDelay = 0.5f;
    bool hasCrash = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground" && !hasCrash){
            hasCrash = true;
            FindObjectOfType<PlayerController>().disableControl();
            CrashEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", loadDelay);
        }
    }
    void ReloadScene() 
    {
        SceneManager.LoadScene(0);
    }
}

