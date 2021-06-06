using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class EshopManager : MonoBehaviour
{
    public GameObject premium, paketo1, paketo2;
    public Button premiumButton, paketo1Button, paketo2Button;
    private string premiumString = "premiumBundle", paketo1String="paketo1" , paketo2String="paketo2";
    public Text successPurchaseText;

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    public void OnPurchaseComplete(Product product)
    {
       

        if (product.definition.id==premiumString)
        {
            premiumButton.interactable = false;
            
            StartCoroutine(DisplayText("Αγοράσατε το πακέτο premium, σας ευχαριστούμε."));
            
        }

        if(product.definition.id == paketo1String)
        {
            paketo1Button.interactable = false;
            StartCoroutine(DisplayText("Αγοράσατε το πακέτο 1, σας ευχαριστούμε."));
            
        }

        if(product.definition.id == paketo2String)
        {
            paketo2Button.interactable = false;
            StartCoroutine(DisplayText("Αγοράσατε το πακέτο 2, σας ευχαριστούμε."));
           
        }

        
    }

    private IEnumerator DisplayText(string text )
    {
       
       
        yield return new WaitForSeconds(0.1f);
        premium.SetActive(false);
        paketo1.SetActive(false);
        paketo2.SetActive(false);
        successPurchaseText.text = text;
        yield return new WaitForSeconds(5f);
        successPurchaseText.text = "";
        

    }

    
    public void OpenPremium()
    {
        premium.SetActive(true);
        paketo1.SetActive(false);
        paketo2.SetActive(false);
    }

    public void OpenPaketo1()
    {
        premium.SetActive(false);
        paketo1.SetActive(true);
        paketo2.SetActive(false);
    }

    public void OpenPaketo2()
    {
        premium.SetActive(false);
        paketo1.SetActive(false);
        paketo2.SetActive(true);
    }
}
