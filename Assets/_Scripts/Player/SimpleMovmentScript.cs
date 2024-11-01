using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovmentScript : MonoBehaviour {

    [SerializeField]
    private InputManager inputManager;
    // Update is called once per frame
    void Update() {
        float horizontalDirection = inputManager.MoveVector2.x;
        float verticalDirection = inputManager.MoveVector2.y;

        Vector3 movementDirection = new Vector3(horizontalDirection, 0f, verticalDirection);

        transform.Translate(movementDirection * .5f * Time.deltaTime);
    }
}
