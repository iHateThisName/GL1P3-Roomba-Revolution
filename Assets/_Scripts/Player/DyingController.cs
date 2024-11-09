using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class DyingController : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if ((collider.CompareTag("Player")))
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
