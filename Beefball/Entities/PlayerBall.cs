using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;
using Microsoft.Xna.Framework;

namespace Beefball.Entities
{
    public partial class PlayerBall
    {
        double _lastTimeDashed = -2000;
        public I2DInput MovementInput { get; set; }
        public IPressableInput BoostInput { get; set; }

        /// <summary>
        /// Initialization logic which is executed only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
        private void CustomInitialize()
        {


        }

        private void CustomActivity()
        {
            MovementActivity();
            DashActivity();
        }

        private void CustomDestroy()
        {


        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {
            

        }

        void DashActivity()
        {
            float magnitude = MovementInput?.Magnitude ?? 0;

            bool shouldBoost = BoostInput?.WasJustPressed == true &&
                TimeManager.CurrentScreenSecondsSince(_lastTimeDashed) > DashFrequency &&
                magnitude > 0;

            if (shouldBoost)
            {
                _lastTimeDashed = TimeManager.CurrentScreenTime;

                float normalizedX = MovementInput.X / magnitude;
                float normalizedY = MovementInput.Y / magnitude;

                XVelocity = normalizedX * DashSpeed;
                YVelocity = normalizedY * DashSpeed;

                CurrentDashCategoryState = DashCategory.Tired;
                InterpolateToState(DashCategory.Rested, DashFrequency);
            }
        }

        private void MovementActivity()
        {
            if (MovementInput != null)
            {
                XAcceleration = MovementInput.X * MovementSpeed;
                YAcceleration = MovementInput.Y * MovementSpeed;
            }
        }

        public void ResetDash()
        {
            StopStateInterpolation(DashCategory.Tired);
            _lastTimeDashed = -1000;
        }
    }
}