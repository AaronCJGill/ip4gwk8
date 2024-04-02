using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    private float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move;

        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");
        move = (move * speed ) * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + move.x, transform.position.y + move.y, -10);
    }
}
