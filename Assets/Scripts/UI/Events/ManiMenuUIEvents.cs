using System;

namespace MainSpace
{

    /// <summary>
    /// Public static delegates to manage MainMenu UI changes.
    ///
    ///
    /// Note: these are "events" in the conceptual sense and not the strict C# sense.
    /// </summary>
    public static class MainMenuUIEvents
    {

        //Show the HomeScreen to play the game
        public static Action HomeScreenShown;

        //// Show the CharScreen to select characters and gears
        public static Action CharScreenShown;

        // Show the Caterpillar Screen with resource links
        public static Action CaterpillarScreenShown;

        // Show the ShopScreen to buy gold/gems/potions
        public static Action ShopScreenShown;

        // Show the ShopScreen but from the OptionsBar
        public static Action OptionsBarShopScreenShown;

        // Show the TaskScreen
        public static Action TaskScreenShown;

        // Show the SettingsScreen
        public static Action SettingsScreenShown;

        // Show the LevelScreen
        public static Action LevelScreenShown;

        // Show the FilterScreen
        public static Action FilterScreenShown;

        public static Action FilterScreenHidden;

        // Show the GameScreen for gameplay
        public static Action GameScreenShown;

        // Triggered when showing a new MenuScreen
        //public static Action<MenuScreen> CurrentScreenChanged;  // Deprecated.

        public static Action<string> CurrentViewChanged;

        // Notifed a TabbedMenu to reset/select first tab
        public static Action<string> TabbedUIReset;
    }
}
