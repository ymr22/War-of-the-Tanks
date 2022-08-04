using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public int m_PlayerNumber = 1;         
    public float m_Speed = 12f;            
    public float m_TurnSpeed = 180f;       
    public AudioSource m_MovementAudio;    
    public AudioClip m_EngineIdling;       
    public AudioClip m_EngineDriving;      
    public float m_PitchRange = 0.2f;

    
    private string m_MovementAxisName;     
    private string m_TurnAxisName;         
    private Rigidbody m_Rigidbody;         
    private float m_MovementInputValue;    
    private float m_TurnInputValue;        
    private float m_OriginalPitch;

    public float forceMovementConstant;
    public float forceRotationConstant;
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    private void OnEnable ()
    {
        m_Rigidbody.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }


    private void OnDisable ()
    {
        m_Rigidbody.isKinematic = true;
    }


    private void Start()
    {
        m_MovementAxisName = "Vertical" + m_PlayerNumber;
        m_TurnAxisName = "Horizontal" + m_PlayerNumber;

        m_OriginalPitch = m_MovementAudio.pitch;
    }
    


    private void EngineAudio()
    {
        // Play the correct audio clip based on whether or not the tank is moving and what audio is currently playing.

        if ( Mathf.Abs(m_MovementInputValue) < 0.1f && Mathf.Abs(m_TurnInputValue) < 0.1f )
        {
            if (m_MovementAudio.clip == m_EngineDriving )
            {
                m_MovementAudio.clip = m_EngineIdling ;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange , m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play();
            }
        }
        else
        {
            if (m_MovementAudio.clip == m_EngineIdling )
            {
                m_MovementAudio.clip = m_EngineDriving ;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange , m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play();
            }

        }
    
    }


    private void Update()
    {
        // Store the player's input and make sure the audio for the engine is playing.
        
        m_MovementInputValue = Input.GetAxis (m_MovementAxisName);
        m_TurnInputValue = Input.GetAxis (m_TurnAxisName);
        //m_Rigidbody.AddRelativeForce(0, 0, 1f, ForceMode.Acceleration);

        EngineAudio ();
        
        
        // Move and turn the tank.
        Move();
        Turn();
    }


    private void Move()
    {
        
        Time.fixedDeltaTime = 0.005f;
        Vector3 movement = new Vector3();
        if (Input.GetAxis((m_MovementAxisName)) > 0)
        {
            movement = transform.forward * m_MovementInputValue * m_Speed ;
        }
        else if (Input.GetAxis((m_MovementAxisName)) <= 0)
        {
            movement = transform.forward * m_MovementInputValue * (m_Speed / 5) * 2 ;
        }
        
        /*float Distance = Vector3.Distance(transform.position, movement);
        Vector3 pos = transform.position;
        
       
        transform.position = Vector3.MoveTowards(pos, pos+movement, (0.3f * Distance) * Time.deltaTime);
*/
       // transform.position = Vector3.Lerp(transform.position, movement, 0.3f);
        
        //m_Rigidbody.MovePosition(m_Rigidbody.position + movement );
       
        if (Input.GetButton (m_MovementAxisName))
        {
            //m_Rigidbody.MovePosition(m_Rigidbody.position + movement );
            m_Rigidbody.AddForce(movement * forceMovementConstant, ForceMode.Acceleration);
        }
        Debug.Log(m_Rigidbody.velocity.magnitude);
        //Debug.Log("Time is: " + Time.deltaTime);
        
        
    }


    private void Turn()
    { 
        // Adjust the rotation of the tank based on the player's input.
        float turn = 0;
        if (m_MovementInputValue > 0)
        {
            turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime ;
        }
        else if (m_MovementInputValue == 0)
        {     
            turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime ;
        }
        else
        {
            turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime * (-1) ;
        }
        
        Quaternion turnRotation = Quaternion.Euler(0f,turn * forceRotationConstant,0f);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }
}