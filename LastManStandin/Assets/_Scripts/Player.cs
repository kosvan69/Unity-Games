﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float speed = 3f;
    public Text healthText;
    public float health = 100f;

    public GameObject ammunition;
    private Transform _transform;

	// Use this for initialization
	void Start ()
	{
	    _transform = GetComponent<Transform>(); // possible nullptr 
	}
	
	// Update is called once per frame
	void Update ()
	{
	    UpdateHealthText();
        HandleMovement();
	    HandleRotation();
	    HandleFire();
	}

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _transform.position += new Vector3(-speed,0,0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _transform.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            _transform.position += new Vector3(0, speed, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _transform.position += new Vector3(0, -speed, 0);
        }
    }

    private void HandleRotation()
    {
        //TODO: Improve messy rotation code
        var mousePosition = Input.mousePosition;
        var mouseRotation = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, mousePosition.z - _transform.position.z));
        float RotationSpeed = 10f;

        if ((_transform.position.x != mousePosition.y) && (_transform.position.y != mousePosition.y))
        {
            _transform.rotation = Quaternion.Slerp(
                _transform.rotation, 
                Quaternion.Euler(0, 0, Mathf.Atan2((mouseRotation.y - _transform.position.y), (mouseRotation.x - _transform.position.x)) * Mathf.Rad2Deg),
                RotationSpeed * Time.deltaTime);
        }
    }

    private void HandleFire()
    {
        const int LEFT_MOUSE_BUTTON = 0;
        if (Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON))
        {
            GameObject newBullet = Instantiate(ammunition);
            newBullet.transform.position = _transform.position;
        }
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;
    }
    private void UpdateHealthText()
    {
        healthText.text = health.ToString();
    }
}
