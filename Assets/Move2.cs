using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        //if kad jei horizatal -> x++; 

        //checkina inputa
        if (direction.magnitude >= 0.1f)
        {
            transform.forward = direction;
            controller.Move(direction * speed * Time.deltaTime);
        }
        PlayerInteract();
    }
    private void PlayerInteract()
    {
        if (Input.GetButton("Interact"))
        {
            Debug.Log("INTERACTINA");
        }
    }
}