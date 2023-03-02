using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private InteractiveObject interactiveObject;

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isLookingAtInteractive())
            {
                interactiveObject.Interact();
                interactiveObject = null;
            }
        }
    }

    private bool isLookingAtInteractive()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 500))
        {
            //Debug.Log(hit.transform.gameObject.name);
            //Debug.DrawLine(cam.transform.position, hit.point, Color.red);
            if (hit.transform.gameObject.tag == "Interactive")
            {
                interactiveObject = hit.transform.gameObject.GetComponent<InteractiveObject>();
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
}

