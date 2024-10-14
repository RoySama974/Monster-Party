using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_PorteCalcul : MonoBehaviour
{

    [Header("Player Settings")]
    [SerializeField] int moveSpeed;

    Renderer _renderer;
    PlayerInput _playerInput;
    Vector2 moveInput = Vector2.zero;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _playerInput = GetComponent<PlayerInput>();
        SetPlayer();
    }


    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(moveInput.x, rb.linearVelocity.y, moveInput.y) * moveSpeed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void SetPlayer()
    {
        PlayerSkin();
    }

    void PlayerSkin()
    {
        if (_playerInput.playerIndex == 0)
        {
            _renderer.material.color = Color.red;
        }
        else if (_playerInput.playerIndex == 1)
        {
            _renderer.material.color = Color.blue;
        }
        else if (_playerInput.playerIndex == 2)
        {
            _renderer.material.color = Color.green;
        }
        else if (_playerInput.playerIndex == 3)
        {
            _renderer.material.color = Color.yellow;
        }

    }
}
