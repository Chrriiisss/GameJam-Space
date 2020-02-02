using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoFinder : MonoBehaviour
{

    private Camera cam;
    public Canvas canvasObject;
    public Text machineName;

    public float detectDistance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        canvasObject.enabled = true;
        machineName.text = "SUPER TEXT";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 CameraCenter = cam.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, cam.nearClipPlane));
        Debug.DrawRay(CameraCenter, cam.transform.forward, Color.green, detectDistance);
        RaycastHit hit;

        if (Physics.Raycast(CameraCenter, cam.transform.forward, out hit, detectDistance) &&
            (hit.collider.gameObject.CompareTag("Machine") || hit.collider.transform.GetChild(0).CompareTag("Machine")))
        {
            canvasObject.enabled = true;
            ISubsystem subsystem = hit.transform.GetComponentInParent<ISubsystem>();

            machineName.text = "" + subsystem.ToString() + ": Press R/Q or Controller Y for info";
            if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button3))
            {
                WindowsVoice.speak(subsystem.GetDescription());
            }
        }
        else
        {
            canvasObject.enabled = false;
        }

    }
}
