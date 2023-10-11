using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Upgrader : MonoBehaviour
{
    //Public var
    public ResourceManager resourceManager;
    public float cost;
    public string text;

    public UnityEvent onActivated;

    //Priv var
    private TextMesh textMesh;


    void Start()
    {
        //Initialize var
        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = text + " $" + cost;
    }

    //If obj enters trigger...
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (resourceManager.CurrentResources() >= cost)
            {
                resourceManager.RemoveResources(cost);
                onActivated.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
