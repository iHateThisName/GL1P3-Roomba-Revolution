using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovmentScript : MonoBehaviour {

    // Update is called once per frame
    void Update() {
        float horizontalDirection = Input.GetAxis("Horizontal");
        float verticalDirection = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalDirection, 0f, verticalDirection);

        transform.Translate(movementDirection * 5f * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Q)) {
            transform.Rotate(Vector3.up * 10f);
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            transform.Rotate(-Vector3.up * 10f);
        }
    }
}
