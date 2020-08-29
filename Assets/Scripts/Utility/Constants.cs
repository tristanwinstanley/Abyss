namespace Assets.Scripts.Utility
{
    public class Constants
    {
        #region Speeds
        public static float PLAYER_SPEED = 10;
        public static float BULLET_SPEED = 20;
        #endregion

        #region Lifetimes
        public static float BULLET_LIFETIME = 2;
        #endregion

        #region Health
        public static int MONSTER_HEALTH = 3;
        public static int PLAYER_HEALTH = 100;
        #endregion
        #region ShootFrequency
        public static float ENEMY_SHOOT_FREQUENCY = 2f;
        #endregion

        #region Tags
        public static string ENEMY_TAG = "Enemy";
        public static string PLAYER_BULLET_TAG = "PlayerBullet";
        public static string ENEMY_BULLET_TAG = "EnemyBullet";
        public static string PLAYER_TAG = "Player";
        #endregion

        #region Layers
        public static int ENEMY_LAYER = 8;
        public static int PLAYER_LAYER = 9;
        #endregion
    }
}
