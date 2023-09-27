using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResourceManager : MonoBehaviour
{
    //Pub Var
    public Text resourceTxt;

    //Priv Var
    private float currentResources;

    void Start()
    {
        currentResources = 0f;
        UpdateUI();
    }

    //Add Resources
    public void AddResources(float _value)
    {
        currentResources += _value;
        UpdateUI();
    }

    //Remove Resources
    public void RemoveResources(float _value)
    {
        currentResources -= _value;
        UpdateUI();
    }

    //Return Resources
    public float CurrentResources()
    {
        return currentResources;
    }

    //Fn Update UI
    public void UpdateUI()
    {
        resourceTxt.text = "Candy: $" + currentResources;
    }
}
