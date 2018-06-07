using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Unit {
    public float moveSpeed;
    public float rotateSpeed;
    private TankWeapon tw;
    void Start()
    {
        tw = GetComponent<TankWeapon>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal1");
        float vertical = Input.GetAxis("Vertical1");
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * vertical);
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * horizontal);

        // Update is called once per frame
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tw.Shoot();
            }
        /*if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        { 
            transform.Rotate(Vector3.up * -rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }*/
    }
}
