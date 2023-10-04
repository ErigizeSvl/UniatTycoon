using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDetector : MonoBehaviour
{
    //Public Var
    public ResourceManager resourceManager;

    //If Obj enters Trigger...
    private void OnTriggerEnter(Collider other)
    {
        //If Obj enters Trigger && isResource...
        if (other.gameObject.GetComponent<Resource>())
        {
            //Send resource value to manager & destroy
            resourceManager.AddResources(other.gameObject.GetComponent<Resource>().value);
            Destroy(other.gameObject);
        }
    }
}
