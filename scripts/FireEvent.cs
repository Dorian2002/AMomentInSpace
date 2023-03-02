using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEvent : InteractiveObject
{
    [SerializeField] public override bool CanInteract { get; set; }
    [SerializeField] private GameObject FireStarter;
    [SerializeField] private ExtinguisherSystem extinguisher;

    void Start()
    {
        DownFire();
        //StartCoroutine(FireEventTrigger());
    }

    public IEnumerator FireEventTrigger()
    {
        while (true)
        {
            if (CanInteract == false)
            {
                if (Random.Range(0, 2) == 1)
                {
                    UpFire();
                }
            }
            yield return new WaitForSeconds(10f);
        }
    }

    private void UpFire()
    {
        CanInteract = true;
        FireStarter.SetActive(true);
    }

    private void DownFire()
    {
        CanInteract = false;
        FireStarter.SetActive(false);
    }

    public override void Interact()
    {
        if (CanInteract && extinguisher.CanInteract == false)
        {
            DownFire();
        }
    }

    public override void Sabotage()
    {
        UpFire();
    }

}
