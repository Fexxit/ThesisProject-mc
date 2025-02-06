using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IInteractable
{
    void Interact();
}


public class PlayerInteract : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] Camera camera;
    [SerializeField] float interactionRange;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnInteract(InputValue input)
    {
        Ray ray = new Ray
        {
            origin = camera.transform.position,
            direction = camera.transform.forward,
        };

        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}
