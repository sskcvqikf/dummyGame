using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace game{
    class Background1{
        Cloud clouds;
        Texture2D bg;
        Texture2D[] rs;
        
        public Background1(Texture2D[] cls, Texture2D[] rocks,Texture2D background){
            clouds = new Cloud(cls, 0, 7680, -100, 300);
            bg = background;
            rs = rocks;
        }

        public void Update(){
            clouds.Update();

        }
        public void Draw(SpriteBatch spriteBatch, int offset_x, int offset_y){
            spriteBatch.Begin();
                for(int i=0; i<4; i++){
                    spriteBatch.Draw(bg, new Vector2(i*1920-offset_x, -180-offset_y), Color.White);
                } 
                for(int i=0; i<4; i++){
                    spriteBatch.Draw(rs[0],new Vector2(i*1920-5-offset_x, -150-offset_y), Color.White);
                    spriteBatch.Draw(rs[3],new Vector2(i*1920-5-offset_x, -150-offset_y), Color.White);
                    
                    spriteBatch.Draw(rs[1],new Vector2(i*1920-5-offset_x, -280-offset_y), Color.White);
                    spriteBatch.Draw(rs[2],new Vector2(i*1920-5-offset_x, -180-offset_y), Color.White);
                }
                for(int i=0; i<4; i++){
                    spriteBatch.Draw(rs[5], new Vector2(i*1920-offset_x, -110-offset_y), Color.White);
                } 
            spriteBatch.End();
            clouds.Draw(spriteBatch, offset_x, offset_y);
        }
    }
    
}