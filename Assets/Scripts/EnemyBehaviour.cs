using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    bool stop = false;

    public Slider healthSlider;

    public int maxHealth;
    int curHealth;
    
    public static EnemyBehaviour instance;

    public int damage;
    
    bool ready = false;
    bool attack = false;
    public float timeBtwAttack;
    float iniTimeBtwAttack;
    public Animator enemyAnimator;
    public Transform player;
    public float minDist;  
    public float speed;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        iniTimeBtwAttack = timeBtwAttack;
        curHealth = maxHealth;
        healthSlider.value = curHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            if (timeBtwAttack > 0)
            {
                timeBtwAttack -= Time.deltaTime;
            }
            else
            {
                ready = true;
                timeBtwAttack = 0;
            }
            transform.LookAt(player);
            if (Vector3.Distance(transform.position, player.position) > minDist)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
                enemyAnimator.SetBool("Run", true);
                enemyAnimator.SetBool("Attack", false);
                enemyAnimator.SetBool("Idle", false);
                enemyAnimator.SetBool("Hit", false);
                attack = false;
            }
            else
            {
                enemyAnimator.SetBool("Run", false);
                enemyAnimator.SetBool("Attack", false);
                enemyAnimator.SetBool("Idle", true);
                enemyAnimator.SetBool("Hit", false);
                attack = true;
            }

            if (attack)
            {
                CheckFire();
            }
        }
        
    }

    void CheckFire()
    {
        if (ready)
        {
            Fire();
        }
        else
        {
            enemyAnimator.SetBool("Attack", false);
            enemyAnimator.SetBool("Run", false);
            enemyAnimator.SetBool("Idle", true);
            enemyAnimator.SetBool("Hit", false);
        }
    }
    
    void Fire()
    {
        enemyAnimator.SetBool("Attack", true);
        enemyAnimator.SetBool("Run", false);
        enemyAnimator.SetBool("Idle", false);
        enemyAnimator.SetBool("Hit", false);
        ready = false;
        timeBtwAttack = iniTimeBtwAttack;
        
    }

    public void DecreaseHealth(int damage)
    {
        curHealth -= damage;
        if (curHealth <= 0)
        {
            StartCoroutine(Dead());
            
        }
        
        healthSlider.value = curHealth;

        Debug.Log(curHealth);
        enemyAnimator.SetBool("Attack", false);
        enemyAnimator.SetBool("Run", false);
        enemyAnimator.SetBool("Idle", false);
        enemyAnimator.SetBool("Hit", true);
    }

    public IEnumerator Dead()
    {
        this.gameObject.GetComponentInChildren<ParticleSystem>().Play();
        stop = true;
        enemyAnimator.SetBool("Attack", false);
        enemyAnimator.SetBool("Run", false);
        enemyAnimator.SetBool("Idle", false);
        enemyAnimator.SetBool("Hit", false);
        yield return new WaitForSeconds(this.gameObject.GetComponentInChildren<ParticleSystem>().duration);
        Destroy(gameObject);
    }

    

}
