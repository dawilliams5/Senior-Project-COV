using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrades/Upgrade")]
public class Upgrade : ScriptableObject
{
    public string name;
    public Sprite icon;
    public string description;
    public float upgradeAmount;
    public string upgradeType;
    
    // Add more properties as needed

    public void setName(string Newname) {   name = Newname; }
    public void setDescription(string Newdescription) {  description = Newdescription; }

    public void setUpgradeType(string NewupgradeType) {  upgradeType = NewupgradeType; }

    public void setUpgradeAmount(int NewupgradeAmount) {  upgradeAmount = NewupgradeAmount; }
    

}
