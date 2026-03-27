using System;
namespace QuickTools.QData
{
    /// <summary>
    /// Clown settings.
    /// </summary>
    public class ClownSettings
    {
        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>The settings.</value>
        QKeyManager Settings { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:ClownSettings"/> allow debugger.
        /// </summary>
        /// <value><c>true</c> if allow debugger; otherwise, <c>false</c>.</value>
        public bool AllowDebugger { get; set; } = false;

        /// <summary>
        /// Gets the setting.
        /// </summary>
        /// <returns>The setting.</returns>
        /// <param name="setting">Setting.</param>
        public string GetSetting(object setting)
        {
            this.Settings.AllowDebugger = this.AllowDebugger;
            this.Settings.LoadKeys();

            return this.Settings.GetKey(setting.ToString()).Value;
        }

        /// <summary>
        /// Updates the setting.
        /// </summary>
        /// <param name="setting">Setting.</param>
        /// <param name="value">Value.</param>
        public void UpdateSetting(object setting, object value)
        {
            this.Settings.AllowDebugger = this.AllowDebugger;
            this.Settings.LoadKeys();
            this.Settings.UpdateKey(new Key() { Name = setting.ToString(), Value = value.ToString() });
            this.Settings.SaveKeys();
        }
        /// <summary>
        /// Adds the setting.
        /// </summary>
        /// <param name="setting">Setting.</param>
        /// <param name="value">Value.</param>
        public void AddSetting(object setting, object value)
        {
            this.Settings.AllowDebugger = this.AllowDebugger;
            this.Settings.LoadKeys();
            this.Settings.Keys.ForEach((item) => {
                if (item.Name == setting.ToString()) throw new Exception($"The setting already exist: {setting}");
            });
            this.Settings.AddKey(setting.ToString(), value.ToString());
            this.Settings.SaveKeys();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ClownSettings"/> class.
        /// </summary>
        /// <param name="settingsFile">Settings file.</param>
        public ClownSettings(string settingsFile)
        {
            this.Settings = new QKeyManager(settingsFile);
            this.Settings.Create();
        }
    }
}