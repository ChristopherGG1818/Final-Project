using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType {
        ArmorHelmet,
        ArmorChest,
        Sword,
        Coin,
        Heart
        }

    public static int getCost(ItemType itemType) {
        switch(itemType) {
            default:
            case ItemType.ArmorChest : return 20;
            case ItemType.ArmorHelmet: return 10;
            case ItemType.Sword: return 30;
        }
    }

    public static Sprite GetSprite(ItemType itemType) {
        switch(itemType) {
            default:
            case ItemType.ArmorChest: return Game_Assets.instance.armorChest;
            case ItemType.ArmorHelmet: return Game_Assets.instance.armorHelmet;
            case ItemType.Coin: return Game_Assets.instance.coin;
            case ItemType.Heart: return Game_Assets.instance.heart;
            case ItemType.Sword: return Game_Assets.instance.sword;
        }
    }

    
}