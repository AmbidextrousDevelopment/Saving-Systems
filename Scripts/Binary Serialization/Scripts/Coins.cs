using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RPG.Saving {
    public class Coins : MonoBehaviour, ISaveable
    {

        public int coins = 19;
        [SerializeField] private TextMeshProUGUI CoinsUI;

      
        void Start()
        {
       
        }

        // Update is called once per frame
        void Update()
        {
            CoinsUI.text = coins.ToString();

            //coins = skilltree.GetBalance();
        }

        public object CaptureState()
        {
            return coins;
        }

        public void RestoreState(object state)
        {
            coins = (int)state;
        }
    }
}