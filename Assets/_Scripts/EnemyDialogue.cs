using UnityEngine;

public class EnemyDialogue : MonoBehaviour
{
    public GameObject enemyDialoge;
    //private bool isCloseEnough = false;
    private DialogTemplate dialogTemplate;
    private bool isTalking = false;

    [SerializeField] private GameObject playerDialogueAvailable;
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
                playerDialogueAvailable.SetActive(true);
                //isTalking = true;
                dialogTemplate.DialougeStart();
            }
        }
    }

    private void OnTriggerExit(Collider Collider)
    {
        if (Collider.CompareTag("Player"))
        {
            //isCloseEnough = false;

            playerDialogueAvailable.SetActive(false);

            dialogTemplate.StopAllCoroutines();
            dialogTemplate.DialougeLeft();
            //isTalking = false;
        }
    }
    
    private void Start() => dialogTemplate = enemyDialoge.GetComponent<DialogTemplate>();

    /*
    private void FixedUpdate()
    {
        if (isCloseEnough && !isTalking)
        {
            
        }
        else if (!isCloseEnough)
        {

        }
    }
    */
}
