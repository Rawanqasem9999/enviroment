using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement);
        controller.Move(movement * 5 * Time.deltaTime);

        Vector3 direction = new Vector3(controller.velocity.x, 0, controller.velocity.z);
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 0.15f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.Move(Vector3.up * 15 * Time.deltaTime);
        }


    }
}