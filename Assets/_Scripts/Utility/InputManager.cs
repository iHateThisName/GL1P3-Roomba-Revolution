using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {
    private InputAction move;
    private InputAction suck;
    private InputAction blow;
    private InputAction look;
    public Vector2 MoveVector2 { get; private set; }
    public Vector2 LookVector2 { get; private set; }
    public bool isSucking { get; private set; } = false;
    public bool isBlowing { get; private set; } = false;
    void Start() {

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        this.move = InputSystem.actions.FindAction("Move");
        this.move.performed += Move;
        this.move.canceled += Move;

        this.look = InputSystem.actions.FindAction("Look");
        this.look.performed += Look;
        this.look.canceled += Look;

        this.suck = InputSystem.actions.FindAction("Suck");
        this.suck.performed += Suck;
        this.suck.canceled += Suck;

        this.blow = InputSystem.actions.FindAction("Blow");
        this.blow.performed += Blow;
        this.blow.canceled += Blow;
    }
    private void Move(InputAction.CallbackContext context) => this.MoveVector2 = context.ReadValue<Vector2>();
    private void Look(InputAction.CallbackContext context) => this.LookVector2 = context.ReadValue<Vector2>();
    private void Suck(InputAction.CallbackContext context) => isSucking = !isSucking;
    private void Blow(InputAction.CallbackContext context) => this.isBlowing = !isBlowing;
}
