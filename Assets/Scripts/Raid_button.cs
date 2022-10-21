using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raid_button : MonoBehaviour
{
    [SerializeField] private Raid_control raid_control;
    [SerializeField] private Image scrolling;
    private float autoRaidTimer = 5;
    [SerializeField] private float playerRaidTimer;
    [SerializeField] private List<Sprite> ButtonsSprite;
    [SerializeField] private Image currentButton;
    [SerializeField] public Animator PauseBut_anim;
    [SerializeField] public Characteristics characteristics;
    public GameObject PauseImg;
    public GameObject PlayImg;
    public Animator m_animator;
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
    public bool isActive = false;   
    public bool isAutoRaid_boost { get; set; }
    private float checkTimer;
    void FixedUpdate()
    {
        if (buttonState == ButtonState.AutoRaid)
        {
            checkTimer = 3f - m_timer;
            characteristics.CheckRaidTimer(checkTimer);
            isActive = true;
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
                        PauseBut_anim.SetBool("IsActive", true);
                        PlayImg.SetActive(true);
                        PauseImg.SetActive(false);
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
                        PauseBut_anim.SetBool("IsActive", true);
                        PlayImg.SetActive(true);
                        PauseImg.SetActive(false);
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
                    raid_control.CloseDice();
                }
            }

            if (m_timer >= autoRaidTimer / 2)
            {
                if (m_canRaid)
                {
                    characteristics.CheckActiveRaid(false);
                    currentButton.sprite = ButtonsSprite[1];
                    m_canRaid = false;
                }
            }

        }

        else if (buttonState == ButtonState.Stopped)
        {
           

        }
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
                characteristics.CheckActiveRaid(true);
                isActive = true;
                currentButton.sprite = ButtonsSprite[0];
                m_hideTimer = 0;
               m_imageIsHide = true;
               m_isStopping = false;
                if (buttonState == ButtonState.Stopped || m_canRaid == false)
                {
                    m_canRaid = true;
                    m_timer = 0;
                    PauseBut_anim.SetBool("IsActive", false);
                    buttonState = ButtonState.AutoRaid;
                    raid_control.StartRaid();
                    m_animator.SetTrigger("Press");
                    PlayImg.SetActive(false);
                    PauseImg.SetActive(true);
          //          if(Tutorial.CheckTutorStep() == 10)
       //             {
      //                  Debug.Log("Step 2 = " + Tutorial.CheckTutorStep());
      //                  GlovalEventSystem.TutorialSteps(10);
      //              }
      //              if (Tutorial.CheckTutorStep() == 9)
       //             {
     //                   Debug.Log("Step 1 = " + Tutorial.CheckTutorStep());
         //              GlovalEventSystem.TutorialSteps(9);
       //             }
                }
        }
    }
    public void GoRaidAfterOffline()
    {
        Debug.Log("ChecnCanRaid =  " + raid_control.ChecnCanRaid());
        if (raid_control.ChecnCanRaid())
        {
            isActive = true;
            currentButton.sprite = ButtonsSprite[0];
            m_hideTimer = 0;
            m_imageIsHide = true;
            m_isStopping = false;
            if (buttonState == ButtonState.Stopped || m_canRaid == false)
            {
                m_canRaid = true;
                m_timer = 0;
                PauseBut_anim.SetBool("IsActive", false);
                buttonState = ButtonState.AutoRaid;
                raid_control.StartRaid();
                m_animator.SetTrigger("Press");
                PlayImg.SetActive(false);
                PauseImg.SetActive(true);
                Debug.Log("CAN _1");
            }
                Debug.Log("CAN _2");
        }
    }
    public void PauseRaid()
    {
        m_isStopping = true;
        isActive = false;
        if (PauseBut_anim.GetBool("IsActive"))
        {
            if (raid_control.ChecnCanRaid())
            {
                PauseBut_anim.SetBool("IsActive", false);
                GoToAutoRaid();
                PlayImg.SetActive(false);
                PauseImg.SetActive(true);
            }
        }
        else
        {
            PauseBut_anim.SetBool("IsActive", true);
            PlayImg.SetActive(true);
            PauseImg.SetActive(false);
        }
    }
    public void ForceStopRaid()
    {
        m_isStopping = true;
        isActive = false;
        buttonState = ButtonState.Stopped;

    }
}
