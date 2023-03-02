using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PassSystem : InteractiveObject
{
    public override bool CanInteract { get; set; }
    [SerializeField] private Image passUI;

    public override void Interact()
    {
        if (CanInteract)
        {
            CanInteract = false;
            GetComponent<MeshRenderer>().enabled = false;
            passUI.gameObject.SetActive(true);
        }
    }

    private void Start()
    {
        passUI.gameObject.SetActive(false);
        CanInteract = true;
    }

    public override void Sabotage()
    {
        throw new System.NotImplementedException();
    }
}
