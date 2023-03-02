using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEvent : InteractiveObject
{
    [SerializeField] private GameObject Lights;
    private bool AreLightsUp;
    [SerializeField] public override bool CanInteract { get; set; }
    [SerializeField] private Door[] Doors;

    private void Start()
    {
        UpLight();
        //StartCoroutine(LightEventTrigger());
    }

    private void DownLight()
    {
        CanInteract = true;
        AreLightsUp = false;
        Lights.SetActive(false);
        RenderSettings.fog = true;
        foreach (Door d in Doors)
        {
            d.OpenDoor(true);
        }
    }
    private void UpLight()
    {
        CanInteract = false;
        AreLightsUp = true;
        Lights.SetActive(true);
        RenderSettings.fog = false;
        foreach (Door d in Doors)
        {
            d.OpenDoor(false);
        }
    }
    public IEnumerator LightEventTrigger()
    {
        while (true)
        {
            if (CanInteract == false)
            {
                if (Random.Range(0, 10) == 1)
                {
                    DownLight();
                }
            }
            yield return new WaitForSeconds(10f);
        }
    }

    public override void Interact()
    {
        if (CanInteract)
        {
            UpLight();
        }
    }

    public override void Sabotage()
    {
        DownLight();
    }

    public bool GetAreLightsUp()
    {
        return AreLightsUp;
    }
}
