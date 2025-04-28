using UnityEngine;

public class GhostBoxHandler : MonoBehaviour
{
    [Header("References")]
    public GameObject ghostBox;
    public GameObject list;
    public float placementThreshold = 0.1f;
    public int boxNumber;
    private listtextmanager listscript;

    private Rigidbody rb;

    private void Start()
    {
        // Get the Rigidbody component (only needed if you want to modify physics)
        rb = GetComponent<Rigidbody>();

        listscript = list.GetComponent<listtextmanager>();

        if (ghostBox)
            ghostBox.SetActive(false); // Start with ghost box hidden
    }

    public void ShowGhostBox()
    {
        if (ghostBox)
            ghostBox.SetActive(true); // Show ghost box when grabbing
    }

    public void CheckPlacement()
    {
        if (!ghostBox || !rb)
            return;

        // Calculate the distance between the real box and ghost box
        float distance = Vector3.Distance(transform.position, ghostBox.transform.position);

        if (distance <= placementThreshold)
        {
            // Snap the real box to the ghost box location and rotation
            transform.position = ghostBox.transform.position;
            transform.rotation = ghostBox.transform.rotation;

            // Disable Rigidbody physics interactions
            rb.isKinematic = true;  // Prevents the box from moving after placing

            // Optionally: zero out the velocity to stop any motion
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            listscript.UpdateText(boxNumber); // Call the UpdateText method from listtextmanager
            // Hide the ghost box (indicating successful placement)
            ghostBox.SetActive(false);
            Debug.Log("Box placed correctly!");
        }
        else
        {
            Debug.Log("Box not placed correctly.");
        }
    }
}
