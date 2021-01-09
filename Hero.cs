using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace game{
    class Hero: IAlive{
        protected int s_status = 0;
        protected int w_status = 0;
        protected bool rl_status = false;
        protected bool ws_status = false;
        protected Texture2D[] standing_hero;
        protected Texture2D[] walking_hero;
        public int x{get; set;}
        public int y{get; set;}
        public Hero(Texture2D[] stand_hero, Texture2D[] walk_hero){
            standing_hero = stand_hero;
            walking_hero = walk_hero;
            x = 310;
            y = 600;
        }
        public void Update(){
            KeyboardState state = Keyboard.GetState();
             if (state.IsKeyDown(Keys.Right)){
                rl_status = true;
                ws_status = true;
            }
                
            if (state.IsKeyDown(Keys.Left)){
                rl_status = false;
                ws_status = true;
            }
                
            if(s_status>=34)
                s_status = 0;
            else 
                s_status+=1;
            if(w_status>=22)
                w_status = 0;
            else 
                w_status+=1;
        }

        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Begin();
            if(ws_status){
                spriteBatch.Draw(walking_hero[w_status], new Vector2(x, y), null, Color.White, 0f,
                    Vector2.Zero, .25f, !rl_status?SpriteEffects.FlipHorizontally:SpriteEffects.None, 0f);
            }else{
                spriteBatch.Draw(standing_hero[s_status/2], new Vector2(x, y), null, Color.White, 0f,
                    Vector2.Zero, .25f, !rl_status?SpriteEffects.FlipHorizontally:SpriteEffects.None, 0f);
            }
            spriteBatch.End();
            ws_status = false;
        }
        public void Draw(SpriteBatch spriteBatch, int offset_x, int offset_y){}
        public void Collision(IAlive bot, int offset_x){
            // Console.WriteLine($"{bot.x-offset_x}, {x}");
            if(bot.x-offset_x>x-50&&bot.x-offset_x<x+50){
                Console.WriteLine($"Collision {bot.x-offset_x} {x}");
            }
        }
    }
}