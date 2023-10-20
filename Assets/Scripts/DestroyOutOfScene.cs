using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestroyOutOfScene : MonoBehaviour
{
    private float upperBound;
    private float lowerBound;

    // Start is called before the first frame update
    void Start()
    {
        upperBound = 30.0f;
        lowerBound = -10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyOutOfBounds();
    }

    void DestroyOutOfBounds()
    {
        if (gameObject.transform.position.z > upperBound || gameObject.transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
    }
}
