using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Item", menuName = "Items", order = 0)]
public class SellingItems : ScriptableObject
{
    public string ItemName;
    public int ItemHp;    
    public Sprite ItemImage;
    public int Value;
}
