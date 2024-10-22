using UnityEngine;
using Unity.VisualScripting;

namespace PorteCalcul
{
    public class Door : MonoBehaviour
    {
        public bool open = false;
        public bool trueDoor;
        
        [SerializeField] GameObject _doorMesh;

        void Start()
        {
            open = false;
        }

        public void ToggleDoor(bool doorState)
        {
            open = doorState;
            _doorMesh.SetActive(open);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) 
            {
                Player player = other.GetComponent<Player>();
                if (trueDoor)
                {
                    player.transform.position = player.startPos;
                    GameManager.instance.AddPoints(player);
                    Debug.Log("AddPoints");
                }
                else
                {

                }
            }
        }


        //private void OnTriggerStay(Collider other)
        //{
        //    if (other.CompareTag("Player"))
        //    {
        //        Player player = other.GetComponent<Player>();
        //        if (player.interacted)
        //        {
        //            ToggleDoor(true);
        //        }
        //        else
        //        {
        //            ToggleDoor(false);
        //        }
        //    }
        //}
    } 
}
