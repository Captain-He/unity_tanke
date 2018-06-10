using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AITank : Unit {
    public float enemySearchRange;
    public float moveSpeed;
    public ISRange stoppingDistance;
    public ISRange attackRange;//判断攻击的半径
    public float rotateSpeed;//转向的速度
    public float coreTimerInterval;

    private GameObject enemy;
    private TankWeapon tw;
    private NavMeshAgent nam;
    private LayerMask enemyLayer;

    private float curAR;
    private float curSD;
    void Start()
    {
        base.Start();
        enemyLayer = LayerManager.GetEnemyLayer(team);
        tw = GetComponent<TankWeapon>();
        nam = GetComponent<NavMeshAgent>();
        tw.Init(team);
        StartCoroutine(Timer());
    }
    void Update()
    {
       
        if (enemy == null)
        {
            SearchEnemy();
            return;
        }
        float dist = Vector3.Distance(enemy.transform.position, transform.position);
        if (dist > curSD)
        {
            nam.SetDestination(enemy.transform.position);//寻找敌人
        }
        else
        {
            nam.ResetPath();
            Vector3 dir = enemy.transform.position - transform.position;
            Quaternion wantedRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, rotateSpeed * Time.deltaTime);
            tw.Shoot(); //转向
        }
        if (dist < curAR)
        {
            tw.Shoot(); //射击
        }
    }

    IEnumerator Timer()
    {
        while (enabled)
        {
            curAR = ISMath.Random(attackRange);
            curSD = ISMath.Random(stoppingDistance);
            curSD = Mathf.Min(curAR,curSD);
            SearchEnemy();
            yield return new WaitForSeconds(coreTimerInterval);
        }
    }
    public void SearchEnemy()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position,enemySearchRange,enemyLayer);
        if(cols.Length > 0)
        {
            float curMinDist = Mathf.Infinity;
            for(int i = 0;i < cols.Length;i++)
            {
                float curDist = Vector3.Distance(transform.position,cols[i].transform.position);
                if(curDist < curMinDist)
                {
                    curMinDist = curDist;
                    enemy = cols[i].gameObject;
                }
            }
        }
      
    }
}

