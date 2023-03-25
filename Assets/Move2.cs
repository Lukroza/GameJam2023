using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

    public GameObject[] objectsToReposition;

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
       // PlayerInteract();
    }
    private void FixedUpdate()
    {
        
    }
    private void PlayerInteract()
    {
        if (Input.GetButton("Interact"))
        {
            //foreach (GameObject obj in objectsToReposition)
            //{
            //    float x = Random.Range(-14, 14);
            //    float z = Random.Range(-14, 14);
            //    obj.transform.position = new Vector3(x, 1, z);
            //    Debug.Log(obj.transform.position.x + "   " + obj.transform.position.z);
            //}

        }
    }
}