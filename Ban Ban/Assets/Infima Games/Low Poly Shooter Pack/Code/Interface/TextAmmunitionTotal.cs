//Copyright 2022, Infima Games. All Rights Reserved.

using System.Globalization;

namespace InfimaGames.LowPolyShooterPack.Interface
{
    /// <summary>
    /// Total Ammunition Text.
    /// </summary>
    public class TextAmmunitionTotal : ElementText
    {
        #region METHODS
        
        /// <summary>
        /// Tick.
        /// </summary>
        protected override void Tick()
        {
            //Total Ammunition.
            float ammunitionSum = equippedWeaponBehaviour.GetMagazineBehaviour().AmmunitionSum;
            
            //Update Text.
            textMesh.text = ammunitionSum.ToString(CultureInfo.InvariantCulture);
        }
        
        #endregion
    }
}