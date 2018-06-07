using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {
    public int damage;// 爆炸伤害
    public float explosionForce;//爆炸的力度
    public float explosionRadius;//爆炸的半径
    public GameObject explosionEffect;
    public float explosionTimeUp;
   void OnCollisionEnter()
    {
        GameObject obj = Instantiate(explosionEffect, transform.position, transform.rotation)as GameObject;
        Destroy (gameObject);
        Destroy(obj, explosionTimeUp);

        Collider[] cols = Physics.OverlapSphere(transform.position,explosionRadius);
        for (int i = 0;i< cols.Length;i++)
        {
            Rigidbody r = cols[i].GetComponent<Rigidbody>();
            if(r != null){
                //被炸到的物体要有刚体才能成功
                r.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
            Unit u = cols[i].GetComponent<Unit>();
            if (u != null)
            {
                u.ApliyyDamage(damage);
            }
        }
    }
}
