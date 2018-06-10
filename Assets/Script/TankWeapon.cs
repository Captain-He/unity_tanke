using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankWeapon : MonoBehaviour {
    public GameObject shell;
    public float shootPower;
    public Transform shootPoint;
    public float shootCoolDown;//攻击冷却的时间
    private AudioSource audioSource;
    private LayerMask enemyLayer;
    private bool isWeaponReady = true;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Init(Team team)
    {
        enemyLayer = LayerManager.GetEnemyLayer(team);
    }
    public void Shoot() {
        if (!isWeaponReady) return;
        GameObject newSheel =Instantiate(shell, shootPoint.position, shootPoint.rotation)as GameObject;
        newSheel.GetComponent<Shell>().Init(enemyLayer);
        Rigidbody r = newSheel.GetComponent<Rigidbody>();
        r.velocity = shootPoint.forward*shootPower;
        audioSource.Play();
        isWeaponReady = false;
        StartCoroutine (WeaponCooldown());
    }
    IEnumerator WeaponCooldown()
    {
        yield return new WaitForSeconds(shootCoolDown);
        isWeaponReady = true;

    }
}
