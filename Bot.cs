using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace game{
    class Bot: Hero{
        public int x{get;set;}
        public int y{get; set;}
        int walk_count = 0;
        bool grl;
        public Bot(Texture2D[] stand_hero, Texture2D[] walk_hero):base(stand_hero, walk_hero){
            x = 3500;
            y = 580;
        }
        public void Update(){
            if(s_status>=34)
                s_status = 0;
            else 
                s_status+=1;
            if(w_status>=22)
                w_status = 0;
            else 
                w_status+=1;
            int tmp;
            Random inv = new Random((int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);
            if(walk_count==0){
                tmp = inv.Next(0,5);
                if(tmp>2){
                walk_count = -34* inv.Next(0,10);
                ws_status = false;
                }
                else{
                walk_count = 23* inv.Next(1,3);
                ws_status = true;
                rl_status = inv.Next(0,2)==0;
                }
            }
            else{
                if(x>=3150&&x<=3850){
                    walk_count += walk_count>0?-1:1;
                    ws_status = (walk_count>0);
                    x += walk_count>0?rl_status?1:-1:0;
                }
                else if(x<3150){
                    walk_count = 23*6;
                    ws_status = true;
                    rl_status = true;
                    x += walk_count>0?rl_status?1:-1:0;
                }
                else if(x>3850){
                    walk_count = 23*6;
                    ws_status = true;
                    rl_status = false;
                    x += walk_count>0?rl_status?1:-1:0;
                }
            }
           
        }
        public void Draw(SpriteBatch spriteBatch, int offset_x, int offset_y){
            spriteBatch.Begin();
            if(ws_status){
                spriteBatch.Draw(walking_hero[w_status], new Vector2(x-offset_x,y), null, Color.White, 0f,
                    Vector2.Zero, .25f, !rl_status?SpriteEffects.FlipHorizontally:SpriteEffects.None, 0f);
            }else{
                spriteBatch.Draw(standing_hero[s_status/2], new Vector2(x-offset_x,y), null, Color.White, 0f,
                    Vector2.Zero, .25f, !rl_status?SpriteEffects.FlipHorizontally:SpriteEffects.None, 0f);
            }
            spriteBatch.End();
            ws_status = false;
        }
    }
}