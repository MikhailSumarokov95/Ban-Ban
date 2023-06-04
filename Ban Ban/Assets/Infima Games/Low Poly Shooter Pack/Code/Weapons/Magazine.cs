//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Magazine.
    /// </summary>
    public class Magazine : MagazineBehaviour
    {

        #region FIELDS SERIALIZED

        [Title(label: "Settings")]
        
        [Tooltip("Total Ammunition.")]
        [SerializeField]
        private int ammunitionTotal = 10;

        [SerializeField]
        private bool isInfinityAmmunitional;

        [Title(label: "Interface")]

        [Tooltip("Interface Sprite.")]
        [SerializeField]
        private Sprite sprite;

        #endregion

        public override int AmmunitionSum { get; set; }

        #region GETTERS

        /// <summary>
        /// Ammunition Total.
        /// </summary>
        public override int GetAmmunitionTotal() => ammunitionTotal;
        /// <summary>
        /// Sprite.
        /// </summary>
        public override Sprite GetSprite() => sprite;

        #endregion

        public override int Reload(int amountOfAmmunitionTake)
        {
            if (isInfinityAmmunitional) return amountOfAmmunitionTake;

            var restAmmunitionInMagazine = AmmunitionSum - amountOfAmmunitionTake;
            int ammunitionTake;

            if (restAmmunitionInMagazine <= 0)
            {
                ammunitionTake = AmmunitionSum;
                AmmunitionSum = 0;
            }

            else
            {
                AmmunitionSum -= amountOfAmmunitionTake;
                ammunitionTake = amountOfAmmunitionTake;
            }

            return ammunitionTake;
        }
    }
}