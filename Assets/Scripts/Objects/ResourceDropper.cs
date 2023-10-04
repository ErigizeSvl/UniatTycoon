using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDropper : MonoBehaviour
{
    //Public var
    public GameObject[] resources;
    public float spawnTime;

    //Priv var
    private int dropperTier;
    private bool isActive;


    void Start()
    {
        //Initialize var
        dropperTier = 1;
        isActive = true;
        StartCoroutine(SpawnCoroutine());

        InvokeRepeating("DropResource", spawnTime, 1f);
    }

    void DropResource()
    {
        if(resources[dropperTier - 1] != null)
        {
            Instantiate(resources[dropperTier - 1], transform.position, Quaternion.identity);
        }
    }

    //Fn change dropper state
    public void ChangeState(bool _state)
    {
        isActive = _state;

        if (isActive)
        {
            StartCoroutine(SpawnCoroutine());
        }
    }

    //Fn upgrade dropper tier
    public void UpgradeDropper()
    {
        if (dropperTier + 1 <= resources.Length)
        {
            dropperTier++;
        }
    }

    //Coroutine 2 instantiate resources
    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(spawnTime);
            DropResource();
        if (isActive)
        {
            StartCoroutine(SpawnCoroutine());
        }
    }
}
