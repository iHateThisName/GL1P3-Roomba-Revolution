using UnityEngine;

public class DestroyYourself : MonoBehaviour {
    public float minTime = 5f;
    public float maxTime = 10f;
    void Start() {
        Destroy(gameObject, Random.Range(minTime, maxTime + 1));
    }
}
