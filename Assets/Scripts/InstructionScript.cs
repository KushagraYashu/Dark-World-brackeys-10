using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionScript : MonoBehaviour
{
    public float delay;
    bool done;
    public GameObject introPanel;
    public GameObject next;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !done)
        {
            done = true;
            introPanel.SetActive(true);
            yield return new WaitForSeconds(delay);
            introPanel.SetActive(false);
            next.SetActive(true);
        }
    }

}
