using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] protected float speed = 4f;
    [SerializeField] protected Vector3 direction = Vector3.right;

    private void Update()
    {
        this.transform.parent.Translate(this.direction * speed * Time.deltaTime);
    }

}
