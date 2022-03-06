using UnityEngine;
using UnityEngine.Audio;

public class TankMovement : MonoBehaviour
{
    public int m_PlayerNumber = 1;
    public float m_Speed = 30f;
    public float m_TurnSpeed = 180f;
    public float m_PitchRange = 0.2f;
    /*public AudioSource m_MovementAudio;
    public AudioClip m_EngineIdle;
    public AudioClip m_EngineDrive;*/

    private string m_MovementAxisName;
    private string m_TurnAxisName;
    private float m_MovementInputValue;
    private float m_TurnInputValue;
    private float m_OriginalPitch;
    private Rigidbody m_Rigidbody;

    private void Awake() {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable() {
        m_Rigidbody.isKinematic = false; //at start of new game
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }

    private void OnDisable() {
        m_Rigidbody.isKinematic = true; //when player dies, disables the player object
    }

    private void Start() {
        m_MovementAxisName = "Vertical" + m_PlayerNumber; //different virtual axis for different players
        m_TurnAxisName = "Horizontal" + m_PlayerNumber;
        //m_OriginalPitch = m_MovementAudio.pitch;
    }

    private void Update() {
        //Getting input
        m_MovementInputValue = Input.GetAxisRaw(m_MovementAxisName);
        m_TurnInputValue = Input.GetAxisRaw(m_TurnAxisName);

    }

    /*private void EngineAudio() {
        //for audio playing
        if(Mathf.Abs(m_MovementInputValue) < 0.1f && Mathf.Abs(m_TurnInputValue) < 0.1f) {  //if tank is not moving
            if(m_MovementAudio.clip == m_EngineDrive) {
                m_MovementAudio.clip = m_EngineIdle;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play();
            }
        } else {
            if (m_MovementAudio.clip == m_EngineIdle) {
                m_MovementAudio.clip = m_EngineDrive;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play();
            }
        }
    }*/

    private void FixedUpdate() {
        //Moving the tank
        Move();
        Turn();
    }

    private void Move() {
        //forward and backwards movement
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }

    private void Turn() {
        //left or right rotation
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }
}
