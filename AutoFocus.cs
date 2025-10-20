using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class AutoFocus : MonoBehaviour
{
    public Volume volume;
    private DepthOfField dof;
    public CameraController cameraController; // Reference to your CameraController

    void Start()
    {
        // Grab the Depth of Field component from the Volume
        if (volume != null)
            volume.profile.TryGet(out dof);

        // Automatically find the CameraController on the same GameObject if not assigned
        if (cameraController == null)
            cameraController = GetComponent<CameraController>();
    }

    void Update()
    {
        if (dof == null || cameraController == null) return;

        // If CameraController has a valid focal point, use it
        if (cameraController != null && cameraController.gameObject != null)
        {
            GameObject focal = cameraController.GetFocalPoint();
            if (focal != null)
            {
                float distance = Vector3.Distance(transform.position, focal.transform.position);
                dof.focusDistance.value = distance;
            }
        }
    }
}
