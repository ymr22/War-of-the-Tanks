using UnityEngine;

public class UIDirectionControl : MonoBehaviour
{
    // This class is used to make sure world space UI
    // elements such as the health bar face the correct direction.

    public bool m_UseRelativeRotation = true;       // Use relative rotation should be used for this gameobject?


    private Quaternion m_RelativeRotation;          // The local rotatation at the start of the scene.

    public GameObject HealthSlider;
    private void Start ()
    {
        m_RelativeRotation = transform.parent.localRotation;

        
    }


    private void Update ()
    {
        if (m_UseRelativeRotation)
            transform.rotation = m_RelativeRotation;
        //HealthSlider.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        //HealthSlider.transform.position = new Vector3(0f, 0f, 0f);
        //transform.Translate(new Vector3(m_RelativeRotation.x, 0, m_RelativeRotation.z));
    }
}