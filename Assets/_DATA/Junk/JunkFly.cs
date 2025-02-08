using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : ParentFly
{
    [SerializeField] protected float minCam;
    [SerializeField] protected float maxCam;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.speed = 0.5f;
        this.minCam = -17;
        this.maxCam = 17;
    }

    protected virtual void OnEnable()
    {
        GetFlyDirection();
    }

    protected virtual void GetFlyDirection()
    {
        Vector3 camPos = GameCtrl.Instance.Cam.transform.position;
        Vector3 objPos = transform.parent.position;
        camPos.x += Random.Range(minCam, maxCam);
        camPos.z += Random.Range(minCam, maxCam);

        Vector3 diff = camPos - objPos;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y,diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0,0,rot_z);
        //transform.parent.eulerAngles = new Vector3(0,0,rot_z);

        Debug.DrawLine(objPos, objPos + diff * 7, Color.red, Mathf.Infinity);
    }

}
