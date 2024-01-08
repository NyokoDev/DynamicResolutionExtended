using Game.UI.InGame;
using Game.UI;
using System;
using System.Reflection;
using System.Reflection.Emit;
using Game.Rendering;
using Colossal.UI.Binding;
using Game.Tools;
using Game.Simulation;
using Unity.Entities;
using Game.UI.Widgets;
using System.Collections.Generic;
using Game;
using Game.Rendering.CinematicCamera;
using Game.Rendering.Utilities;
// The entirety of this code stands as the creation of Nyoko. Any attempt to redistribute or share this code without explicit authorization is strictly prohibited.
namespace DynamicResolutionExtended.Systems
{
    public partial class ModeSystem : SystemBase
    {

        protected override void OnUpdate()
        {
            SetPrivateFieldValue();

        }
        public void SetPrivateFieldValue()
        {
            Type type = typeof(Game.Rendering.Utilities.AdaptiveDynamicResolutionScale);
            FieldInfo fieldInfo = type.GetField("s_CurrentScaleFraction", BindingFlags.NonPublic | BindingFlags.Static);

            if (fieldInfo != null)
            {
                // Setting the value to whatever Fraction is.
                fieldInfo.SetValue(null, ModSettings.Fraction);

            }
            else
            {
                Console.WriteLine("[Critical] CurrentScaleFraction not found.");
            }
        }
    }
}




// The entirety of this code stands as the creation of Nyoko. Any attempt to redistribute or share this code without explicit authorization is strictly prohibited.