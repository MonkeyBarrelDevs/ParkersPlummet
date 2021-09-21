using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpriteHandler : MonoBehaviour
{
    // Fields
    [SerializeField] EventHandler.Upgrades upgrade;
    [SerializeField] List<Sprite> sprites;

    // Hiddens
    EventHandler eventHandler;

    // Start is called before the first frame update
    void Start()
    {
        eventHandler = GameObject.FindGameObjectWithTag("EventHandler").GetComponent<EventHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (eventHandler.upgradeLevels.TryGetValue(upgrade, out int level))
            gameObject.GetComponent<Image>().sprite = sprites[level];
    }
}
