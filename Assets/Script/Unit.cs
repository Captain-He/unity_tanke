using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    public int health = 100;
    public GameObject deadEffect;//死亡后的效果
    public void ApliyyDamage(int damage) { //应用伤害
        if (health > damage)
        {
            health -= damage;
        }
        else {
            Destruct();
        }

    }
    public void Destruct() {
        if (deadEffect != null)
        {
            Instantiate(deadEffect, transform.position, transform.rotation);//在死亡的位置留下预留体
        }
        Destroy(gameObject);
    }
}
