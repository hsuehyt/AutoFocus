using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class AutoFocus : MonoBehaviour
{
    public Volume volume;
    private DepthOfField dof;

    void Start()
    {
        volume.profile.TryGet(out dof);
    }

    void Update()
    {
        if (dof != null)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit))
                dof.focusDistance.value = hit.distance;
        }
    }
}
