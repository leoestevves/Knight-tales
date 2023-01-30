using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCamera : MonoBehaviour
{
    private Transform player;
    private float playerX;
    private float playerY;

    public float offSetX;
    public float smooth;

    public float limitUp;
    public float limitDown;
    public float limitLeft;
    public float limitRight;




    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<MageController>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerX = Mathf.Clamp(player.position.x + offSetX, limitLeft, limitRight);
        playerY = Mathf.Clamp(player.position.y, limitDown, limitUp);

        transform.position = Vector3.Lerp(transform.position, new Vector3(playerX, playerY, transform.position.z), smooth);
    }
}
