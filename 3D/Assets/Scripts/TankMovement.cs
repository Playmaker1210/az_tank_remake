using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public int m_PlayerNumber = 1;
    public float m_Speed = 150f;
    public float m_TurnSpeed = 180f;   

    private string m_MovementAxisName;
    private string m_TurnAxisName;
    protected float m_MovementInputValue;
    private float m_TurnInputValue;
    private Rigidbody m_Rigidbody;
    private Vector3 movement;

    public CharacterController controller;

    //getter for the audio
    public float getMovementInputValue() {
        return m_MovementInputValue;
    }
    public float getTurnInputValue() {
        return m_TurnInputValue;
    }

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
    }

    private void Update() {
        //Getting input
        m_MovementInputValue = Input.GetAxisRaw(m_MovementAxisName);
        m_TurnInputValue = Input.GetAxisRaw(m_TurnAxisName);
    }   

    private void FixedUpdate() {
        //Moving the tank
        Move();
        Turn();
    }

    private void Move() {
        //forward and backwards movement
        movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;
        //m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
        controller.Move(movement);
    }

    private void Turn() {
        //left or right rotation
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }
}
