using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PorteCalcul
{
    public class GameManager : MonoBehaviour
    {
        public List<Player> _players;
        public Transform[] _posCams;
        public static GameManager instance;
            

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("Il y a plus d'une instance de GameManager_PorteCalcul dans la scène");
                return;
            }
            instance = this;


        }

        void Update()
        {

        }

        public void ReferencePlayers(PlayerInput playerInput)
        {
            Player player = playerInput.GetComponent<Player>();
            _players.Add(player);
        }


    } 
}
