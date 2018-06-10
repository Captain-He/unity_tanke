using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team {
Red,Blue,Green
}
public class Unit : MonoBehaviour {
    public int health = 100;
    private int curHealth = 100;
    public Team team;
    public GameObject deadEffect;//死亡后的效果

    public int GetCurHealth()
    {
        return curHealth;
    }
    public void Start()
    {
        curHealth = health;
    }
    public void ApliyyDamage(int damage) { //应用伤害
        if (curHealth > damage)
        {
            curHealth -= damage;
        }
        else {
            if (this.gameObject.name == "redhome")
            {
                Destruct();
                GameManager.instance.Failed();
                return;
            }
                
            if (this.gameObject.name == "greenhome")
            {
                Destruct();
                GameManager.instance.Failed();
                return;
            }

            if (this.gameObject.name == "Tank")
            {
                Destruct();
                GameManager.instance.Failed();
                return;
            }
            else
            {
                Destruct();
            }

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
