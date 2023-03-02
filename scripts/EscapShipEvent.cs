using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapShipEvent : InteractiveObject
{
    public override bool CanInteract { get; set; }
    [SerializeField] private Text EndMessage;

    void Start()
    {
        EndMessage.text = "";
    }

    public override void Interact()
    {
        StartCoroutine(EscapeSpaceStation());
    }

    private IEnumerator EscapeSpaceStation()
    {
        EndMessage.text = "Aller monte !";
        yield return new WaitForSeconds(3);
        Application.Quit();
    }
    public override void Sabotage()
    {
        throw new System.NotImplementedException();
    }
}
