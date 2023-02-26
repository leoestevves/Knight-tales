using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private Transform platform, pointA, pointB;
    [SerializeField] private float platformSpeed;

    [SerializeField] private Vector3 pointDestiny;
    
    [SerializeField] private GameObject player;

    private void Start()
    {
        platform.position = pointA.position;
        pointDestiny = pointB.position;
    }

    private void Update()
    {
        if(platform.position == pointA.position)
        {
            pointDestiny = pointB.position;
        }

        if(platform.position == pointB.position)
        {
            pointDestiny = pointA.position;
        }

        platform.position = Vector3.MoveTowards(platform.position, pointDestiny, platformSpeed * Time.deltaTime);
    }
}
