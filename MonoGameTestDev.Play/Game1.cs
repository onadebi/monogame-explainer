using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AppCore = MonoGameTestDev.Core;

namespace MonoGameTestDev.Play;

public class Game1 : AppCore.Core
{

    private Texture2D _logo;
    private Texture2D _externalTexture;
    private static readonly int _width = 1200;
    private static readonly int _height = 900;

    public Game1() : base("Frozen Era", _width, _height, false)
    {

    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // TODO: use this.Content to load your game content here
        _logo = Content.Load<Texture2D>("images/logo");

        #region external texture
        string filepath = Path.Combine(AppContext.BaseDirectory, "Content", "images", "logo.png");
        if (!File.Exists(filepath))
        { throw new FileNotFoundException("Texture file was not found.", filepath); }
        _externalTexture = Texture2D.FromFile(((Game)this).GraphicsDevice, filepath);
        #endregion

        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // Begin the sprite batch to prepare for rendering.
        SpriteBatch.Begin();

        //Draw the logo texture
        SpriteBatch.Draw(_logo, Vector2.Zero, Color.White);

        #region Load from file if _externalTexture is not nul
        if (_externalTexture != null)
        {
            Vector2 position = new Vector2 { X = (_width - _externalTexture.Width) / 2f, Y = (_height - _externalTexture.Height) / 2f };
            Vector2 alternative_center_position = new Vector2(Window.ClientBounds.Width - _externalTexture.Width, Window.ClientBounds.Height - _externalTexture.Height) * 0.5f;
            SpriteBatch.Draw(_externalTexture, alternative_center_position, Color.Green);
        }
        #endregion
        // Always end the sprite batch when finished.
        SpriteBatch.End();

        // TODO: Add your drawing code here
        base.Draw(gameTime);
    }
}
