using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    // Public Var
    public float speed;

    // Private Var
    private Vector3 movVector;
    void Start()
    {
        movVector = transform.forward * speed;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<Resource>())
        {
            Transform collidedObject = collision.gameObject.transform;

            collidedObject.position = new Vector3(collidedObject.position.x + movVector.x * Time.deltaTime,
                                                  collidedObject.position.y + movVector.y * Time.deltaTime,
                                                  collidedObject.position.z + movVector.z * Time.deltaTime);
        }
    }
}
