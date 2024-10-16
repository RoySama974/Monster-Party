using UnityEngine;
using Unity.VisualScripting;

namespace PorteCalcul
{
    public class Interruptor : MonoBehaviour
    {
        [SerializeField] Door _linkedDoor;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _linkedDoor.ToggleDoor();
                Debug.Log("Player In");
            }
        }

     



    } 
}
