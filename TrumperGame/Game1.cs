#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Media;

#endregion

namespace TrumperGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D DEFAULT;
        
        //SONG
        SoundEffect song;

        //THE THREE MASK LIGHTS
        Texture2D BlueLight;
        Texture2D RedLight;
        Texture2D GreenLight;

        //Start position given by coordinates
        int startX, startY;
        int finishX, finishY;

        //PARTICLE OUR Character
        Particle particle;

        //The array for the level of pipe objects
        Pipe[][] level;

        //THE array of decaying pipes
        List<Pipe> decayingPipes = new List<Pipe>();

        //VARIABLE FOR LEVEL and LIVES
        int LEVEL;
        int LIVES;
        int DIFFICULTY;

        // 1 = startMenu, 2 = game, 3 = endMenu
        int GAME_STATE = 1; 

        //HORIZONTAL OR VERTICAL
        bool Vertical = true;
        

        //All Our Textures Oh God Why
        Texture2D Mask;
        Texture2D Particle;

        //4 PipeXs
        Texture2D PipeX;
        Texture2D PipeX_d1;
        Texture2D PipeX_d2;
        Texture2D PipeX_d3;
        //4 PipeYs
        Texture2D PipeY;
        Texture2D PipeY_d1;
        Texture2D PipeY_d2;
        Texture2D PipeY_d3;
        //4 Pipe1s
        Texture2D Pipe1;
        Texture2D Pipe1_d1;
        Texture2D Pipe1_d2;
        Texture2D Pipe1_d3;
        //4 Pipe2s
        Texture2D Pipe2;
        Texture2D Pipe2_d1;
        Texture2D Pipe2_d2;
        Texture2D Pipe2_d3;
        //4 Pipe3s
        Texture2D Pipe3;
        Texture2D Pipe3_d1;
        Texture2D Pipe3_d2;
        Texture2D Pipe3_d3;
        //4 Pipe4s
        Texture2D Pipe4;
        Texture2D Pipe4_d1;
        Texture2D Pipe4_d2;
        Texture2D Pipe4_d3;
        //4 Pipe5s
        Texture2D Pipe5;
        Texture2D Pipe5_d1;
        Texture2D Pipe5_d2;
        Texture2D Pipe5_d3;
        //4 Pipe6s
        Texture2D Pipe6;
        Texture2D Pipe6_d1;
        Texture2D Pipe6_d2;
        Texture2D Pipe6_d3;
        //4 Pipe7s
        Texture2D Pipe7;
        Texture2D Pipe7_d1;
        Texture2D Pipe7_d2;
        Texture2D Pipe7_d3;
        //4 Pipe8s
        Texture2D Pipe8;
        Texture2D Pipe8_d1;
        Texture2D Pipe8_d2;
        Texture2D Pipe8_d3;
        //4 Pipe9s
        Texture2D Pipe9;
        Texture2D Pipe9_d1;
        Texture2D Pipe9_d2;
        Texture2D Pipe9_d3;
        //Menus
        Texture2D MENU_START;
        Texture2D MENU_END;
        Texture2D MENU_INSTRUCTIONS;
        //Oldstate for mouse input
        private MouseState oldState;

        /**
         * Define all the predefs for the movement function
         * Take a second look later when revisiting
         * 
         **/


        public Game1(): base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 900;
            graphics.PreferredBackBufferHeight = 900;
            Window.Title = "Gamma Jamma";

            graphics.ApplyChanges();

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


            LEVEL = 1;
            LIVES = 3;
            makeLevel1();

        }

        void makeLevel1()
        {
            startX = 100;
            startY = 100;
            finishX = 700;
            finishY = 400;

            DIFFICULTY = 2750;

            particle = new Particle(startX, startY);
            decayingPipes = new List<Pipe>();

            string[] lines;
            lines = System.IO.File.ReadAllLines(@"Content/LevelText.txt");

            Pipe pipe;
            level = new Pipe[9][];

            for (int row = 0; row < 9; row++)
            {
                level[row] = new Pipe[9];
                for (int col = 0; col < 9; col++)
                {
                    pipe = new Pipe(((char)lines[row][col]), DIFFICULTY);
                    level[row][col] = pipe;
                }
            }
        }

        void makeLevel2()
        {
            startX = 100;
            startY = 500;
            finishX = 700;
            finishY = 100;

            DIFFICULTY = 2750;

            particle = new Particle(startX, startY);
            decayingPipes = new List<Pipe>();

            string[] lines;
            lines = System.IO.File.ReadAllLines(@"Content/LevelText2.txt");

            Pipe pipe;
            level = new Pipe[9][];

            for (int row = 0; row < 9; row++)
            {
                level[row] = new Pipe[9];
                for (int col = 0; col < 9; col++)
                {
                    pipe = new Pipe(((char)lines[row][col]), DIFFICULTY);
                    level[row][col] = pipe;
                }
            }
        }

        void makeLevel3()
        {
            startX = 100;
            startY = 100;
            finishX = 200;
            finishY = 100;

            DIFFICULTY = 2250;

            particle = new Particle(startX, startY);
            decayingPipes = new List<Pipe>();

            string[] lines;
            lines = System.IO.File.ReadAllLines(@"Content/LevelText3.txt");

            Pipe pipe;
            level = new Pipe[9][];

            for (int row = 0; row < 9; row++)
            {
                level[row] = new Pipe[9];
                for (int col = 0; col < 9; col++)
                {
                    pipe = new Pipe(((char)lines[row][col]), DIFFICULTY);
                    level[row][col] = pipe;
                }
            }
        }

        void makeLevel4()
        {
            startX = 700;
            startY = 700;
            finishX = 100;
            finishY = 700;

            DIFFICULTY = 2000;

            particle = new Particle(startX, startY);
            decayingPipes = new List<Pipe>();

            string[] lines;
            lines = System.IO.File.ReadAllLines(@"Content/LevelText4.txt");

            Pipe pipe;
            level = new Pipe[9][];

            for (int row = 0; row < 9; row++)
            {
                level[row] = new Pipe[9];
                for (int col = 0; col < 9; col++)
                {
                    pipe = new Pipe(((char)lines[row][col]), DIFFICULTY);
                    level[row][col] = pipe;
                }
            }
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            //Quick test of sound that works
            SoundPlayer backgroundMusic = new SoundPlayer("game_music.wav");
            backgroundMusic.PlayLooping();

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Song
            song = Content.Load<SoundEffect>("game_music.wav");

            DEFAULT = Content.Load<Texture2D>("BLANK.png");

            Mask = Content.Load<Texture2D>("gradient2.png");
            Particle = Content.Load<Texture2D>("character.png");

            //Load all the light masks
            BlueLight = Content.Load<Texture2D>("blueMask.png");
            RedLight = Content.Load<Texture2D>("redMask.png");
            GreenLight = Content.Load<Texture2D>("greenMask.png");

            //PIPE X
            PipeX = Content.Load<Texture2D>("pipeX/pipeX.png");
            PipeX_d1 = Content.Load<Texture2D>("pipeX/pipeX_d1.png");
            PipeX_d2 = Content.Load<Texture2D>("pipeX/pipeX_d2.png");
            PipeX_d3 = Content.Load<Texture2D>("pipeX/pipeX_d3.png");
            //PIPE Y
            PipeY = Content.Load<Texture2D>("pipeY/pipeY.png");
            PipeY_d1 = Content.Load<Texture2D>("pipeY/pipeY_d1.png");
            PipeY_d2 = Content.Load<Texture2D>("pipeY/pipeY_d2.png");
            PipeY_d3 = Content.Load<Texture2D>("pipeY/pipeY_d3.png");
            //PIPE 1
            Pipe1 = Content.Load<Texture2D>("pipe1/pipe1.png");
            Pipe1_d1 = Content.Load<Texture2D>("pipe1/pipe1_d1.png");
            Pipe1_d2 = Content.Load<Texture2D>("pipe1/pipe1_d2.png");
            Pipe1_d3 = Content.Load<Texture2D>("pipe1/pipe1_d3.png");
            //PIPE 2
            Pipe2 = Content.Load<Texture2D>("pipe2/pipe2.png");
            Pipe2_d1 = Content.Load<Texture2D>("pipe2/pipe2_d1.png");
            Pipe2_d2 = Content.Load<Texture2D>("pipe2/pipe2_d2.png");
            Pipe2_d3 = Content.Load<Texture2D>("pipe2/pipe2_d3.png");
            //PIPE 3
            Pipe3 = Content.Load<Texture2D>("pipe3/pipe3.png");
            Pipe3_d1 = Content.Load<Texture2D>("pipe3/pipe3_d1.png");
            Pipe3_d2 = Content.Load<Texture2D>("pipe3/pipe3_d2.png");
            Pipe3_d3 = Content.Load<Texture2D>("pipe3/pipe3_d3.png");
            //PIPE 4
            Pipe4 = Content.Load<Texture2D>("pipe4/pipe4.png");
            Pipe4_d1 = Content.Load<Texture2D>("pipe4/pipe4_d1.png");
            Pipe4_d2 = Content.Load<Texture2D>("pipe4/pipe4_d2.png");
            Pipe4_d3 = Content.Load<Texture2D>("pipe4/pipe4_d3.png");
            //PIPE 5
            Pipe5 = Content.Load<Texture2D>("pipe5/pipe5.png");
            Pipe5_d1 = Content.Load<Texture2D>("pipe5/pipe5_d1.png");
            Pipe5_d2 = Content.Load<Texture2D>("pipe5/pipe5_d2.png");
            Pipe5_d3 = Content.Load<Texture2D>("pipe5/pipe5_d3.png");
            //PIPE 6
            Pipe6 = Content.Load<Texture2D>("pipe6/pipe6.png");
            Pipe6_d1 = Content.Load<Texture2D>("pipe6/pipe6_d1.png");
            Pipe6_d2 = Content.Load<Texture2D>("pipe6/pipe6_d2.png");
            Pipe6_d3 = Content.Load<Texture2D>("pipe6/pipe6_d3.png");
            //PIPE 7
            Pipe7 = Content.Load<Texture2D>("pipe7/pipe7.png");
            Pipe7_d1 = Content.Load<Texture2D>("pipe7/pipe7_d1.png");
            Pipe7_d2 = Content.Load<Texture2D>("pipe7/pipe7_d2.png");
            Pipe7_d3 = Content.Load<Texture2D>("pipe7/pipe7_d3.png");
            //PIPE 8
            Pipe8 = Content.Load<Texture2D>("pipe8/pipe8.png");
            Pipe8_d1 = Content.Load<Texture2D>("pipe8/pipe8_d1.png");
            Pipe8_d2 = Content.Load<Texture2D>("pipe8/pipe8_d2.png");
            Pipe8_d3 = Content.Load<Texture2D>("pipe8/pipe8_d3.png");
            //PIPE 9
            Pipe9 = Content.Load<Texture2D>("pipe9/pipe9.png");
            Pipe9_d1 = Content.Load<Texture2D>("pipe9/pipe9_d1.png");
            Pipe9_d2 = Content.Load<Texture2D>("pipe9/pipe9_d2.png");
            Pipe9_d3 = Content.Load<Texture2D>("pipe9/pipe9_d3.png");
            //Menus
            MENU_START = Content.Load<Texture2D>("MainScreen.png");
            MENU_END = Content.Load<Texture2D>("menuEnd.png");
            MENU_INSTRUCTIONS = Content.Load<Texture2D>("instructionsMenu.png");
            //Start to play the song beacuse it is loaded now
           // MediaPlayer.Play(song);
            //MediaPlayer.IsRepeating = true;
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            this.IsMouseVisible = true;

            MediaPlayer.IsRepeating = true;

            if (GAME_STATE == 2)
            {
                KeyboardState state = Keyboard.GetState();
                bool leftArrowKeyDown = state.IsKeyDown(Keys.Left);
                bool rightArrowKeyDown = state.IsKeyDown(Keys.Right);
                bool upArrowKeyDown = state.IsKeyDown(Keys.Up);
                bool downArrowKeyDown = state.IsKeyDown(Keys.Down);

                //Defines for this that don't need to be global
                int Distance = 2;
                int AlignmentBuffer = 8;
                int particleX = particle.currentX + 50;
                int particleY = particle.currentY + 50;
                int DisplacementX = (particleX % 100);
                int DisplacementY = (particleY % 100);
                int ParticleColumnX = ((particleX - DisplacementX) / 100);
                int ParticleRowY = ((particleY - DisplacementY) / 100);


                //If the game has started
                // Which way is it moving (right in this case)
                if (state.IsKeyDown(Keys.Right))
                {
                    // Can it move...
                    // Is there a pipe to the right
                    if (((level[ParticleRowY][ParticleColumnX + 1].type != '0')
                        // If there is no pipe to the right, is it at the center yet
                        || (DisplacementX < 50))
                        // If we are not, make sure we're moving down the center
                        && (DisplacementY > (50 - AlignmentBuffer) && DisplacementY < (50 + AlignmentBuffer)))
                    {
                        // Is the particle missaligned
                        if (DisplacementY > (50 - AlignmentBuffer) && DisplacementX < (50 + AlignmentBuffer))
                        {
                            // Realign
                            particleY = (ParticleRowY * 100) + 50;
                            particle.currentY = particleY - 50;
                        }
                        // Make Sure you can move into the next block
                        // Is it to the center yet
                        if (DisplacementX < 50
                            // If it is...
                        || DisplacementX >= 50
                            // The pipe your in can exit right
                        && (level[ParticleRowY][ParticleColumnX].access[3] == 1
                            // The pipe to your right can enter left
                        && level[ParticleRowY][ParticleColumnX + 1].access[2] == 1))
                        {
                            // Check to see if it's entering new pipe
                            if ((((particleX + Distance) - (particleX % 100)) / 100) > (ParticleColumnX))
                            {
                                // Move
                                particle.currentX = particle.currentX + Distance;
                                particleX = particleX + Distance;
                            }
                            // If it isn't a new pipe
                            else
                            // Move
                            {
                                particle.currentX = particle.currentX + Distance;
                                particleX = particleX + Distance;
                            }
                        }
                    }
                }
                if (state.IsKeyDown(Keys.Left))
                {
                    // Can it move...
                    // Is there a pipe to the right
                    if (((level[ParticleRowY][ParticleColumnX - 1].type != '0')
                        // If there is no pipe to the right, is it at the center yet
                        || (DisplacementX > 50))
                        // If we are not, make sure we're moving down the center
                        && (DisplacementY > (50 - AlignmentBuffer) && DisplacementY < (50 + AlignmentBuffer)))
                    {
                        // Is the particle missaligned
                        if (DisplacementY > (50 - AlignmentBuffer) && DisplacementX < (50 + AlignmentBuffer))
                        {
                            // Realign
                            particleY = (ParticleRowY * 100) + 50;
                            particle.currentY = particleY - 50;
                        }
                        // Make Sure you can move into the next block
                        // Is it to the center yet
                        if (DisplacementX > 50
                            // If it is...
                        || DisplacementX <= 50
                            // The pipe your in can exit right
                        && (level[ParticleRowY][ParticleColumnX].access[2] == 1
                            // The pipe to your right can enter left
                        && level[ParticleRowY][ParticleColumnX - 1].access[3] == 1))
                        {
                            // Check to see if it's entering new pipe
                            if ((((particleX - Distance) - (particleX % 100)) / 100) < (ParticleColumnX))
                            {
                                // Move
                                particle.currentX = particle.currentX - Distance;
                                particleX = particleX - Distance;

                            }
                            // If it isn't a new pipe
                            else
                            // Move
                            {
                                particleX = particleX - Distance;
                                particle.currentX = particle.currentX - Distance;
                            }
                        }
                    }
                }
                if (state.IsKeyDown(Keys.Down))
                {
                    // Can it move...
                    // Is there a pipe to the right
                    if (((level[ParticleRowY + 1][ParticleColumnX].type != '0')
                        // If there is no pipe to the right, is it at the center yet
                        || (DisplacementY < 50))
                        // If we are not, make sure we're moving down the center
                        && (DisplacementX > (50 - AlignmentBuffer) && DisplacementX < (50 + AlignmentBuffer)))
                    {
                        // Is the particle missaligned
                        if (DisplacementX > (50 - AlignmentBuffer) && DisplacementX < (50 + AlignmentBuffer))
                        {
                            // Realign
                            particleX = (ParticleColumnX * 100) + 50;
                            particle.currentX = particleX - 50;
                        }
                        // Make Sure you can move into the next block
                        // Is it to the center yet
                        if (DisplacementY < 50
                            // If it is...
                        || DisplacementY >= 50
                            // The pipe your in can exit right
                        && (level[ParticleRowY][ParticleColumnX].access[1] == 1
                            // The pipe to your right can enter left
                        && level[ParticleRowY + 1][ParticleColumnX].access[0] == 1))
                        {
                            // Check to see if it's entering new pipe
                            if ((((particleY + Distance) - (particleY % 100)) / 100) > (ParticleRowY))
                            {
                                // Move
                                particle.currentY = particle.currentY + Distance;
                                particleY = particleY + Distance;
                            }
                            // If it isn't a new pipe
                            else
                            // Move
                            {
                                particleY = particleY + Distance;
                                particle.currentY = particle.currentY + Distance;
                            }
                        }
                    }
                }
                if (state.IsKeyDown(Keys.Up))
                {
                    // Can it move...
                    // Is there a pipe to the right
                    if (((level[ParticleRowY - 1][ParticleColumnX].type != '0')
                        // If there is no pipe to the right, is it at the center yet
                        || (DisplacementY > 50))
                        // If we are not, make sure we're moving down the center
                        && (DisplacementX > (50 - AlignmentBuffer) && DisplacementX < (50 + AlignmentBuffer)))
                    {
                        // Is the particle missaligned
                        if (DisplacementX > (50 - AlignmentBuffer) && DisplacementX < (50 + AlignmentBuffer))
                        {
                            // Realign
                            particleX = (ParticleColumnX * 100) + 50;
                            particle.currentX = particleX - 50;
                        }
                        // Make Sure you can move into the next block
                        // Is it to the center yet
                        if (DisplacementY > 50
                            // If it is...
                        || DisplacementY <= 50
                            // The pipe your in can exit right
                        && (level[ParticleRowY][ParticleColumnX].access[0] == 1
                            // The pipe to your right can enter left
                        && level[ParticleRowY - 1][ParticleColumnX].access[1] == 1))
                        {
                            // Check to see if it's entering new pipe
                            if ((((particleY - Distance) - (particleY % 100)) / 100) < (ParticleRowY))
                            {
                                // Move
                                particle.currentY = particle.currentY - Distance;
                                particleY = particleY - Distance;
                            }
                            // If it isn't a new pipe
                            else
                            // Move
                            {
                                particleY = particleY - Distance;
                                particle.currentY = particle.currentY - Distance;
                            }

                        }
                    }
                }


                //Add the pipe to decaying list if it is not decaying
                if (level[ParticleRowY][ParticleColumnX].decaying == false)
                {
                    level[ParticleRowY][ParticleColumnX].timer.Start();
                    decayingPipes.Add(level[ParticleRowY][ParticleColumnX]);
                }

                //Check for Death
                if (level[ParticleRowY][ParticleColumnX].Rads == 3)
                {
                    /*********GO TO DEATH SCREEN THEN GET TO CHOOSE RESTART*************/
                    LIVES--;
                    if (LIVES <= 0)
                    {
                        GAME_STATE = 3;
                    }
                    if (LIVES > 0)
                    {
                        if (LEVEL == 1)
                        {
                            makeLevel1();
                        }
                        else if (LEVEL == 2)
                        {
                            makeLevel2();
                        }
                        else if (LEVEL == 3)
                        {
                            makeLevel3();
                        }
                        else if (LEVEL == 4)
                        {
                            makeLevel4();
                        }
                    }

                }

                //Check for Win
                if ((ParticleRowY == (finishY / 100)) && (ParticleColumnX == (finishX / 100)))
                {
                    /******************GO TO THE WIN SCREEN*********************/
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!YOU HAVE WON!!!!!!!!!!!");
                    //testFlag = true;
                    if (LEVEL == 1)
                    {
                        LEVEL++;
                        makeLevel2();
                    }
                    else if (LEVEL == 2)
                    {
                        LEVEL++;
                        makeLevel3();
                    }
                    else if (LEVEL == 3)
                    {
                        LEVEL++;
                        makeLevel4();
                    }
                    //else
                }
            }
            else if (GAME_STATE == 3)
            {
                MouseState newState = Mouse.GetState();

                if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
                {
                    if ((newState.X < 400 && newState.X > 100) && (newState.Y > 700 && newState.Y < 800))
                    {
                        GAME_STATE = 1;
                    }
                    if ((newState.X < 800 && newState.X > 500) && (newState.Y > 700 && newState.Y < 800))
                    {
                        Exit();
                    }
                }

                oldState = newState; // this reassigns the old state so that it is ready for next time
            }
            else if (GAME_STATE == 1)
            {
                MouseState newState = Mouse.GetState();

                if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
                {
                    if ((newState.X < 800 && newState.X > 100) && (newState.Y > 700 && newState.Y < 800))
                    {
                        GAME_STATE = 5;
                    }
                }
                oldState = newState; // this reassigns the old state so that it is ready for next time
            }
            else if (GAME_STATE == 4)
            {
                MouseState newState = Mouse.GetState();

                if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
                {
                    if ((newState.X < 700 && newState.X > 200) && (newState.Y > 200 && newState.Y < 400))
                    {
                        GAME_STATE = 1;
                    }
                    if ((newState.X < 700 && newState.X > 200) && (newState.Y > 500 && newState.Y < 700))
                    {
                        Exit();
                    }
                }

                oldState = newState; // this reassigns the old state so that it is ready for next time
            }

            // Instructions menu
            else if(GAME_STATE == 5)
            {
                MouseState newState = Mouse.GetState();

                if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
                {
                    if ((newState.X > 100 && newState.X < 800) && (newState.Y > 700 && newState.Y < 800))
                    {
                        GAME_STATE = 2;
                        LIVES = 3;
                        LEVEL = 1;
                        makeLevel1();
                    }
                }
                oldState = newState; // this reassigns the old state so that it is ready for next time
            }


            base.Update(gameTime);
        }



        protected Texture2D getPipe(int row, int col)
        {
            //NEED TO CHECK FOR CORRUPTED PIPE
            Pipe pipe = level[row][col];
            if (pipe.type == 'x')
            {
                if (pipe.Rads == 3) { return PipeX_d3; }
                else if (pipe.Rads == 2) { return PipeX_d2; }
                else if (pipe.Rads == 1) { return PipeX_d1; }
                else { return PipeX; }
            }
            else if (pipe.type == 'y')
            {
                if (pipe.Rads == 3) { return PipeY_d3; }
                else if (pipe.Rads == 2) { return PipeY_d2; }
                else if (pipe.Rads == 1) { return PipeY_d1; }
                else { return PipeY; }
            }
            else if (pipe.type == '1')
            {
                if (pipe.Rads == 3) { return Pipe1_d3; }
                else if (pipe.Rads == 2) { return Pipe1_d2; }
                else if (pipe.Rads == 1) { return Pipe1_d1; }
                else { return Pipe1; }
            }
            else if (pipe.type == '2')
            {
                if (pipe.Rads == 3) { return Pipe2_d3; }
                else if (pipe.Rads == 2) { return Pipe2_d2; }
                else if (pipe.Rads == 1) { return Pipe2_d1; }
                else { return Pipe2; }
            }
            else if (pipe.type == '3')
            {
                if (pipe.Rads == 3) { return Pipe3_d3; }
                else if (pipe.Rads == 2) { return Pipe3_d2; }
                else if (pipe.Rads == 1) { return Pipe3_d1; }
                else { return Pipe3; }
            }
            else if (pipe.type == '4')
            {
                if (pipe.Rads == 3) { return Pipe4_d3; }
                else if (pipe.Rads == 2) { return Pipe4_d2; }
                else if (pipe.Rads == 1) { return Pipe4_d1; }
                else { return Pipe4; }
            }
            else if (pipe.type == '5')
            {
                if (pipe.Rads == 3) { return Pipe5_d3; }
                else if (pipe.Rads == 2) { return Pipe5_d2; }
                else if (pipe.Rads == 1) { return Pipe5_d1; }
                else { return Pipe5; }
            }
            else if (pipe.type == '6')
            {
                if (pipe.Rads == 3) { return Pipe6_d3; }
                else if (pipe.Rads == 2) { return Pipe6_d2; }
                else if (pipe.Rads == 1) { return Pipe6_d1; }
                else { return Pipe6; }
            }
            else if (pipe.type == '7')
            {
                if (pipe.Rads == 3) { return Pipe7_d3; }
                else if (pipe.Rads == 2) { return Pipe7_d2; }
                else if (pipe.Rads == 1) { return Pipe7_d1; }
                else { return Pipe7; }
            }
            else if (pipe.type == '8')
            {
                if (pipe.Rads == 3) { return Pipe8_d3; }
                else if (pipe.Rads == 2) { return Pipe8_d2; }
                else if (pipe.Rads == 1) { return Pipe8_d1; }
                else { return Pipe8; }
            }
            else if (pipe.type == '9')
            {
                if (pipe.Rads == 3) { return Pipe9_d3; }
                else if (pipe.Rads == 2) { return Pipe9_d2; }
                else if (pipe.Rads == 1) { return Pipe9_d1; }
                else { return Pipe9; }
            }

            return DEFAULT;

        }


        /// <summary>
        /// THE DRAW FUNCTION
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            if (GAME_STATE == 1)
            {
                // Render startMenu
                spriteBatch.Draw(MENU_START, new Vector2(0, 0), Color.White);
            }
            if (GAME_STATE == 3)
            {
                spriteBatch.Draw(MENU_END, new Vector2(0, 0), Color.White);
            }
            
            if (GAME_STATE == 5)
            {
                spriteBatch.Draw(MENU_INSTRUCTIONS, new Vector2(0, 0), Color.White);
            }
            spriteBatch.End();
            if (GAME_STATE == 2)
            {
                if (Vertical)
                {
                    spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
                    //Draw the base background
                    int pixelX = 0;
                    int pixelY = 0;
                    for (int row = 0; row < 9; row++)
                    {
                        for (int col = 0; col < 9; col++)
                        {
                            Texture2D currentPipe = getPipe(row, col);
                            level[row][col].xPos = pixelX;
                            level[row][col].yPos = pixelY;
                            spriteBatch.Draw(currentPipe, new Vector2(pixelX, pixelY), Color.White);
                            pixelX += 100;
                        }
                        pixelX = 0;
                        pixelY += 100;
                    }

                    //Draw all the character light and the light for the end
                    //NEED THESE offset because the the image is 150px
                    int offsetX = -25;
                    int offsetY = -25;
                    spriteBatch.Draw(GreenLight, new Vector2(particle.currentX + offsetX, particle.currentY + offsetY), Color.White);
                    spriteBatch.Draw(Particle, new Vector2(particle.currentX, particle.currentY), Color.White);

                    //END LGHT
                    spriteBatch.Draw(GreenLight, new Vector2(finishX + offsetX, finishY + offsetY), Color.White);
                    spriteBatch.Draw(BlueLight, new Vector2(finishX + offsetX + 15, finishY + offsetY), Color.White);
                    spriteBatch.End();

                    spriteBatch.Begin();
                    //Draw the mask over the character light at his position
                    offsetX = -900;
                    offsetY = -900;
                    spriteBatch.Draw(Mask, new Vector2(particle.currentX + offsetX, particle.currentY + offsetY), Color.Black);

                    //DRAW SOME LIVES
                    if (LIVES > 0)
                    {
                        spriteBatch.Draw(Particle, new Vector2(-10, -15), Color.White);
                    }
                    if (LIVES > 1)
                    {
                        spriteBatch.Draw(Particle, new Vector2(40, -15), Color.White);
                    }
                    if (LIVES > 2)
                    {
                        spriteBatch.Draw(Particle, new Vector2(90, -15), Color.White);
                    }
                    spriteBatch.End();
                }

                //I was working on the horizontal shift but the way we check doesnt alllow for that kind of movement
                else
                {
                    int yPixel = 400;
                }

            }

            base.Draw(gameTime);
        }
    }
}
