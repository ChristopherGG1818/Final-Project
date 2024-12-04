using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CodeMonkey.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class UI_Shop : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    private IShopCustomer customer;

    private void Awake() {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
        
    }

    private void Start() {
        createItemButton(Item.ItemType.ArmorHelmet, Item.GetSprite(Item.ItemType.ArmorHelmet), "Helmet", Item.getCost(Item.ItemType.ArmorHelmet), 0);
        createItemButton(Item.ItemType.ArmorChest, Item.GetSprite(Item.ItemType.ArmorChest), "Chestplate", Item.getCost(Item.ItemType.ArmorChest), 1);
        createItemButton(Item.ItemType.Sword, Item.GetSprite(Item.ItemType.Sword), "Sword", Item.getCost(Item.ItemType.Sword), 2);

        Hide();
    }

    private void createItemButton(Item.ItemType itemType, Sprite itemSprite, string itemString, int itemCost, int position) {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 45f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * position);

        shopItemTransform.Find("itemName").GetComponent<TextMeshProUGUI>().SetText(itemString);
        shopItemTransform.Find("itemCost").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("itemSprite").GetComponent<Image>().sprite = itemSprite;

        shopItemTransform.GetComponent<Button_UI>().ClickFunc = () => {
            //button gets clicked
            TryBuyItem(itemType);

        };
    }

    private void TryBuyItem(Item.ItemType itemType) {
         if (customer.tryToBuy(Item.getCost(itemType))) {
            customer.BoughtItem(itemType);
         } else {
            Debug.Log("Cannot Afford " + itemType);
         }
        
    }

    public void Show(IShopCustomer customer) {
        this.customer = customer;
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }


}
