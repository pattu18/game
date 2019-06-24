// このファイルで必要なライブラリのnamespaceを指定
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/// <summary>
/// プロジェクト名がnamespaceとなります
/// </summary>
namespace Invaders
{
    /// <summary>
    /// ゲームの基盤となるメインのクラス
    /// 親クラスはXNA.FrameworkのGameクラス
    /// </summary>
    public class Game1 : Game
    {
        // フィールド（このクラスの情報を記述）
        private GraphicsDeviceManager graphicsDeviceManager;//グラフィックスデバイスを管理するオブジェクト
        private SpriteBatch spriteBatch;//画像をスクリーン上に描画するためのオブジェクト
        private Texture2D textureziki; //画像用の変数
        private Texture2D texturebatu;
        private Vector2 position;//自機の位置  
        private Vector2 positionbatu;//×の位置
        private Texture2D texturetama;
        private Vector2 maru;
        private Vector2 batu2;
        private Vector2 batu3;
        /// <summary>
        /// コンストラクタ
        /// （new で実体生成された際、一番最初に一回呼び出される）
        /// </summary>
        public Game1()
        {
            //グラフィックスデバイス管理者の実体生成
            graphicsDeviceManager = new GraphicsDeviceManager(this);

            //画像サイズの設定
            graphicsDeviceManager.PreferredBackBufferWidth = 768;//横幅
            graphicsDeviceManager.PreferredBackBufferHeight = 1024;//縦幅

            //コンテンツデータ（リソースデータ）のルートフォルダは"Contentに設定
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// 初期化処理（起動時、コンストラクタの後に1度だけ呼ばれる）
        /// </summary>
        protected override void Initialize()
        {
            // この下にロジックを記述
            position = new Vector2(352, 824);//自機の座標を設定
            positionbatu = new Vector2(352, 300);
            batu2 = new Vector2(152, 300);
            batu3 = new Vector2(552, 300);
            maru = new Vector2(352,-100);
            // この上にロジックを記述)
            base.Initialize();// 親クラスの初期化処理呼び出し。絶対に消すな！！
        }

        /// <summary>
        /// コンテンツデータ（リソースデータ）の読み込み処理
        /// （起動時、１度だけ呼ばれる）
        /// </summary>
        protected override void LoadContent()
        {
            // 画像を描画するために、スプライトバッチオブジェクトの実体生成
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // この下にロジックを記述
            //画像の読み込み
            textureziki = Content.Load<Texture2D>("grid");//グリッドの読み込み(自機)
            texturebatu = Content.Load<Texture2D>("batu");//×の読み込み(敵)
            texturetama = Content.Load<Texture2D>("maru");//弾の読み込み(弾)
            // この上にロジックを記述
        }

        /// <summary>
        /// コンテンツの解放処理
        /// （コンテンツ管理者以外で読み込んだコンテンツデータを解放）
        /// </summary>
        protected override void UnloadContent()
        {
            // この下にロジックを記述


            // この上にロジックを記述
        }

        /// <summary>
        /// 更新処理
        /// （1/60秒の１フレーム分の更新内容を記述。音再生はここで行う）
        /// </summary>
        /// <param name="gameTime">現在のゲーム時間を提供するオブジェクト</param>
        protected override void Update(GameTime gameTime)
        {
            // ゲーム終了処理（ゲームパッドのBackボタンかキーボードのエスケープボタンが押されたら終了）
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) ||
                 (Keyboard.GetState().IsKeyDown(Keys.Escape)))
            {
                Exit();
            }

            // この下に更新ロジックを記述
            KeyboardState keyboard = Keyboard.GetState();

            //→キー押したら右に移動
            if (keyboard.IsKeyDown(Keys.Right)) 
            {
                position.X = position.X + 10;
            }
            //←キー押したら左に移動
            else if (keyboard.IsKeyDown(Keys.Left))
            {
                position.X = position.X - 10;
            }
            //↑キー押したら上に移動
            //else if (keyboard.IsKeyDown(Keys.Up))
            //{
            //    position.Y = position.Y + -10;
            //}
            //↓キー押したら下に移動
            //else if (keyboard.IsKeyDown(Keys.Down))
            //{
            //    position.Y = position.Y + 10;
            //}
            else if (keyboard.IsKeyDown(Keys.Space))
            {
                maru = position;
            }
            //else if ((keyboard.IsKeyDown(Keys.Space) == KeyState.Pressed) && 
            //        ((keyboard.IsKeyDown(Keys.Space).== KeyState.Released))
            //     {

            //     }













            float A1 = positionbatu.X - maru.X;
            float B1 = positionbatu.Y - maru.Y;

            float AA1 = A1 * A1;
            float BB1 = B1 * B1;

            AA1 = (float)System.Math.Pow((A1), 2);
            BB1 = (float)System.Math.Pow((B1), 2);

            float C1 = AA1 + BB1;
            float X1 = (float)System.Math.Sqrt(C1);

            if (X1 < 64)
            {
                positionbatu.X = positionbatu.X + 1000;
            }




            float A2 = batu2.X - maru.X;
            float B2 = batu2.Y - maru.Y;

            float AA2 = A2 * A2;
            float BB2 = B2 * B2;

            AA1 = (float)System.Math.Pow((A2), 2);
            BB1 = (float)System.Math.Pow((B2), 2);

            float C2 = AA2 + BB2;
            float X2 = (float)System.Math.Sqrt(C2);

            if (X2 < 64)
            {
                batu2.X = batu2.X + 1000;
            }






            float A3 = batu3.X - maru.X;
            float B3 = batu3.Y - maru.Y;

            float AA3 = A3 * A3;
            float BB3 = B3 * B3;

            AA1 = (float)System.Math.Pow((A3), 2);
            BB1 = (float)System.Math.Pow((B3), 2);

            float C3 = AA3 + BB3;
            float X3 = (float)System.Math.Sqrt(C3);

            if (X3 < 64)
            {
                batu3.X = batu3.X + 1000;
            }
            maru.Y -= 20;

            if (position.X < 0)
            {
                position.X = 0;
            }
            if (position.X > 704)
            {
                position.X = 704;
            }
            if (position.Y < 0)
            {
                position.Y = 0;
            }
            if (position.Y > 948)
            {
                position.Y = 948;
            }



            // この上にロジックを記述
            base.Update(gameTime); // 親クラスの更新処理呼び出し。絶対に消すな！！
        }

        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="gameTime">現在のゲーム時間を提供するオブジェクト</param>
        protected override void Draw(GameTime gameTime)
        {
            // 画面クリア時の色を設定
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // この下に描画ロジックを記述
            spriteBatch.Begin();//描画開始
            spriteBatch.Draw(textureziki, position, Color.White);
            //spriteBatch.Draw(texture2, new Vector2(352, 300), Color.White);
            spriteBatch.Draw(texturebatu, positionbatu, Color.White);
            spriteBatch.Draw(texturebatu, batu2, Color.White);
            spriteBatch.Draw(texturebatu, batu3, Color.White);
            spriteBatch.Draw(texturetama, maru, Color.White);
            spriteBatch.End();//描画終了
            //この上にロジックを記述
            base.Draw(gameTime); // 親クラスの更新処理呼び出し。絶対に消すな！！
        }
    }
}
