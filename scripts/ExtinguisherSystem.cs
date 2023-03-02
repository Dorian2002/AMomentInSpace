using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtinguisherSystem : InteractiveObject
{
    public override bool CanInteract { get; set; }
    [SerializeField] private Image Extinguisher;

    public override void Interact()
    {
        if (CanInteract)
        {
            CanInteract = false;
            gameObject.SetActive(false);
            Extinguisher.gameObject.SetActive(true);
        }
    }

    void Start()
    {
        CanInteract = true;
        Extinguisher.gameObject.SetActive(false);
    }

    public override void Sabotage()
    {
        throw new System.NotImplementedException();
    }
}

