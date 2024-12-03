using UnityEngine;

public class EnemyDialogue : MonoBehaviour
{
    private float rotationSpeed = 5f;

    private bool isTalking = false;

    [SerializeField]
    private GameObject textBouble;

    [SerializeField]
    private DialogTemplate dialogTemplate;

    [SerializeField]
    protected RoamingAI roamingAI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
public static EnemyDialogue instance {  get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*
        if (Collider.CompareTag("Player"))
        {
            isCloseEnough = true;
        }
        */
        if (collision.collider.CompareTag("Player"))
        {
            if (!isTalking)
            {
                isTalking = true;
                textBouble.SetActive(true);
                dialogTemplate.DialougeStart();
                roamingAI.enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider Collider)
    {
        if (Collider.CompareTag("Player"))
        {
            dialogTemplate.StopAllCoroutines();
            dialogTemplate.DialougeLeft();
            textBouble.SetActive(false);
            roamingAI.enabled =true;
            isTalking = false;
        }
    }
}
