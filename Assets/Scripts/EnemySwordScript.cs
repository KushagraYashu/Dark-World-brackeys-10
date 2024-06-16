using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordScript : MonoBehaviour
{
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.name);
            other.gameObject.GetComponent<PlayerBehaviour>().DecreaseHealth(EnemyBehaviour.instance.damage);
        }
        //Debug.Log(other.gameObject.name);
    }

}