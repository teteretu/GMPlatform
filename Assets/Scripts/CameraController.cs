using UnityEngine;

public class CameraController : MonoBehaviour
{
    // [SerializeField] private float speed;
    private float currentPosition;
    // private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    private void Update()
    {
        // transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosition, transform.position.y, transform.position.z), ref velocity, speed);

        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosition = _newRoom.position.x;
    }
}
