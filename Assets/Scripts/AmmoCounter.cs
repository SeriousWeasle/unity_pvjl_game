using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    public GameObject player;
    WeaponHandler wh;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        wh = player.GetComponent<WeaponHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        int wep = wh.weaponIndex;
        switch (wep)
        {
            case 0:
                text.text = wh.getShells().ToString();
                break;
            case 1:
                text.text = wh.getBullets().ToString();
                break;
            case 2:
                text.text = "-";
                break;
            default:
                text.text = "0";
                break;
        }
    }
}
