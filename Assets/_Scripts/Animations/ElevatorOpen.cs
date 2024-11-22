using UnityEngine;

public class ElevatorOpen : MonoBehaviour
{
[SerializeField] private ElevatorAnimator anim;

   private void OnTriggerEnter(Collider collider){
        if (collider.gameObject.CompareTag("Player")){
            anim.PlayAnimation();
        }
    }
}
