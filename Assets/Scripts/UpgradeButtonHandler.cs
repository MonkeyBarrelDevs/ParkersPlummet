using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonHandler : MonoBehaviour
{
    EventHandler eventHandler;

    void Start()
    {
        eventHandler = GetComponent<EventHandler>();
    }

    public void BuyHorsepower()
    {
        eventHandler.Buy(EventHandler.Upgrades.Horsepower);
    }


    public void BuyFlexibility()
    {
        eventHandler.Buy(EventHandler.Upgrades.Flexibility);
    }

    public void BuyTorque()
    {
        eventHandler.Buy(EventHandler.Upgrades.Torque);
    }

    public void BuyTime()
    {
        eventHandler.Buy(EventHandler.Upgrades.Time);
    }
}
