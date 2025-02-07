using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : LoadAutoComponents
{
    [SerializeField] protected float speed;
    [SerializeField] protected Vector3 direction = Vector3.right;

    private void Update()
    {
        this.transform.parent.Translate(this.direction * speed * Time.deltaTime);
    }
}
