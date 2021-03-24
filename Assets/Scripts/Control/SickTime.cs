using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SickTime : MonoBehaviour
{
    [SerializeField] float timeUntilDie = 10f;
    [SerializeField] Slider silderContainer;
    float timerSickness = 0f;
    bool isSick = false;

    void Start()
    {
        silderContainer = silderContainer.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        silderContainer.value = timerSickness;
        if (isSick)
        {
            timerSickness += Time.deltaTime;
        }

        if (timerSickness >= timeUntilDie)
        {
            Debug.Log("Player Died");
        }
    }

    public float GetCurrentTimeSick() { return timerSickness; }

    public void ActivateSickTime(bool isActive)
    {
        isSick = isActive;
    }

}
