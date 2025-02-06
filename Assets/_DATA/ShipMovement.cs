using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 worldPos;
    [SerializeField] protected float speed = 0.1f;
    void Update()
    {
        // input pos mouse
        worldPos = InputManager.Instance.mouseWorldPos;
        this.worldPos.z = 0;

        Vector3 newPos = Vector3.Lerp(this.transform.parent.position, worldPos, this.speed);
        this.transform.parent.position = newPos;
    }
}
