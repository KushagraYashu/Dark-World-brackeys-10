using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionLogic : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(LayerMask.LayerToName(other.gameObject.layer));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
