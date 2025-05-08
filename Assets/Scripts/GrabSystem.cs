using UnityEngine;

public class GrabSystem : MonoBehaviour
{
    public Transform cameraTransform;

    public float grabDistance = 3f;

    public KeyCode grabKey = KeyCode.F;
    public KeyCode rotateLeftKey = KeyCode.Q;
    public KeyCode rotateRightKey = KeyCode.E;

    public float rotationSpeed = 100f;

    public Transform holdPoint;

    private GameObject holdObject;

    private GrabbableObject holdScript;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);

        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        if (Input.GetKeyDown(grabKey))
        {
            if (holdObject == null)
            {
                if(Physics.Raycast(ray, out hit, grabDistance))
                {
                    if (hit.collider.CompareTag("Grabbable"))
                    {
                        holdObject = hit.collider.gameObject;

                    }
                    if (holdScript != null)
                    {
                        //holdScript.Grab(holdPoint)
                    }
                }
            }
        }
        else
        {
            //holdScript.Release();

            holdObject = null;
            holdScript = null;
        }
    }
}
