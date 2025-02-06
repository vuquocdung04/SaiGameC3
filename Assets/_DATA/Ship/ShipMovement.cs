using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected float speed = 0.1f;
    void Update()
    {

    }

    private void FixedUpdate()
    {
        this.GetTargetPos();
        this.LookAtTarget();
        this.Moving();
    }

    protected virtual void GetTargetPos()
    {
        targetPos = InputManager.Instance.mouseWorldPos;
        this.targetPos.z = 0;
    }

    protected virtual void LookAtTarget()
    {
        Vector3 diff = this.targetPos - this.transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        this.transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }

    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(this.transform.parent.position, targetPos, this.speed);
        this.transform.parent.position = newPos;
    }
}
