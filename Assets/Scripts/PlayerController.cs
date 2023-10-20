using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/********************************************
 * GameObject "Player" that moves back and forth across the scene.
 * 
 * Naty Kozelkova
 * October 10, 2023 Version 1.0
 *******************************************/

public class PlayerController : MonoBehaviour
{

    [SerializeField] private GameObject projectile;

    private float speed;
    private float centerToEdge;
    private float move;
    private float maxSpeed;


    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f;
        centerToEdge = 24f;

    }

    // To call the PlayerMovement method each frame
    void Update()
    {
        PlayerMovement();
    }

    // This method is responsible for moving the player left and right
    // It prevents the player from moving beyond the CenterToEdge mark
    void PlayerMovement()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed * move);
        if (Mathf.Abs(transform.position.x) > centerToEdge)
        {
            float edge = centerToEdge;
            if(transform.position.x < 0)
            {
                edge = -centerToEdge;
            }
            transform.position = new Vector3(centerToEdge, transform.position.y, transform.position.z);

        }
    }

    // OnMove called when the Move action of the playerInputAction detects an input from the player
    // It sets the "move" field to either 1 or -1 based on the x-value of the input's Vector2
    void OnMove(InputValue input)
    {
        Vector2 moveDirection = input.Get<Vector2>();
        move = moveDirection.x;
        Debug.Log(move);

    }

    // Fires projectile on fire action
    void OnFire()
    {
        Instantiate(projectile, transform.position + Vector3.up, projectile.transform.rotation);
    }
}
