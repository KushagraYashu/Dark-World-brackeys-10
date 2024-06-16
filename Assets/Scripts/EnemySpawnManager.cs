using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject next;
    public GameObject UIPanel;
    
    public float enemSpeed;
    public int enemDamage;

    public int totalEnemies;
    int totalSpawned;

    public GameObject enemyPrefab;

    public GameObject curSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (curSpawn == null && totalSpawned<totalEnemies)
        {
            
            curSpawn = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            curSpawn.GetComponent<EnemyBehaviour>().speed = enemSpeed;
            curSpawn.GetComponent<EnemyBehaviour>().damage = enemDamage;
            totalSpawned++;
        }
        if(totalSpawned ==  totalEnemies && curSpawn == null)
        {
            next.SetActive(true);
            UIPanel.SetActive(true);
            Destroy(UIPanel, 3f);
            this.GetComponent<EnemySpawnManager>().enabled = false;
        }
    }
}
