namespace Assets.Scripts.Utility
{
    public static class Constants
    {
        #region Speeds
        public const float PLAYER_SPEED = 30;
        public const float PL_MAX_UP_SPEED = 100;
        public const float PL_MAX_DOWN_SPEED = 35;

        public const float BULLET_SPEED = 150;
        public const float ENEMY_SPEED = 5;
        #endregion

        #region Lifetimes
        public const float BULLET_LIFETIME = 5;
        #endregion

        #region Health
        public const int KAMI_HEALTH = 3;
        public const int MONSTER_HEALTH = 50;
        public const int PLAYER_HEALTH = 100;
        public const int ENEMY_SPAWNER_HEALTH = 10;
        #endregion
        #region Frequencies in second
        public const float ENEMY_SHOOT_FREQUENCY = 0.5f;
        public const float ENEMY_SPAWN_FREQUENCY = 5f;
        #endregion

        #region Tags
        public const string ENEMY_TAG = "Enemy";
        public const string PLAYER_BULLET_TAG = "PlayerBullet";
        public const string ENEMY_BULLET_TAG = "EnemyBullet";

        public const string PLAYER_TAG = "Player";
        public const string JUMP_CLD_TAG = "jump_cld";
        #endregion

        #region Layers
        public const int ENEMY_LAYER = 8;
        public const int PLAYER_LAYER = 9;
        #endregion
    }
}
