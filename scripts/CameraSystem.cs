using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : InteractiveObject
{
    [SerializeField] public override bool CanInteract { get; set; }
    [SerializeField] private GameObject[] Cameras;
    [SerializeField] private GameObject PlayerCamera;
    private bool InCamSystem = false;
    private int CamIndex = 0;

    private void Start()
    {
        CanInteract = true;
    }

    void Update()
    {
        if (InCamSystem)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Cameras[CamIndex].SetActive(false);

                if (CamIndex == 0)
                {
                    CamIndex = Cameras.Length-1;
                }
                else
                {
                    CamIndex -= 1;
                }
                Cameras[CamIndex].SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Cameras[CamIndex].SetActive(false);
                if (CamIndex == Cameras.Length-1)
                {
                    CamIndex = 0;
                }
                else
                {
                    CamIndex += 1;
                }
                Cameras[CamIndex].SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                ExitCamSystem();
            }
        }
    }

    private void ExitCamSystem()
    {
        StartCoroutine(ExitCamDelay());
    }

    private void EnterCamSystem()
    {
        StartCoroutine(EnterCamDelay());
    }

    public override void Interact()
    {
        EnterCamSystem();
    }

    private IEnumerator EnterCamDelay()
    {
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.F));
        InCamSystem = true;
        Cameras[CamIndex].SetActive(true);
        PlayerCamera.SetActive(false);
    }

    private IEnumerator ExitCamDelay()
    {
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.F));
        InCamSystem = false;
        PlayerCamera.SetActive(true);
        Cameras[CamIndex].SetActive(false);
    }

    public bool GetInCamSystem()
    {
        return InCamSystem;
    }

    public override void Sabotage()
    {
        throw new System.NotImplementedException();
    }
}
