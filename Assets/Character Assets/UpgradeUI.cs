using System;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public Upgrade[] Upgrades;
    public Player player;
    public bullet bullet;
    public weapon weapon;
    public GameObject UpgradePanel;
    public Image upgradeImage1;
    public Image upgradeImage2;
    public Image upgradeImage3;
    public Text upgradeName1;
    public Text upgradeName2;
    public Text upgradeName3;
    public Text upgradeDescription1;
    public Text upgradeDescription2;
    public Text upgradeDescription3;
    public Button upgradeButton1;
    public Button upgradeButton2;
    public Button upgradeButton3;
    public int index;
    public int index2;
    public int index3;
    public bool timeToPick = false;
    public bool upgradePicked = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeToPick)
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                UpgradeSelect(index);
                timeToPick = false;
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                UpgradeSelect(index2);
                timeToPick = false;
            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                UpgradeSelect(index3);
                timeToPick = false;
                
            }
        }

    }
    public int getInt(int type)
    {
        if(type == 1)
        {
            return index;
        }
        if(type == 2)
        {
            return index2;
        }
        else
        {
            return index3;
        }

    }
    public void UpgradeSelect(int choosenIndex)
    {
        if (Upgrades[choosenIndex].name == "Tri-Shot")
        {
            weapon.triShot = true;
        }
        else if (Upgrades[choosenIndex].name == "Guns Akimbo")
        {
            weapon.doubleshoot = true;
        }
        else if (Upgrades[choosenIndex].name == "Behind You!!")
        {
            weapon.shootBackwards = true;
        }
        else
        {
            if (Upgrades[choosenIndex].upgradeType == "Health")
            {
                player.UpgradeHealth(Upgrades[choosenIndex].upgradeAmount);
            }
            else if(Upgrades[choosenIndex].upgradeType == "Heal")
            {
                player.Heal(Upgrades[choosenIndex].upgradeAmount);
            }
            else if (Upgrades[choosenIndex].upgradeType == "Movement")
            {
                player.UpgradeSpeed(Upgrades[choosenIndex].upgradeAmount);
            }
            else if (Upgrades[choosenIndex].upgradeType == "Weapon Fire Rate")
            {
                weapon.UpgradeFireRate(Upgrades[choosenIndex].upgradeAmount);
            }
            else if (Upgrades[choosenIndex].upgradeType == "Damage")
            {
                bullet.UpgradeDamage(Upgrades[choosenIndex].upgradeAmount);
            }
            else if (Upgrades[choosenIndex].upgradeType == "Bullet Speed")
            {
                bullet.UpgradeSpeed(Upgrades[choosenIndex].upgradeAmount);
            }
        }
        UpgradePanel.SetActive(false);
        upgradePicked = true;

    }

    public void ChooseUpgrades()
    {
        upgradePicked = false;
        UpgradePanel.SetActive(true);
        index = UnityEngine.Random.Range(0, Upgrades.Length);
        index2 = UnityEngine.Random.Range(0, Upgrades.Length);
        index3 = UnityEngine.Random.Range(0, Upgrades.Length);

        upgradeImage1.sprite = Upgrades[index].icon;
        upgradeImage2.sprite = Upgrades[index2].icon;
        upgradeImage3.sprite = Upgrades[index3].icon;

        upgradeName1.text = Upgrades[index].name;
        upgradeName2.text = Upgrades[index2].name;
        upgradeName3.text = Upgrades[index3].name;

        upgradeDescription1.text = Upgrades[index].description;
        upgradeDescription2.text = Upgrades[index2].description;
        upgradeDescription3.text = Upgrades[index3].description;
        timeToPick = true;
    }
}
