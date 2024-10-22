using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static PorteCalcul.Player;

namespace PorteCalcul
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] int numberOfStage;
        public List<Player> _players;
        public Transform _posCam; 
        public Transform[] _spawnPoints; 

        
        public Dictionary<PlayerNumber, int> playerScores = new Dictionary<PlayerNumber, int>();


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

        private void Start()
        {
            playerScores.Add(PlayerNumber.P1, 0);
            playerScores.Add(PlayerNumber.P2, 0);
            playerScores.Add(PlayerNumber.P3, 0);
            playerScores.Add(PlayerNumber.P4, 0);
        }

        void Update()
        {

        }

        public void ReferencePlayers(PlayerInput playerInput)
        {
            Player player = playerInput.GetComponent<Player>();
            _players.Add(player);
            
            PlacePlayer(playerInput.playerIndex);
            
        }

        void PlacePlayer(int playerIndex) 
        {
            _players[playerIndex].transform.parent.position = _spawnPoints[playerIndex].position;
        }

        public void AddPoints(PorteCalcul.Player player) 
        {
            if (player.playerNumber == PlayerNumber.None) return;

            if (playerScores.ContainsKey(player.playerNumber))
            {
                playerScores[player.playerNumber]++;
                if (playerScores[player.playerNumber] == numberOfStage)
                {
                    Victory();
                    return;
                }
                else
                {
                    CalculSystem.instance.LaunchOperation();
                }
                Debug.Log($"{player.playerNumber} Good Answer: {playerScores[player.playerNumber]}");
            }
        }

        void Victory()
        {
            Debug.Log("VICTORY");
        }


    } 
}
