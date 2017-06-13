using UnityEngine;
using System.Collections;

public class PowerupManager : MonoBehaviour
{

    // Use this for initialization


    public bool ShieldOn;
    public float PowerUpDuration;
    public GameObject PowerShield;
    public bool JumpOn;
    public bool MagnetOn;
    public GameObject MagnetAbsorb;
    public float MagnetUpDuration;
    public PlayerController player;

    private float Jumpforce;
    public bool WingsOn;
    public float WingsDuration;


    public GameObject Wings;
    public GameObject deactivateWings;

    public TimeController Timemanagement;
    public float TimeRewindingDuration = 2.8f;
    public float speed = 40;

    public bool RewindOn = false;

    //public BasicTimeSkip ChangingColorTimeSkip;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        Timemanagement = FindObjectOfType<TimeController>();
        //ChangingColorTimeSkip = FindObjectOfType<BasicTimeSkip>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (ShieldOn)
        {
            PowerShield.SetActive(true);
            PowerUpDuration -= Time.deltaTime;
            if (PowerUpDuration <= 0)
            {
                ShieldOn = false;
                PowerShield.SetActive(false);
            }
        }
        if (JumpOn)
        {
            player.myRigidBody.velocity = new Vector2(player.myRigidBody.velocity.x, Jumpforce);
            
            JumpOn = false;
        }
        if(MagnetOn)
        {
            MagnetAbsorb.SetActive(true);
            MagnetUpDuration -= Time.deltaTime;
            if(MagnetUpDuration <= 0)
            {
                MagnetOn = false;
                MagnetAbsorb.SetActive(false);
            }
        }
        if(WingsOn)
        {
            Wings.SetActive(true);
            deactivateWings.SetActive(true);
            player.transform.position += new Vector3(speed * Time.deltaTime, 0.3f, 0.0f);
            WingsDuration -= Time.deltaTime;

            if (WingsDuration <= 0)
            {

                WingsOn = false;
                deactivateWings.SetActive(false);
                Wings.SetActive(false);
            }
        }
        //if (RewindOn)
        //{
           
        //        Timemanagement.isReversing = true;
        //        TimeRewindingDuration -= Time.deltaTime;
        //        player.myRigidBody.isKinematic = true;
        //        ChangingColorTimeSkip.enabled = true;
        //        if (TimeRewindingDuration<=0)
        //        {
        //            player.myRigidBody.isKinematic = false;
        //            RewindOn = false;
        //            Timemanagement.isReversing = false;
        //            ChangingColorTimeSkip.enabled = false;
        //            player.Rewinding = false;
        //            player.myCollider.isTrigger = false;
        //        }
            
        //}
    }
    public void ActivatePowerUp(bool Shield, float time)
    {
        ShieldOn = Shield;
        PowerUpDuration = time;

    }
    public void ActivateJumpDash(bool Jump, float jumpforce)
    {

        JumpOn = Jump;
        this.Jumpforce = jumpforce;
    }

    public void ActivateMagnetPower(bool MagnetIstrue, float Magnettime)
    {
        MagnetOn = MagnetIstrue;
        MagnetUpDuration = Magnettime;
    }

    public void ActivateWingPower(bool WingsISTrue, float Wingtime)
    {
        WingsOn = WingsISTrue;
        WingsDuration = Wingtime;
    }

    //public void ActivateRewindingTime(bool ObtainRewinding, float rewindtime)
    //{
    //    RewindOn = ObtainRewinding;
    //    TimeRewindingDuration = rewindtime;
    //}
}
