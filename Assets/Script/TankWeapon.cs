using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankWeapon : MonoBehaviour {
    public GameObject shell;
    public float shootPower;
    public Transform shootPoint;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Shoot() {
        GameObject newSheel =Instantiate(shell, shootPoint.position, shootPoint.rotation)as GameObject;
        Rigidbody r = newSheel.GetComponent<Rigidbody>();
        r.velocity = shootPoint.forward*shootPower;
        audioSource.Play();
    }
}
