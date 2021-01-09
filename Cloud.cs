using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace game{
    class Cloud{
        private Texture2D[] clouds;
        Random rd = new Random((int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);
        double[, ] locs;
        double[] speeds;
        int _x1, _x2, _y1, _y2;
        public Cloud(Texture2D[] clouds, int x1, int x2, int y1, int y2){
            _x1 = x1; _x2 = x2; _y1 = y1;_y2 = y2; 
            locs = new double[clouds.Length, 2];
            speeds = new double[clouds.Length];;
            this.clouds = clouds;
            for(int i=0; i<clouds.Length;i++){
                locs[i, 0] = rd.Next(_x1-600, _x2+600);
                locs[i, 1] = rd.Next(_y1, _y2);
                speeds[i] = rd.NextDouble();
            }

        }
        public void Update(){
            for(int i=0; i<clouds.Length;i++){
                if(locs[i, 0]<-600){
                    locs[i, 0] = _x2 + 600;
                    locs[i, 1] = rd.Next(_y1, _y2);
                }
                locs[i, 0] -= speeds[i];
            }
        }
        public void Draw(SpriteBatch spriteBatch, int offset_x, int offset_y){
            spriteBatch.Begin();
            float scale = (float)rd.NextDouble(); 
            for(int i=0; i<clouds.Length;i++){
                spriteBatch.Draw(clouds[i], new Vector2(Convert.ToInt32(locs[i,0])-offset_x, Convert.ToInt32(locs[i,1])-offset_y), null, Color.White, 0f,
                    Vector2.Zero, .2f, SpriteEffects.None, 0f);
            }
            spriteBatch.End();
        }
    }
    
}