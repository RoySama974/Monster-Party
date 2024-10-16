using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager_PorteCalcul : MonoBehaviour
{
    public List<Player_PorteCalcul>  _players;
    public static GameManager_PorteCalcul instance;


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

    public void ReferencePlayers( PlayerInput playerInput)
    {
        Player_PorteCalcul player = playerInput.GetComponent<Player_PorteCalcul>();
        _players.Add(player);
    }

    
}
