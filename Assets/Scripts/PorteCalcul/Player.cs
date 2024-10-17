using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PorteCalcul
{
    public class Player : MonoBehaviour
    {

        [Header("Player Settings")]
        [SerializeField] int moveSpeed;

        [SerializeField] Camera _cam;
        private Renderer _renderer;
        private PlayerInput _playerInput;
        private Vector2 moveInput = Vector2.zero;
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();

        }
        void Start()
        {
            _renderer = GetComponent<Renderer>();
            _playerInput = GetComponent<PlayerInput>();
            SetPlayer();
            _cam.transform.position = GameManager.instance._posCams[0].position;
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

        void SetPlayer()
        {
            PlayerSkin();
            CamLayerUpdate();
        }

        void CamLayerUpdate()
        {
            int layerToAdd = 0;

            if (_playerInput.playerIndex == 0)
            {
                layerToAdd = LayerMask.NameToLayer("Player1");

            }
            else if (_playerInput.playerIndex == 1)
            {
                layerToAdd = LayerMask.NameToLayer("Player2");
            }
            else if (_playerInput.playerIndex == 2)
            {
                layerToAdd = LayerMask.NameToLayer("Player3");
            }
            else if (_playerInput.playerIndex == 3)
            {
                layerToAdd = LayerMask.NameToLayer("Player4");
            }

            this.gameObject.layer = layerToAdd;
            _cam.cullingMask |= (1 << layerToAdd);
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
}
