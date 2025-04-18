using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class BoxPlacementManager : MonoBehaviour
{
    [Header("References")]
    public GameObject ghostBox;
    public float placementThreshold = 0.1f;

    private XRGrabInteractable grabInteractable;

    public static event Action OnBoxGrabbed;
    public static event Action OnBoxPlacedCorrectly;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable)
        {
            grabInteractable.selectEntered.AddListener(OnGrabStart);
            grabInteractable.selectExited.AddListener(OnGrabEnd);
        }

        if (ghostBox)
            ghostBox.SetActive(false);
    }

    private void OnGrabStart(SelectEnterEventArgs args)
    {
        if (ghostBox)
            ghostBox.SetActive(true);

        OnBoxGrabbed?.Invoke();
    }

    private void OnGrabEnd(SelectExitEventArgs args)
    {
        CheckPlacement();
    }

    private void CheckPlacement()
    {
        if (!ghostBox)
            return;

        float distance = Vector3.Distance(transform.position, ghostBox.transform.position);

        if (distance <= placementThreshold)
        {
            ghostBox.SetActive(false);
            OnBoxPlacedCorrectly?.Invoke();
        }
    }

    private void OnDestroy()
    {
        if (grabInteractable)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabStart);
            grabInteractable.selectExited.RemoveListener(OnGrabEnd);
        }
    }
}
