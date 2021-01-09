using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace game{
    interface IAlive{
    int x{set; get;}
    int y{set; get;}
    void Update();
    void Draw(SpriteBatch spriteBatch);
    void Draw(SpriteBatch spriteBatch, int offset_x, int offset_y);
}
}
