using System;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Specialized;
using FlatRedBall.Audio;
using FlatRedBall.Screens;
using Beefball.Entities;
using Beefball.Screens;
using Microsoft.Xna.Framework;
namespace Beefball.Screens
{
    public partial class GameScreen
    {
        void OnPuckVsGoalCollided (Entities.Puck puck, Entities.Goal goal) 
        {
            if (goal == LeftGoal)
            {
                _player2score++;
                ReactToNewScore();
            }
            else if (goal == RightGoal)
            {
                _player1score++;
                ReactToNewScore();
            }
        }
        
        void ReactToNewScore()
        {
            PlayerBall1.X = -180;
            PlayerBall1.Y = 0;
            PlayerBall1.Velocity = Vector3.Zero;
            PlayerBall1.Acceleration = Vector3.Zero;

            PlayerBall2.X = 180;
            PlayerBall2.Y = 0;
            PlayerBall2.Velocity = Vector3.Zero;
            PlayerBall2.Acceleration = Vector3.Zero;

            Puck.X = 0;
            Puck.Y = 0;
            Puck.Velocity = Vector3.Zero;

            ScoreHud.Score1 = _player1score;
            ScoreHud.Score2 = _player2score;

            PlayerBall1.ResetDash();
            PlayerBall2.ResetDash();
        }
    }
}
