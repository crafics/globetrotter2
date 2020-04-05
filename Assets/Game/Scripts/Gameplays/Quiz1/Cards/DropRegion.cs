namespace Game.Scripts.Gameplays.Quiz1.Cards
{
    /// <summary>
    /// Determines where on the battlefield a given card can be played
    /// </summary>
    public enum DropRegion
    {
        /// <summary>
        /// Card can be played on the whole map.
        /// </summary>
        WholeMap = 0,

        /// <summary>
        /// Card can be played on the half of the battlefield controlled by the opponent.
        /// </summary>
        EnemyHalf = 1,

        /// <summary>
        /// Card can be played on the enemy spawn area.
        /// </summary>
        EnemySpawn = 2,

        /// <summary>
        /// Card can be played on the half of the battlefield controlled by the local user.
        /// </summary>
        AllyHalf = 3,

        /// <summary>
        /// Card can be played on the caster's spawn area
        /// </summary>
        AllySpawn = 4
    }
}
