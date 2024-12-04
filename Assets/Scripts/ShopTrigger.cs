using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    [SerializeField] private UI_Shop uiShop;
    private void OnTriggerEnter2D( Collider2D collider) {
        IShopCustomer customer = collider.GetComponent<IShopCustomer>();
        if (customer != null) {
            uiShop.Show(customer);
        }
    }

    private void OnTriggerExit2D( Collider2D collider) {
        IShopCustomer customer = collider.GetComponent<IShopCustomer>();
        if (customer != null) {
            uiShop.Hide();
        }
    }
}
