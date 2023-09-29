using UnityEngine;

public class PlayerRotationHandler : MonoBehaviour
{
    public Transform playerTransform;
    public Camera mainCamera;
    public LayerMask aimLayerMask;
    public Transform gunTransform;
    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, aimLayerMask))
        {
            Vector3 targetDirection = hit.point - gunTransform.position;

            playerTransform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(targetDirection, Vector3.up));
        }
    }
}