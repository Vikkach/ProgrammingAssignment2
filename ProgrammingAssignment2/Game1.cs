using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProgrammingAssignment2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        const int WindowWidth = 800;
        const int WindowHeight = 600;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //declare sprites
        Texture2D bird0;
        Texture2D bird1;
        Texture2D bird2;

        //declare x and y speeds
        int xSpeed;
        int ySpeed;

        // used to handle generating random values
        Random rand = new Random();
        const int ChangeDelayTime = 1000;
        int elapsedTime = 0;

        // used to keep track of current sprite and location
        Texture2D currentSprite;
        Rectangle drawRectangle = new Rectangle();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = WindowWidth;
            graphics.PreferredBackBufferHeight = WindowHeight;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            bird0 = Content.Load<Texture2D>(@"graphics\bird0");
            bird1 = Content.Load<Texture2D>(@"graphics\bird1");
            bird2 = Content.Load<Texture2D>(@"graphics\bird2");


            // set the currentSprite variable to one of your sprite variables
            currentSprite = bird0;

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedTime > ChangeDelayTime)
            {
                elapsedTime = 0;

                // generate a random number between 0 and 2 inclusived
                int spriteNumber = rand.Next(0, 3);

                // sets current sprite
                if (spriteNumber == 0)
                {
                    currentSprite = bird0;
                }
                else if (spriteNumber == 1)
                {
                    currentSprite = bird1;
                }
                else if (spriteNumber == 2)
                {
                    currentSprite = bird2;
                }

                // set the drawRectangle.Width and drawRectangle.Height to match the width and height of currentSprite
                drawRectangle.Height = bird0.Height;
                drawRectangle.Width = bird0.Width;

                //x = WindowWidth/2 + bird0.Width/2
                //y = WindowHeight/2 + bird0.Height/2
                drawRectangle.X = 326;
                drawRectangle.Y = 255;

                // generate random numbers  between -4 and 4 inclusive for the x and y speed 
                xSpeed = rand.Next(-4, 5);
                ySpeed = rand.Next(-4, 5);

            }

            // move the drawRectangle by the x speed and the y speed
            drawRectangle.X = drawRectangle.X + xSpeed;
            drawRectangle.Y = drawRectangle.Y + ySpeed;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // draw current sprite
            spriteBatch.Begin();
            spriteBatch.Draw(currentSprite, drawRectangle, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
