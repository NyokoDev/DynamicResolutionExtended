// <copyright file="ModSettings.cs" company="algernon (K. Algernon A. Sheppard)">
// Copyright (c) algernon (K. Algernon A. Sheppard). All rights reserved.
// Licensed under the Apache Licence, Version 2.0 (the "License"); you may not use this file except in compliance with the License.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace DynamicResolutionExtended
{
    using System.Xml.Serialization;
    using Colossal.IO.AssetDatabase;
    using DynamicResolutionExtended;
    using Game.Modding;
    using Game.Settings;
    using UnityEngine;


    /// <summary>
    /// The mod's settings.
    /// </summary>
    [FileLocation(Mod.ModName)]
    public class ModSettings : ModSetting
    {
        private bool HighestValue;
        public float LowestValueSet = 0.001f;
        public float HighestValueSet = 5f;
        public static float Fraction = 1f;
        private bool LowestValue = false;
 

        /// <summary>
        /// Initializes a new instance of the <see cref="ModSettings"/> class.
        /// </summary>  
        /// <param name="mod"><see cref="IMod"/> instance.</param>
        public ModSettings(IMod mod)
            : base(mod)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether the entire map should be unlocked on load.
        /// </summary>
        [SettingsUISection("SetHigherValue")]
        public bool SetHigherValue
        {
            get => HighestValue;

            set
            {
                HighestValue = value;

                // Assign contra value to ensure that JSON contains at least one non-default value.
                Contra = value;

                // Clear conflicting settings.
                if (value)
                {
                    LowestValue = false;
                    Fraction = HighestValueSet;
                    
                }

                // Ensure state.
                EnsureState();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the entire map should be unlocked on load.
        /// </summary>
        [SettingsUISection("SetLowerValue")]
        public bool SetLowerValue
        {
            get => LowestValue;

            set
            {
                LowestValue = value;

                // Clear conflicting settings.
                if (value)
                {
                    HighestValue = false;
                    Fraction = LowestValueSet;

                }

                // Ensure state.
                EnsureState();
            }
        }

        [SettingsUIHidden]
        public bool Contra { get; set; } = false;

        /// <summary>
        /// Sets a value indicating whether the mod's settings should be reset.
        /// </summary>
        [XmlIgnore]
        [SettingsUIButton]
        [SettingsUISection("ResetModSettings")]
        [SettingsUIConfirmation]
        public bool ResetModSettings
        {
            set
            {
                // Apply defaults.
                SetDefaults();

                // Ensure contra is set correctly.
                Contra = SetHigherValue;

                // Save.
                ApplyAndSave();
            }
        }

        /// <summary>
        /// Restores mod settings to default.
        /// </summary>
        public override void SetDefaults()
        {
            HighestValue = false;
            LowestValue = false;

        }

        /// <summary>
        /// Returns a value indicating whether the no starting tiles option should be hidden.
        /// </summary>
        /// <returns><c>true</c> (hide starting tiles option) if 'Unlock all tiles' is selected, <c>false</c> (don't hide) otherwise.</returns>
        public bool StartingTilesHidden() => SetHigherValue;

        /// <summary>
        /// Enables Unlock All as the default option and that no options are duplicated.
        /// </summary>
        private void EnsureState()
        {
         
        }
    }
}