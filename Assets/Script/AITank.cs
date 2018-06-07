using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AITank : Unit {
    public GameObject player;
    public float moveSpeed;
    public float attackRange;//判断攻击的半径
    public float shootCoolDown;

    private float timer;
    private TankWeapon tw;
    private NavMeshAgent nam;
    void Start()
    {
        tw = GetComponent<TankWeapon>();
        nam = GetComponent<NavMeshAgent>();
    }
    /*
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (player == null) return;
        float dist = Vector3.Distance(player.transform.position,transform.position);
        if (dist > attackRange) {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        transform.LookAt(player.transform.position);
        if (timer > shootCoolDown)
        {
            tw.Shoot();
            timer = 0f;
        }
    }*/
    void Update()
    {
       
        timer += Time.fixedDeltaTime;
        if (player == null) return;
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist > attackRange)
        {
            nam.SetDestination(player.transform.position);
        }
        else
        {
            nam.ResetPath();
            transform.LookAt(player.transform.position);
            if (timer > shootCoolDown)
            {
               
                tw.Shoot();
                timer = 0f;
            }
        }
    }
}

