using UnityEngine;

namespace Code.Placeholder
{
    /// <summary>
    /// Allows you to move the player in general and to target points.
    /// </summary>
    /// <remarks>
    /// This is not a script to take seriously, it is a placeholder.
    /// </remarks>
    public class MovePlayer : MonoBehaviour
    {
        private Transform transform;

        [SerializeField]
        private Transform[] teleports;
    
        private void Start()
        {
            transform = gameObject.GetComponent<Transform>();
        }
    
        private void Update()
        {
            MovePlayerWithWASD();
            TeleportToLocations();
        }

        private void TeleportToLocations()
        {
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                ActuallyTeleport(0);
            }
            else if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                ActuallyTeleport(1);
            }
            else if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                ActuallyTeleport(2);
            }
            else if (Input.GetKeyUp(KeyCode.Alpha4))
            {
                ActuallyTeleport(3);
            }
        }

        private void ActuallyTeleport(int number)
        {
            if (teleports.Length >= number)
            {
                if (teleports[number] == null)
                {
                    return;
                }
                
                transform.position = teleports[number].position;
            }
        }

        /// <summary>
        /// Do not use this, use the new Unity method and Ridged-body...
        /// </summary>
        private void MovePlayerWithWASD()
        {
            Vector3 position = transform.position;
            float speed = 5;
            
            if (Input.GetAxis("Horizontal") > 0)
            {
                position.x += Time.deltaTime * speed;
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                position.x -= Time.deltaTime * speed;
            }
        
            if (Input.GetAxis("Vertical") > 0)
            {
                position.y += Time.deltaTime * speed;
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                position.y -= Time.deltaTime * speed;
            }

            transform.position = position;
        }
    }
}