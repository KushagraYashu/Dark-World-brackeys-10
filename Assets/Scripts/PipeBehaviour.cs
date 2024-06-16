using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PipeBehaviour : MonoBehaviour
{
    public float delayTime;

    AudioSource laugh;

    public int levelIndex;

    private void Start()
    {
        laugh = GetComponent<AudioSource>();
    }

    private IEnumerator OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Load");
            
            if(!laugh.isPlaying)
            {
                laugh.Play();
            }

            try
            {
                GetComponent<EndScreen>().yes = true;
                GetComponent<EndScreen>().Credits();
            }
            catch
            {

            }

            yield return new WaitForSeconds(delayTime);
            SceneManager.LoadScene(levelIndex);
        }
    }
}
