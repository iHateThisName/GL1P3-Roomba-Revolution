using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {
    [Header("References")]
    [SerializeField]
    private PauseMenuScripts pauseMenuScripts;

    private InputAction move;
    private InputAction suck;
    private InputAction blow;
    private InputAction look;
    private InputAction pause;
    private InputAction dash;

    public bool isPaused { get; private set; } = false;
    public Vector2 MoveVector2 { get; private set; }
    public Vector2 LookVector2 { get; private set; }
    public bool isSucking { get; private set; } = false;
    public bool isBlowing { get; private set; } = false;
    public bool isDashing { get; private set; } = false;

    public static InputManager Instance { get; private set; }
    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }
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
        this.suck.performed += ctx => { if (!isPaused) Suck(ctx); };
        this.suck.canceled += ctx => { if (!isPaused) Suck(ctx); };

        this.blow = InputSystem.actions.FindAction("Blow");
        this.blow.performed += ctx => { if (!isPaused) Blow(ctx); };
        this.blow.canceled += ctx => { if (!isPaused) Blow(ctx); };

        this.pause = InputSystem.actions.FindAction("Pause");
        this.pause.performed += Pause;

        this.dash = InputSystem.actions.FindAction("Dash");
        this.dash.performed += ctx => { if (!isPaused) Dash(ctx); };
        this.dash.canceled += ctx => { if (!isPaused) Dash(ctx); };
    }

    private void OnDestroy()
    {
        this.move.performed -= Move;
        this.move.canceled -= Move;

        this.look.performed -= Look;
        this.look.canceled -= Look;

        this.suck.performed -= Suck;
        this.suck.canceled -= Suck;

        this.blow.performed -= Blow;
        this.blow.canceled -= Blow;

        this.pause.performed -= Pause;

        this.dash.performed -= Dash;
        this.dash.canceled -= Dash;

        this.isBlowing = false;
        this.isSucking = false;
        this.isPaused = false;
        this.isDashing = false;
    }
    private void Move(InputAction.CallbackContext context) => this.MoveVector2 = context.ReadValue<Vector2>();
    private void Look(InputAction.CallbackContext context) => this.LookVector2 = context.ReadValue<Vector2>();
    private void Suck(InputAction.CallbackContext context) => this.isSucking = !this.isSucking;
    private void Blow(InputAction.CallbackContext context) => this.isBlowing = !this.isBlowing;
    private void Dash(InputAction.CallbackContext context) => this.isDashing = !this.isDashing;

    private void Pause(InputAction.CallbackContext context) {
        if (context.performed) {
            isPaused = !isPaused;
            Debug.Log("Is paused: " + isPaused);
            pauseMenuScripts.Pause(isPaused);
        }

        if (this.isPaused) {
            this.isBlowing = false;
            this.isSucking = false;
            this.isDashing = false;
        }
    }

    public void UnPause()
    {
        if (this.isPaused) this.isPaused = false;
    }
}
