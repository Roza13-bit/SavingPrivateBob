using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGuyController : MonoBehaviour
{
    [SerializeField] CharacterController myGuyCC;

    [SerializeField] float movementSpeed = 5;

    [SerializeField] float smoothTurning = 0.1f;

    [SerializeField] Animator animator;

    float turnSmoothVelocity;

    Vector3 moveVector;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = transform.right * horizontal + transform.forward * vertical;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothTurning);

            animator.SetBool("isRunning", true);

            myGuyCC.Move(direction * movementSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

        }
        else
        {
            animator.SetBool("isRunning", false);

        }

        moveVector = Vector3.zero;

        if (myGuyCC.isGrounded == false)
        {
            moveVector += Physics.gravity;

        }

        myGuyCC.Move(moveVector * Time.deltaTime);

       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            

        } */

    }

}
