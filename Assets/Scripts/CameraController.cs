using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;

    private Vector3 targetPosition;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        moveSpeed = player.movementSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed);
    }
}
