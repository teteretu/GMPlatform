using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            if (collider.transform.position.x < transform.position.x)
            {
                cam.MoveToNewRoom(nextRoom);
            } else
            {
                cam.MoveToNewRoom(previousRoom);
            }
        }
    }
}
