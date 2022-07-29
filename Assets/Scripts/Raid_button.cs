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
    [SerializeField] private List<Sprite> ButtonsSprite;
    [SerializeField] private Image currentButton;
    [SerializeField] private AutoRaid autoraid;
    private Animator m_animator;
    public enum ButtonState
    {
        Stopped,
        AutoRaid,
        PlayerRaid
    }
    public ButtonState buttonState;
    public float m_timer;
    public bool m_isStopping = false;
    private bool m_imageIsHide = false;
    public bool m_canRaid;
    private float m_hideTimer;
    public bool isAutoRaid_boost { get; set; }
    void FixedUpdate()
    {
        if (buttonState == ButtonState.AutoRaid)
        {
            m_timer += Time.fixedDeltaTime;

            scrolling.fillAmount = m_timer / autoRaidTimer;
            if (isAutoRaid_boost)
            {
                if (m_timer >= playerRaidTimer)
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
            else if (!isAutoRaid_boost)
            {
                if (m_timer >= autoRaidTimer)
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
            if (m_imageIsHide)
            {
                m_hideTimer += Time.fixedDeltaTime;

                if (m_hideTimer > 3f)
                {
                    m_imageIsHide = false;
                    raid_control.CheckSlots();
                }
            }

            if (m_timer >= autoRaidTimer / 2)
            {
                if (m_canRaid)
                {
                    currentButton.sprite = ButtonsSprite[1];
                    m_canRaid = false;
                }
            }

        }
/*        else if (buttonState == ButtonState.PlayerRaid)
        {
            m_timer += Time.fixedDeltaTime;

            scrolling.fillAmount = m_timer / playerRaidTimer;

            if (m_timer > playerRaidTimer)
            {
                buttonState = ButtonState.Stopped;
                m_timer = 0;
            }
        }*/
        else if (buttonState == ButtonState.Stopped)
        {
           

        }
    }
    private void OnEnable()
    {
        m_animator = GetComponent<Animator>();
    }
    public void GoToPlayerRaid()
    {
        if (raid_control.ChecnCanRaid())
        {
            m_imageIsHide = true;
            m_isStopping = false;
            if (buttonState == ButtonState.Stopped || m_timer >= autoRaidTimer / 2)
            {
                m_canRaid = true;
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
            
            currentButton.sprite = ButtonsSprite[0];
            m_hideTimer = 0;
            m_imageIsHide = true;
            m_isStopping = false;
            if (buttonState == ButtonState.Stopped || m_canRaid == false)
            {
                m_canRaid = true;
                m_timer = 0;
                autoraid.PauseBut_anim.SetBool("IsActive", false);
                buttonState = ButtonState.AutoRaid;
                raid_control.StartRaid();
                m_animator.SetTrigger("Press");
                autoraid.PlayImg.SetActive(false);
                autoraid.PauseImg.SetActive(true);
            }
        }
    }
    public void PauseRaid()
    {
        m_isStopping = true;
    }
    
}
