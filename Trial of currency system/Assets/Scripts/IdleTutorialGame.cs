using UnityEngine;
using UnityEngine.UI;

public class IdleTutorialGame : MonoBehaviour
{
    // Episode 1
    public Text coinText;
    public double coins;
    public double coinsClickValue;

    // Episode 2
    public Text coinsPerSecText;
    public Text clickUpgrade1Text;
    public Text productionUpgrade1Text;

    public double coinsPerSecond;
    public double clickUpgrade1Cost;
    public int clickUpgrade1Level;

    public double productionUpgrade1Cost;
    public int productionUpgrade1Level;

    public void Start()
    {
        coinsClickValue = 1;
        clickUpgrade1Cost = 10;
        productionUpgrade1Cost = 25;
    }

    public void Update()
    {
        coinsPerSecond = productionUpgrade1Level;

        coinText.text = "Coins: " + coins.ToString("F0");
        coinsPerSecText.text = coinsPerSecond.ToString("F0") + " coins/s";
        clickUpgrade1Text.text = "Click Upgrade 1\nCost: " + clickUpgrade1Cost.ToString("F0") + " coins\nPower: +1 Click\nLevel: " + clickUpgrade1Level;
        productionUpgrade1Text.text  = "Production Upgrade 1\nCost: " + productionUpgrade1Cost.ToString("F0") + " coins\nPower: +1 coins/s\nLevel: " + productionUpgrade1Level;

        coins += coinsPerSecond * Time.deltaTime; 
    }

    // Buttons
    public void Click()
    {
        coins += coinsClickValue ;
    }

    public void BuyClickUpgrade1()
    {
        if (coins >= clickUpgrade1Cost)
        {
            clickUpgrade1Level++;
            coins -= clickUpgrade1Cost;
            clickUpgrade1Cost *= 1.07;
            coinsClickValue++; 
        }
    }

    public void BuyProductionUpgrade1()
    {
        if (coins >= productionUpgrade1Cost)
        {
            productionUpgrade1Level++;
            coins -= productionUpgrade1Cost;
            productionUpgrade1Cost *= 1.07;
        }
    } 
}
