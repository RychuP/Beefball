using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Gui;
using FlatRedBall.Math;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Localization;
using Microsoft.Xna.Framework;

using Beefball.Entities;
using Microsoft.Xna.Framework.Input;


namespace Beefball.Screens;

public partial class GameScreen
{
    int _player1score = 0;
    int _player2score = 0;

    void CustomInitialize()
    {
        AssignInput();

    }

    void CustomActivity(bool firstTimeCalled)
    {


    }

    void CustomDestroy()
    {


    }

    static void CustomLoadStaticContent(string contentManagerName)
    {


    }

    void AssignInput()
    {
        PlayerBall1.MovementInput = InputManager.Keyboard.Get2DInput(
            Keys.A, Keys.D, Keys.W, Keys.S);
        PlayerBall1.BoostInput = InputManager.Keyboard.GetKey(Keys.Space);
    }
}
