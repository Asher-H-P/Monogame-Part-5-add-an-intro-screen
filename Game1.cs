using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Monogame_Part_5_add_an_intro_screen
{
    public class Game1 : Game
    {
        enum Screen
        {
            Intro,
            TribbleYard

        }
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D brown;
        Texture2D cream;
        Texture2D grey;
        Texture2D orange;
        SoundEffect music;
        SoundEffect yell;
        SoundEffect run;
        Texture2D background;
        Texture2D titleScreen;
        Texture2D bars;
        Rectangle bRect;
        Rectangle cRect;
        Rectangle gRect;
        Rectangle oRect;
        Rectangle barRect;
        Vector2 bSpeed;
        Vector2 cSpeed;
        Vector2 gSpeed;
        Vector2 oSpeed;
        Screen screen;
        MouseState mouseState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.Window.Title = "Tribbles";
            bRect = new Rectangle(100, 100, 100, 100);
            cRect = new Rectangle(320, 75, 100, 100);
            gRect = new Rectangle(90, 300, 100, 100);
            oRect = new Rectangle(76, 243, 100, 100);
            bSpeed = new Vector2(2, 4);
            cSpeed = new Vector2(5, 0);
            gSpeed = new Vector2(20, 20);
            oSpeed = new Vector2(1, 1);
            screen = Screen.Intro;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            brown = Content.Load<Texture2D>("tribbleBrown");
            cream = Content.Load<Texture2D>("tribbleCream");
            grey = Content.Load<Texture2D>("tribbleGrey");
            orange = Content.Load<Texture2D>("tribbleOrange");
            music = Content.Load<SoundEffect>("Yoshi Story");
            yell = Content.Load<SoundEffect>("aargh");
            run = Content.Load<SoundEffect>("run_cowd");
            background = Content.Load<Texture2D>("prisoncell");
            titleScreen = Content.Load<Texture2D>("Untitled");
            bars = Content.Load<Texture2D>("rectangle");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mouseState = Mouse.GetState();
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.TribbleYard;

            }
            else if (screen == Screen.TribbleYard)
            {
                bRect.X += (int)bSpeed.X;
                bRect.Y += (int)bSpeed.Y;
                cRect.X += (int)cSpeed.X;
                cRect.Y += (int)cSpeed.Y;
                gRect.X += (int)gSpeed.X;
                gRect.Y += (int)gSpeed.Y;
                oRect.X += (int)oSpeed.X;
                oRect.Y += (int)oSpeed.Y;
                if (bRect.Left <= 0 || bRect.Right >= _graphics.PreferredBackBufferWidth)
                {
                    bSpeed.X *= -1;
                    music.Play();
                }
                if (bRect.Top <= 0 || bRect.Bottom >= _graphics.PreferredBackBufferHeight)
                {
                    bSpeed.Y *= -1;
                    music.Play();
                }
                if (cRect.Left <= 0 || cRect.Right >= _graphics.PreferredBackBufferWidth)
                {
                    cSpeed.X *= -1;
                    run.Play();
                }
                if (cRect.Top <= 0 || cRect.Bottom >= _graphics.PreferredBackBufferHeight)
                {
                    cSpeed.Y *= -1;
                    run.Play();
                }
                if (gRect.Left <= 0 || gRect.Right >= _graphics.PreferredBackBufferWidth)
                {
                    gSpeed.X *= -1;
                    music.Play();
                }
                if (gRect.Top <= 0 || gRect.Bottom >= _graphics.PreferredBackBufferHeight)
                {
                    gSpeed.Y *= -1;
                    music.Play();
                }
                if (oRect.Left <= 0 || oRect.Right >= _graphics.PreferredBackBufferWidth)
                {
                    oSpeed.X *= -1;
                    yell.Play();
                }
                if (oRect.Top <= 0 || oRect.Bottom >= _graphics.PreferredBackBufferHeight)
                {
                    oSpeed.Y *= -1;
                    yell.Play();
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(titleScreen, new Rectangle(0, 0, 800, 500), Color.White);
            }
            else if (screen == Screen.TribbleYard)
            {
                _spriteBatch.Draw(background, new Vector2(0, 0), Color.Salmon);
                _spriteBatch.Draw(brown, bRect, Color.White);
                _spriteBatch.Draw(cream, cRect, Color.White);
                _spriteBatch.Draw(grey, gRect, Color.White);
                _spriteBatch.Draw(orange, oRect, Color.White);
                _spriteBatch.Draw(bars, new Rectangle(25, 0, 10, 500), Color.Gray);
                _spriteBatch.Draw(bars, new Rectangle(75, 0, 10, 500), Color.Gray);
                _spriteBatch.Draw(bars, new Rectangle(125, 0, 10, 500), Color.Gray);
                _spriteBatch.Draw(bars, new Rectangle(175, 0, 10, 500), Color.Gray);
                _spriteBatch.Draw(bars, new Rectangle(225, 0, 10, 500), Color.Gray);
                _spriteBatch.Draw(bars, new Rectangle(275, 0, 10, 500), Color.Gray);
                _spriteBatch.Draw(bars, new Rectangle(325, 0, 10, 500), Color.Gray);
                _spriteBatch.Draw(bars, new Rectangle(375, 0, 10, 500), Color.Gray);
                _spriteBatch.Draw(bars, new Rectangle(425, 0, 10, 500), Color.Gray);
                _spriteBatch.Draw(bars, new Rectangle(475, 0, 10, 500), Color.Gray);
                _spriteBatch.Draw(bars, new Rectangle(525, 0, 10, 500), Color.Gray);
                _spriteBatch.Draw(bars, new Rectangle(575, 0, 10, 500), Color.Gray);
                _spriteBatch.Draw(bars, new Rectangle(625, 0, 10, 500), Color.Gray);
                _spriteBatch.Draw(bars, new Rectangle(675, 0, 10, 500), Color.Gray);
                _spriteBatch.Draw(bars, new Rectangle(725, 0, 10, 500), Color.Gray);
                _spriteBatch.Draw(bars, new Rectangle(775, 0, 10, 500), Color.Gray);
                _spriteBatch.Draw(bars, new Rectangle(825, 0, 10, 500), Color.Gray);
                _spriteBatch.Draw(bars, new Rectangle(875, 0, 10, 500), Color.Gray);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}