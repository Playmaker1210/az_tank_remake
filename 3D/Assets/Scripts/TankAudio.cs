using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAudio : MonoBehaviour
{
    public AudioSource m_MovementAudio;
    public AudioClip m_EngineIdle;
    public AudioClip m_EngineDrive;
    public TankMovement tankMovement;
    public float m_PitchRange = 0.2f;
    private float m_OriginalPitch;

    private void Start() {
        m_OriginalPitch = m_MovementAudio.pitch;
    }

    private void EngineAudio() {
        //for audio playing
        if(Mathf.Abs(tankMovement.getMovementInputValue()) < 0.1f && Mathf.Abs(tankMovement.getTurnInputValue()) < 0.1f) {  //if tank is not moving
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
    }
}
