using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollisionLogic : MonoBehaviour
{

    public PlayerBehaviour player;
    public Animator swordAnimator;


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyBehaviour>().DecreaseHealth(PlayerBehaviour.instance.damage);
        }       
        
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
