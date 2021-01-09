using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace game
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Background1 bg;
        Hero hero;
        Bot baryga;
        private int offset_x = 4000;
        private int offset_y = 160;  
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 800; 
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            Texture2D[] cls = new Texture2D[50];
            Random rd = new Random((int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);
            for(int i=0;i<30;i++){
                cls.SetValue(Content.Load<Texture2D>("clouds" + rd.Next(2,7)), i);
            }
            for(int i=20; i<50; i++){
                cls.SetValue(Content.Load<Texture2D>("clouds" + rd.Next(3,4)), i);
            }
            Texture2D[] rocks = new Texture2D[]{
                Content.Load<Texture2D>("rocks1"),Content.Load<Texture2D>("rocks2"),
                Content.Load<Texture2D>("rocks3"),Content.Load<Texture2D>("rocks4"),
                Content.Load<Texture2D>("rocks5"),Content.Load<Texture2D>("floor") 
            };
            bg = new Background1(cls, rocks, Content.Load<Texture2D>("sky"));
            Texture2D[] shero = new Texture2D[18];
            Texture2D[] whero = new Texture2D[23];
            Texture2D[] sbaryga = new Texture2D[18];
            Texture2D[] wbaryga = new Texture2D[23];
            for(int i=0; i<23;i++){
                whero[i] = Content.Load<Texture2D>("whero"+i);
                wbaryga[i] = Content.Load<Texture2D>("wbaryga"+i);
                if(i<18){
                    shero[i] = Content.Load<Texture2D>("shero"+i);
                    sbaryga[i] = Content.Load<Texture2D>("sbaryga"+i);
                }
            } 
            hero = new Hero(shero, whero);
            baryga = new Bot(sbaryga, wbaryga);
        } 

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (state.IsKeyDown(Keys.Right)){
                if(offset_x <= 6500)
                    offset_x += 5;
            }
                
            if (state.IsKeyDown(Keys.Left)){
                if(offset_x >= 60)
                    offset_x += -5;
            }
                
            // if (state.IsKeyDown(Keys.Down))
            //     if(offset_y <= 160)
            //         offset_y += 5;
            // if (state.IsKeyDown(Keys.Up))
            //     if(offset_y >= 120)
            //         offset_y += -5;
            bg.Update();
            hero.Collision(baryga, offset_x);
            hero.Update();
            baryga.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color());
            bg.Draw(spriteBatch, offset_x, offset_y);
            baryga.Draw(spriteBatch, offset_x, offset_y);
            hero.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}