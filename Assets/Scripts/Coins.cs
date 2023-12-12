using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
   [SerializeField] DataContainer dataContainer;
   [SerializeField] private TMPro.TextMeshProUGUI coinsCountText;
   public void Add(int count)
   {
        dataContainer.coins += count;
      coinsCountText.text = "Coins:" + dataContainer.coins.ToString();
   }
}
