using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpCallEvent : InteractiveObject
{
    public override bool CanInteract { get; set; }
    [SerializeField] private Text Counter;
    [SerializeField] private GameObject EscapeShip;
    [SerializeField] private Animator EscapeDoor1;
    [SerializeField] private Animator EscapeDoor2;
    private float seconds;
    private int minutes;
    public override void Interact()
    {
        if (CanInteract)
        {
            minutes = 1;
            seconds = -0.5f;
            Counter.enabled = true;
            CanInteract = false;
        }
    }

    void Start()
    {
        CanInteract = true;
        EscapeShip.SetActive(false);
        Counter.enabled = false;
    }

    void Update()
    {
        if (Counter.enabled)
        {
            if (seconds <= -0.5 && minutes > 0)
            {
                minutes -= 1;
                seconds = 59.48f;
            }
            else if (seconds <= 21 && seconds >= 20 && minutes == 0)
            {
                EscapeShip.SetActive(true);
                EscapeDoor1.SetBool("opening", true);
                seconds -= Time.deltaTime;
            }
            else if (seconds <= 0 && minutes == 0)
            {
                Counter.enabled = false;
                EscapeDoor1.SetBool("opening", false);
                StartCoroutine(OpenExitDoor2());
            }
            else
            {
                seconds -= Time.deltaTime;
            }
            Counter.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }

    private IEnumerator OpenExitDoor2()
    {
        yield return new WaitForSeconds(3);
        EscapeDoor2.SetBool("opening", true);
    }

    public override void Sabotage()
    {
        throw new System.NotImplementedException();
    }
}
