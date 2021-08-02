using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player;


    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z - 8f);
    }
}