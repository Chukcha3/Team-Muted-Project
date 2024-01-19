using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDescription : MonoBehaviour
{
    [SerializeField] public TMP_Text name;
    [SerializeField] public TMP_Text description;
    [SerializeField] Image image;
    public bool isMouseOnSlot = false;
    public bool isMouseOnCraft = false;
    // Start is called before the first frame update
    void Start()
    {
        image.color = new Color(0, 0, 0, 0);
        name.color = new Color(0, 0, 0, 0);
        description.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
        if (isMouseOnSlot)
        {
            image.color = new Color(255, 255, 255, 255);
            name.color = new Color(0, 0, 0, 255);
            description.color = new Color(0, 0, 0, 255);
        }
        else
        {
            image.color = new Color(0, 0, 0, 0);
            name.color = new Color(0, 0, 0, 0);
            description.color = new Color(0, 0, 0, 0);
        }
    }
}
