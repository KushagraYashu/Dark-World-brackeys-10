using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickup : MonoBehaviour
{
    public GameObject weaponHolder;
    public PlayerBehaviour playerBehaviour;
    public GameObject next;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            weaponHolder.SetActive(true);
            playerBehaviour.allowed = true;
            playerBehaviour.secAttackDisp = true;
            next.SetActive(true);
            Destroy(gameObject);
        }
    }

}
