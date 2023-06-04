using UnityEngine;
using System.Globalization;


namespace InfimaGames.LowPolyShooterPack.Interface
{
    public class TextSuperGrenadesCurrent : ElementText
    {
        #region FIELDS SERIALIZED

        [Title(label: "Colors")]

        [Tooltip("Determines if the color of the text should changes as superGrenades are thrown.")]
        [SerializeField]
        private bool updateColor = true;

        [Tooltip("Determines how fast the color changes as the superGrenade are thrown.")]
        [SerializeField]
        private float emptySpeed = 1.5f;

        [Tooltip("Color used on this text when the player character has no superGrendes.")]
        [SerializeField]
        private Color emptyColor = Color.red;

        #endregion

        #region METHODS

        /// <summary>
        /// Tick.
        /// </summary>
        protected override void Tick()
        {
            //Current.
            float current = characterBehaviour.GetSuperGrenadesCurrent();
            //Total.

            //Update Text.
            textMesh.text = current.ToString(CultureInfo.InvariantCulture);

            //Determine if we should update the text's color.
            if (updateColor)
            {
                //Calculate Color Alpha. Helpful to make the text color change based on grenade count.
                float colorAlpha = (current / 10) * emptySpeed;
                //Lerp Color. This makes sure that the text color changes based on grenade count.
                textMesh.color = Color.Lerp(emptyColor, Color.white, colorAlpha);
            }
        }

        #endregion
    }
}