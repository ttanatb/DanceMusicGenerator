using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    const float SPEED = 30;
    const float ROT_SPEED = 60;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        if (Input.GetKey(KeyCode.W))
            newPos.y = newPos.y + SPEED * Time.deltaTime;
        else if (Input.GetKey(KeyCode.S))
            newPos.y = newPos.y - SPEED * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
            newPos.x = newPos.x + SPEED * Time.deltaTime;
        else if (Input.GetKey(KeyCode.A))
            newPos.x = newPos.x - SPEED * Time.deltaTime;

        if (Input.GetMouseButton(0))
            newPos.z = newPos.z + SPEED * Time.deltaTime;
        else if (Input.GetMouseButton(1))
            newPos.z = newPos.z - SPEED * Time.deltaTime;

        transform.position = newPos;

        Vector3 mousePos = Input.mousePosition;
        if (mousePos.x < 100)
            transform.Rotate(-Vector3.up * ROT_SPEED * Time.deltaTime);
        else if (mousePos.x > Screen.width - 100)
            transform.Rotate(Vector3.up* ROT_SPEED * Time.deltaTime);


        if (mousePos.y < 100)
            transform.Rotate(-Vector3.left * ROT_SPEED * Time.deltaTime);
        else if (mousePos.y > Screen.height - 100)
            transform.Rotate(Vector3.left * ROT_SPEED * Time.deltaTime);
    }
}