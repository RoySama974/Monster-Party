using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PorteCalcul
{
    public class Player : MonoBehaviour
    {

        [Header("Player Settings")]
        [SerializeField] int moveSpeed; 
        [SerializeField] int health;
        public Vector3 startPos;

        public enum PlayerNumber
        {
            None, P1, P2, P3, P4
        }

        public PlayerNumber playerNumber = PlayerNumber.None;
       

        [SerializeField] Camera _cam;
        private Renderer _renderer;
        [HideInInspector] public PlayerInput _playerInput;
        private Vector2 moveInput = Vector2.zero;
        private Rigidbody rb;

        public InputAction playerControls;


        private void Awake()
        {
            rb = GetComponent<Rigidbody>();

        }
        void Start()
        {
            startPos = transform.position;
            _renderer = GetComponent<Renderer>();
            _playerInput = GetComponent<PlayerInput>();
            SetPlayer();
            _cam.transform.position = GameManager.instance._posCam.position;
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

        //public void OnInteract(InputAction.CallbackContext context) 
        //{
        //    //Equivaut a un GetKeyDown (appuie sur le bouton)
        //    context.action.started += context =>
        //    {
        //        interacted = !interacted;


        //    };

        //    //Equivaut a un GetKeyDown (appuie sur le bouton)
        //    //context.action.performed += context =>
        //    //{
        //    //    interacted = !interacted;
        //    //};

        //    ////Equivaut a un GetKeyUp (quand on relache le bouton)
        //    //context.action.canceled += context =>
        //    //{
        //    //    interacted = false;
        //    //};

        //    //interacted = !interacted;

        //}



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
                playerNumber = PlayerNumber.P1;

            }
            else if (_playerInput.playerIndex == 1)
            {
                layerToAdd = LayerMask.NameToLayer("Player2");
                playerNumber = PlayerNumber.P2;
            }
            else if (_playerInput.playerIndex == 2)
            {
                layerToAdd = LayerMask.NameToLayer("Player3");
                playerNumber = PlayerNumber.P3;
            }
            else if (_playerInput.playerIndex == 3)
            {
                layerToAdd = LayerMask.NameToLayer("Player4");
                playerNumber = PlayerNumber.P4;
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
