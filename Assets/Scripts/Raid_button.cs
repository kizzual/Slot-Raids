using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raid_button : MonoBehaviour
{
    [SerializeField] private Raid_control raid_control;
    [SerializeField] private Image scrolling;
    [SerializeField] private float autoRaidTimer;
    [SerializeField] private float playerRaidTimer;
    private Animator m_animator;
    private enum ButtonState
    {
        Stopped,
        AutoRaid,
        PlayerRaid
    }
    private ButtonState buttonState;
    private float m_timer;
    private bool m_isStopping = false;
    private bool m_imageIsHide = false;
    void FixedUpdate()
    {
        if (buttonState == ButtonState.AutoRaid)
        {
            m_timer += Time.fixedDeltaTime;

            scrolling.fillAmount = m_timer / autoRaidTimer;
            if (m_timer > autoRaidTimer)
            {
                if (!m_isStopping)
                {
                    buttonState = ButtonState.Stopped;
                    GoToAutoRaid();
                }
                else
                {
                    buttonState = ButtonState.Stopped;
                    m_timer = 0;
                }
            }

        }
        else if (buttonState == ButtonState.PlayerRaid)
        {
            m_timer += Time.fixedDeltaTime;

            scrolling.fillAmount = m_timer / playerRaidTimer;

            if (m_timer > playerRaidTimer)
            {
                buttonState = ButtonState.Stopped;
                m_timer = 0;
            }
        }
        else if(buttonState == ButtonState.Stopped)
        {
            if(m_imageIsHide)
            {
                m_timer += Time.fixedDeltaTime;

                if (m_timer > 2f)
                {
                    m_imageIsHide = false;
                    raid_control.CheckSlots();
                }
            }
            
        }
    }
    private void OnEnable()
    {
        buttonState = ButtonState.Stopped;
        m_timer = 0;
        m_imageIsHide = false;
        m_animator = GetComponent<Animator>();
    }
    public void GoToPlayerRaid()
    {
        if (raid_control.ChecnCanRaid())
        {
            m_imageIsHide = true;
            m_isStopping = false;
            if (buttonState == ButtonState.Stopped)
            {
                m_timer = 0;
                buttonState = ButtonState.PlayerRaid;
                m_animator.SetTrigger("Press");
                raid_control.StartRaid();
            }
        }
    }
    public void GoToAutoRaid()
    {
        if (raid_control.ChecnCanRaid())
        {
            m_imageIsHide = true;
            m_isStopping = false;
            if (buttonState == ButtonState.Stopped)
            {
                m_timer = 0;
                buttonState = ButtonState.AutoRaid;
                raid_control.StartRaid();
                m_animator.SetTrigger("Press");
            }
        }
    }
    public void PauseRaid()
    {
        m_isStopping = true;
    }
    
}
