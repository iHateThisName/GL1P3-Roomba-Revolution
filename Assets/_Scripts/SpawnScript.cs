using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    [SerializeField]
    private GameObject achievementPrefab;

    private GameObject ui;

    // Start is called before the first frame update
    void Start() {
        ui = new GameObject("UI");
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.P)) {

            Instantiate(achievementPrefab).transform.SetParent(ui.transform);
        }
    }

}
