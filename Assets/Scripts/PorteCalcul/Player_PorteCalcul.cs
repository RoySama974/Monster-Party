using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_PorteCalcul : MonoBehaviour
{

    [Header("Player Settings")]
    [SerializeField] int moveSpeed;


    Vector2 moveInput = Vector2.zero;
    Rigidbody rb;
    void Start()
    {
        
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
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
}
