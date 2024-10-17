using UnityEngine;
using Unity.VisualScripting;

namespace PorteCalcul
{
    public class Door : MonoBehaviour
    {
        public bool open = false;
        void Start()
        {
            open = false;
        }

        public void ToggleDoor()
        {
            open = !open;
            if (open)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 10f, transform.position.z);
            }
        }
    } 
}
